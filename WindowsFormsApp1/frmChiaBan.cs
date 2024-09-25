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
    public partial class frmChiaBan : Form
    {
        public frmChiaBan()
        {
            InitializeComponent();
            cbBanChia.SelectedIndexChanged += cbBanChia_SelectedIndexChanged;
            cbBanChiaDen.SelectedIndexChanged += cbBanChiaDen_SelectedIndexChanged;
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        private Button SelectedBanTach;
        private Button SelectedBanTachDen;
        private List<Button> SelectedBanTachDenList = new List<Button>();
        DataTable table = new DataTable();
        int ban_id;

        private void frmChiaBan_Load(object sender, EventArgs e)
        {
            loadBan();
            loadData(ban_id);
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

        private void loadBan()
        {
            var tables = from kv in db.tbKhuVucs select kv;
            cbBanChia.DataSource = tables.ToList();
            cbBanChia.DisplayMember = "khuvuc_ten";
            cbBanChia.ValueMember = "khuvuc_id";
            cbBanChiaDen.DataSource = tables.ToList();
            cbBanChiaDen.DisplayMember = "khuvuc_ten";
            cbBanChiaDen.ValueMember = "khuvuc_id";
            var danhSachBan = from b in db.tbBans select b;
            int size = 80;
            int padding = 5;
            int xA = 10, yA = 10;
            int xB = 10, yB = 10;
            int counterA = 1;
            int counterB = 1;
            int counterC = 1;
            int counterX = 1;
            int counterY = 1;
            int counterZ = 1;
            foreach (var ban in danhSachBan)
            {
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
                btnBan.Tag = ban.ban_id; 
                btnBan.Click += btnBan_Click;

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
                    pnlBanChia.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChia.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanChia.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChia.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanChia.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChia.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }
            foreach (var ban in danhSachBan)
            {
                Button btnBanB = new Button();
                btnBanB.Width = size;
                btnBanB.Height = size;

                if (ban.khuvuc_id == 1)
                {
                    btnBanB.Text = $"A{counterX}\n{ban.ban_trangthai}";
                    counterX++;
                }
                else if (ban.khuvuc_id == 2)
                {
                    btnBanB.Text = $"B{counterY}\n{ban.ban_trangthai}";
                    counterY++;
                }
                else if (ban.khuvuc_id == 3)
                {
                    btnBanB.Text = $"C{counterZ}\n{ban.ban_trangthai}";
                    counterZ++;
                }
                btnBanB.TextAlign = ContentAlignment.MiddleCenter;
                btnBanB.Tag = ban.ban_id;
                btnBanB.Click += btnBan_Click;

                if (ban.ban_trangthai == "Trống")
                {
                    btnBanB.BackColor = Color.White;
                }

                else if (ban.ban_trangthai == "Có người")
                {
                    btnBanB.BackColor = Color.Cyan;
                }
                if (ban.khuvuc_id == 1)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChiaDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChiaDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChiaDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChiaDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChiaDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChiaDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
        }

        protected void loadData(int banId)
        {
            table.Columns.Add("Sản phẩm", typeof(string));
            table.Columns.Add("Số lượng", typeof(int));
            table.Columns.Add("Đơn giá", typeof(int));
            table.Columns.Add("Thành tiền", typeof(decimal));
            var hoaDonList = from hd in db.tbHoaDons
                             join hdct in db.tbHoaDonChiTiets on hd.hoadon_id equals hdct.hoadon_id
                             join sp in db.tbThanhPhams on hdct.thanhpham_id equals sp.thanhpham_id
                             where hd.ban_id == banId
                             select new
                             {
                                 sp.thanhpham_ten,
                                 hdct.thanhpham_soluong,
                                 sp.thanhpham_dongia,
                                 hoadonchitiet_thanhtien = hdct.thanhpham_soluong * sp.thanhpham_dongia,
                                 hd.hoadon_mahoadon
                             };
            var MaHoaDonData = hoaDonList.FirstOrDefault();
            foreach (var item in hoaDonList)
            {
                DataRow row = table.NewRow();
                row["Tên sản phẩm"] = item.thanhpham_ten;
                row["Đơn giá"] = item.thanhpham_dongia;
                row["Số lượng"] = item.thanhpham_soluong;
                row["Thành tiền"] = item.thanhpham_dongia * item.thanhpham_soluong;
                table.Rows.Add(row);
            }

            grvChonSanPham.DataSource = table;
        }

        private void loadSanPham(int banId)
        {
            grvChonSanPham.DataSource = null;
            grvChonSanPham.Rows.Clear();
            grvChonSanPham.Columns.Clear();
            grvChonSanPham.Refresh();

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "CheckBoxColumn",
                HeaderText = "Chọn",
                Width = 50,
                ReadOnly = false,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
            grvChonSanPham.Columns.Add(checkBoxColumn);
            grvChonSanPham.Columns.Add("thanhpham_id", "Mã sản phẩm");
            grvChonSanPham.Columns["thanhpham_id"].Visible = false;
            grvChonSanPham.Columns.Add("Tên sản phẩm", "Sản phẩm");
            grvChonSanPham.Columns.Add("Số lượng", "Số lượng");
            grvChonSanPham.Columns.Add("Đơn giá", "Đơn giá");
            grvChonSanPham.Columns.Add("Thành tiền", "Thành tiền");

            var hoaDonList = from hd in db.tbHoaDons
                             join hdct in db.tbHoaDonChiTiets on hd.hoadon_id equals hdct.hoadon_id
                             join sp in db.tbThanhPhams on hdct.thanhpham_id equals sp.thanhpham_id
                             where hd.ban_id == banId
                             select new
                             {
                                 sp.thanhpham_id,
                                 sp.thanhpham_ten,
                                 hdct.thanhpham_soluong,
                                 sp.thanhpham_dongia,
                                 hoadonchitiet_thanhtien = hdct.thanhpham_soluong * sp.thanhpham_dongia
                             };

            foreach (var item in hoaDonList)
            {
                int rowIndex = grvChonSanPham.Rows.Add();
                grvChonSanPham.Rows[rowIndex].Cells["Tên sản phẩm"].Value = item.thanhpham_ten;
                grvChonSanPham.Rows[rowIndex].Cells["Số lượng"].Value = item.thanhpham_soluong;
                grvChonSanPham.Rows[rowIndex].Cells["Đơn giá"].Value = item.thanhpham_dongia;
                grvChonSanPham.Rows[rowIndex].Cells["Thành tiền"].Value = item.hoadonchitiet_thanhtien;
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btnBan = sender as Button;
            int banId = (int)btnBan.Tag; // Lấy mã bàn từ thuộc tính Tag
            loadSanPham(banId);
            // Nếu nút này ở flpBanTach (Bàn cần tách)
            if (pnlBanChia.Controls.Contains(btnBan))
            {
                if (btnBan.BackColor == Color.Cyan) // Chỉ có thể chọn bàn có người
                {
                    if (SelectedBanTach != null && SelectedBanTach != btnBan)
                    {
                        SelectedBanTach.BackColor = Color.Cyan; // Trả lại màu gốc nếu chọn bàn khác
                    }

                    btnBan.BackColor = Color.LimeGreen; // Đánh dấu bàn được chọn
                    SelectedBanTach = btnBan;
                    loadSanPham(banId);
                }
            }
            // Nếu nút này ở flpBanTachDen (Bàn đích để tách sang)
            else if (pnlBanChiaDen.Controls.Contains(btnBan))
            {
                if (btnBan.BackColor == Color.White) // Kiểm tra xem có phải bàn trống không
                {
                    if (SelectedBanTachDen != null && SelectedBanTachDen != btnBan)
                    {
                        SelectedBanTachDen.BackColor = Color.White;
                    }

                    btnBan.BackColor = Color.LimeGreen; // Đánh dấu bàn được chọn
                    SelectedBanTachDen = btnBan;
                    loadSanPham(banId);
                }
            }
        }

        private void cbBanChia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanChia.Text == "All")
            {
                var danhSachBan = from ban in db.tbBans select ban;

                pnlBanChia.Controls.Clear();

                int size = 80;
                int padding = 5;
                int x = 10, y = 10;

                int counterA = 1;
                int counterB = 1;
                int counterC = 1;

                foreach (var ban in danhSachBan)
                {
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
                    btnBan.Click += btnBan_Click;

                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBan.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBan.BackColor = Color.Cyan;
                    }

                    btnBan.Location = new Point(x, y);
                    pnlBanChia.Controls.Add(btnBan);

                    x += size + padding;
                    if (x + size > pnlBanChia.Width)
                    {
                        x = 10;
                        y += size + padding;
                    }
                }
            }
            else if (cbBanChia.SelectedValue != null && int.TryParse(cbBanChia.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                pnlBanChia.Controls.Clear();

                int size = 80;
                int padding = 5;
                int xA = 10, yA = 10;

                int counterA = 1;
                int counterB = 1;
                int counterC = 1;

                foreach (var ban in danhSachBanTheoKhuVuc)
                {
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
                    btnBan.Tag = ban.ban_id;
                    btnBan.Click += btnBan_Click;

                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBan.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBan.BackColor = Color.Cyan;
                    }

                    btnBan.Location = new Point(xA, yA);
                    pnlBanChia.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChia.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }
        }

        private void cbBanChiaDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanChiaDen.Text == "All")
            {
                var danhSachBan = from ban in db.tbBans select ban;

                pnlBanChiaDen.Controls.Clear();

                int size = 80;
                int padding = 5;
                int xB = 10, yB = 10;

                int counterX = 1;
                int counterY = 1;
                int counterZ = 1;

                foreach (var ban in danhSachBan)
                {
                    Button btnBanB = new Button();
                    btnBanB.Width = size;
                    btnBanB.Height = size;

                    if (ban.khuvuc_id == 1)
                    {
                        btnBanB.Text = $"A{counterX}\n{ban.ban_trangthai}";
                        counterX++;
                    }
                    else if (ban.khuvuc_id == 2)
                    {
                        btnBanB.Text = $"B{counterY}\n{ban.ban_trangthai}";
                        counterY++;
                    }
                    else if (ban.khuvuc_id == 3)
                    {
                        btnBanB.Text = $"C{counterZ}\n{ban.ban_trangthai}";
                        counterZ++;
                    }

                    btnBanB.TextAlign = ContentAlignment.MiddleCenter;
                    btnBanB.Tag = ban.ban_id;
                    btnBanB.Click += btnBan_Click;

                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBanB.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBanB.BackColor = Color.Cyan;
                        continue;
                    }

                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChiaDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChiaDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
            else if (cbBanChiaDen.SelectedValue != null && int.TryParse(cbBanChiaDen.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                pnlBanChiaDen.Controls.Clear();

                int size = 80;
                int padding = 5;
                int xB = 10, yB = 10;

                int counterX = 1;
                int counterY = 1;
                int counterZ = 1;

                foreach (var ban in danhSachBanTheoKhuVuc)
                {
                    Button btnBanB = new Button();
                    btnBanB.Width = size;
                    btnBanB.Height = size;

                    if (ban.khuvuc_id == 1)
                    {
                        btnBanB.Text = $"A{counterX}\n{ban.ban_trangthai}";
                        counterX++;
                    }
                    else if (ban.khuvuc_id == 2)
                    {
                        btnBanB.Text = $"B{counterY}\n{ban.ban_trangthai}";
                        counterY++;
                    }
                    else if (ban.khuvuc_id == 3)
                    {
                        btnBanB.Text = $"C{counterZ}\n{ban.ban_trangthai}";
                        counterZ++;
                    }

                    btnBanB.TextAlign = ContentAlignment.MiddleCenter;
                    btnBanB.Tag = ban.ban_id;
                    btnBanB.Click += btnBan_Click;

                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBanB.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBanB.BackColor = Color.Cyan;
                    }
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChiaDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChiaDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
        }

        private void grvChonSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvChonSanPham.Columns[e.ColumnIndex].Name == "Thành tiền")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
            else if (grvChonSanPham.Columns[e.ColumnIndex].Name == "Đơn giá")
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnChiaBan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem bàn gốc và bàn mới đã được chọn chưa
            if (SelectedBanTach != null && SelectedBanTachDen != null)
            {
                // Lấy ID của bàn gốc và bàn mới
                int banGocId = (int)SelectedBanTach.Tag; // ID bàn gốc
                int banMoiId = (int)SelectedBanTachDen.Tag; // ID bàn mới

                // Lấy hóa đơn gốc
                var hoaDonGoc = db.tbHoaDons.FirstOrDefault(hd => hd.ban_id == banGocId);
                if (hoaDonGoc != null)
                {
                    // Tạo hóa đơn mới cho bàn mới
                    var hoaDonMoi = new tbHoaDon
                    {
                        hoadon_mahoadon = maTuTang(), // Tạo mã hóa đơn mới
                        ban_id = banMoiId,
                        hoadon_trangthai = 0, // Đặt trạng thái hóa đơn là "đang mở"
                        hoadon_ngaynhap = DateTime.Now
                    };
                    db.tbHoaDons.InsertOnSubmit(hoaDonMoi);
                    db.SubmitChanges(); // Lưu thay đổi để lấy ID của hóa đơn mới

                    // Duyệt qua các dòng sản phẩm đã chọn và chuyển sản phẩm
                    foreach (DataGridViewRow row in grvChonSanPham.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["CheckBoxColumn"].Value);
                        if (isSelected)
                        {
                            // Lấy thông tin chi tiết sản phẩm
                            var sanPhamId = Convert.ToInt32(row.Cells["thanhpham_id"].Value);
                            var sanPhamSoLuong = Convert.ToInt32(row.Cells["Số lượng"].Value);

                            // Tạo chi tiết hóa đơn mới cho bàn mới
                            var chiTietMoi = new tbHoaDonChiTiet
                            {
                                hoadon_id = hoaDonMoi.hoadon_id,
                                thanhpham_id = sanPhamId,
                                thanhpham_soluong = sanPhamSoLuong
                            };
                            db.tbHoaDonChiTiets.InsertOnSubmit(chiTietMoi);

                            // Xóa sản phẩm khỏi hóa đơn gốc
                            var chiTietCu = db.tbHoaDonChiTiets.FirstOrDefault(ct => ct.hoadon_id == hoaDonGoc.hoadon_id && ct.thanhpham_id == sanPhamId);
                            if (chiTietCu != null)
                            {
                                db.tbHoaDonChiTiets.DeleteOnSubmit(chiTietCu);
                            }
                        }
                    }

                    db.SubmitChanges(); // Lưu tất cả các thay đổi

                    // Cập nhật trạng thái của bàn
                    var banGoc = db.tbBans.FirstOrDefault(b => b.ban_id == banGocId);
                    var banMoi = db.tbBans.FirstOrDefault(b => b.ban_id == banMoiId);

                    if (banGoc != null)
                    {
                        // Kiểm tra xem bàn gốc có còn sản phẩm hay không
                        bool conSanPham = db.tbHoaDonChiTiets.Any(ct => ct.hoadon_id == hoaDonGoc.hoadon_id);
                        if (conSanPham)
                        {
                            banGoc.ban_trangthai = "Có người"; // Bàn gốc vẫn còn sản phẩm
                            SelectedBanTach.BackColor = Color.Cyan; 
                        }
                        else
                        {
                            banGoc.ban_trangthai = null; // Bàn gốc không còn sản phẩm
                            SelectedBanTach.BackColor = Color.White; // Đặt màu trắng cho bàn gốc
                            db.tbHoaDons.DeleteOnSubmit(hoaDonGoc); // Xóa hóa đơn gốc nếu hết sản phẩm
                        }
                    }

                    if (banMoi != null)
                    {
                        banMoi.ban_trangthai = "Có người"; // Đặt bàn mới là "có người"
                        SelectedBanTachDen.BackColor = Color.Cyan; 
                    }

                    db.SubmitChanges(); // Lưu các thay đổi

                    // Xóa lựa chọn bàn
                    SelectedBanTach = null;
                    SelectedBanTachDen = null;
                }
            }
            else
            {
                // Hiển thị thông báo nếu chưa chọn đủ bàn
                MessageBox.Show("Chọn 1 bàn có người và 1 bàn trống để tách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
