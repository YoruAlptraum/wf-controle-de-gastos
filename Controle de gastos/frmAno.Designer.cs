
namespace Controle_de_gastos
{
    partial class frmAno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAno));
            this.nudAno = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAno)).BeginInit();
            this.SuspendLayout();
            // 
            // nudAno
            // 
            this.nudAno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAno.Location = new System.Drawing.Point(0, 0);
            this.nudAno.Name = "nudAno";
            this.nudAno.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nudAno.Size = new System.Drawing.Size(484, 49);
            this.nudAno.TabIndex = 0;
            this.nudAno.ThousandsSeparator = true;
            this.nudAno.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfirmar.Location = new System.Drawing.Point(0, 55);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(484, 50);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 44F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 105);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.nudAno);
            this.Font = new System.Drawing.Font("Trebuchet MS", 27F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione o ano";
            ((System.ComponentModel.ISupportInitialize)(this.nudAno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudAno;
        private System.Windows.Forms.Button btnConfirmar;
    }
}