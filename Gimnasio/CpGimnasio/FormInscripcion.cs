using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormInscripcion : Form
    {
        private Cliente clienteActual = null;

        public FormInscripcion()
        {
            InitializeComponent();
        }

        private void FormInscripcion_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.PAGO;
            ConfigurarEstilos();
            CargarCombos();
            LimpiarFormulario();
        }

        private void SetLabelsTransparent()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label) c.BackColor = Color.Transparent;
                if (c is Panel || c is GroupBox) SetLabelsTransparentRecursive(c);
            }
        }
        private void SetLabelsTransparentRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label) c.BackColor = Color.Transparent;
                if (c.HasChildren) SetLabelsTransparentRecursive(c);
            }
        }

        private void ConfigurarEstilos()
        {
            btnBuscarCI.BackColor = Color.FromArgb(75, 85, 99);
            btnBuscarCI.ForeColor = Color.White;
            btnBuscarCI.FlatStyle = FlatStyle.Flat;
            btnBuscarCI.FlatAppearance.BorderSize = 0;
            btnBuscarCI.Cursor = Cursors.Hand;
            btnBuscarCI.Image = null;

            btnCobrar.BackColor = Color.FromArgb(16, 185, 129);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.FlatAppearance.BorderSize = 0;
            btnCobrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCobrar.Cursor = Cursors.Hand;
            btnCobrar.Image = null;

            lblEstadoMembresia.Text = "";
        }

        private void CargarCombos()
        {
            var membresias = Repositorio<Membresia>.Listar().Where(m => m.activo == true).ToList();
            cmbMembresia.DataSource = membresias;
            cmbMembresia.DisplayMember = "tipo";
            cmbMembresia.ValueMember = "id";
            cmbMembresia.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "QR", "Tarjeta", "Transferencia" });
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnBuscarCI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCI.Text))
            {
                MessageBox.Show("Ingrese un número de CI para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clienteActual = Repositorio<Cliente>.Listar().FirstOrDefault(c => c.ci == txtCI.Text.Trim() && c.activo == true);

            if (clienteActual != null)
            {
                txtNombre.Text = clienteActual.nombre;
                txtApellido.Text = clienteActual.apellido;
                txtTelefono.Text = clienteActual.telefono;
                txtCorreo.Text = clienteActual.correo;

                var ultimaInscripcion = Repositorio<Inscripcion>.Listar()
                    .Where(i => i.id_cliente == clienteActual.id)
                    .OrderByDescending(i => i.fecha_fin)
                    .FirstOrDefault();

                if (ultimaInscripcion != null && ultimaInscripcion.fecha_fin >= DateTime.Now.Date && ultimaInscripcion.estado == "Activa")
                {
                    int diasRestantes = (ultimaInscripcion.fecha_fin - DateTime.Now.Date).Days;
                    var membresia = Repositorio<Membresia>.ObtenerUno(ultimaInscripcion.id_membresia);

                    lblEstadoMembresia.Text = $"ESTADO: ACTIVO ({diasRestantes} días restantes del plan {membresia.tipo})";
                    lblEstadoMembresia.ForeColor = Color.Green;

                    Repositorio<RegistroAcceso>.Crear(new RegistroAcceso { id_cliente = clienteActual.id, fecha_hora = DateTime.Now, tipo = "Entrada" });

                    MessageBox.Show($"ACCESO PERMITIDO.\nLe quedan {diasRestantes} días.", "Check-In Automático", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    lblEstadoMembresia.Text = "ESTADO: VENCIDO. Requiere renovación inmediata.";
                    lblEstadoMembresia.ForeColor = Color.Red;
                    MessageBox.Show("El plan del cliente ha expirado. Por favor, seleccione un nuevo plan y realice el cobro.", "Renovación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                lblEstadoMembresia.Text = "CLIENTE NUEVO";
                lblEstadoMembresia.ForeColor = Color.Blue;
                MessageBox.Show("Cliente no registrado. Complete sus datos.", "Nuevo Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
        }

        private void cmbMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembresia.SelectedItem != null)
            {
                var membresiaSeleccionada = (Membresia)cmbMembresia.SelectedItem;
                lblMontoPagar.Text = $"Total a Pagar: {membresiaSeleccionada.precio:0.00} Bs.";
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                var membresiaSel = (Membresia)cmbMembresia.SelectedItem;

                if (clienteActual == null)
                {
                    clienteActual = Repositorio<Cliente>.Crear(new Cliente
                    {
                        ci = txtCI.Text.Trim(),
                        nombre = txtNombre.Text.Trim(),
                        apellido = txtApellido.Text.Trim(),
                        telefono = txtTelefono.Text.Trim(),
                        correo = txtCorreo.Text.Trim(),
                        fecha_registro = DateTime.Now,
                        activo = true
                    });
                }
                else
                {
                    clienteActual.nombre = txtNombre.Text.Trim();
                    clienteActual.apellido = txtApellido.Text.Trim();
                    clienteActual.telefono = txtTelefono.Text.Trim();
                    clienteActual.correo = txtCorreo.Text.Trim();
                    Repositorio<Cliente>.Modificar(clienteActual);
                }

                var nuevaInscripcion = new Inscripcion
                {
                    id_cliente = clienteActual.id,
                    id_membresia = membresiaSel.id,
                    fecha_inicio = dtpInicio.Value.Date,
                    fecha_fin = dtpInicio.Value.Date.AddDays(membresiaSel.duracion_dias),
                    monto_pagado = membresiaSel.precio,
                    metodo_pago = cmbMetodoPago.Text,
                    fecha_transaccion = DateTime.Now,
                    estado = "Activa"
                };
                Repositorio<Inscripcion>.Crear(nuevaInscripcion);
                Repositorio<RegistroAcceso>.Crear(new RegistroAcceso { id_cliente = clienteActual.id, fecha_hora = DateTime.Now, tipo = "Entrada" });

                MessageBox.Show($"¡Cobro exitoso!\nMembresía válida hasta el: {nuevaInscripcion.fecha_fin.ToShortDateString()}", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("CI y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }
            if (cmbMembresia.SelectedItem == null || string.IsNullOrWhiteSpace(cmbMetodoPago.Text))
            {
                MessageBox.Show("Seleccione plan y método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            clienteActual = null;
            txtCI.Clear(); txtNombre.Clear(); txtApellido.Clear(); txtTelefono.Clear(); txtCorreo.Clear();
            if (cmbMembresia.Items.Count > 0) cmbMembresia.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now;
            lblEstadoMembresia.Text = "";
            txtCI.Focus();
        }
    }
}