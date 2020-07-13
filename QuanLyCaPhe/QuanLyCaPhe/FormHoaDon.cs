using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCaPhe.BSLayer;
using QuanLyCaPhe.Builders;

namespace QuanLyCaPhe
{
    public partial class FormHoaDon : Form
    {
        ThongKeHoaDon tkHoaDon;
        public FormHoaDon()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            if (FormManHinhChinh.quyentruycap == QuyenTruyCap.Administrator)
            {
                tkHoaDon = new ThongKeHoaDonBuilder().Build();
                //Quản trị viên có thể xem tất cả các dữ liệu.
                dgvHoaDon.DataSource = tkHoaDon.LayThongKeHoaDon().Tables[0];
            }
            else
            {
                tkHoaDon = new ThongKeHoaDonBuilder().taoMaNV(FormManHinhChinh.IDNguoiDangNhap).Build();
                if (FormManHinhChinh.IDNguoiDangNhap != 0)
                    dgvHoaDon.DataSource = tkHoaDon.LayThongKeHoaDonTheoNhanVien().Tables[0];
            }
            dgvHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void txtngay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvHoaDon.CurrentCell.RowIndex;
                txtma.Text = dgvHoaDon.Rows[r].Cells["IDHoaDon"].Value.ToString();
                txtTenNhanVien.Text = dgvHoaDon.Rows[r].Cells["TenNV"].Value.ToString();
                txtTenKhachHang.Text = dgvHoaDon.Rows[r].Cells["TenKH"].Value.ToString();
                txtngay.Value = DateTime.Parse(dgvHoaDon.Rows[r].Cells["NgayBan"].Value.ToString());
                txttt.Text = dgvHoaDon.Rows[r].Cells["ThanhTien"].Value.ToString();
            }
            catch { }
        }
    }
}
