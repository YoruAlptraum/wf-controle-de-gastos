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
            ctrl.NovoAno(Convert.ToInt32(nudAno.Value));
            main.AdicionarCmbAnos();
            main.frmNovoAno = null;
            this.Close();
        }
    }
}
