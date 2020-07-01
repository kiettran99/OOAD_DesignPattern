using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyCaPhe.BSLayer;
namespace QuanLyCaPhe
{
    public partial class FormNhanVien : Form
    {
        DataTable dataTable = null;
        NhanVien BLNV = new NhanVien();
        string err;
        string tk, mk;
        DangNhap BLDN = new DangNhap();
        public FormNhanVien()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }
        void LoadData()
        {
            if (FormManHinhChinh.quyentruycap == QuyenTruyCap.Administrator)
            {
                try
                {
                    label1.Text = "Danh Mục Nhân Viên";

                    //Chuyển về bình thường
                    txtMaNV.ReadOnly = false;
                    txtTenNV.ReadOnly = false;
                    txtHoNV.ReadOnly = false;
                    txtDiaChi.ReadOnly = false;
                    txtDienThoai.ReadOnly = false;
                    txtHoNV.ReadOnly = false;
                    dtbNgayNV.Enabled = true;
                    dtbNgaySinh.Enabled = true;
                    rdbNu.Enabled = false;

                    dataTable = new DataTable();
                    dataTable.Clear();
                    DataSet ds = BLNV.LayNhanVien();
                    dataTable = ds.Tables[0];
                    // đưa dữ liệu vào dataGridView
                    dgvNhanVien.DataSource = dataTable;
                    dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                }
                catch (SqlException errr)
                {
                    MessageBox.Show(errr.Message);
                }
                txtMaNV.ResetText();
                txtTenNV.ResetText();
                txtHoNV.ResetText();
                txtDiaChi.ResetText();
                txtDienThoai.ResetText();
                txtHoNV.ResetText();
                dtbNgayNV.ResetText();
                dtbNgaySinh.ResetText();
                // không cho thao tác trên các nút lưu/hủy
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                // cho phép thao tác trên thêm/sửa/xóa/thoát               
                btnSua.Enabled = true;
                dgvNhanVien_CellClick(null, null);
            }
            else
            {
                //Chặn chỉ cho xem
                label1.Text = "Thông tin nhân viên";
                panel1.Visible = false;
                gbTongQuat.Visible = false;

                txtMaNV.ReadOnly = true;
                txtTenNV.ReadOnly = true;
                txtHoNV.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtDienThoai.ReadOnly = true;
                txtHoNV.ReadOnly = true;
                dtbNgayNV.Enabled = false;
                dtbNgaySinh.Enabled = false;
                rdbNu.Enabled = false;
                
                //Lấy nhân viên theo ID đăng nhập
                DataTable dt = BLNV.LayNhanVienTheoID(FormManHinhChinh.IDNguoiDangNhap).Tables[0];
                txtMaNV.Text = dt.Rows[0]["MaNV"].ToString();
                rdbNu.Checked = (bool)dt.Rows[0]["Nu"];
                dtbNgayNV.Text = dt.Rows[0]["NgayBD"].ToString();      
                txtHoNV.Text = dt.Rows[0]["HoNV"].ToString();
                txtTenNV.Text = dt.Rows[0]["TenNV"].ToString();
                txtDienThoai.Text = dt.Rows[0]["SDT"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            }
        }



        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            if (FormDangNhap.MaNV == 0)
            {
                btnSua.Enabled = false;
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            BLNV.LayTKMK(FormDangNhap.MaNV.ToString(), ref tk, ref mk);
            txtTenTK.Text = tk.ToString();
            txtPassTK.Text = mk.ToString();
            if (FormDangNhap.MaNV == 0)
            {
                btnSua.Enabled = false;
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvNhanVien.CurrentCell.RowIndex;
                txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                rdbNu.Checked = (bool)dgvNhanVien.Rows[r].Cells[3].Value;
                dtbNgayNV.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
                dtbNgayNV.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
                txtHoNV.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;

            //thuc hiện lệnh
            NhanVien blnv = new NhanVien();
            if (FormDangNhap.MaNV.ToString() != txtMaNV.Text.Trim())
                MessageBox.Show("Bạn không đủ quyền để thay đổi thông tin của người khác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else blnv.SuaNhanVien(FormDangNhap.MaNV.ToString(), txtHoNV.Text.Trim(), txtTenNV.Text.Trim(), rdbNu.Checked, dtbNgayNV.Value,
                 dtbNgaySinh.Value, txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), ref err);
            // Load lại DataGridView
            LoadData();
            // THông Báo
            MessageBox.Show(err);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            btnSua.Enabled = false;

            btnReLoad.Enabled = false;
            btnThoat.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            txtMaNV.ResetText();
            txtMaNV.Enabled = false;
            txtTenNV.ResetText();
            txtHoNV.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtHoNV.ResetText();
            dtbNgayNV.ResetText();
            dtbNgaySinh.ResetText();

            dgvNhanVien_CellClick(null, null);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dgvNhanVien_CellClick(null, null);

            btnSua.Enabled = true;

            btnThoat.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnReLoad.Enabled = true;
            if (FormDangNhap.MaNV == 0)
            {
                btnSua.Enabled = false;
            }
        }

        private void btnSuaPass_Click(object sender, EventArgs e)
        {

            BLDN.SuaPass(txtMaNV.Text.Trim(), txtNewPass.Text.Trim(), ref err);
            MessageBox.Show(err);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = new DialogResult();
            kq = MessageBox.Show("Bạn thật sự muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (kq == DialogResult.OK)
            {
                Close();
            }
        }


    }
}
