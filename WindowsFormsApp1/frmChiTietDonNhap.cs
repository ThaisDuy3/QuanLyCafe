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
    public partial class frmChiTietDonNhap : Form
    {
        public frmChiTietDonNhap(string maDonHang)
        {
            InitializeComponent();
            this.maDonHang = maDonHang;
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        private string maDonHang;

        private void frmChiTietDonNhap_Load(object sender, EventArgs e)
        {
            loadChiTietDonNhapHang();
        }

        private void loadChiTietDonNhapHang()
        {
            var getDataChiTiet = from ct in db.tbNhapHangChiTiets
                                 where ct.nhaphang_id == maDonHang
                                 select new
                                 {
                                     ct.nhaphangchitiet_sanpham,
                                     ct.nguyenlieu_nhacungcap,
                                     ct.nhaphangchitiet_soluong,
                                     ct.nhaphangchitiet_dongia,
                                     ct.nhaphangchitiet_thanhtien
                                 };

            // Gán dữ liệu vào DataGridView
            grvChiTietDonNhapHang.DataSource = getDataChiTiet.ToList();

            // Đặt lại tiêu đề các cột
            grvChiTietDonNhapHang.Columns["nhaphangchitiet_sanpham"].HeaderText = "Tên sản phẩm";
            grvChiTietDonNhapHang.Columns["nguyenlieu_nhacungcap"].HeaderText = "Nhà cung cấp";
            grvChiTietDonNhapHang.Columns["nhaphangchitiet_soluong"].HeaderText = "Số lượng";
            grvChiTietDonNhapHang.Columns["nhaphangchitiet_dongia"].HeaderText = "Đơn giá";
            grvChiTietDonNhapHang.Columns["nhaphangchitiet_thanhtien"].HeaderText = "Thành tiền";
        }

        private void grvChiTietDonNhapHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvChiTietDonNhapHang.Columns[e.ColumnIndex].Name == "nhaphangchitiet_thanhtien")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".") + " VNĐ";
                    e.FormattingApplied = true;
                }
            }
            else if (grvChiTietDonNhapHang.Columns[e.ColumnIndex].Name == "nhaphangchitiet_dongia")
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
