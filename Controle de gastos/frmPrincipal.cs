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
            PreencherCmbMes();
            PreencherCmbFiltros();

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
            cmbFiltros.SelectedIndex = 0;

            //Preencher a listview
            PreencherlvwControle(false);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            btnRemover.Enabled = btnAlterar.Enabled = false;
        }

        public void AdicionarCmbAnos()
        {
            string anoAtual = cmbAno.Text;
            dt = new DataTable();
            //adicionar os diferentes anos na combobox
            dt = ctrl.ControleAnos();
            cmbAno.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                cmbAno.Items.Add(dr[0]);
            }
            if (cmbAno.Items.Contains(anoAtual)) cmbAno.SelectedItem = anoAtual;
        }
        private void PreencherCmbMes()
        {
            string[] meses = new string[]
            {
                "Todos os Meses","Janeiro","Fevereiro","Março","Abril","Maio",
                "Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro"
            };
            cmbMes.Items.Clear();
            foreach (string m in meses)
            {
                cmbMes.Items.Add($"** {m} **");
            }
        }
        private void PreencherCmbFiltros()
        {
            string[] filtros = new string[]
            {
                "Todos os Registros","Receitas","Despesas"
            };
            cmbFiltros.Items.Clear();
            foreach (string f in filtros)
            {
                cmbFiltros.Items.Add($"** {f} **");
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
                frmCtrl = new frmControle(this, criar,Int32.Parse(oAno),cmbMes.SelectedIndex, p);
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
            //Tecla mais modificador de tecla - controle
            if (ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D0:
                    case Keys.NumPad0://Outubro
                        cmbMes.SelectedIndex = 10;
                        cmbMes.Focus();
                        break;
                    case Keys.D1:
                    case Keys.NumPad1://Novembro
                        cmbMes.SelectedIndex = 11;
                        cmbMes.Focus();
                        break;
                    case Keys.D2:
                    case Keys.NumPad2://Dezembro
                        cmbMes.SelectedIndex = 12;
                        cmbMes.Focus();
                        break;
                    case Keys.A:
                        AddAno();
                        break;
                    case Keys.W:
                        this.Close();
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        RemoverItem();//Remover Item
                        break;
                    case Keys.Enter://Alterar Item
                        AlterarItem();
                        break;
                    case Keys.N://Novo Registro
                        AbrirControle(true);
                        break;
                    case Keys.C://Comparar Tabelas
                        Comparar();
                        break;
                    //Selecionar Meses
                    case Keys.D0:
                    case Keys.NumPad0://Todos os meses
                        cmbMes.SelectedIndex = 0;
                        cmbMes.Focus();
                        break;
                    case Keys.D1:
                    case Keys.NumPad1://Janeiro
                        cmbMes.SelectedIndex = 1;
                        cmbMes.Focus();
                        break;
                    case Keys.D2:
                    case Keys.NumPad2://Fevereiro
                        cmbMes.SelectedIndex = 2;
                        cmbMes.Focus();
                        break;
                    case Keys.D3:
                    case Keys.NumPad3://Março
                        cmbMes.SelectedIndex = 3;
                        cmbMes.Focus();
                        break;
                    case Keys.D4:
                    case Keys.NumPad4://Abril
                        cmbMes.SelectedIndex = 4;
                        cmbMes.Focus();
                        break;
                    case Keys.D5:
                    case Keys.NumPad5://Maio
                        cmbMes.SelectedIndex = 5;
                        cmbMes.Focus();
                        break;
                    case Keys.D6:
                    case Keys.NumPad6://Junho
                        cmbMes.SelectedIndex = 6;
                        cmbMes.Focus();
                        break;
                    case Keys.D7:
                    case Keys.NumPad7://Julho
                        cmbMes.SelectedIndex = 7;
                        cmbMes.Focus();
                        break;
                    case Keys.D8:
                    case Keys.NumPad8://Agosto
                        cmbMes.SelectedIndex = 8;
                        cmbMes.Focus();
                        break;
                    case Keys.D9:
                    case Keys.NumPad9://Setembro
                        cmbMes.SelectedIndex = 9;
                        cmbMes.Focus();
                        break;
                    //Filtros
                    //Todos os registros
                    //Receitas
                    //Despesas
                    case Keys.T:
                        cmbFiltros.SelectedIndex = 0;
                        cmbFiltros.Focus();
                        break;
                    case Keys.R:
                        cmbFiltros.SelectedIndex = 1;
                        cmbFiltros.Focus();
                        break;
                    case Keys.D:
                        cmbFiltros.SelectedIndex = 2;
                        cmbFiltros.Focus();
                        break;
                    case Keys.L:
                        lvwControle.Focus();
                        break;
                    case Keys.A:
                        cmbAno.SelectedItem = "controle" + DateTime.Now.Year;
                        cmbMes.SelectedIndex = DateTime.Now.Month;
                        break;
                }
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
        private void AlterarItem()
        {
            if (lvwControle.SelectedItems.Count > 0)
            {
                AbrirControle(false, lvwControle.SelectedItems[0].SubItems[0].Text,
                    lvwControle.SelectedItems[0].SubItems[1].Text,
                    lvwControle.SelectedItems[0].SubItems[2].Text,
                    lvwControle.SelectedItems[0].SubItems[3].Text,
                    lvwControle.SelectedItems[0].SubItems[4].Text);
            }
        }
        private void Comparar()
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
        private void AddAno()
        {
            if (frmNovoAno == null)
            {
                frmNovoAno = new frmAno(this);
                frmNovoAno.Show();
            }
            else frmNovoAno.BringToFront();
        }
        public void AtualizarLvwControle()
        {
            if (cmbMes.Text.Contains("Todos os Meses"))
            {
                if (cmbFiltros.Text.Contains("Todos os Registros"))
                {
                    PreencherlvwControle(true);
                }
                else if (cmbFiltros.Text.Contains("Despesas"))
                {
                    PreencherlvwControle(true, false);
                }
                else PreencherlvwControle(true, true);
            }
            else
            {
                if (cmbFiltros.Text.Contains("Todos os Registros"))
                {
                    PreencherlvwControle(false);
                }
                else if (cmbFiltros.Text.Contains("Despesas"))
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
            AlterarItem();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            AbrirControle(true);
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            Comparar();
        }

        private void btnAddAno_Click(object sender, EventArgs e)
        {
            AddAno();
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
