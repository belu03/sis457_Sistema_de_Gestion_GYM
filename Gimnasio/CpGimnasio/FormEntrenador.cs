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

    public partial class FormEntrenador : Form
    {
        int idEntrenadorSeleccionado = 0;
        public FormEntrenador()
        {
            InitializeComponent();
        }
        private void CargarLista()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = EntrenadorCln.listar();
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
        }

        private void FormEntrenador_Load(object sender, EventArgs e)
        {
            // Limpiamos cualquier rastro previo
            dgvLista.DataSource = null;
            // Recargamos directamente desde la base de datos al abrir
            dgvLista.DataSource = EntrenadorCln.listar();
            // Ocultamos las columnas técnicas que no quieres mostrar
            dgvLista.Columns["id"].Visible = false; // El ID es necesario internamente, pero oculto
            CargarLista();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic no sea en el encabezado (el encabezado tiene índice -1)
            if (e.RowIndex >= 0)
            {
                // Guardamos el ID de la fila seleccionada
                idEntrenadorSeleccionado = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["id"].Value);

                // Llenamos los TextBox con los datos de la fila
                txtNombre.Text = dgvLista.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvLista.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                txtEspecialidad.Text = dgvLista.Rows[e.RowIndex].Cells["especialidad"].Value.ToString();
                txtCorreo.Text = dgvLista.Rows[e.RowIndex].Cells["correo"].Value.ToString();
                txtTelefono.Text = dgvLista.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
            }
        }
        private void GuardarEntrenador_Click(object sender, EventArgs e)
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
            Entrenador entrenador = new Entrenador();
            entrenador.nombre = txtNombre.Text;
            entrenador.apellido = txtApellido.Text;
            entrenador.telefono = txtTelefono.Text;
            entrenador.especialidad = txtEspecialidad.Text;
            entrenador.correo = txtCorreo.Text;// Asegúrate que tu objeto Entrenador tenga este campo

            int resultado = EntrenadorCln.crear(entrenador);

            if (resultado > 0)
            {
                MessageBox.Show("Guardado con éxito");
                dgvLista.DataSource = EntrenadorCln.listar();
                btnNuevo_Click(null, null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idEntrenadorSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un entrenador de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está segura de que desea eliminar este entrenador?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int eliminado = EntrenadorCln.eliminar(idEntrenadorSeleccionado);

                if (eliminado > 0)
                {
                    MessageBox.Show("Entrenador eliminado exitosamente.");
                    dgvLista.DataSource = EntrenadorCln.listar();
                    btnNuevo_Click(null, null); // Limpiar formulario
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar. El entrenador podría tener registros relacionados (como asistencias).");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idEntrenadorSeleccionado = 0; // Reiniciamos el ID
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtNombre.Focus(); // Ponemos el cursor listo para escribir
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idEntrenadorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un entrenador de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // AUDITORÍA: Usamos la capa de negocio, no el contexto directo aquí
                // Esto garantiza que la lógica de guardado sea consistente en todo el sistema
                var entrenador = new Entrenador();
                entrenador.id = idEntrenadorSeleccionado;
                entrenador.nombre = txtNombre.Text;
                entrenador.apellido = txtApellido.Text;
                entrenador.telefono = txtTelefono.Text;
                entrenador.especialidad = txtEspecialidad.Text;
                entrenador.correo = txtCorreo.Text;

                // Llamamos a nuestra lógica probada
                int resultado = EntrenadorCln.modificar(entrenador);

                if (resultado > 0)
                {
                    MessageBox.Show("Entrenador editado con éxito.");

                    // FORZAR REFRESH
                    CargarLista();
                    btnNuevo_Click(null, null);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cambio. El entrenador podría haber sido eliminado o el ID es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Si está vacío, usamos el listar normal que devuelve objetos tipo Entrenador
                dgvLista.DataSource = EntrenadorCln.listar();
            }
            else
            {
                // Si tiene texto, usamos el que devuelve spEntrenadorListar1_Result
                dgvLista.DataSource = EntrenadorCln.listar(filtro);
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpEntrenador.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpEntrenador.SetError(txtNombre, "El nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                erpEntrenador.SetError(txtApellido, "El apellido es obligatorio");
                esValido = false;
            }

            // AQUÍ REALIZAMOS EL CAMBIO:
            // Ya no validamos correo, ahora validamos teléfono
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                erpEntrenador.SetError(txtTelefono, "El teléfono es obligatorio");
                esValido = false;
            }

            // Opcional: Validar que el teléfono solo tenga números (Control de calidad)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                erpEntrenador.SetError(txtTelefono, "El teléfono solo debe contener números");
                esValido = false;
            }

            return esValido;
        }
    }
}
