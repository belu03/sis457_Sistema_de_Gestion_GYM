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

    public partial class FormServicio : Form
    {
        int idServicioSeleccionado = 0;
        public FormServicio()
        {
            InitializeComponent();
        }
        private void CargarLista()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = ServicioCln.listar();
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
        }

        private void FormServicio_Load(object sender, EventArgs e)
        {
            // Limpiamos cualquier rastro previo
            dgvLista.DataSource = null;
            // Recargamos directamente desde la base de datos al abrir
            dgvLista.DataSource = ServicioCln.listar();
            // Ocultamos las columnas técnicas que no quieres mostrar
            dgvLista.Columns["id"].Visible = false; // El ID es necesario internamente, pero oculto
            CargarLista();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvLista.Rows[e.RowIndex].DataBoundItem as Horario;
                if (fila != null)
                {
                    //cboServicio.SelectedValue = fila.id_servicio;
                    //cboEntrenador.SelectedValue = fila.id_entrenador;
                    // ... resto de tus asignaciones
                }
            }
        }
        private void dgvLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificamos si estamos en la columna que quieres mostrar
            if (dgvLista.Columns[e.ColumnIndex].Name == "servicio" && e.RowIndex >= 0)
            {
                // Obtenemos el objeto Horario de la fila actual
                var fila = dgvLista.Rows[e.RowIndex].DataBoundItem as Horario;
                if (fila != null && fila.Servicio != null)
                {
                    // AQUÍ: Cambia 'nombre' por el nombre real de la propiedad en tu clase Servicio
                    // (Si no sabes cuál es, busca en tu entidad Servicio la propiedad de texto)
                    e.Value = fila.Servicio.nombre;
                    e.FormattingApplied = true;
                }
            }

            if (dgvLista.Columns[e.ColumnIndex].Name == "entrenador" && e.RowIndex >= 0)
            {
                var fila = dgvLista.Rows[e.RowIndex].DataBoundItem as Horario;
                if (fila != null && fila.Entrenador != null)
                {
                    e.Value = fila.Entrenador.nombre; // Cambia 'nombre' si es necesario
                    e.FormattingApplied = true;
                }
            }
        }
        private void GuardarServicio_Click(object sender, EventArgs e)
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
            Servicio servicio = new Servicio();
            servicio.nombre = txtNombre.Text;
            servicio.descripcion = txtDescripcion.Text;
            if (int.TryParse(txtDuracion.Text, out int duracionConvertida))
            {
                // Si la conversión tuvo éxito, asignamos el valor
                servicio.duracion = duracionConvertida;
            }
            else
            {
                // Si el usuario escribió letras en lugar de números
                MessageBox.Show("Por favor, ingrese un valor numérico válido en la duración.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detenemos el proceso para evitar errores
            }
            if (int.TryParse(txtCapacidadM.Text, out int capacidad_maximaConvertida))
            {
                // Si la conversión tuvo éxito, asignamos el valor
                servicio.capacidad_maxima = capacidad_maximaConvertida;
            }
            else
            {
                // Si el usuario escribió letras en lugar de números
                MessageBox.Show("Por favor, ingrese un valor numérico válido en la capacidad máxima.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detenemos el proceso para evitar errores
            }

            int resultado = ServicioCln.crear(servicio);

            if (resultado > 0)
            {
                MessageBox.Show("Guardado con éxito");
                dgvLista.DataSource = ServicioCln.listar();
                btnNuevo_Click(null, null);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idServicioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un servicio de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está segura de que desea eliminar este servicio?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int eliminado = ServicioCln.eliminar(idServicioSeleccionado);

                if (eliminado > 0)
                {
                    MessageBox.Show("Servicio eliminado exitosamente.");
                    dgvLista.DataSource = ServicioCln.listar();
                    btnNuevo_Click(null, null); // Limpiar formulario
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar. El Servicio podría tener registros relacionados (como asistencias).");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Cambiamos el tamaño del formulario para el nuevo registro
            this.Size = new Size(1476, 874);

            // Reiniciamos los valores
            idServicioSeleccionado = 0;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtDuracion.Clear();
            txtCapacidadM.Clear();

            // Ponemos el cursor listo para escribir
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idServicioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un servicio de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // AUDITORÍA: Usamos la capa de negocio, no el contexto directo aquí
                // Esto garantiza que la lógica de guardado sea consistente en todo el sistema
                var servicio = new Servicio();
                servicio.id = idServicioSeleccionado;
                servicio.nombre = txtNombre.Text;
                servicio.descripcion = txtDescripcion.Text;
                if (int.TryParse(txtDuracion.Text, out int duracionConvertida))
                {
                    // Si la conversión tuvo éxito, asignamos el valor
                    servicio.duracion = duracionConvertida;
                }
                else
                {
                    // Si el usuario escribió letras en lugar de números
                    MessageBox.Show("Por favor, ingrese un valor numérico válido en la duración.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detenemos el proceso para evitar errores
                }
                if (int.TryParse(txtCapacidadM.Text, out int capacidad_maximaConvertida))
                {
                    // Si la conversión tuvo éxito, asignamos el valor
                    servicio.capacidad_maxima = capacidad_maximaConvertida;
                }
                else
                {
                    // Si el usuario escribió letras en lugar de números
                    MessageBox.Show("Por favor, ingrese un valor numérico válido en la capacidad máxima.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Detenemos el proceso para evitar errores
                }

                // Llamamos a nuestra lógica probada
                int resultado = ServicioCln.modificar(servicio);

                if (resultado > 0)
                {
                    MessageBox.Show("Servicio editado con éxito.");

                    // FORZAR REFRESH
                    CargarLista();
                    btnNuevo_Click(null, null);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cambio. El servicio podría haber sido eliminado o el ID es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Si está vacío, usamos el listar normal que devuelve objetos tipo Servicio
                dgvLista.DataSource = ServicioCln.listar();
            }
            else
            {
                // Si tiene texto, usamos el que devuelve spServicioListar1_Result
                dgvLista.DataSource = ServicioCln.listar(filtro);
            }
        }
        private bool validar()
        {
            bool esValido = true;
            erpServicio.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpServicio.SetError(txtNombre, "El nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                erpServicio.SetError(txtDescripcion, "La descripción es obligatoria");
                esValido = false;
            }

            // AQUÍ REALIZAMOS EL CAMBIO:
            // Ya no validamos correo, ahora validamos teléfono
            if (string.IsNullOrWhiteSpace(txtCapacidadM.Text))
            {
                erpServicio.SetError(txtCapacidadM, "La capacidad máxima es obligatoria");
                esValido = false;
            }

            // Opcional: Validar que el teléfono solo tenga números (Control de calidad)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCapacidadM.Text, @"^\d+$"))
            {
                erpServicio.SetError(txtCapacidadM, "La capacidad máxima solo debe contener números");
                esValido = false;
            }

            return esValido;
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            new FormHorario().Show();
        }
    }
}
