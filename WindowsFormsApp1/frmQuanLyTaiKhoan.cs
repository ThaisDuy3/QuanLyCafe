using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan(tbTaiKhoan user)
        {
            InitializeComponent();
            currentUser = user;
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        private tbTaiKhoan currentUser;

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData();
        }

        protected void loadData()
        {
            if (currentUser != null)
            {
                txtTenTaiKhoan.Text = currentUser.taikhoan_tentaikhoan;
                txtHoTen.Text = currentUser.taikhoan_hoten;

                if (!string.IsNullOrEmpty(currentUser.taikhoan_hinhanh))
                {
                    // Assuming the images are stored in a folder named "images" within your project
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images", currentUser.taikhoan_hinhanh);

                    if (File.Exists(imagePath))
                    {
                        ptHinhAnh.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // Handle case where the image file doesn't exist (optional)
                        MessageBox.Show("Hình ảnh không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(currentUser != null)
            {
                tbTaiKhoan upd = (from tk in db.tbTaiKhoans where tk.taikhoan_id == currentUser.taikhoan_id select tk).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) || string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) || string.IsNullOrWhiteSpace(txtNhapLai.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (upd == null || txtMatKhauCu.Text != upd.taikhoan_matkhau)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtMatKhauMoi.Text != txtNhapLai.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                upd.taikhoan_matkhau = txtMatKhauMoi.Text;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhauCu.Text = string.Empty;
                txtMatKhauMoi.Text = string.Empty;
                txtNhapLai.Text = string.Empty;
                loadData();
            }
        }
    }
}
