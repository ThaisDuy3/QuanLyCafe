using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmQuanLy : Form
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        int id_loaisanpham;
        int id_sanpham;
        int id_ban;
        int id_nguyenlieu;
        string madonhang;

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            loadLoaiSanPham();
            loadSanPham();
            loadBan();
            loadNguyenLieu();
            loadComboSanPham();
            loadComboTrangThaiBan();
            loadKhuVucBan();
            btnSuaLoaiDoUong.Enabled = false;
            btnXoaLoaiDoUong.Enabled = false;
            btnSuaDoUong.Enabled = false;
            btnXoaDoUong.Enabled = false;
            btnSuaBan.Enabled = false;
            btnXoaBan.Enabled = false;
            txtTenBan.Text = soBanTuTang();
        }
        
        protected void loadLoaiSanPham()
        {
            var getData = from lsp in db.tbLoaiSanPhams orderby lsp.loaisanpham_id descending select
                          new
                          {
                              lsp.loaisanpham_id,
                              lsp.loaisanpham_ten
                          };
            grvDanhSachLoaiDoUong.DataSource = getData;
            grvDanhSachLoaiDoUong.Columns["loaisanpham_id"].HeaderText = "ID loại";
            grvDanhSachLoaiDoUong.Columns["loaisanpham_ten"].HeaderText = "Tên loại";         
        }

        protected void loadSanPham()
        {
            var getData = from sp in db.tbThanhPhams orderby sp.thanhpham_id descending select
                          new {
                              sp.thanhpham_id,
                              sp.loaisanpham_id,
                              sp.loaisanpham_ten,
                              sp.thanhpham_ten,
                              sp.thanhpham_soluong,
                              sp.thanhpham_dongia
                          };
            grvDanhSachDoUong.DataSource = getData;
            grvDanhSachDoUong.Columns["thanhpham_id"].HeaderText = "ID";
            grvDanhSachDoUong.Columns["loaisanpham_id"].HeaderText = "ID loại";
            grvDanhSachDoUong.Columns["loaisanpham_ten"].HeaderText = "Tên loại";
            grvDanhSachDoUong.Columns["thanhpham_ten"].HeaderText = "Tên đồ uống";
            grvDanhSachDoUong.Columns["thanhpham_soluong"].HeaderText = "Số lượng";
            grvDanhSachDoUong.Columns["thanhpham_dongia"].HeaderText = "Đơn giá";

            grvDanhSachDoUong.Columns["loaisanpham_id"].Visible = false;
        }

        protected void loadBan()
        {
            var getData = from ban in db.tbBans orderby ban.ban_id descending select 
                          new
                          {
                              ban.ban_id,
                              ban.ban_ten,
                              ban.ban_trangthai,
                              ban.khuvuc_id,
                              ban.khuvuc_ten
                          };
            grvDanhSachBan.DataSource = getData;
            grvDanhSachBan.Columns["ban_id"].HeaderText = "ID bàn";
            grvDanhSachBan.Columns["ban_ten"].HeaderText = "Tên bàn";
            grvDanhSachBan.Columns["ban_trangthai"].HeaderText = "Trạng thái";
            grvDanhSachBan.Columns["khuvuc_ten"].HeaderText = "Khu vực";
            grvDanhSachBan.Columns["khuvuc_id"].Visible = false;
        }

        protected void loadNguyenLieu()
        {
            var getData = from nl in db.tbNguyenLieus
                          orderby nl.nguyenlieu_id descending
                          select
                                new
                                {
                                    nl.nguyenlieu_id,
                                    nl.nguyenlieu_ten,
                                    nl.nguyenlieu_nhacungcap
                                };
            grvNguyenLieu.DataSource = getData;
            grvNguyenLieu.Columns["nguyenlieu_id"].HeaderText = "ID";
            grvNguyenLieu.Columns["nguyenlieu_ten"].HeaderText = "Tên nguyên liệu";
            grvNguyenLieu.Columns["nguyenlieu_nhacungcap"].HeaderText = "Nhà cung cấp";
        }

        protected void loadComboSanPham()
        {
            var getDataLoai = from lsp in db.tbLoaiSanPhams select lsp;
            cbDoUongLoai.DataSource = getDataLoai;
            cbDoUongLoai.DisplayMember = "loaisanpham_ten";
            cbDoUongLoai.ValueMember = "loaisanpham_id";
        }

        protected void loadComboTrangThaiBan()
        {
            cbTrangThaiBan.Items.Clear();
            cbTrangThaiBan.Items.Add("Trống");
            cbTrangThaiBan.Items.Add("Có người");
        }

        public string soBanTuTang()
        {
            // Kiem tra ma hoa don cuoi cung trong database
            string s = "Bàn số ";
            int k = 0;
            var checkSoBan = from sb in db.tbBans select sb;
            if (checkSoBan.Count() > 0)
            {
                string tenBan = (from tb in db.tbBans orderby tb.ban_ten descending select tb).First().ban_ten;
                k = Convert.ToInt32(tenBan.Substring(7, 2));
                k = k + 1;
                if (k < 10)
                    s = s + "0";
                else if (k > 10 && k < 100)
                    s = s + "";
                s = s + k.ToString();
            }
            else
            {
                k = k + 1;
                if (k < 10)
                    s = s + "0";
                else if (k > 10 && k < 100)
                    s = s + "";
                s = s + k.ToString();
            }
            return s;
        }

        protected void loadKhuVucBan()
        {
            var getDataLoai = from kv in db.tbKhuVucs select kv;
            cbKhuVucBan.DataSource = getDataLoai;
            cbKhuVucBan.DisplayMember = "khuvuc_ten";
            cbKhuVucBan.ValueMember = "khuvuc_id";
        }

        //LOẠI SẢN PHẨM
        private void grvDanhSachLoaiDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tenlsp = grvDanhSachLoaiDoUong.CurrentRow.Cells["loaisanpham_ten"].Value.ToString();
            txtLoaiDoUongTen.Text = tenlsp;
            id_loaisanpham = Convert.ToInt32(grvDanhSachLoaiDoUong.CurrentRow.Cells["loaisanpham_id"].Value);
            txtLoaiDoUongId.Text = id_loaisanpham.ToString();
            btnThemLoaiDoUong.Enabled = false;
            btnSuaLoaiDoUong.Enabled = true;
            btnXoaLoaiDoUong.Enabled = true;
        }

        private void btnRefreshLoaiDoUong_Click(object sender, EventArgs e)
        {
            btnThemLoaiDoUong.Enabled = true;
            btnSuaLoaiDoUong.Enabled = false;
            btnXoaLoaiDoUong.Enabled = false;

            txtLoaiDoUongId.Text = string.Empty;
            txtLoaiDoUongTen.Text = string.Empty;

            loadLoaiSanPham();
        }

        private void btnThemLoaiDoUong_Click(object sender, EventArgs e)
        {
            tbLoaiSanPham ins = new tbLoaiSanPham();
            ins.loaisanpham_ten = txtLoaiDoUongTen.Text;
            var check = from lsp in db.tbLoaiSanPhams where lsp.loaisanpham_ten == txtLoaiDoUongTen.Text select lsp;
            if (txtLoaiDoUongTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check.Count() > 0)
            {
                MessageBox.Show("Dữ liệu trùng, nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLoaiDoUongTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Không được nhập số, vui lòng nhập chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                db.tbLoaiSanPhams.InsertOnSubmit(ins);
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadLoaiSanPham();
            }
        }

        private void btnSuaLoaiDoUong_Click(object sender, EventArgs e)
        {
            tbLoaiSanPham upd = (from lsp in db.tbLoaiSanPhams where lsp.loaisanpham_id == id_loaisanpham select lsp).FirstOrDefault();
            if (txtLoaiDoUongTen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (upd == null)
            {
                MessageBox.Show("Error X_X", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLoaiDoUongTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Không được nhập số, vui lòng nhập chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                upd.loaisanpham_ten = txtLoaiDoUongTen.Text;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiDoUongId.Text = string.Empty;
                txtLoaiDoUongTen.Text = string.Empty;
                loadLoaiSanPham();
            }
        }

        private void btnXoaLoaiDoUong_Click(object sender, EventArgs e)
        {
            tbLoaiSanPham del = (from lsp in db.tbLoaiSanPhams where lsp.loaisanpham_id == id_loaisanpham select lsp).FirstOrDefault();
            if (del == null)
            {
                MessageBox.Show("Chọn dữ liệu cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                db.tbLoaiSanPhams.DeleteOnSubmit(del);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiDoUongId.Text = string.Empty;
                txtLoaiDoUongTen.Text = string.Empty;
                loadLoaiSanPham();
            }
        }


        //SẢN PHẨM
        private void grvDanhSachDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tensp = grvDanhSachDoUong.CurrentRow.Cells["thanhpham_ten"].Value.ToString();
            txtDoUongTen.Text = tensp;
            id_sanpham = Convert.ToInt32(grvDanhSachDoUong.CurrentRow.Cells["thanhpham_id"].Value);
            txtDoUongID.Text = id_sanpham.ToString();
            int loaiSanPhamId = Convert.ToInt32(grvDanhSachDoUong.CurrentRow.Cells["loaisanpham_id"].Value);
            cbDoUongLoai.SelectedValue = loaiSanPhamId;
            decimal dongia = Convert.ToDecimal(grvDanhSachDoUong.CurrentRow.Cells["thanhpham_dongia"].Value);
            txtDonGia.Text = dongia.ToString();
            int sl = Convert.ToInt32(grvDanhSachDoUong.CurrentRow.Cells["thanhpham_soluong"].Value);
            nmSoLuong.Value = sl;
            btnThemDoUong.Enabled = false;
            btnSuaDoUong.Enabled = true;
            btnXoaDoUong.Enabled = true;
        }

        private void btnRefreshDoUong_Click(object sender, EventArgs e)
        {
            btnThemDoUong.Enabled = true;
            btnSuaDoUong.Enabled = false;
            btnXoaDoUong.Enabled = false;

            txtDoUongID.Text = string.Empty;
            txtDoUongTen.Text = string.Empty;
            txtDonGia.Text = string.Empty;
            cbDoUongLoai.SelectedIndex = -1;  // Clears the selection in the ComboBox
            nmSoLuong.Value = 1;  // Sets the NumericUpDown to 0 or any other default value

            loadSanPham();
        }

        private void btnThemDoUong_Click(object sender, EventArgs e)
        {
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            tbThanhPham ins = new tbThanhPham();
            ins.thanhpham_ten = txtDoUongTen.Text;
            var check = from lsp in db.tbThanhPhams where lsp.thanhpham_ten == txtDoUongTen.Text select lsp;
            if (txtDoUongTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check.Count() > 0)
            {
                MessageBox.Show("Dữ liệu trùng, nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDoUongTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Không được nhập số, vui lòng nhập chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ins.loaisanpham_id = Convert.ToInt32(cbDoUongLoai.SelectedValue);
                ins.loaisanpham_ten = cbDoUongLoai.Text;
                ins.thanhpham_soluong = (int)nmSoLuong.Value;
                ins.thanhpham_dongia = donGia;
                db.tbThanhPhams.InsertOnSubmit(ins);
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadSanPham();
            }
        }

        private void btnSuaDoUong_Click(object sender, EventArgs e)
        {
            decimal donGia = Convert.ToDecimal(txtDonGia.Text);

            tbThanhPham upd = (from lsp in db.tbThanhPhams where lsp.thanhpham_id == id_sanpham select lsp).FirstOrDefault();
            if (txtDoUongTen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (upd == null)
            {
                MessageBox.Show("Error X_X", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDoUongTen.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Không được nhập số, vui lòng nhập chữ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                upd.thanhpham_ten = txtDoUongTen.Text;
                upd.loaisanpham_id = Convert.ToInt32(cbDoUongLoai.SelectedValue);
                upd.loaisanpham_ten = cbDoUongLoai.Text;
                upd.thanhpham_soluong = (int)nmSoLuong.Value;
                upd.thanhpham_dongia = donGia;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoUongID.Text = string.Empty;
                txtDoUongTen.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                cbDoUongLoai.SelectedIndex = -1;  // Clears the selection in the ComboBox
                nmSoLuong.Value = 1;  // Sets the NumericUpDown to 0 or any other default value
                loadSanPham();
            }
        }

        private void btnXoaDoUong_Click(object sender, EventArgs e)
        {
            tbThanhPham del = (from lsp in db.tbThanhPhams where lsp.thanhpham_id == id_sanpham select lsp).FirstOrDefault();
            if (del == null)
            {
                MessageBox.Show("Chọn dữ liệu cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                db.tbThanhPhams.DeleteOnSubmit(del);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoUongID.Text = string.Empty;
                txtDoUongTen.Text = string.Empty;
                txtDonGia.Text = string.Empty;
                cbDoUongLoai.SelectedIndex = -1;  // Clears the selection in the ComboBox
                nmSoLuong.Value = 1;  // Sets the NumericUpDown to 0 or any other default value
                loadSanPham();
            }
        }

        private void grvDanhSachDoUong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvDanhSachDoUong.Columns[e.ColumnIndex].Name == "thanhpham_dongia")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".");
                    e.FormattingApplied = true;
                }
            }
        }

        //BÀN   
        private void grvDanhSachBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tenban = grvDanhSachBan.CurrentRow.Cells["ban_ten"].Value.ToString();
            txtTenBan.Text = tenban;
            id_ban = Convert.ToInt32(grvDanhSachBan.CurrentRow.Cells["ban_id"].Value);
            txtBanID.Text = id_ban.ToString();
            string trangthaiban = grvDanhSachBan.CurrentRow.Cells["ban_trangthai"].Value.ToString();
            cbTrangThaiBan.SelectedItem = trangthaiban;
            int khuvucid = Convert.ToInt32(grvDanhSachBan.CurrentRow.Cells["khuvuc_id"].Value);
            cbKhuVucBan.SelectedValue = khuvucid;
            btnThemBan.Enabled = false;
            btnSuaBan.Enabled = true;
            btnXoaBan.Enabled = true;
        }

        private void btnRefreshBan_Click(object sender, EventArgs e)
        {
            btnThemBan.Enabled = true;
            btnSuaBan.Enabled = false;
            btnXoaBan.Enabled = false;

            txtBanID.Text = string.Empty;
            txtTenBan.Text = string.Empty;
            cbTrangThaiBan.SelectedIndex = -1;
            cbKhuVucBan.SelectedIndex = -1;

            loadBan();
            txtTenBan.Text = soBanTuTang();
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            tbBan ins = new tbBan();
            ins.ban_ten = txtTenBan.Text;
            var check = from ban in db.tbBans where ban.ban_ten == txtTenBan.Text select ban;
            if (txtTenBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (check.Count() > 0)
            {
                MessageBox.Show("Dữ liệu trùng, nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ins.ban_id = Convert.ToInt32(cbTrangThaiBan.SelectedValue);
                ins.ban_trangthai = cbTrangThaiBan.Text;
                ins.khuvuc_id = Convert.ToInt32(cbKhuVucBan.SelectedValue);
                ins.khuvuc_ten = cbKhuVucBan.Text;
                db.tbBans.InsertOnSubmit(ins);
                db.SubmitChanges();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadBan();
                txtTenBan.Text = soBanTuTang();
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            tbBan upd = (from ban in db.tbBans where ban.ban_id == id_ban select ban).FirstOrDefault();
            if (txtTenBan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (upd == null)
            {
                MessageBox.Show("Error X_X", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                upd.ban_ten = txtTenBan.Text;
                upd.ban_trangthai = cbTrangThaiBan.Text;
                upd.khuvuc_ten = cbKhuVucBan.Text;
                db.SubmitChanges();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBanID.Text = string.Empty;
                txtTenBan.Text = string.Empty;
                cbTrangThaiBan.SelectedIndex = -1;
                cbKhuVucBan.SelectedIndex = -1;
                loadBan();
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            tbBan del = (from ban in db.tbBans where ban.ban_id == id_ban select ban).FirstOrDefault();
            if (del == null)
            {
                MessageBox.Show("Chọn dữ liệu cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                db.tbBans.DeleteOnSubmit(del);
                db.SubmitChanges();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBanID.Text = string.Empty;
                txtTenBan.Text = string.Empty;
                cbTrangThaiBan.SelectedIndex = -1;
                cbKhuVucBan.SelectedIndex = -1;
                loadBan();
            }
        }

        //THỐNG KÊ
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Get selected date range
            DateTime tuNgay = dtTuNgay.Value.Date;
            DateTime denNgay = dtDenNgay.Value.Date;

            // Query to filter by date range and status
            var getData = from hd in db.tbHoaDons
                          join ban in db.tbBans on hd.ban_id equals ban.ban_id
                          where hd.hoadon_trangthai == 1 &&
                                hd.hoadon_ngaynhap >= tuNgay &&
                                hd.hoadon_ngaynhap <= denNgay
                          orderby hd.hoadon_id descending
                          select new
                          {
                              hd.hoadon_id,
                              ban.ban_ten,
                              hd.hoadon_tongtien,
                              hd.hoadon_ngaynhap,
                              hd.hoadon_ngayxuat
                          };

            // Set the data source for the DataGridView
            grvBangDoanhThu.DataSource = getData.ToList();

            // Update column headers
            grvBangDoanhThu.Columns["ban_ten"].HeaderText = "Bàn";
            grvBangDoanhThu.Columns["hoadon_tongtien"].HeaderText = "Tổng tiền";
            grvBangDoanhThu.Columns["hoadon_ngaynhap"].HeaderText = "Ngày nhập";
            grvBangDoanhThu.Columns["hoadon_ngayxuat"].HeaderText = "Ngày xuất";

            // Hide the 'hoadon_id' column
            grvBangDoanhThu.Columns["hoadon_id"].Visible = false;
        }

        private void grvBangDoanhThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvBangDoanhThu.Columns[e.ColumnIndex].Name == "hoadon_tongtien")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnThongKeDonNhap_Click(object sender, EventArgs e)
        {
            DateTime ngayNhap = dtNgayNhapHang.Value.Date;

            var getData = from dnh in db.tbNhapHangs
                          where dnh.nhaphang_ngaynhap <= ngayNhap
                          orderby dnh.nhaphang_id descending
                          select dnh;

            grvDonNhapHang.DataSource = getData.ToList();
            grvDonNhapHang.Columns["nhaphang_id"].HeaderText = "Mã đơn hàng";
            grvDonNhapHang.Columns["nhaphang_ngaynhap"].HeaderText = "Ngày nhập";
            grvDonNhapHang.Columns["nhaphang_tongtien"].HeaderText = "Tổng tiền";
        }

        private void grvDonNhapHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvDonNhapHang.Columns[e.ColumnIndex].Name == "nhaphang_tongtien")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void grvDonNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //madonhang = grvDonNhapHang.CurrentRow.Cells["nhaphang_id"].Value.ToString();
        }

        private void btnChiTietDonNhapHang_Click(object sender, EventArgs e)
        {
            string maDonHang = grvDonNhapHang.CurrentRow.Cells["nhaphang_id"].Value.ToString();

            // Khởi tạo và truyền mã đơn hàng vào form chi tiết
            frmChiTietDonNhap ctdnh = new frmChiTietDonNhap(maDonHang);
            ctdnh.ShowDialog();
        }


        //NGUYÊN LIỆU
        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            frmNhapHang nh = new frmNhapHang();
            nh.Show();
        }

        private void grvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tennl = grvNguyenLieu.CurrentRow.Cells["nguyenlieu_ten"].Value.ToString();
            txtTenNguyenLieu.Text = tennl;
            id_nguyenlieu = Convert.ToInt32(grvNguyenLieu.CurrentRow.Cells["nguyenlieu_id"].Value);
            txtNguyenLieuID.Text = id_nguyenlieu.ToString();
            string ncc = grvNguyenLieu.CurrentRow.Cells["nguyenlieu_nhacungcap"].Value.ToString();
            txtNguyenLieuNhaCungCap.Text = ncc;
            btnThemDonHang.Enabled = false;
            btnXoaNguyenLieu.Enabled = true;
        }

        private void btnRefreshNguyenLieu_Click(object sender, EventArgs e)
        {
            btnThemDonHang.Enabled = true;
            btnXoaNguyenLieu.Enabled = false;

            txtNguyenLieuID.Text = string.Empty;
            txtTenNguyenLieu.Text = string.Empty;
            txtNguyenLieuNhaCungCap.Text = string.Empty;

            loadNguyenLieu();
        }
    }
}
