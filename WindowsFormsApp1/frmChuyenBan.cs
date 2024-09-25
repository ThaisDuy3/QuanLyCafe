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
    public partial class frmChuyenBan : Form
    {
        public frmChuyenBan()
        {
            InitializeComponent();
            cbBanChuyen.SelectedIndexChanged += cbBanChuyen_SelectedIndexChanged;
            cbBanChuyenDen.SelectedIndexChanged += cbBanChuyenDen_SelectedIndexChanged;
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        private Button SelectedBanChuyen;
        private Button SelectedBanChuyenDen;

        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            loadBan();
        }

        private void loadBan()
        {
            // Load tables into the ComboBox
            var tables = from t in db.tbKhuVucs select t;
            cbBanChuyen.DataSource = tables.ToList();
            cbBanChuyen.DisplayMember = "khuvuc_ten";
            cbBanChuyen.ValueMember = "khuvuc_id";
            cbBanChuyenDen.DataSource = tables.ToList();
            cbBanChuyenDen.DisplayMember = "khuvuc_ten";
            cbBanChuyenDen.ValueMember = "khuvuc_id";
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

            //Bàn đang ngồi
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
                    pnlBanChuyen.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChuyen.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanChuyen.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChuyen.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBan.Location = new Point(xA, yA);
                    pnlBanChuyen.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChuyen.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }

            //Bàn muốn chuyển
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
                    pnlBanChuyenDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChuyenDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 2)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChuyenDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChuyenDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
                if (ban.khuvuc_id == 3)
                {
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChuyenDen.Controls.Add(btnBanB);

                    xB += size + padding;
                    if (xB + size > pnlBanChuyenDen.Width)
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

            if (pnlBanChuyen.Controls.Contains(btnBan)) 
            {
                if (btnBan.BackColor == Color.Cyan) // Kiểm tra xem có phải bàn có người không
                {
                    if (SelectedBanChuyen != null && SelectedBanChuyen != btnBan)
                    {
                        SelectedBanChuyen.BackColor = Color.Cyan;
                    }

                    btnBan.BackColor = Color.LimeGreen; // Đánh dấu bàn được chọn
                    SelectedBanChuyen = btnBan;
                }
            }
            else if (pnlBanChuyenDen.Controls.Contains(btnBan)) // Nếu nút này ở flpBanChuyenDen
            {
                if (btnBan.BackColor == Color.White) // Kiểm tra xem có phải bàn trống không
                {
                    if (SelectedBanChuyenDen != null && SelectedBanChuyenDen != btnBan)
                    {
                        SelectedBanChuyenDen.BackColor = Color.White;
                    }

                    btnBan.BackColor = Color.LimeGreen; // Đánh dấu bàn được chọn
                    SelectedBanChuyenDen = btnBan;
                }
            }
        }

        private void cbBanChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanChuyen.Text == "All")
            {
                // Load all tables regardless of their area
                var danhSachBan = from ban in db.tbBans select ban;

                // Clear current controls on panel
                pnlBanChuyen.Controls.Clear();

                // Initialize positions for placing buttons
                int size = 80;
                int padding = 5;
                int x = 10, y = 10;

                int counterA = 1;
                int counterB = 1;
                int counterC = 1;

                foreach (var ban in danhSachBan)
                {
                    // Create a new button for each table
                    Button btnBan = new Button();
                    btnBan.Width = size;
                    btnBan.Height = size;

                    // Set the text based on the table's area
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
                    btnBan.Tag = ban.ban_id; // Assign the table's ID to the Tag property
                    btnBan.Click += btnBan_Click;

                    // Set the button color based on the table's status
                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBan.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBan.BackColor = Color.Cyan;
                    }

                    // Set the button position and add it to the flow layout panel
                    btnBan.Location = new Point(x, y);
                    pnlBanChuyen.Controls.Add(btnBan);

                    // Update the position for the next button
                    x += size + padding;
                    if (x + size > pnlBanChuyen.Width)
                    {
                        x = 10;
                        y += size + padding;
                    }
                }
            }
            else if (cbBanChuyen.SelectedValue != null && int.TryParse(cbBanChuyen.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                // Load tables based on the selected area (not "Tất cả")
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                // Clear current controls on panel
                pnlBanChuyen.Controls.Clear();

                int size = 80;
                int padding = 5;
                int xA = 10, yA = 10;

                int counterA = 1;
                int counterB = 1;
                int counterC = 1;

                foreach (var ban in danhSachBanTheoKhuVuc)
                {
                    // Create a new button for each table
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

                    // Set the button color based on the table's status
                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBan.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBan.BackColor = Color.Cyan;
                    }

                    // Set the button position and add it to the flow layout panel
                    btnBan.Location = new Point(xA, yA);
                    pnlBanChuyen.Controls.Add(btnBan);

                    xA += size + padding;
                    if (xA + size > pnlBanChuyen.Width)
                    {
                        xA = 10;
                        yA += size + padding;
                    }
                }
            }
        }

        private void cbBanChuyenDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanChuyenDen.Text == "All")
            {
                // Load all tables regardless of their area
                var danhSachBan = from ban in db.tbBans select ban;

                // Clear current controls on panel
                pnlBanChuyenDen.Controls.Clear();

                // Initialize positions for placing buttons
                int size = 80;
                int padding = 5;
                int xB = 10, yB = 10;

                int counterX = 1;
                int counterY = 1;
                int counterZ = 1;

                foreach (var ban in danhSachBan)
                {
                    // Create a new button for each table
                    Button btnBanB = new Button();
                    btnBanB.Width = size;
                    btnBanB.Height = size;

                    // Set the text based on the table's area
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
                    btnBanB.Tag = ban.ban_id; // Assign the table's ID to the Tag property
                    btnBanB.Click += btnBan_Click;

                    // Set the button color based on the table's status
                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBanB.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBanB.BackColor = Color.Cyan;
                        continue;
                    }

                    // Set the button position and add it to the flow layout panel
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChuyenDen.Controls.Add(btnBanB);

                    // Update the position for the next button
                    xB += size + padding;
                    if (xB + size > pnlBanChuyenDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
            else if (cbBanChuyenDen.SelectedValue != null && int.TryParse(cbBanChuyenDen.SelectedValue.ToString(), out int selectedKhuVucID))
            {
                // Load tables based on the selected area (not "Tất cả")
                var danhSachBanTheoKhuVuc = from ban in db.tbBans
                                            where ban.khuvuc_id == selectedKhuVucID
                                            select ban;

                // Clear current controls on panel
                pnlBanChuyenDen.Controls.Clear();

                int size = 80;
                int padding = 5;
                int xB = 10, yB = 10;

                int counterX = 1;
                int counterY = 1;
                int counterZ = 1;

                foreach (var ban in danhSachBanTheoKhuVuc)
                {
                    // Create a new button for each table
                    Button btnBanB = new Button();
                    btnBanB.Width = size;
                    btnBanB.Height = size;

                    // Set the text based on the table's area
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
                    btnBanB.Tag = ban.ban_id; // Assign the table's ID to the Tag property
                    btnBanB.Click += btnBan_Click;

                    // Set the button color based on the table's status
                    if (ban.ban_trangthai == "Trống")
                    {
                        btnBanB.BackColor = Color.White;
                    }
                    else if (ban.ban_trangthai == "Có người")
                    {
                        btnBanB.BackColor = Color.Cyan;
                        continue;
                    }

                    // Set the button position and add it to the flow layout panel
                    btnBanB.Location = new Point(xB, yB);
                    pnlBanChuyenDen.Controls.Add(btnBanB);

                    // Update the position for the next button
                    xB += size + padding;
                    if (xB + size > pnlBanChuyenDen.Width)
                    {
                        xB = 10;
                        yB += size + padding;
                    }
                }
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn chuyển bàn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (SelectedBanChuyen != null && SelectedBanChuyenDen != null)
                {
                    int banChuyenID = (int)SelectedBanChuyen.Tag;
                    int banChuyenDenID = (int)SelectedBanChuyenDen.Tag;

                    var banChuyen = db.tbBans.SingleOrDefault(b => b.ban_id == banChuyenID);
                    var banChuyenDen = db.tbBans.SingleOrDefault(b => b.ban_id == banChuyenDenID);

                    if (banChuyen != null && banChuyenDen != null)
                    {
                        // Update trạng thái trong cơ sở dữ liệu
                        banChuyen.ban_trangthai = "Trống";
                        banChuyenDen.ban_trangthai = "Có người";
                        db.SubmitChanges();

                        // Update hóa đơn để chuyển đến bàn mới
                        var hoaDonsOnBanChuyen = db.tbHoaDons.Where(hd => hd.ban_id == banChuyenID && hd.hoadon_trangthai == 0).ToList();
                        foreach (var hoaDon in hoaDonsOnBanChuyen)
                        {
                            hoaDon.ban_id = banChuyenDenID;
                        }
                        db.SubmitChanges();

                        // Update giao diện người dùng
                        SelectedBanChuyen.BackColor = Color.White;
                        SelectedBanChuyen.Text = $"{banChuyen.ban_ten}\nTrống";
                        SelectedBanChuyenDen.BackColor = Color.Cyan;
                        SelectedBanChuyenDen.Text = $"{banChuyenDen.ban_ten}\nCó người";


                        SelectedBanChuyen = null;
                        SelectedBanChuyenDen = null;

                        loadBan();

                        MessageBox.Show("Chuyển bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Chọn bàn có người và bàn trống để chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
