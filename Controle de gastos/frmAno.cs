using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controle_de_gastos.Classes;

namespace Controle_de_gastos
{
    public partial class frmAno : Form
    {
        Controle ctrl = new Controle();
        frmPrincipal main;
        public frmAno(frmPrincipal main)
        {
            InitializeComponent();
            this.main = main;
            nudAno.Minimum = 0;
            nudAno.Maximum = 5000;
            nudAno.Value = DateTime.Now.Year;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }
        private void Confirmar()
        {
            string m = "";
            m = ctrl.NovoAno(Convert.ToInt32(nudAno.Value));
            MessageBox.Show(m);
            if (m.Equals("Tabela criada"))
            {
                main.AdicionarCmbAnos();
                main.frmNovoAno = null;
                this.Close();
            }
        }

        private void frmAno_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.frmNovoAno = null;
        }

        private void frmAno_Shown(object sender, EventArgs e)
        {
            CenterMouseOverControl(nudAno);
        }
        private void CenterMouseOverControl(Control ctl)
        {
            // See where to put the mouse.
            Point target = new Point(
                (ctl.Left + ctl.Right) / 2,
                (ctl.Top + ctl.Bottom) / 2);

            // Convert to screen coordinates.
            Point screen_coords = ctl.Parent.PointToScreen(target);

            Cursor.Position = screen_coords;
        }

        private void frmAno_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (btnConfirmar.Enabled) Confirmar();
                    break;
            }
            if (ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        this.Close();
                        break;
                }
            }
        }
    }
}
