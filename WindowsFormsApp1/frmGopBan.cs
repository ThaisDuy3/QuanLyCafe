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
    public partial class frmGopBan : Form
    {
        public frmGopBan()
        {
            InitializeComponent();
            cbBanGop.SelectedIndexChanged += cbBanGop_SelectedIndexChanged;
            cbBanGopDen.SelectedIndexChanged += cbBanGopDen_SelectedIndexChanged;
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        private Button SelectedBanGop;
        private Button SelectedBanGopDen;
        private List<Button> SelectedBanGopList = new List<Button>();
        private List<Button> SelectedBanGopDenList = new List<Button>();

        private void frmGopBan_Load(object sender, EventArgs e)
        {
            loadBan();
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
            // Load tables into the ComboBox
            var tables = from kv in db.tbKhuVucs select kv;
            cbBanGop.DataSource = tables.ToList();
            cbBanGop.DisplayMember = "khuvuc_ten";
            cbBanGop.ValueMember = "khuvuc_id";
            cbBanGopDen.DataSource = tables.ToList();
            cbBanGopDen.DisplayMember = "khuvuc_ten";
            cbBanGopDen.ValueMember = "khuvuc_id";
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
                btnBan.Click += btnBan_Click;

                // Đặt màu cho bàn dựa trên trạng thái
                if (ban.ban_trangthai == "Trống")
                {
                    btnBan.BackColor = Color.White;
                }
                else if (ban.ban_trangthai == "Có người")
                {
                    btnBan.BackColor = Color.Cyan;

                }
                // Đặt vị trí của nút bàn và thêm vào panel phù hợp
                if (ban.khuvuc_id == 1)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanGop.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanGop.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanGop.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanGop.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanGop.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanGop.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }
            foreach (var ban in danhSachBan)
            {

                // Tạo Button mới cho mỗi bàn
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
                btnBanB.Tag = ban.ban_id; // Gán ID của bàn vào thuộc tính Tag
                btnBanB.Click += btnBan_Click;

                // Đặt màu cho bàn dựa trên trạng thái
                if (ban.ban_trangthai == "Trống")
                {
                    btnBanB.BackColor = Color.White;
                }

                else if (ban.ban_trangthai == "Có người")
                {
                    btnBanB.BackColor = Color.Cyan;
                    continue;
                }
                // Đặt vị trí của nút bàn và thêm vào panel phù hợp
                if (ban.khuvuc_id == 1)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanGopDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanGopDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanGopDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanGopDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanGopDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanGopDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            Button btnBan = sender as Button;

            // Kiểm tra nếu nút này nằm trong flpBanGop
            if (pnlBanGop.Controls.Contains(btnBan))
            {
                if (btnBan.BackColor == Color.Cyan) // Kiểm tra xem có phải bàn có người không
                {
                    if (SelectedBanGopList.Contains(btnBan)) // Nếu bàn đã được chọn thì bỏ chọn
                    {
                        btnBan.BackColor = Color.Cyan;
                        SelectedBanGopList.Remove(btnBan); // Loại bỏ khỏi danh sách
                    }
                    else // Nếu bàn chưa được chọn thì chọn nó
                    {
                        btnBan.BackColor = Color.LimeGreen;
                        SelectedBanGopList.Add(btnBan); // Thêm bàn vào danh sách được chọn

                    }
                }
            }
            // Kiểm tra nếu nút này nằm trong flpBanGopDen
            else if (pnlBanGopDen.Controls.Contains(btnBan)) // Nếu nút này ở flpBanChuyenDen
            {
                if (SelectedBanGopList.Count < 2)
                {
                    MessageBox.Show("Chọn 2 bàn để gộp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Dừng lại nếu chưa chọn đủ 2 bàn
                }

                // Nếu đã chọn đủ 2 bàn, tiếp tục xử lý
                if (SelectedBanGopDen != null && SelectedBanGopDen != btnBan)
                {
                    // Giữ nguyên màu xám nếu bàn đã có người
                    if (SelectedBanGopDen.BackColor != Color.Cyan)
                    {
                        SelectedBanGopDen.BackColor = Color.White; // Chỉ thay đổi màu nếu bàn trống
                    }
                }

                btnBan.BackColor = Color.LimeGreen; // Đánh dấu bàn mới được chọn
                SelectedBanGopDen = btnBan;
            }
        }

        private void cbBanGop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanGop.Text == "All")
            {
                var danhSachBan = from ban in db.tbBans select ban;

                pnlBanGop.Controls.Clear();

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
                    pnlBanGop.Controls.Add(btnBan);

                    x += size + padding;
                    if (x + size > pnlBanGop.Width)
                    {
                        x = 10;
                        y += size + padding;
                    }
                }
            }
            else if (cbBanGop.SelectedValue != null && int.TryParse(cbBanGop.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                pnlBanGop.Controls.Clear();

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
                    pnlBanGop.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanGop.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }
        }

        private void cbBanGopDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanGopDen.Text == "All")
            {
                var danhSachBan = from ban in db.tbBans select ban;

                pnlBanGopDen.Controls.Clear();

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
                    pnlBanGopDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanGopDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
            else if (cbBanGopDen.SelectedValue != null && int.TryParse(cbBanGopDen.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                pnlBanGopDen.Controls.Clear();

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
                    pnlBanGopDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanGopDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn gộp bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (SelectedBanGopList.Count >= 2 && SelectedBanGopDen != null)
                {
                    decimal tongTien = 0;

                    var newHoaDon = new tbHoaDon
                    {
                        ban_id = (int)SelectedBanGopDen.Tag,
                        hoadon_trangthai = 0,
                        hoadon_ngaynhap = DateTime.Now,
                        hoadon_mahoadon = maTuTang(),
                        hoadon_tongtien = 0
                    };
                    db.tbHoaDons.InsertOnSubmit(newHoaDon);
                    db.SubmitChanges();

                    int newHoaDonId = newHoaDon.hoadon_id;

                    foreach (Button selectedBan in SelectedBanGopList)
                    {
                        int banGopID = (int)selectedBan.Tag;
                        int banGopDenID = (int)SelectedBanGopDen.Tag;

                        var banGop = db.tbBans.SingleOrDefault(b => b.ban_id == banGopID);
                        var banGopDen = db.tbBans.SingleOrDefault(b => b.ban_id == banGopDenID);

                        if (banGop != null && banGopDen != null)
                        {
                            // Kiểm tra nếu bàn đang gộp trùng với bàn nhận gộp
                            if (banGopID == banGopDenID)
                            {
                                // Gộp các chi tiết hóa đơn vào hóa đơn hiện tại (không xóa hóa đơn gốc)
                                var hoaDonsOnBanGop = db.tbHoaDons.Where(hd => hd.ban_id == banGopID && hd.hoadon_trangthai == 0).ToList();

                                foreach (var hoaDon in hoaDonsOnBanGop)
                                {
                                    tongTien += hoaDon.hoadon_tongtien ?? 0;

                                    var chiTietHoaDons = db.tbHoaDonChiTiets.Where(ct => ct.hoadon_id == hoaDon.hoadon_id).ToList();
                                    foreach (var chiTiet in chiTietHoaDons)
                                    {
                                        chiTiet.hoadon_id = newHoaDonId;  // Chuyển chi tiết sang hóa đơn mới
                                    }
                                    // Nếu hóa đơn là của bàn gộp và cũng là bàn nhận gộp, xóa hóa đơn gốc
                                }
                            }
                            else
                            {
                                // Nếu bàn không trùng, tiếp tục xử lý như bình thường
                                banGop.ban_trangthai = "Trống";  // Bàn cũ (được gộp) không còn sử dụng
                                banGopDen.ban_trangthai = "Có người"; // Bàn nhận gộp đang có người
                                db.SubmitChanges();

                                // Tìm tất cả các hóa đơn chưa thanh toán của bàn được gộp
                                var hoaDonsOnBanGop = db.tbHoaDons.Where(hd => hd.ban_id == banGopID && hd.hoadon_trangthai == 0).ToList();

                                // Di chuyển chi tiết hóa đơn từ hóa đơn cũ sang hóa đơn mới
                                foreach (var hoaDon in hoaDonsOnBanGop)
                                {
                                    tongTien += hoaDon.hoadon_tongtien ?? 0;

                                    var chiTietHoaDons = db.tbHoaDonChiTiets.Where(ct => ct.hoadon_id == hoaDon.hoadon_id).ToList();
                                    foreach (var chiTiet in chiTietHoaDons)
                                    {
                                        chiTiet.hoadon_id = newHoaDonId;  // Chuyển chi tiết sang hóa đơn mới
                                        chiTiet.ban_id = (int)SelectedBanGopDen.Tag;
                                    }
                                    db.tbHoaDons.DeleteOnSubmit(hoaDon); // Xóa hóa đơn cũ
                                }
                            }
                            db.SubmitChanges();
                            selectedBan.BackColor = Color.White;
                            SelectedBanGopDen.BackColor = Color.Cyan;
                        }
                    }
                    var newHoaDonToUpdate = db.tbHoaDons.SingleOrDefault(hd => hd.hoadon_id == newHoaDonId);
                    if (newHoaDonToUpdate != null)
                    {
                        newHoaDonToUpdate.hoadon_tongtien = tongTien; // Update total amount
                        db.SubmitChanges(); // Save changes to the database
                    }
                    // Reset
                    SelectedBanGopList.Clear();
                    SelectedBanGopDen = null;
                    MessageBox.Show("Gộp bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chọn ít nhất 2 bàn để gộp và 1 bàn nhận gộp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}



