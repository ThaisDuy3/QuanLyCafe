namespace WindowsFormsApp1
{
    partial class frmGopBan
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
            this.cbBanGopDen = new System.Windows.Forms.ComboBox();
            this.pnlBanGop = new System.Windows.Forms.Panel();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.pnlBanGopDen = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBanGop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbBanGopDen
            // 
            this.cbBanGopDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanGopDen.FormattingEnabled = true;
            this.cbBanGopDen.Location = new System.Drawing.Point(167, 344);
            this.cbBanGopDen.Name = "cbBanGopDen";
            this.cbBanGopDen.Size = new System.Drawing.Size(161, 28);
            this.cbBanGopDen.TabIndex = 34;
            this.cbBanGopDen.SelectedIndexChanged += new System.EventHandler(this.cbBanGopDen_SelectedIndexChanged);
            // 
            // pnlBanGop
            // 
            this.pnlBanGop.Location = new System.Drawing.Point(17, 53);
            this.pnlBanGop.Name = "pnlBanGop";
            this.pnlBanGop.Size = new System.Drawing.Size(797, 259);
            this.pnlBanGop.TabIndex = 33;
            // 
            // btnGopBan
            // 
            this.btnGopBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.Location = new System.Drawing.Point(679, 643);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(135, 38);
            this.btnGopBan.TabIndex = 28;
            this.btnGopBan.Text = "Gộp bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // pnlBanGopDen
            // 
            this.pnlBanGopDen.Location = new System.Drawing.Point(17, 378);
            this.pnlBanGopDen.Name = "pnlBanGopDen";
            this.pnlBanGopDen.Size = new System.Drawing.Size(797, 259);
            this.pnlBanGopDen.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 31;
            this.label2.Text = "Bàn muốn gộp:";
            // 
            // cbBanGop
            // 
            this.cbBanGop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanGop.FormattingEnabled = true;
            this.cbBanGop.Location = new System.Drawing.Point(138, 19);
            this.cbBanGop.Name = "cbBanGop";
            this.cbBanGop.Size = new System.Drawing.Size(150, 28);
            this.cbBanGop.TabIndex = 30;
            this.cbBanGop.SelectedIndexChanged += new System.EventHandler(this.cbBanGop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Bàn hiện tại:";
            // 
            // frmGopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(826, 691);
            this.Controls.Add(this.cbBanGopDen);
            this.Controls.Add(this.pnlBanGop);
            this.Controls.Add(this.btnGopBan);
            this.Controls.Add(this.pnlBanGopDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBanGop);
            this.Controls.Add(this.label1);
            this.Name = "frmGopBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gộp bàn";
            this.Load += new System.EventHandler(this.frmGopBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBanGopDen;
        private System.Windows.Forms.Panel pnlBanGop;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.Panel pnlBanGopDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBanGop;
        private System.Windows.Forms.Label label1;
    }
}