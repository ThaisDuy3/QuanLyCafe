namespace WindowsFormsApp1
{
    partial class frmChiTietDonNhap
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
            this.grvChiTietDonNhapHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTietDonNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grvChiTietDonNhapHang
            // 
            this.grvChiTietDonNhapHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvChiTietDonNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvChiTietDonNhapHang.Location = new System.Drawing.Point(12, 45);
            this.grvChiTietDonNhapHang.Name = "grvChiTietDonNhapHang";
            this.grvChiTietDonNhapHang.RowTemplate.Height = 24;
            this.grvChiTietDonNhapHang.Size = new System.Drawing.Size(776, 393);
            this.grvChiTietDonNhapHang.TabIndex = 0;
            this.grvChiTietDonNhapHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvChiTietDonNhapHang_CellFormatting);
            // 
            // frmChiTietDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grvChiTietDonNhapHang);
            this.Name = "frmChiTietDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết đơn nhập hàng";
            this.Load += new System.EventHandler(this.frmChiTietDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTietDonNhapHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvChiTietDonNhapHang;
    }
}