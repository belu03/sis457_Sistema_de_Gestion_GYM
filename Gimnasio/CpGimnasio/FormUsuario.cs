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
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que el clic no sea en el encabezado (el encabezado tiene índice -1)
            if (e.RowIndex >= 0)
            {
                // Guardamos el ID de la fila seleccionada
                idUsuarioSeleccionado = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["id"].Value);

                // Llenamos los TextBox con los datos de la fila
                txtNombre.Text = dgvLista.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvLista.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                txtEmail.Text = dgvLista.Rows[e.RowIndex].Cells["correo"].Value.ToString();
            }
        }
        private void GuardarUsuario_Click(object sender, EventArgs e)
        {
            // 1. Crear el objeto usuario
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.nombre = txtNombre.Text;
            nuevoUsuario.apellido = txtApellido.Text;
            nuevoUsuario.correo = txtEmail.Text;
            nuevoUsuario.tipo = "Cliente";

            // 2. Ejecutar la creación en la base de datos
            int idGenerado = UsuarioCln.crear(nuevoUsuario);

            if (idGenerado > 0)
            {
                MessageBox.Show("Guardado exitosamente");

                // 3. LA CLAVE: Forzar la actualización total
                dgvLista.DataSource = null; // Borramos la conexión anterior
                dgvLista.DataSource = UsuarioCln.listar(); // Recargamos desde la base de datos

                // 4. Limpiar los campos para un nuevo registro
                txtNombre.Clear();
                txtApellido.Clear();
                txtEmail.Clear();
            }
            else
            {
                MessageBox.Show("Error al guardar en la base de datos.");
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
            idUsuarioSeleccionado = 0; // Reiniciamos el ID
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtNombre.Focus(); // Ponemos el cursor listo para escribir
        }
    }
}
