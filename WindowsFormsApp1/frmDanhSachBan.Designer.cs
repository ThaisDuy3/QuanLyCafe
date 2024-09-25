namespace WindowsFormsApp1
{
    partial class frmDanhSachBan
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThongTinTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grvHoaDon = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSoBan = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnHuyBan = new System.Windows.Forms.Button();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemDoUong = new System.Windows.Forms.Button();
            this.cbDoU = new System.Windows.Forms.ComboBox();
            this.cbLoai = new System.Windows.Forms.ComboBox();
            this.pnlBan1 = new System.Windows.Forms.Panel();
            this.cbKhuVuc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBan2 = new System.Windows.Forms.Panel();
            this.pnlBan3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChiaBan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvHoaDon)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MintCream;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQuanLy,
            this.mnTaiKhoan});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnQuanLy
            // 
            this.mnQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnQuanLy.Name = "mnQuanLy";
            this.mnQuanLy.Size = new System.Drawing.Size(77, 28);
            this.mnQuanLy.Text = "Admin";
            this.mnQuanLy.Click += new System.EventHandler(this.mnQuanLy_Click);
            // 
            // mnTaiKhoan
            // 
            this.mnTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnThongTinTaiKhoan,
            this.mnDangXuat});
            this.mnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnTaiKhoan.Name = "mnTaiKhoan";
            this.mnTaiKhoan.Size = new System.Drawing.Size(105, 28);
            this.mnTaiKhoan.Text = "Tài khoản";
            // 
            // mnThongTinTaiKhoan
            // 
            this.mnThongTinTaiKhoan.Name = "mnThongTinTaiKhoan";
            this.mnThongTinTaiKhoan.Size = new System.Drawing.Size(195, 28);
            this.mnThongTinTaiKhoan.Text = "Đổi mật khẩu";
            this.mnThongTinTaiKhoan.Click += new System.EventHandler(this.mnThongTinTaiKhoan_Click);
            // 
            // mnDangXuat
            // 
            this.mnDangXuat.Name = "mnDangXuat";
            this.mnDangXuat.Size = new System.Drawing.Size(195, 28);
            this.mnDangXuat.Text = "Đăng xuất";
            this.mnDangXuat.Click += new System.EventHandler(this.mnDangXuat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaHoaDon);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.grvHoaDon);
            this.panel2.Location = new System.Drawing.Point(548, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 442);
            this.panel2.TabIndex = 1;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(130, 7);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(115, 27);
            this.txtMaHoaDon.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mã hóa đơn:";
            // 
            // grvHoaDon
            // 
            this.grvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvHoaDon.Location = new System.Drawing.Point(4, 40);
            this.grvHoaDon.Name = "grvHoaDon";
            this.grvHoaDon.RowTemplate.Height = 24;
            this.grvHoaDon.Size = new System.Drawing.Size(443, 399);
            this.grvHoaDon.TabIndex = 0;
            this.grvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvHoaDon_CellFormatting);
            this.grvHoaDon.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvHoaDon_CellValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSoBan);
            this.panel3.Controls.Add(this.txtTongTien);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Controls.Add(this.btnChuyenBan);
            this.panel3.Location = new System.Drawing.Point(548, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 72);
            this.panel3.TabIndex = 2;
            // 
            // txtSoBan
            // 
            this.txtSoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoBan.Location = new System.Drawing.Point(3, 3);
            this.txtSoBan.Name = "txtSoBan";
            this.txtSoBan.Size = new System.Drawing.Size(123, 27);
            this.txtSoBan.TabIndex = 13;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(137, 41);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(184, 27);
            this.txtTongTien.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(133, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tổng tiền:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(344, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(103, 66);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.Location = new System.Drawing.Point(3, 34);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(123, 35);
            this.btnChuyenBan.TabIndex = 4;
            this.btnChuyenBan.Text = "Chuyển bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // btnHuyBan
            // 
            this.btnHuyBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBan.Location = new System.Drawing.Point(221, 3);
            this.btnHuyBan.Name = "btnHuyBan";
            this.btnHuyBan.Size = new System.Drawing.Size(96, 66);
            this.btnHuyBan.TabIndex = 7;
            this.btnHuyBan.Text = "Hủy bàn";
            this.btnHuyBan.UseVisualStyleBackColor = true;
            this.btnHuyBan.Click += new System.EventHandler(this.btnHuyBan_Click);
            // 
            // btnGopBan
            // 
            this.btnGopBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.Location = new System.Drawing.Point(3, 3);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(103, 66);
            this.btnGopBan.TabIndex = 6;
            this.btnGopBan.Text = "Gộp bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmSoLuong);
            this.panel4.Controls.Add(this.btnThemDoUong);
            this.panel4.Controls.Add(this.cbDoU);
            this.panel4.Controls.Add(this.cbLoai);
            this.panel4.Location = new System.Drawing.Point(548, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 72);
            this.panel4.TabIndex = 3;
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSoLuong.Location = new System.Drawing.Point(287, 23);
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(66, 27);
            this.nmSoLuong.TabIndex = 3;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemDoUong
            // 
            this.btnThemDoUong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDoUong.Location = new System.Drawing.Point(359, 4);
            this.btnThemDoUong.Name = "btnThemDoUong";
            this.btnThemDoUong.Size = new System.Drawing.Size(88, 62);
            this.btnThemDoUong.TabIndex = 2;
            this.btnThemDoUong.Text = "Thêm món";
            this.btnThemDoUong.UseVisualStyleBackColor = true;
            this.btnThemDoUong.Click += new System.EventHandler(this.btnThemDoUong_Click);
            // 
            // cbDoU
            // 
            this.cbDoU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDoU.FormattingEnabled = true;
            this.cbDoU.Location = new System.Drawing.Point(4, 38);
            this.cbDoU.Name = "cbDoU";
            this.cbDoU.Size = new System.Drawing.Size(277, 28);
            this.cbDoU.TabIndex = 1;
            // 
            // cbLoai
            // 
            this.cbLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoai.FormattingEnabled = true;
            this.cbLoai.Location = new System.Drawing.Point(4, 4);
            this.cbLoai.Name = "cbLoai";
            this.cbLoai.Size = new System.Drawing.Size(277, 28);
            this.cbLoai.TabIndex = 0;
            this.cbLoai.SelectedIndexChanged += new System.EventHandler(this.cbLoai_SelectedIndexChanged);
            // 
            // pnlBan1
            // 
            this.pnlBan1.Location = new System.Drawing.Point(12, 99);
            this.pnlBan1.Name = "pnlBan1";
            this.pnlBan1.Size = new System.Drawing.Size(523, 131);
            this.pnlBan1.TabIndex = 5;
            // 
            // cbKhuVuc
            // 
            this.cbKhuVuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKhuVuc.FormattingEnabled = true;
            this.cbKhuVuc.Location = new System.Drawing.Point(129, 40);
            this.cbKhuVuc.Name = "cbKhuVuc";
            this.cbKhuVuc.Size = new System.Drawing.Size(156, 26);
            this.cbKhuVuc.TabIndex = 4;
            this.cbKhuVuc.SelectedIndexChanged += new System.EventHandler(this.cbKhuVuc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn khu:";
            // 
            // pnlBan2
            // 
            this.pnlBan2.Location = new System.Drawing.Point(12, 262);
            this.pnlBan2.Name = "pnlBan2";
            this.pnlBan2.Size = new System.Drawing.Size(523, 131);
            this.pnlBan2.TabIndex = 6;
            // 
            // pnlBan3
            // 
            this.pnlBan3.Location = new System.Drawing.Point(12, 425);
            this.pnlBan3.Name = "pnlBan3";
            this.pnlBan3.Size = new System.Drawing.Size(523, 131);
            this.pnlBan3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Khu A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Khu B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Khu C";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChiaBan);
            this.panel1.Controls.Add(this.btnHuyBan);
            this.panel1.Controls.Add(this.btnGopBan);
            this.panel1.Location = new System.Drawing.Point(213, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 72);
            this.panel1.TabIndex = 10;
            // 
            // btnChiaBan
            // 
            this.btnChiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiaBan.Location = new System.Drawing.Point(112, 3);
            this.btnChiaBan.Name = "btnChiaBan";
            this.btnChiaBan.Size = new System.Drawing.Size(103, 66);
            this.btnChiaBan.TabIndex = 8;
            this.btnChiaBan.Text = "Chia bàn";
            this.btnChiaBan.UseVisualStyleBackColor = true;
            this.btnChiaBan.Click += new System.EventHandler(this.btnChiaBan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = global::WindowsFormsApp1.Properties.Resources.icons8_refresh_24;
            this.btnRefresh.Location = new System.Drawing.Point(495, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmDanhSachBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1010, 646);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlBan3);
            this.Controls.Add(this.pnlBan2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKhuVuc);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlBan1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDanhSachBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Cafe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDanhSachBan_FormClosing);
            this.Load += new System.EventHandler(this.frmDanhSachBan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvHoaDon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnQuanLy;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbLoai;
        private System.Windows.Forms.ComboBox cbDoU;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Button btnThemDoUong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Panel pnlBan1;
        private System.Windows.Forms.ComboBox cbKhuVuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlBan2;
        private System.Windows.Forms.Panel pnlBan3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHuyBan;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.DataGridView grvHoaDon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaHoaDon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSoBan;
        private System.Windows.Forms.ToolStripMenuItem mnTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnThongTinTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnDangXuat;
        private System.Windows.Forms.Button btnChiaBan;
    }
}