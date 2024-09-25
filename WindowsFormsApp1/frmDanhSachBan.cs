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
    public partial class frmDanhSachBan : Form
    {
        public frmDanhSachBan(tbTaiKhoan user)
        {
            InitializeComponent();
            currentUser = user;

            if (currentUser.taikhoan_quyen == true)
            {
                mnQuanLy.Enabled = true;  // Admin can access
            }
            else
            {
                mnQuanLy.Enabled = false;  // Non-admins cannot access
            }
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        int selectedBanId;
        DataTable table = new DataTable();
        private Button LuuNut;
        private tbTaiKhoan currentUser;

        private void frmDanhSachBan_Load(object sender, EventArgs e)
        {
            loadBan();
            //loadComboBan();
            loadKhuVuc();
            loadComboLoaiDoUong();
            loadSanPham();
            // Thiết lập các cột cho DataTable
            table.Columns.Add("Tên sản phẩm", typeof(string));
            table.Columns.Add("Số lượng", typeof(int));
            table.Columns.Add("Đơn giá", typeof(decimal));
            table.Columns.Add("Thành tiền", typeof(decimal));
        }

        public string maTuTang()
        {
            string s = "HD";
            int k = 0;
            var checkHoaDon = from hd in db.tbHoaDons select hd;
            if (checkHoaDon.Count() > 0)
            {
                string hoaDon = (from hd in db.tbHoaDons orderby hd.hoadon_mahoadon descending select hd).First().hoadon_mahoadon;
                k = Convert.ToInt32(hoaDon.Substring(2, 4));
                k = k + 1;
                if (k < 10)
                    s = s + "000";
                else if (k < 100)
                    s = s + "00";
                else if (k < 1000)
                    s = s + "0";
                s = s + k.ToString();
            }
            else
            {
                k = k + 1;
                if (k < 10)
                    s = s + "000";
                else if (k < 100)
                    s = s + "00";
                else if (k < 1000)
                    s = s + "0";
                s = s + k.ToString();
            }
            return s;
        }

        private void mnQuanLy_Click(object sender, EventArgs e)
        {
            frmQuanLy ql = new frmQuanLy();
            ql.Show();
        }

        private void mnThongTinTaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan qltk = new frmQuanLyTaiKhoan(currentUser);
            qltk.Show();
        }

        //protected void loadComboBan()
        //{
        //    var getDataLoai = from bn in db.tbBans select bn;
        //    cbBan.DataSource = getDataLoai;
        //    cbBan.DisplayMember = "ban_ten";
        //    cbBan.ValueMember = "ban_id";
        //}

        protected void loadKhuVuc()
        {
            var getDataLoai = from kv in db.tbKhuVucs select kv;
            cbKhuVuc.DataSource = getDataLoai;
            cbKhuVuc.DisplayMember = "khuvuc_ten";
            cbKhuVuc.ValueMember = "khuvuc_id";
        }

        private void loadBan()
        {
            db = new dbcsdlDataContext();

            cbKhuVuc.SelectedIndexChanged += new EventHandler(cbKhuVuc_SelectedIndexChanged);
            // Xóa các control hiện tại trên panel trước khi thêm mới
            pnlBan1.Controls.Clear();
            pnlBan2.Controls.Clear();
            pnlBan3.Controls.Clear();



            // Lấy danh sách các bàn từ cơ sở dữ liệu
            var danhSachBan = from b in db.tbBans select b;

            // Thiết lập kích thước và vị trí ban đầu cho các nút bàn
            int size = 80; // Kích thước nút
            int padding = 5; // Khoảng cách giữa các nút

            // Thiết lập vị trí x, y ban đầu cho mỗi khu vực
            int xA = 10, yA = 10;
            int xB = 10, yB = 10;
            int xC = 10, yC = 10;

            int counterA = 1;
            int counterB = 1;
            int counterC = 1;

            foreach (var ban in danhSachBan)
            {
                // Tạo Button mới cho mỗi bàn
                Button btnBan = new Button();
                btnBan.Width = size;
                btnBan.Height = size;
                if (ban.khuvuc_id == 1)
                {
                    btnBan.Text = $"A{counterA}\n{ban.ban_trangthai}";
                    counterA++;
                }
                else if (ban.khuvuc_id == 2)
                {
                    btnBan.Text = $"B{counterB}\n{ban.ban_trangthai}";
                    counterB++;
                }
                else if (ban.khuvuc_id == 3)
                {
                    btnBan.Text = $"C{counterC}\n{ban.ban_trangthai}";
                    counterC++;
                }
                btnBan.TextAlign = ContentAlignment.MiddleCenter;
                btnBan.Tag = ban.ban_id; // Gán ID của bàn vào thuộc tính Tag
                btnBan.Click += new EventHandler(btnBan_Click);


                // Đặt màu cho bàn dựa trên trạng thái
                if (ban.ban_trangthai == "Trống")
                {
                    btnBan.BackColor = Color.White;
                }
                else if (ban.ban_trangthai == "Có người")
                {
                    btnBan.BackColor = Color.Cyan;
                }

                // Thêm nút bàn vào panel
                if (ban.khuvuc_id == 1)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBan1.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBan1.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                else if (ban.khuvuc_id == 2)
                {
                    btnBan.Location = new Point(xB, yB);
                    pnlBan2.Controls.Add(btnBan);

                    xB += size + padding;
                    if (xB + size > pnlBan2.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                else if (ban.khuvuc_id == 3)
                {
                    btnBan.Location = new Point(xC, yC);
                    pnlBan3.Controls.Add(btnBan);

                    xC += size + padding;
                    if (xC + size > pnlBan3.Width)
                    {
                        xC = 10;
                        yC += size + padding;
                    }
                }
            }
        }

        protected void loadComboLoaiDoUong()
        {
            var getData = from lsp in db.tbLoaiSanPhams select lsp;
            cbLoai.DataSource = getData.ToList();
            cbLoai.DisplayMember = "loaisanpham_ten";
            cbLoai.ValueMember = "loaisanpham_id";

            // Gọi hàm để load sản phẩm theo loại đầu tiên
            if (cbLoai.Items.Count > 0)
            {
                cbLoai.SelectedIndex = 0; // Chọn loại đầu tiên
            }
        }

        protected void loadSanPham()
        {
            var getData = from sp in db.tbThanhPhams select sp;
            cbDoU.DataSource = getData;
            cbDoU.DisplayMember = "thanhpham_ten";
            cbDoU.ValueMember = "thanhpham_id";
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedValue != null && int.TryParse(cbLoai.SelectedValue.ToString(), out int selectedLoaiSanPhamID))
            {
                // Lọc danh sách sản phẩm theo loại sản phẩm đã chọn
                var danhSachSanPhamTheoLoai = from sp in db.tbThanhPhams
                                              where sp.loaisanpham_id == selectedLoaiSanPhamID
                                              select sp;

                var products = danhSachSanPhamTheoLoai.ToList();

                // Kiểm tra xem có sản phẩm nào được tìm thấy không
                if (products.Count > 0)
                {
                    cbDoU.DataSource = products;
                    cbDoU.DisplayMember = "thanhpham_ten";
                    cbDoU.ValueMember = "thanhpham_id";
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào thuộc loại sản phẩm đã chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btnBan = sender as Button;
            LuuNut = btnBan;
            selectedBanId = (int)btnBan.Tag;
            //cbBan.SelectedValue = selectedBanId;
            var tenBan = (from bn in db.tbBans
                          where bn.ban_id == selectedBanId
                          select bn.ban_ten).FirstOrDefault();
            txtSoBan.Text = tenBan.ToString();
            LoadHoaDon(selectedBanId);
        }

        private void LoadHoaDon(int banId)
        {
            table.Clear();
            grvHoaDon.Tag = banId;

            var hoaDon = from hd in db.tbHoaDons
                         join hdct in db.tbHoaDonChiTiets on hd.hoadon_id equals hdct.hoadon_id
                         join tp in db.tbThanhPhams on hdct.thanhpham_id equals tp.thanhpham_id
                         where hd.ban_id == banId
                         select new
                         {
                             tp.thanhpham_ten,
                             hdct.thanhpham_soluong,
                             tp.thanhpham_dongia,
                             hoadonchitiet_thanhtien = hdct.thanhpham_soluong * tp.thanhpham_dongia,
                             hd.hoadon_mahoadon
                         };


            var MaHoaDonData = hoaDon.FirstOrDefault();
            if (MaHoaDonData != null)
            {
                txtMaHoaDon.Text = MaHoaDonData.hoadon_mahoadon;
            }
            else
            {
                txtMaHoaDon.Text = "";
            }
            foreach (var item in hoaDon)
            {
                DataRow row = table.NewRow();
                row["Tên sản phẩm"] = item.thanhpham_ten;
                row["Số lượng"] = item.thanhpham_soluong;
                row["Đơn giá"] = item.thanhpham_dongia;
                row["Thành tiền"] = item.thanhpham_dongia * item.thanhpham_soluong;
                table.Rows.Add(row);
            }

            grvHoaDon.DataSource = table;
            txtTongTien.Text = string.Format("{0:#,##0.##}", TinhTongTien()).Replace(",", ".") + " VNĐ";
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            frmChuyenBan cb = new frmChuyenBan();
            cb.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thanh toán bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                                
                var ban = db.tbBans.SingleOrDefault(b => b.ban_id == selectedBanId);
                if (ban != null && ban.ban_trangthai == "Có người")
                {
                    table.Clear();
                    ban.ban_trangthai = "Trống";
                    var hoaDons = db.tbHoaDons.Where(hd => hd.ban_id == selectedBanId && hd.hoadon_trangthai == 0).ToList();
                    foreach (var hoaDon in hoaDons)
                    {
                        hoaDon.hoadon_trangthai = 1; // Set invoice status to '1' (paid)
                        hoaDon.hoadon_ngayxuat = DateTime.Now;

                        //xóa hóa đơn chi tiết sau khi thanh toán nhưng giữ lại hóa đơn
                        var chiTietHoaDons = db.tbHoaDonChiTiets.Where(ct => ct.hoadon_id == hoaDon.hoadon_id).ToList();
                        db.tbHoaDonChiTiets.DeleteAllOnSubmit(chiTietHoaDons);


                    }
                    txtMaHoaDon.Text = string.Empty;
                    txtTongTien.Text = string.Empty;
                    nmSoLuong.Value = 0;
                    db.SubmitChanges();
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bàn này không có hóa đơn để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                LoadHoaDon(selectedBanId);
                loadBan();
                
                //MessageBox.Show("Không có bàn nào được chọn để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhuVuc.Text == "All")
            {
                loadBan();
            }
            else if (cbKhuVuc.SelectedValue != null && int.TryParse(cbKhuVuc.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                pnlBan1.Controls.Clear();
                pnlBan2.Controls.Clear();
                pnlBan3.Controls.Clear();
                int size = 80;
                int padding = 5;
                int xA = 10, yA = 10;
                int xB = 10, yB = 10;
                int xC = 10, yC = 10;

                int counterA = 1;
                int counterB = 1;
                int counterC = 1;

                foreach (var ban in danhSachBanTheoKhuVuc)
                {
                    // Tạo Button mới cho mỗi bàn
                    Button btnBan = new Button();
                    btnBan.Width = size;
                    btnBan.Height = size;
                    if (ban.khuvuc_id == 1)
                    {
                        btnBan.Text = $"A{counterA}\n{ban.ban_trangthai}";
                        counterA++;
                    }
                    else if (ban.khuvuc_id == 2)
                    {
                        btnBan.Text = $"B{counterB}\n{ban.ban_trangthai}";
                        counterB++;
                    }
                    else if (ban.khuvuc_id == 3)
                    {
                        btnBan.Text = $"C{counterC}\n{ban.ban_trangthai}";
                        counterC++;
                    }
                    btnBan.TextAlign = ContentAlignment.MiddleCenter;
                    btnBan.Tag = ban.ban_id; // Gán ID của bàn vào thuộc tính Tag
                    btnBan.Click += new EventHandler(btnBan_Click);

                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBan.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBan.BackColor = Color.Cyan;
                    }

                    if (ban.khuvuc_id == 1)
                    {
                        btnBan.Location = new Point(xA, yA);
                        pnlBan1.Controls.Add(btnBan);

                        xA += size + padding;
                        if (xA + size > pnlBan1.Width)
                        {
                            xA = 10;
                            yA += size + padding;
                        }
                    }
                    else if (ban.khuvuc_id == 2)
                    {
                        btnBan.Location = new Point(xB, yB);
                        pnlBan2.Controls.Add(btnBan);

                        xB += size + padding;
                        if (xB + size > pnlBan2.Width)
                        {
                            xB = 10;
                            yB += size + padding;
                        }
                    }
                    else if (ban.khuvuc_id == 3)
                    {
                        btnBan.Location = new Point(xC, yC);
                        pnlBan3.Controls.Add(btnBan);

                        xC += size + padding;
                        if (xC + size > pnlBan3.Width)
                        {
                            xC = 10;
                            yC += size + padding;
                        }
                    }
                }
            }
        }

        private void btnThemDoUong_Click(object sender, EventArgs e)
        {
            if (cbLoai.SelectedValue != null)
            {
                int soLuong = (int)nmSoLuong.Value;

                // Kiểm tra nếu số lượng là 0
                if (soLuong == 0)
                {
                    MessageBox.Show("Số lượng không thể bằng 0. Vui lòng nhập số lượng hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại và không thêm món
                }

                int sanPhamId = (int)cbDoU.SelectedValue;
                var sanPham = db.tbThanhPhams.FirstOrDefault(sp => sp.thanhpham_id == sanPhamId);

                if (sanPham != null)
                {
                    // Tính toán thành tiền
                    decimal thanhTien = (decimal)(sanPham.thanhpham_dongia * soLuong);

                    // Lấy hóa đơn hiện tại của bàn
                    var hoaDonHienTai = db.tbHoaDons.FirstOrDefault(hd => hd.ban_id == selectedBanId && hd.hoadon_trangthai == 0);

                    if (hoaDonHienTai == null)
                    {
                        // Nếu chưa có hóa đơn, tạo mới hóa đơn
                        hoaDonHienTai = new tbHoaDon
                        {
                            ban_id = selectedBanId,
                            hoadon_trangthai = 0,
                            hoadon_ngaynhap = DateTime.Now,
                            hoadon_mahoadon = maTuTang(),
                            hoadon_tongtien = thanhTien
                            // Các thuộc tính khác nếu cần
                        };
                        db.tbHoaDons.InsertOnSubmit(hoaDonHienTai);
                        db.SubmitChanges();
                    }
                    else
                    {
                        // Nếu hóa đơn đã tồn tại, cập nhật tổng tiền
                        hoaDonHienTai.hoadon_tongtien += thanhTien; // Cộng thêm thành tiền của món mới
                        db.SubmitChanges();
                    }

                    // Thêm món vào chi tiết hóa đơn
                    var chiTietMoi = new tbHoaDonChiTiet
                    {
                        hoadon_id = hoaDonHienTai.hoadon_id,
                        thanhpham_id = sanPham.thanhpham_id,
                        thanhpham_soluong = soLuong,
                        ban_id = selectedBanId,
                        // Các thuộc tính khác nếu cần
                    };
                    db.tbHoaDonChiTiets.InsertOnSubmit(chiTietMoi);
                    db.SubmitChanges();

                    // Cập nhật lại ListView
                    LoadHoaDon(selectedBanId);

                    // Cập nhật trạng thái bàn
                    var ban = db.tbBans.FirstOrDefault(b => b.ban_id == selectedBanId);
                    if (ban != null)
                    {
                        ban.ban_trangthai = "Có người"; // Thay đổi trạng thái bàn
                        db.SubmitChanges();
                        LoadHoaDon(selectedBanId);
                        loadBan();
                    }
                    nmSoLuong.Value = 1;
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }   

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hủy bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                var ban = db.tbBans.SingleOrDefault(b => b.ban_id == selectedBanId);
                if (ban != null && ban.ban_trangthai == "Có người")
                {
                    var hoaDons = db.tbHoaDons.Where(hd => hd.ban_id == selectedBanId && hd.hoadon_trangthai == 0).ToList();
                    foreach (var hoaDon in hoaDons)
                    {
                        // Xóa chi tiết hóa đơn trước khi xóa hóa đơn
                        var chiTietHoaDons = db.tbHoaDonChiTiets.Where(ct => ct.hoadon_id == hoaDon.hoadon_id).ToList();
                        db.tbHoaDonChiTiets.DeleteAllOnSubmit(chiTietHoaDons);

                        // Xóa hóa đơn
                        db.tbHoaDons.DeleteOnSubmit(hoaDon);
                    }

                    table.Clear(); 
                    ban.ban_trangthai = "Trống";
                    txtMaHoaDon.Text = string.Empty;
                    txtTongTien.Text = string.Empty;
                    nmSoLuong.Value = 0;
                    db.SubmitChanges();
                    MessageBox.Show("Hủy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chọn bàn cần hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                loadBan();
            }
        }

        private void grvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == grvHoaDon.Columns["Số lượng"].Index || e.ColumnIndex == grvHoaDon.Columns["Đơn giá"].Index))
            {
                DataGridViewRow row = grvHoaDon.Rows[e.RowIndex];

                decimal donGia = Convert.ToDecimal(row.Cells["Đơn giá"].Value ?? 0);
                int soLuong = Convert.ToInt32(row.Cells["Số lượng"].Value ?? 0);
                decimal thanhTien = donGia * soLuong;

                row.Cells["Thành tiền"].Value = thanhTien;
            }
        }

        private void grvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvHoaDon.Columns[e.ColumnIndex].Name == "Thành tiền")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
            else if(grvHoaDon.Columns[e.ColumnIndex].Name == "Đơn giá")
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".");
                    e.FormattingApplied = true;
                }
            }
        }

        private int TinhTongTien()
        {
            int tongTien = 0;
            foreach (DataRow row in table.Rows)
            {
                tongTien += Convert.ToInt32(row["Thành tiền"]);
            }
            return tongTien;
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            frmGopBan gb = new frmGopBan();
            gb.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadBan();
        }

        private void mnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Close the main form and open the login form
                this.Hide(); // Hide the current form
                frmDangNhap dn = new frmDangNhap();
                dn.Show();
                currentUser = null;
            }
        }

        private void frmDanhSachBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnChiaBan_Click(object sender, EventArgs e)
        {
            frmChiaBan cb = new frmChiaBan();
            cb.Show();
        }
    }
}
