
namespace Controle_de_gastos
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.splTop = new System.Windows.Forms.SplitContainer();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddAno = new System.Windows.Forms.Button();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnComparar = new System.Windows.Forms.Button();
            this.lblPrevisao = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbFiltros = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwControle = new System.Windows.Forms.ListView();
            this.chDescriçao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splTop)).BeginInit();
            this.splTop.Panel1.SuspendLayout();
            this.splTop.Panel2.SuspendLayout();
            this.splTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splTop
            // 
            resources.ApplyResources(this.splTop, "splTop");
            this.splTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splTop.Name = "splTop";
            // 
            // splTop.Panel1
            // 
            this.splTop.Panel1.Controls.Add(this.cmbMes);
            // 
            // splTop.Panel2
            // 
            this.splTop.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // cmbMes
            // 
            resources.ApplyResources(this.cmbMes, "cmbMes");
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            resources.GetString("cmbMes.Items"),
            resources.GetString("cmbMes.Items1"),
            resources.GetString("cmbMes.Items2"),
            resources.GetString("cmbMes.Items3"),
            resources.GetString("cmbMes.Items4"),
            resources.GetString("cmbMes.Items5"),
            resources.GetString("cmbMes.Items6"),
            resources.GetString("cmbMes.Items7"),
            resources.GetString("cmbMes.Items8"),
            resources.GetString("cmbMes.Items9"),
            resources.GetString("cmbMes.Items10"),
            resources.GetString("cmbMes.Items11"),
            resources.GetString("cmbMes.Items12")});
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnAddAno, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbAno, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnAddAno
            // 
            this.btnAddAno.BackgroundImage = global::Controle_de_gastos.Properties.Resources.add;
            resources.ApplyResources(this.btnAddAno, "btnAddAno");
            this.btnAddAno.Name = "btnAddAno";
            this.btnAddAno.UseVisualStyleBackColor = true;
            this.btnAddAno.Click += new System.EventHandler(this.btnAddAno_Click);
            // 
            // cmbAno
            // 
            resources.ApplyResources(this.cmbAno, "cmbAno");
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnComparar);
            this.panel1.Controls.Add(this.lblPrevisao);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.btnRemover);
            this.panel1.Controls.Add(this.btnAlterar);
            this.panel1.Controls.Add(this.btnNovo);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnComparar
            // 
            resources.ApplyResources(this.btnComparar, "btnComparar");
            this.btnComparar.BackgroundImage = global::Controle_de_gastos.Properties.Resources.compare;
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // lblPrevisao
            // 
            resources.ApplyResources(this.lblPrevisao, "lblPrevisao");
            this.lblPrevisao.Name = "lblPrevisao";
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.Name = "lblTotal";
            // 
            // btnRemover
            // 
            resources.ApplyResources(this.btnRemover, "btnRemover");
            this.btnRemover.BackgroundImage = global::Controle_de_gastos.Properties.Resources.trash;
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            resources.ApplyResources(this.btnAlterar, "btnAlterar");
            this.btnAlterar.BackgroundImage = global::Controle_de_gastos.Properties.Resources.Alterar;
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnNovo
            // 
            resources.ApplyResources(this.btnNovo, "btnNovo");
            this.btnNovo.BackgroundImage = global::Controle_de_gastos.Properties.Resources.add;
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbFiltros);
            this.panel2.Controls.Add(this.splTop);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // cmbFiltros
            // 
            resources.ApplyResources(this.cmbFiltros, "cmbFiltros");
            this.cmbFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltros.FormattingEnabled = true;
            this.cmbFiltros.Items.AddRange(new object[] {
            resources.GetString("cmbFiltros.Items"),
            resources.GetString("cmbFiltros.Items1"),
            resources.GetString("cmbFiltros.Items2")});
            this.cmbFiltros.Name = "cmbFiltros";
            this.cmbFiltros.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwControle);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // lvwControle
            // 
            this.lvwControle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwControle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDescriçao,
            this.chValor,
            this.chStatus,
            this.chData});
            resources.ApplyResources(this.lvwControle, "lvwControle");
            this.lvwControle.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lvwControle.HideSelection = false;
            this.lvwControle.Name = "lvwControle";
            this.lvwControle.UseCompatibleStateImageBehavior = false;
            this.lvwControle.View = System.Windows.Forms.View.Details;
            this.lvwControle.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwControle_ColumnClick);
            this.lvwControle.SelectedIndexChanged += new System.EventHandler(this.lvwControle_SelectedIndexChanged);
            // 
            // chDescriçao
            // 
            resources.ApplyResources(this.chDescriçao, "chDescriçao");
            // 
            // chValor
            // 
            resources.ApplyResources(this.chValor, "chValor");
            // 
            // chStatus
            // 
            resources.ApplyResources(this.chStatus, "chStatus");
            // 
            // chData
            // 
            resources.ApplyResources(this.chData, "chData");
            // 
            // frmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrincipal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyDown);
            this.splTop.Panel1.ResumeLayout(false);
            this.splTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splTop)).EndInit();
            this.splTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvwControle;
        private System.Windows.Forms.Label lblPrevisao;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ColumnHeader chDescriçao;
        private System.Windows.Forms.ColumnHeader chValor;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.SplitContainer splTop;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.ComboBox cmbFiltros;
        private System.Windows.Forms.Button btnComparar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddAno;
    }
}

