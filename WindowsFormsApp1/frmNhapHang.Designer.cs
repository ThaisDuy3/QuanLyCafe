namespace WindowsFormsApp1
{
    partial class frmNhapHang
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
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNhapHang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.grvDanhSachSanPhamNhan = new System.Windows.Forms.DataGridView();
            this.grvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachSanPhamNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(338, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(417, 38);
            this.label5.TabIndex = 38;
            this.label5.Text = "THÊM ĐƠN NHẬP HÀNG";
            // 
            // dtNgayNhap
            // 
            this.dtNgayNhap.CustomFormat = "dd/mm/yyyy";
            this.dtNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayNhap.Location = new System.Drawing.Point(495, 169);
            this.dtNgayNhap.Name = "dtNgayNhap";
            this.dtNgayNhap.Size = new System.Drawing.Size(284, 34);
            this.dtNgayNhap.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ngày nhập:";
            // 
            // txtMaNhapHang
            // 
            this.txtMaNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhapHang.Location = new System.Drawing.Point(495, 112);
            this.txtMaNhapHang.Name = "txtMaNhapHang";
            this.txtMaNhapHang.Size = new System.Drawing.Size(284, 34);
            this.txtMaNhapHang.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 30;
            this.label1.Text = "Mã nhập hàng:";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(462, 459);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(63, 40);
            this.btnXoa.TabIndex = 42;
            this.btnXoa.Text = "<";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnChuyen
            // 
            this.btnChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyen.Location = new System.Drawing.Point(462, 413);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(63, 40);
            this.btnChuyen.TabIndex = 41;
            this.btnChuyen.Text = ">";
            this.btnChuyen.UseVisualStyleBackColor = true;
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // grvDanhSachSanPhamNhan
            // 
            this.grvDanhSachSanPhamNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvDanhSachSanPhamNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDanhSachSanPhamNhan.Location = new System.Drawing.Point(531, 339);
            this.grvDanhSachSanPhamNhan.Name = "grvDanhSachSanPhamNhan";
            this.grvDanhSachSanPhamNhan.RowTemplate.Height = 24;
            this.grvDanhSachSanPhamNhan.Size = new System.Drawing.Size(518, 238);
            this.grvDanhSachSanPhamNhan.TabIndex = 40;
            this.grvDanhSachSanPhamNhan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDanhSachSanPhamNhan_CellEndEdit);
            this.grvDanhSachSanPhamNhan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvDanhSachSanPhamNhan_CellFormatting);
            // 
            // grvDanhSachSanPham
            // 
            this.grvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvDanhSachSanPham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDanhSachSanPham.Location = new System.Drawing.Point(10, 339);
            this.grvDanhSachSanPham.Name = "grvDanhSachSanPham";
            this.grvDanhSachSanPham.RowTemplate.Height = 24;
            this.grvDanhSachSanPham.Size = new System.Drawing.Size(446, 238);
            this.grvDanhSachSanPham.TabIndex = 39;
            this.grvDanhSachSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDanhSachSanPham_CellClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(961, 298);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 35);
            this.btnLuu.TabIndex = 43;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(694, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 29);
            this.label6.TabIndex = 45;
            this.label6.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(815, 593);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(234, 34);
            this.txtTongTien.TabIndex = 44;
            // 
            // frmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1061, 659);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.grvDanhSachSanPhamNhan);
            this.Controls.Add(this.grvDanhSachSanPham);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtNgayNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaNhapHang);
            this.Controls.Add(this.label1);
            this.Name = "frmNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Hàng";
            this.Load += new System.EventHandler(this.frmNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachSanPhamNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNhapHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.DataGridView grvDanhSachSanPhamNhan;
        private System.Windows.Forms.DataGridView grvDanhSachSanPham;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}