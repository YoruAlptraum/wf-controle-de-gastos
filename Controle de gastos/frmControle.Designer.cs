
namespace Controle_de_gastos
{
    partial class frmControle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControle));
            this.label1 = new System.Windows.Forms.Label();
            this.txbDescriçao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txbDescriçao
            // 
            this.txbDescriçao.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txbDescriçao, "txbDescriçao");
            this.txbDescriçao.Name = "txbDescriçao";
            this.txbDescriçao.TextChanged += new System.EventHandler(this.txbDescriçao_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            resources.GetString("cmbStatus.Items"),
            resources.GetString("cmbStatus.Items1")});
            resources.ApplyResources(this.cmbStatus, "cmbStatus");
            this.cmbStatus.Name = "cmbStatus";
            // 
            // nudValor
            // 
            this.nudValor.BackColor = System.Drawing.Color.White;
            this.nudValor.DecimalPlaces = 2;
            resources.ApplyResources(this.nudValor, "nudValor");
            this.nudValor.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudValor.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nudValor.Name = "nudValor";
            this.nudValor.Click += new System.EventHandler(this.nudValor_Click);
            this.nudValor.Enter += new System.EventHandler(this.nudValor_Enter);
            // 
            // btnConfirmar
            // 
            resources.ApplyResources(this.btnConfirmar, "btnConfirmar");
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtpData
            // 
            this.dtpData.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpData.CalendarTitleBackColor = System.Drawing.Color.Purple;
            resources.ApplyResources(this.dtpData, "dtpData");
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpData.Name = "dtpData";
            // 
            // frmControle
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.nudValor);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbDescriçao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Controle_FormClosed);
            this.Shown += new System.EventHandler(this.frmControle_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDescriçao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}