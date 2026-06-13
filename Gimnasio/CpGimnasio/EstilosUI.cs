using System.Drawing;
using System.Windows.Forms;

namespace CpGimnasio
{
    public static class EstilosUI
    {
        // 1. ESTILO PARA CRUD (Clientes, Entrenadores, Ventas)
        public static void FormatearGrilla(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 57, 85);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
        }

        // 2. ESTILO EXCLUSIVO PARA REPORTES GERENCIALES (Estilo Cebra)
        public static void FormatearGrillaReporte(DataGridView dgv)
        {
            // Primero le aplicamos la base limpia...
            FormatearGrilla(dgv);

            // ... y luego le inyectamos la magia contable (Filas alternadas)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250); // Gris/celeste casi invisible

            // En un reporte a veces no quieres que toda la fila se pinte al hacer clic, 
            // sino solo la celda para copiar un dato. Si prefieres que se pinte toda la fila, borra la siguiente línea:
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}