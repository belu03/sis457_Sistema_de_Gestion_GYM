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

    public partial class FormHorario : Form
    {
        int idHorarioSeleccionado = 0;
        public FormHorario()
        {
            InitializeComponent();
        }
        private void CargarLista()
        {
            // 1. Obtener la lista limpia
            var lista = HorarioCln.listar();
            dgvLista.DataSource = lista;

            // 2. IMPORTANTE: Si AutoGenerateColumns = false, debemos definir las columnas
            // Limpiamos las que existan por si acaso
            dgvLista.Columns.Clear();

            // 3. Agregamos las columnas manualmente (esto evita los Proxies raros)
            dgvLista.Columns.Add("dia", "Día");
            dgvLista.Columns["dia"].DataPropertyName = "dia";

            dgvLista.Columns.Add("hora_inicio", "Hora Inicio");
            dgvLista.Columns["hora_inicio"].DataPropertyName = "hora_inicio";

            dgvLista.Columns.Add("hora_fin", "Hora Fin");
            dgvLista.Columns["hora_fin"].DataPropertyName = "hora_fin";
            // Cargas tus datos normalmente

            dgvLista.DataSource = HorarioCln.listar();

            // Ocultar columnas específicas por nombre
            if (dgvLista.Columns["Servicio"] != null) dgvLista.Columns["Servicio"].Visible = false;
            if (dgvLista.Columns["Entrenador"] != null) dgvLista.Columns["Entrenador"].Visible = false;
        }

        private void FormHorario_Load(object sender, EventArgs e)
        {
            // A. Datos fijos (Días y Horas)
            cboDia.Items.AddRange(new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });

            string[] horas = { "07:00", "08:00", "09:00", "10:00", "11:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00" };
            cboHoraInicio.Items.AddRange(horas);
            cboHoraFin.Items.AddRange(horas);

            // B. Datos relacionales (Servicio y Entrenador)
            // Aquí usamos la capa de negocio que ya creamos antes
            cboServicio.DataSource = ServicioCln.listar();
            cboServicio.DisplayMember = "nombre"; // Lo que el usuario ve
            cboServicio.ValueMember = "id";       // Lo que guardamos internamente

            cboEntrenador.DataSource = EntrenadorCln.listar();
            cboEntrenador.DisplayMember = "nombre";
            cboEntrenador.ValueMember = "id";

            // C. Importante: Limpiar selección inicial para que no aparezca nada seleccionado
            cboDia.SelectedIndex = -1;
            cboServicio.SelectedIndex = -1;
            // Forzamos la autogeneración por código
            dgvLista.AutoGenerateColumns = false;

            // ... tu lógica de carga ...
            CargarLista();

        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Verificamos que el clic no sea en el encabezado
            if (e.RowIndex >= 0)
            {
                // 2. EXTRAEMOS EL OBJETO DIRECTAMENTE
                // En lugar de buscar por nombre de columna ("id", "dia"), 
                // obtenemos el objeto Horario completo que está "atado" a esa fila.
                var filaSeleccionada = dgvLista.Rows[e.RowIndex].DataBoundItem as Horario;

                if (filaSeleccionada != null)
                {
                    // 3. ASIGNAMOS USANDO EL OBJETO
                    idHorarioSeleccionado = filaSeleccionada.id;

                    cboDia.Text = filaSeleccionada.dia;
                    cboHoraInicio.Text = ((TimeSpan)filaSeleccionada.hora_inicio).ToString(@"hh\:mm");
                    cboHoraFin.Text = ((TimeSpan)filaSeleccionada.hora_fin).ToString(@"hh\:mm");

                    // Esto es mucho más seguro que usar Cells["nombre_columna"]
                    cboServicio.SelectedValue = filaSeleccionada.id_servicio;
                    cboEntrenador.SelectedValue = filaSeleccionada.id_entrenador;
               
                }
            }

        }
        private void GuardarHorario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDia.Text) ||
                 cboServicio.SelectedValue == null ||
                 cboEntrenador.SelectedValue == null ||
                 cboHoraInicio.SelectedIndex == -1 ||
                 cboHoraFin.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, asegúrese de haber seleccionado todos los campos antes de guardar.",
                                "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // ¡Aquí es donde se detiene todo!
            }

            // Si pasaste el filtro, entonces intentamos guardar
        

            // 2. Si el código llega hasta aquí, es porque la validación fue exitosa.
            Horario horario = new Horario();

            // 2. Asignamos el día (es texto, se asigna directo)
            horario.dia = cboDia.Text;

            // 3. CORRECCIÓN DE TIEMPO (De string a TimeSpan)
            // El ComboBox tiene texto ("14:00"), pero la BD necesita un tiempo real (TimeSpan)
            horario.hora_inicio = TimeSpan.Parse(cboHoraInicio.Text);
            horario.hora_fin = TimeSpan.Parse(cboHoraFin.Text);

            // 4. CORRECCIÓN DE RELACIONES (De string a ID)
            // Nunca guardes el texto del combo ("Zumba"), guarda el ID numérico del combo.
            // Usamos (int) para asegurar que el ID sea un número entero.
            horario.id_servicio = (int)cboServicio.SelectedValue;
            horario.id_entrenador = (int)cboEntrenador.SelectedValue;

            int resultado = HorarioCln.crear(horario);

            if (resultado > 0)
            {
                MessageBox.Show("Guardado con éxito");
                dgvLista.DataSource = HorarioCln.listar();
                btnNuevo_Click(null, null);
            }
            if (cboDia.SelectedIndex == -1)
            {
                
                return;
            }

            if (cboServicio.SelectedValue == null)
            {
                MessageBox.Show("¡Atención! El 'Servicio' no tiene un valor válido (es null).");
                return;
            }

            // ... aquí tu código de guardado ...
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idHorarioSeleccionado == 0)
            {
                MessageBox.Show("Por favor, seleccione un horario de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Está segura de que desea eliminar este horario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int eliminado = HorarioCln.eliminar(idHorarioSeleccionado);

                if (eliminado > 0)
                {
                    MessageBox.Show("Horario eliminado exitosamente.");
                    dgvLista.DataSource = HorarioCln.listar();
                    btnNuevo_Click(null, null); // Limpiar formulario
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar. El horario podría tener registros relacionados (como asistencias).");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // 1. Reseteamos el ID seleccionado a 0 (indica que el formulario está en modo "nuevo")
            idHorarioSeleccionado = 0;

            // 2. Limpiamos los ComboBox (usando SelectedIndex = -1)
            cboDia.SelectedIndex = -1;
            cboHoraInicio.SelectedIndex = -1;
            cboHoraFin.SelectedIndex = -1;
            cboServicio.SelectedIndex = -1;
            cboEntrenador.SelectedIndex = -1;

            // 3. Limpiamos cualquier texto guía que pudieras haber dejado en los campos
            cboDia.Text = "";
            cboHoraInicio.Text = "";
            cboHoraFin.Text = "";

            // 4. Ponemos el foco en el primer campo para que el usuario empiece a escribir
            cboDia.Focus();

            // 5. Opcional: Limpiamos los errores del ErrorProvider si los hubiera
            // erpHorario.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idHorarioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un Horario de la lista para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // AUDITORÍA: Usamos la capa de negocio, no el contexto directo aquí
                // Esto garantiza que la lógica de guardado sea consistente en todo el sistema
                var horario = new Horario();
                // 1. Instanciamos el objeto

                // 2. Asignamos el día (es texto, se asigna directo)
                horario.dia = cboDia.Text;

                // 3. CORRECCIÓN DE TIEMPO (De string a TimeSpan)
                // El ComboBox tiene texto ("14:00"), pero la BD necesita un tiempo real (TimeSpan)
                horario.hora_inicio = TimeSpan.Parse(cboHoraInicio.Text);
                horario.hora_fin = TimeSpan.Parse(cboHoraFin.Text);

                // 4. CORRECCIÓN DE RELACIONES (De string a ID)
                // Nunca guardes el texto del combo ("Zumba"), guarda el ID numérico del combo.
                // Usamos (int) para asegurar que el ID sea un número entero.
                horario.id_servicio = (int)cboServicio.SelectedValue;
                horario.id_entrenador = (int)cboEntrenador.SelectedValue;


                // Llamamos a nuestra lógica probada
                int resultado = HorarioCln.modificar(horario);

                if (resultado > 0)
                {
                    MessageBox.Show("Horario editado con éxito.");

                    // FORZAR REFRESH
                    CargarLista();
                    btnNuevo_Click(null, null);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cambio. El Horario podría haber sido eliminado o el ID es incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;

            if (string.IsNullOrWhiteSpace(filtro))
            {
                // Esto está bien, llama al listar() que devuelve List<Horario>
                dgvLista.DataSource = HorarioCln.listar();
            }
            else
            {
                // AQUÍ ESTABA EL ERROR: No pongas nada referente a "spHorarioListar1_Result"
                // Simplemente llama al método que creamos en HorarioCln
                dgvLista.DataSource = HorarioCln.listar(filtro);
            }

            // Opcional: Asegúrate de ocultar las columnas técnicas cada vez que filtres
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
        }
        private bool validar()
        {
            bool esValido = true;
            erpHorario.Clear();

            if (string.IsNullOrWhiteSpace(cboDia.Text))
            {
                erpHorario.SetError(cboDia, "El dia es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(cboEntrenador.Text))
            {
                erpHorario.SetError(cboEntrenador, "El Entrenador es obligatorio");
                esValido = false;
            }

            // AQUÍ REALIZAMOS EL CAMBIO:
            // Ya no validamos correo, ahora validamos teléfono
            if (string.IsNullOrWhiteSpace(cboServicio.Text))
            {
                erpHorario.SetError(cboServicio, "El Servicio es obligatorio");
                esValido = false;
            }

            return esValido;
        }

        
    }
}
