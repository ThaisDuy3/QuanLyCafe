namespace WindowsFormsApp1
{
    partial class frmChuyenBan
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
            this.cbBanChuyen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.pnlBanChuyen = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBanChuyenDen = new System.Windows.Forms.Panel();
            this.cbBanChuyenDen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbBanChuyen
            // 
            this.cbBanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanChuyen.FormattingEnabled = true;
            this.cbBanChuyen.Location = new System.Drawing.Point(138, 28);
            this.cbBanChuyen.Name = "cbBanChuyen";
            this.cbBanChuyen.Size = new System.Drawing.Size(150, 28);
            this.cbBanChuyen.TabIndex = 21;
            this.cbBanChuyen.SelectedIndexChanged += new System.EventHandler(this.cbBanChuyen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "Bàn hiện tại:";
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.Location = new System.Drawing.Point(658, 652);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(156, 38);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // pnlBanChuyen
            // 
            this.pnlBanChuyen.Location = new System.Drawing.Point(17, 62);
            this.pnlBanChuyen.Name = "pnlBanChuyen";
            this.pnlBanChuyen.Size = new System.Drawing.Size(797, 259);
            this.pnlBanChuyen.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Bàn muốn chuyển:";
            // 
            // pnlBanChuyenDen
            // 
            this.pnlBanChuyenDen.Location = new System.Drawing.Point(17, 387);
            this.pnlBanChuyenDen.Name = "pnlBanChuyenDen";
            this.pnlBanChuyenDen.Size = new System.Drawing.Size(797, 259);
            this.pnlBanChuyenDen.TabIndex = 25;
            // 
            // cbBanChuyenDen
            // 
            this.cbBanChuyenDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanChuyenDen.FormattingEnabled = true;
            this.cbBanChuyenDen.Location = new System.Drawing.Point(198, 353);
            this.cbBanChuyenDen.Name = "cbBanChuyenDen";
            this.cbBanChuyenDen.Size = new System.Drawing.Size(150, 28);
            this.cbBanChuyenDen.TabIndex = 27;
            // 
            // frmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(831, 700);
            this.Controls.Add(this.cbBanChuyenDen);
            this.Controls.Add(this.pnlBanChuyen);
            this.Controls.Add(this.btnChuyenBan);
            this.Controls.Add(this.pnlBanChuyenDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBanChuyen);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmChuyenBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển bàn";
            this.Load += new System.EventHandler(this.frmChuyenBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBanChuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Panel pnlBanChuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBanChuyenDen;
        private System.Windows.Forms.ComboBox cbBanChuyenDen;
    }
}