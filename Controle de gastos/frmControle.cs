using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Controle_de_gastos.Classes;
using System.Globalization;
using System.Diagnostics;

namespace Controle_de_gastos
{
    public partial class frmControle : Form
    {
        Conexao conexao = new Conexao();
        Controle ctrl = new Controle();
        public frmPrincipal principal;
        public bool criar;
        int idControle;
        public frmControle(frmPrincipal principal,bool criar,int oAno,params string[] p)
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0;
            btnConfirmar.Enabled = false;
            this.principal = principal;
            this.criar = criar;            
            if (p.Length == 5) AtualizarCampos(p);

            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.CustomFormat = "dd/MM";

            DateTime maxdate = new DateTime(oAno, 12, 31);
            DateTime mindate = new DateTime(oAno, 1, 1);
            dtpData.MaxDate = maxdate;
            dtpData.MinDate = mindate;

            KeyPreview = true;
        }
        public void AtualizarCampos(string[] p)
        {
            txbDescriçao.Text = p[0];
            nudValor.Value = Decimal.Parse(p[1]);
            if (p[2].Equals("ok"))
            {
                cmbStatus.SelectedIndex = 0;
            }
            else
            {
                cmbStatus.SelectedIndex = 1;
            }
            DateTime.TryParseExact(p[3],"dd/MM",null, DateTimeStyles.None, out DateTime d);
            dtpData.Value = d;
            idControle = Int32.Parse(p[4]);
            Debug.WriteLine(idControle);
        }
        private void Controle_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrincipal.frmCtrl = null;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }
        void Confirmar()
        {
            bool prev;
            if (cmbStatus.SelectedIndex == 0) prev = false;
            else prev = true;
            //Alterar ou Criar um item
            if (criar)
            {
                //criar um item
                ctrl.NovoRegistro("controle" + dtpData.Value.Year,
                    txbDescriçao.Text,prev,Convert.ToDouble(nudValor.Value),
                    dtpData.Value);
            }
            else
            {
                //alterar o item
                ctrl.AlterarRegistro("controle" + dtpData.Value.Year,
                    txbDescriçao.Text,prev, Convert.ToDouble(nudValor.Value),
                    dtpData.Value,idControle);
            }
            //atualizar a listview do form principal
            principal.AtualizarLvwControle();
            if(principal.frmClone != null)
            {
                principal.frmClone.AtualizarLvwControle();
            }
        }
        private void Controle_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && btnConfirmar.Enabled)
            {
                Confirmar();
            }
        }

        private void txbDescriçao_TextChanged(object sender, EventArgs e)
        {
            if(txbDescriçao.TextLength > 0)
            {
                btnConfirmar.Enabled = true;
            }
        }
    }
}
