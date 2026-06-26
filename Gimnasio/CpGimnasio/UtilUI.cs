using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public static class UtilUI
    {
        public static void Posicionar(Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;

            Form principal = Application.OpenForms
                                        .Cast<Form>()
                                        .FirstOrDefault(f => f is FrmPrincipal);

            if (principal != null)
            {
                int x = principal.Left + (principal.Width - frm.Width) / 2;
                int y = principal.Top + (principal.Height - frm.Height) / 2 - 115;

                frm.Location = new Point(x, y);
            }
        }
    }
}