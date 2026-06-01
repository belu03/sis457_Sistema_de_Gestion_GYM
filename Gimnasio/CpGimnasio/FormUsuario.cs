using CadGimnasio;
using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CpGimnasio
{

    public partial class FormUsuario : Form
    {
        int idUsuarioSeleccionado = 0;
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            // Limpiamos cualquier rastro previo
            dgvLista.DataSource = null;
            // Recargamos directamente desde la base de datos al abrir
            dgvLista.DataSource = UsuarioCln.listar();
            // Ocultamos las columnas técnicas que no quieres mostrar
            dgvLista.Columns["id"].Visible = false; // El ID es necesario internamente, pero oculto

            // Si habías cambiado 'tipo' por 'telefono', asegúrate de ocultar cualquier columna vieja
            if (dgvLista.Columns["tipo"] != null)
            {
                dgvLista.Columns["tipo"].Visible = false;
            }
            dgvLista.Columns["Asistencia"].Visible = false;
            dgvLista.Columns["Membresia"].Visible = false;
            dgvLista.Columns["Pago"].Visible = false;
            dgvLista.Columns["Reserva"].Visible = false;
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. Guardamos el ID
                idUsuarioSeleccionado = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["id"].Value);

                // 2. Llenamos los TextBox con seguridad
                // Usamos .ToString() con cuidado por si algún valor es nulo
                txtNombre.Text = dgvLista.Rows[e.RowIndex].Cells["nombre"].Value?.ToString() ?? "";
                txtApellido.Text = dgvLista.Rows[e.RowIndex].Cells["apellido"].Value?.ToString() ?? "";

                // CORRECCIÓN AQUÍ: Asegúrate de que el nombre de la columna en el Grid sea exactamente "correo" o "telefono"
                // Si tu columna se llama "correo" en el SP, usa "correo". Si ya no existe, bórralo.
                txtEmail.Text = dgvLista.Rows[e.RowIndex].Cells["correo"].Value?.ToString() ?? "";

                // 3. AGREGA ESTO: Asegúrate de que txtTelefono tenga el campo correcto
                // Si la columna en el Grid se llama "telefono", pon "telefono".
                txtTelefono.Text = dgvLista.Rows[e.RowIndex].Cells["telefono"].Value?.ToString() ?? "";
            }
        }
        private void GuardarUsuario_Click(object sender, EventArgs e)
        {
            // 1. Ejecutamos la validación
            if (!validar())
            {
                // Si validar() devuelve false, el "!" lo convierte en true
                // y entramos aquí para detener todo.
                MessageBox.Show("Por favor, corrija los errores en el formulario antes de guardar.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // <--- ESTE "RETURN" ES LA CLAVE. Detiene la ejecución.
            }

            // 2. Si el código llega hasta aquí, es porque la validación fue exitosa.
            Usuario usuario = new Usuario();
            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.telefono = txtTelefono.Text; // Asegúrate que tu objeto Usuario tenga este campo

            int resultado = UsuarioCln.crear(usuario);

            if (resultado > 0)
            {
                MessageBox.Show("Guardado con éxito");
                dgvLista.DataSource = UsuarioCln.listar();
                btnNuevo_Click(null, null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está segura de que desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int eliminado = UsuarioCln.eliminar(idUsuarioSeleccionado);

                if (eliminado > 0)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.");
                    dgvLista.DataSource = UsuarioCln.listar();
                    btnNuevo_Click(null, null); // Limpiar formulario
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar. El usuario podría tener registros relacionados (como asistencias).");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // 1. Cambiamos el tamaño del formulario
            this.Size = new Size(1476, 874);

            // 2. Lógica existente
            idUsuarioSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Desea guardar los cambios realizados en este usuario?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                using (var context = new GimnasioEntities())
                {
                    var usuarioModificar = context.Usuario.Find(idUsuarioSeleccionado);
                    if (usuarioModificar != null)
                    {
                        usuarioModificar.nombre = txtNombre.Text;
                        usuarioModificar.apellido = txtApellido.Text;
                        usuarioModificar.correo = txtEmail.Text;

                        // --- AÑADE ESTA LÍNEA AQUÍ ---
                        usuarioModificar.telefono = txtTelefono.Text;
                        // -----------------------------

                        context.SaveChanges();
                    }
                }

                MessageBox.Show("Usuario editado con éxito.");
                dgvLista.DataSource = UsuarioCln.listar();
                btnNuevo_Click(null, null); // Limpiar
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Si está vacío, usamos el listar normal que devuelve objetos tipo Usuario
                dgvLista.DataSource = UsuarioCln.listar();
            }
            else
            {
                // Si tiene texto, usamos el que devuelve spUsuarioListar1_Result
                dgvLista.DataSource = UsuarioCln.listar(filtro);
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpUsuario.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpUsuario.SetError(txtNombre, "El nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                erpUsuario.SetError(txtApellido, "El apellido es obligatorio");
                esValido = false;
            }

            // AQUÍ REALIZAMOS EL CAMBIO:
            // Ya no validamos correo, ahora validamos teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                erpUsuario.SetError(txtTelefono, "El teléfono es obligatorio");
                esValido = false;
            }

            // Opcional: Validar que el teléfono solo tenga números (Control de calidad)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                erpUsuario.SetError(txtTelefono, "El teléfono solo debe contener números");
                esValido = false;
            }

            return esValido;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            new FormServicio().Show();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            new FormReserva().Show();
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            new FormMembresia().Show();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            new FormPago().Show();
        }

       
    }
}
