using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using Controle_de_gastos.Classes;

namespace Controle_de_gastos
{
    public partial class frmPrincipal : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        Controle ctrl = new Controle();
        DataTable dt;
        static public frmControle frmCtrl = null;
        public frmPrincipal frmClone = null;
        public frmPrincipal frmOriginal = null;
        public frmAno frmNovoAno = null;
        private double total = 0, totalPrev = 0;
        public frmPrincipal(params frmPrincipal[] frmOriginal)
        {
            InitializeComponent();
            if (frmOriginal.Length > 0)
            {
                btnComparar.Enabled = btnComparar.Visible = false;
                this.frmOriginal = frmOriginal[0];
            }
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvwControle.ListViewItemSorter = lvwColumnSorter;

            lvwControle.FullRowSelect = true;
            KeyPreview = true;

            //Preencher a combo box e selecionar o item inicial
            AdicionarCmbAnos();
            cmbMes.Sorted = false;
            CultureInfo culture = new CultureInfo("pt-BR",false);
            cmbMes.SelectedIndex = DateTime.Today.Month;
            cmbAno.SelectedItem = "controle"+ DateTime.Today.Year.ToString();
            cmbFiltros.SelectedItem = "Todos os registros";

            //Preencher a listview
            PreencherlvwControle(false);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            btnRemover.Enabled = btnAlterar.Enabled = false;
        }

        public void AdicionarCmbAnos()
        {
            dt = new DataTable();
            //adicionar os diferentes anos na combobox
            dt = ctrl.ControleAnos();
            cmbAno.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                cmbAno.Items.Add(dr[0]);
            }
        }

        //preenche a listview sem filtro
        private void PreencherlvwControle(bool anoInteiro)
        {
            dt = new DataTable();
            dt = ctrl.dtLvwControle(cmbAno.Text, cmbMes.SelectedIndex, anoInteiro);
            PreencherlvwControle(dt);
        }
        //preenche a listview com filtro
        private void PreencherlvwControle(bool anoInteiro, bool receita)
        {
            dt = new DataTable();
            dt = ctrl.dtLvwControle(cmbAno.Text, cmbMes.SelectedIndex, anoInteiro, receita);
            PreencherlvwControle(dt);
        }
        //faz o preenchimento da listview com base na dataTable
        private void PreencherlvwControle(DataTable dt)
        {
            lvwControle.Items.Clear();
            total = totalPrev = 0;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string s;
                    ListViewItem item = new ListViewItem(dr["descriçao"].ToString());
                    item.SubItems.Add(dr["valor"].ToString());
                    if (Convert.ToBoolean(dr["previsao"]))
                    {
                        s = "previsão";
                        totalPrev += Convert.ToDouble(dr["valor"]);
                    }
                    else
                    {
                        s = "ok";
                        total += Convert.ToDouble(dr["valor"]);
                    }
                    item.SubItems.Add(s);
                    DateTime dateTime = Convert.ToDateTime(dr["dataregistro"]);
                    item.SubItems.Add(dateTime.ToString("dd/MM"));
                    item.SubItems.Add(dr["id"].ToString());
                    lvwControle.Items.Add(item);
                }
            }
            lblTotal.Text =    $"Total....: R$ {total}";
            lblPrevisao.Text = $"Previsão: R$ {totalPrev}";
        }


        void AbrirControle(bool criar,params string[] p)
        {
            string oAno = cmbAno.Text.Substring(8,4);
            if (frmCtrl == null)
            {
                frmCtrl = new frmControle(this, criar,Int32.Parse(oAno), p);
                frmCtrl.Show();
                frmCtrl.TopLevel = true;
            }
            else
            {
                frmCtrl.BringToFront();
                frmCtrl.criar = criar;
                if (!criar)
                {
                    frmCtrl.AtualizarCampos(p);
                }
            }
            btnAlterar.Enabled = btnRemover.Enabled = false;
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                RemoverItem();
            }
        }
        private void RemoverItem()
        {
            //se tiver algum item selecionado
            if (lvwControle.SelectedItems.Count>0)
            {
                //remover item
                ctrl.RemoverRegistro(cmbAno.Text,
                    Int32.Parse(lvwControle.SelectedItems[0].SubItems[4].Text));
                AtualizarLvwControle();
            }
        }
        public void AtualizarLvwControle()
        {
            if (cmbMes.Text.Equals("Todos os meses"))
            {
                if (cmbFiltros.Text.Equals("Todos os registros"))
                {
                    PreencherlvwControle(true);
                }
                else if (cmbFiltros.Text.Equals("Despesas"))
                {
                    PreencherlvwControle(true, false);
                }
                else PreencherlvwControle(true, true);
            }
            else
            {
                if (cmbFiltros.Text.Equals("Todos os registros"))
                {
                    PreencherlvwControle(false);
                }
                else if (cmbFiltros.Text.Equals("Despesas"))
                {
                    PreencherlvwControle(false, false);
                }
                else PreencherlvwControle(false, true);
            }
            btnRemover.Enabled = btnAlterar.Enabled = false;
        }
        private void lvwControle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwControle.SelectedItems.Count > 0)
                btnAlterar.Enabled = btnRemover.Enabled = true;
            else btnAlterar.Enabled = btnRemover.Enabled = false;
        }
        //Ordenar por coluna
        private void lvwControle_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwControle.Sort();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //remover item
            RemoverItem();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AbrirControle(false,lvwControle.SelectedItems[0].SubItems[0].Text,
                lvwControle.SelectedItems[0].SubItems[1].Text,
                lvwControle.SelectedItems[0].SubItems[2].Text,
                lvwControle.SelectedItems[0].SubItems[3].Text,
                lvwControle.SelectedItems[0].SubItems[4].Text);
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            AbrirControle(true);
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (frmClone == null)
            {
                frmClone = new frmPrincipal(this);
                frmClone.Show();
            }
            else
            {
                frmClone.BringToFront();
            }
            btnAlterar.Enabled = btnRemover.Enabled = false;
        }

        private void btnAddAno_Click(object sender, EventArgs e)
        {
            if (frmNovoAno == null)
            {
                frmNovoAno = new frmAno(this);
                frmNovoAno.Show();
            }
            else frmNovoAno.BringToFront();
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarLvwControle();
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(frmOriginal != null)
            {
                frmOriginal.frmClone = null;
            }
        }
    }
}
