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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        dbcsdlDataContext db = new dbcsdlDataContext();
        DataTable dt = new DataTable();
        int id_nhaphang;

        public string maTuTang()
        {
            // Kiem tra ma hoa don cuoi cung trong database
            string s = "HD24";
            int k = 0;
            var checkMaHoaDon = from nh in db.tbNhapHangs select nh;
            if (checkMaHoaDon.Count() > 0)
            {
                string maHoaDon = (from hd1 in db.tbNhapHangs orderby hd1.nhaphang_id descending select hd1).First().nhaphang_id;
                k = Convert.ToInt32(maHoaDon.Substring(4, 4));
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

        private int TinhTongTien()
        {
            int tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                tongTien += Convert.ToInt32(row["nhaphangchitiet_thanhtien"]);
            }
            return tongTien;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            txtMaNhapHang.Text = maTuTang();
            loadData();

            //grvDanhSachSanPhamNhan.Columns[0].HeaderText = "ID sản phẩm";
            //grvDanhSachSanPhamNhan.Columns[1].HeaderText = "Tên sản phẩm";
            //grvDanhSachSanPhamNhan.Columns[2].HeaderText = "Nhà cung cấp";
            //grvDanhSachSanPhamNhan.Columns[3].HeaderText = "Số lượng";
            //grvDanhSachSanPhamNhan.Columns[4].HeaderText = "Đơn giá";
            //grvDanhSachSanPhamNhan.Columns[5].HeaderText = "Thành tiền";
        }

        protected void loadData()
        {
            var getData = from nl in db.tbNguyenLieus
                          select new
                          {
                              nl.nguyenlieu_id,
                              nl.nguyenlieu_ten,
                              nl.nguyenlieu_nhacungcap
                          };

            grvDanhSachSanPham.DataSource = getData;
            grvDanhSachSanPham.Columns["nguyenlieu_ten"].HeaderText = "Tên sản phẩm";
            grvDanhSachSanPham.Columns["nguyenlieu_id"].HeaderText = "ID sản phẩm";
            grvDanhSachSanPham.Columns["nguyenlieu_nhacungcap"].HeaderText = "Nhà cung cấp";

            //grvDanhSachSanPham.Columns["nguyenlieu_id"].Visible = false;
        }

        private void grvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_nhaphang = Convert.ToInt32(grvDanhSachSanPham.CurrentRow.Cells["nguyenlieu_id"].Value);
        }

        private void grvDanhSachSanPhamNhan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            // Kiểm tra xem ô nào đang được chỉnh sửa
            if (columnIndex == grvDanhSachSanPhamNhan.Columns["nhaphangchitiet_soluong"].Index ||
                columnIndex == grvDanhSachSanPhamNhan.Columns["nhaphangchitiet_dongia"].Index)
            {
                // Lấy dữ liệu từ ô đang chỉnh sửa
                int soLuong = Convert.ToInt32(grvDanhSachSanPhamNhan.Rows[rowIndex].Cells["nhaphangchitiet_soluong"].Value);
                int donGia = Convert.ToInt32(grvDanhSachSanPhamNhan.Rows[rowIndex].Cells["nhaphangchitiet_dongia"].Value);
                // Tính toán thành tiền
                int thanhTien = soLuong * donGia;
                // Cập nhật dữ liệu vào DataTable
                dt.Rows[rowIndex]["nhaphangchitiet_thanhtien"] = thanhTien;
                // Cập nhật lại DataGridView
                grvDanhSachSanPhamNhan.Refresh();
                // Cập nhật tổng tiền
                txtTongTien.Text = string.Format("{0:#,##0.##}", TinhTongTien()).Replace(",", ".") + " VNĐ";
            }
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (id_nhaphang == 0)
            {
                MessageBox.Show("Chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tbNguyenLieu checkSanPham = (from sp in db.tbNguyenLieus where sp.nguyenlieu_id == id_nhaphang select sp).FirstOrDefault();

            if (checkSanPham == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra xem cột đã tồn tại trước khi thêm
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("nguyenlieu_id", typeof(int));
                dt.Columns.Add("nguyenlieu_ten", typeof(string));
                dt.Columns.Add("nguyenlieu_nhacungcap", typeof(string));
                dt.Columns.Add("nhaphangchitiet_soluong", typeof(int));
                dt.Columns.Add("nhaphangchitiet_dongia", typeof(int));
                dt.Columns.Add("nhaphangchitiet_thanhtien", typeof(int));
            }

            // Kiểm tra xem sản phẩm đã có trong DataTable chưa
            DataRow[] existingRows = dt.Select("nguyenlieu_id = " + id_nhaphang);

            if (existingRows.Length > 0)
            {
                MessageBox.Show("Đã có sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                dt.Rows.Add(checkSanPham.nguyenlieu_id, checkSanPham.nguyenlieu_ten, checkSanPham.nguyenlieu_nhacungcap, 0, 0, 0);
            }

            grvDanhSachSanPhamNhan.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDanhSachSanPhamNhan.CurrentRow == null)
            {
                MessageBox.Show("Không còn sản phẩm để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy giá trị sanpham_id từ DataGridView grvSanpham
            id_nhaphang = Convert.ToInt32(grvDanhSachSanPhamNhan.CurrentRow.Cells["nguyenlieu_id"].Value);

            // Tìm hàng trong DataTable dựa trên sanpham_id
            DataRow[] rows = dt.Select("nguyenlieu_id = " + id_nhaphang);

            // Kiểm tra nếu dữ liệu tồn tại trong DataTable
            if (rows.Length == 0)
            {
                MessageBox.Show("Chọn sản phẩm để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Xóa hàng khỏi DataTable
                foreach (DataRow row in rows)
                {
                    dt.Rows.Remove(row);
                }

                // Cập nhật lại DataGridView grvSanpham
                grvDanhSachSanPhamNhan.DataSource = dt;
                txtTongTien.Text = string.Format("{0:#,##0.##}", TinhTongTien()).Replace(",", ".") + " VNĐ";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaNhapHang.Text;
            int tongTien = Convert.ToInt32(txtTongTien.Text.Replace(".", "").Replace(" VNĐ", ""));
            var nhaphang = db.tbNhapHangs.SingleOrDefault(dh => dh.nhaphang_id == maHoaDon);

            if (nhaphang != null)
            {
                // trước Xóa hết dữ liệu đã có trong bảng chi tiết
                var getDataChiTiet = from dhct in db.tbNhapHangChiTiets where dhct.nhaphang_id == txtMaNhapHang.Text select dhct;
                db.tbNhapHangChiTiets.DeleteAllOnSubmit(getDataChiTiet);
                db.SubmitChanges();
                foreach (DataRow row in dt.Rows)
                {
                    tbNhapHangChiTiet insertChiTiet = new tbNhapHangChiTiet
                    {
                        nhaphang_id = maHoaDon,
                        nhaphangchitiet_sanpham = (string)row["nguyenlieu_ten"],
                        nguyenlieu_nhacungcap = (string)row["nguyenlieu_nhacungcap"],
                        nhaphangchitiet_soluong = (int)row["nhaphangchitiet_soluong"],
                        nhaphangchitiet_dongia = (int)row["nhaphangchitiet_dongia"],
                        nhaphangchitiet_thanhtien = (int)row["nhaphangchitiet_thanhtien"],
                        nguyenlieu_id = (int)row["nguyenlieu_id"]
                    };
                    db.tbNhapHangChiTiets.InsertOnSubmit(insertChiTiet);
                }
                db.SubmitChanges();
            }
            else
            {
                tbNhapHang insertDonHang = new tbNhapHang
                {
                    nhaphang_id = maHoaDon,
                    nhaphang_ngaynhap = dtNgayNhap.Value,
                    nhaphang_tongtien = tongTien
                };
                db.tbNhapHangs.InsertOnSubmit(insertDonHang);
                db.SubmitChanges();
                foreach (DataRow row in dt.Rows)
                {
                    tbNhapHangChiTiet insertChiTiet = new tbNhapHangChiTiet
                    {
                        nhaphang_id = insertDonHang.nhaphang_id,
                        nhaphangchitiet_sanpham = (string)row["nguyenlieu_ten"],
                        nguyenlieu_nhacungcap = (string)row["nguyenlieu_nhacungcap"],
                        nhaphangchitiet_soluong = (int)row["nhaphangchitiet_soluong"],
                        nhaphangchitiet_dongia = (int)row["nhaphangchitiet_dongia"],
                        nhaphangchitiet_thanhtien = (int)row["nhaphangchitiet_thanhtien"],
                        nguyenlieu_id = (int)row["nguyenlieu_id"]
                    };
                    db.tbNhapHangChiTiets.InsertOnSubmit(insertChiTiet);
                }
                db.SubmitChanges();
                MessageBox.Show("Hoàn thành đơn hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtMaNhapHang.Text = maTuTang();
            txtTongTien.Text = string.Empty;
            dt.Clear();    
            grvDanhSachSanPhamNhan.DataSource = dt;
        }

        private void grvDanhSachSanPhamNhan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grvDanhSachSanPhamNhan.Columns[e.ColumnIndex].Name == "nhaphangchitiet_thanhtien")
            {
                if (e.Value != null)
                {
                    // Định dạng số với dấu chấm và thêm "VNĐ"
                    e.Value = string.Format("{0:#,##0.##}", e.Value).Replace(",", ".");
                    e.FormattingApplied = true;
                }
            }
            else if (grvDanhSachSanPhamNhan.Columns[e.ColumnIndex].Name == "nhaphangchitiet_dongia")
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
