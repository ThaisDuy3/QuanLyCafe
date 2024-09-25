namespace WindowsFormsApp1
{
    partial class frmChiaBan
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
            this.cbBanChiaDen = new System.Windows.Forms.ComboBox();
            this.pnlBanChia = new System.Windows.Forms.Panel();
            this.btnChiaBan = new System.Windows.Forms.Button();
            this.pnlBanChiaDen = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBanChia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grvChonSanPham = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grvChonSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBanChiaDen
            // 
            this.cbBanChiaDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanChiaDen.FormattingEnabled = true;
            this.cbBanChiaDen.Location = new System.Drawing.Point(167, 396);
            this.cbBanChiaDen.Name = "cbBanChiaDen";
            this.cbBanChiaDen.Size = new System.Drawing.Size(161, 28);
            this.cbBanChiaDen.TabIndex = 41;
            this.cbBanChiaDen.SelectedIndexChanged += new System.EventHandler(this.cbBanChiaDen_SelectedIndexChanged);
            // 
            // pnlBanChia
            // 
            this.pnlBanChia.Location = new System.Drawing.Point(17, 48);
            this.pnlBanChia.Name = "pnlBanChia";
            this.pnlBanChia.Size = new System.Drawing.Size(551, 322);
            this.pnlBanChia.TabIndex = 40;
            // 
            // btnChiaBan
            // 
            this.btnChiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiaBan.Location = new System.Drawing.Point(980, 694);
            this.btnChiaBan.Name = "btnChiaBan";
            this.btnChiaBan.Size = new System.Drawing.Size(135, 38);
            this.btnChiaBan.TabIndex = 35;
            this.btnChiaBan.Text = "Chia bàn";
            this.btnChiaBan.UseVisualStyleBackColor = true;
            this.btnChiaBan.Click += new System.EventHandler(this.btnChiaBan_Click);
            // 
            // pnlBanChiaDen
            // 
            this.pnlBanChiaDen.Location = new System.Drawing.Point(17, 430);
            this.pnlBanChiaDen.Name = "pnlBanChiaDen";
            this.pnlBanChiaDen.Size = new System.Drawing.Size(1098, 259);
            this.pnlBanChiaDen.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "Bàn muốn chia:";
            // 
            // cbBanChia
            // 
            this.cbBanChia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBanChia.FormattingEnabled = true;
            this.cbBanChia.Location = new System.Drawing.Point(138, 14);
            this.cbBanChia.Name = "cbBanChia";
            this.cbBanChia.Size = new System.Drawing.Size(150, 28);
            this.cbBanChia.TabIndex = 37;
            this.cbBanChia.SelectedIndexChanged += new System.EventHandler(this.cbBanChia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Bàn hiện tại:";
            // 
            // grvChonSanPham
            // 
            this.grvChonSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvChonSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvChonSanPham.Location = new System.Drawing.Point(574, 48);
            this.grvChonSanPham.Name = "grvChonSanPham";
            this.grvChonSanPham.RowTemplate.Height = 24;
            this.grvChonSanPham.Size = new System.Drawing.Size(541, 322);
            this.grvChonSanPham.TabIndex = 42;
            this.grvChonSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvChonSanPham_CellFormatting);
            // 
            // frmChiaBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1127, 744);
            this.Controls.Add(this.grvChonSanPham);
            this.Controls.Add(this.cbBanChiaDen);
            this.Controls.Add(this.pnlBanChia);
            this.Controls.Add(this.btnChiaBan);
            this.Controls.Add(this.pnlBanChiaDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBanChia);
            this.Controls.Add(this.label1);
            this.Name = "frmChiaBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chia bàn";
            this.Load += new System.EventHandler(this.frmChiaBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvChonSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBanChiaDen;
        private System.Windows.Forms.Panel pnlBanChia;
        private System.Windows.Forms.Button btnChiaBan;
        private System.Windows.Forms.Panel pnlBanChiaDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBanChia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grvChonSanPham;
    }
}