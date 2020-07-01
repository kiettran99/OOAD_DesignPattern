using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCaPhe.BSLayer;

namespace QuanLyCaPhe
{
    public partial class FormAdmin : Form
    {
        #region Properties TabNhanVien
        DataTable dataTable = null;
        BanLuongNhanVien BCLNV = new BanLuongNhanVien();
        NhanVien BLNV = new NhanVien();
        ThucAn BLTA = new ThucAn();
        ThucAn ta = null;
        LoaiThucAn BTLTA = new LoaiThucAn();
        BanAn BTLBA = new BanAn();
        DangNhap BLDN = new DangNhap();
        ChamCong BLCHC = new ChamCong();
        TinhLuong BLTL = new TinhLuong();

        string err;
        string tk, mk;
        private string error;
        bool ThemF = false;
        string tenanh = "";

        #endregion

        public FormAdmin()
        {
            InitializeComponent();
            LoadDanhThu();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Chọn tab nhân viên, sẽ load dữ liệu lên.
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    LoadDanhThu();
                    break;
                case 1:
                    LoadDataF();
                    break;
                case 2:
                    LoadDataDM();
                    break;
                case 3:
                    LoadDataBanAn();
                    break;
                case 4:
                    LoadTTTK();
                    break;
                case 5:
                    LoadDataNV();
                    break;
                case 6:
                    LoadDataCHC();
                    break;
                case 7:
                    LoadTL();
                    break;
                case 9:
                    LoadDataLuongNV();
                    break;
            }   
        }

        #region TabDanhThu

        private void LoadDanhThu()
        {
            DanhThu dt = new DanhThu();
            dgvDanhThu.DataSource = dt.LayDanhThu(dtpNgayTaoHoaDon.Value, dtpNgayKetThucHoaDon.Value).Tables[0];
        }


        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DanhThu dt = new DanhThu();
            dgvDanhThu.DataSource = dt.LayDanhThu(dtpNgayTaoHoaDon.Value, dtpNgayKetThucHoaDon.Value).Tables[0];
        }

        #endregion

        #region tabthucan
        private void btnThemF_Click(object sender, EventArgs e)
        {
            ThemF = true;

            btnThemF.Enabled = false;

            btnXoaF.Enabled = false;
            btnSuaF.Enabled = false;
            btnXemF.Enabled = false;

            btnLuuF.Enabled = true;
            btnHuyF.Enabled = true;
            txtFID.ResetText();
            txtFName.ResetText();
            txtSFname.ResetText();
            cmbDanhMucF.ResetText();
            txtGiaF.ResetText();
            int idTA = 1;
            //if (dgvThucAn.Rows.Count > 1)
            //    idTA = (int.Parse(dgvThucAn.Rows[dgvThucAn.Rows.Count - 2].Cells[0].Value.ToString()) + 1);
            idTA = BLTA.TimMaxIDThucAn() + 1;
            txtFID.Text = idTA.ToString();

        }

        private void dgvThucAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvThucAn.CurrentCell.RowIndex;
                txtFID.Text = dgvThucAn.Rows[r].Cells["MaThucAn"].Value.ToString();
                txtFName.Text = dgvThucAn.Rows[r].Cells["TenMonAn"].Value.ToString();
                cmbDanhMucF.Text = dgvThucAn.Rows[r].Cells["Column9"].Value.ToString();
                txtGiaF.Text = dgvThucAn.Rows[r].Cells["Gia"].Value.ToString();
            }
            catch
            {

            }
        }


        private void btnHuyF_Click(object sender, EventArgs e)
        {
            btnThemF.Enabled = true;
            btnXoaF.Enabled = true;
            btnSuaF.Enabled = true;
            btnXemF.Enabled = true;
            btnLuuF.Enabled = false;
            btnHuyF.Enabled = false;
            dgvThucAn_CellClick(null, null);
        }

        private void btnXoaF_Click(object sender, EventArgs e)
        {
            btnThemF.Enabled = true;
            btnXoaF.Enabled = true;
            btnSuaF.Enabled = true;
            btnXemF.Enabled = true;
            btnLuuF.Enabled = true;
            btnHuyF.Enabled = true;
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BLTA.XoaThucAn(txtFID.Text, ref err);
                    LoadDataF();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void btnLuuF_Click(object sender, EventArgs e)
        {
            string IDDanhMuc = BTLTA.TimIDTheoTenLoaiThucAn(cmbDanhMucF.Text);
            if (ThemF == true)
            {             
                BLTA.ThemThucAn(txtFID.Text.Trim(), IDDanhMuc, float.Parse(txtGiaF.Text.Trim()), txtFName.Text.Trim());
                 
                // Load lại DataGridView
                LoadDataF();
                // THông Báo
                MessageBox.Show(err);
            }
            else
            {
                BLTA.SuaThucAn(txtFID.Text.Trim(), IDDanhMuc, float.Parse(txtGiaF.Text.Trim()), txtFName.Text.Trim());
                LoadDataF();
                MessageBox.Show(err);
            }
        }
        private void btnSuaF_Click(object sender, EventArgs e)
        {
            ThemF = false;

            txtFID.ResetText();
            txtFName.ResetText();
            cmbDanhMucF.ResetText();
            txtGiaF.ResetText();
            btnSuaF.Enabled = false;
            btnXoaF.Enabled = false;
            btnLuuF.Enabled = true;
            btnXemF.Enabled = false;
            btnHuyF.Enabled = true;
            dgvThucAn_CellClick(null, null);
        }


        private void btnXemF_Click(object sender, EventArgs e)
        {
            LoadDataF();
        }
        #endregion

        #region TabDanhMuc
        private bool themDM = false;

        private void LoadDataDM()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BTLTA.LayDanhMuc();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvDanhMuc.DataSource = dataTable;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
            txtTenDM.ResetText();
            txtIDDM.ResetText();
            // không cho thao tác trên các nút lưu/hủy
            btnThemDM.Enabled = true;
            btnLuuDM.Enabled = false;
            btnXemDM.Enabled = true;
            btnXoaDM.Enabled = true;
            btnSuaDM.Enabled = true;
            dgvDanhMuc_CellClick(null, null);
        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            themDM = true;
            btnThemDM.Enabled = false;
            btnSuaDM.Enabled = false;
            btnXemDM.Enabled = false;
            btnLuuDM.Enabled = true;
            txtIDDM.ResetText();
            txtTenDM.ResetText();
            int idDM = 1;
            if (dgvDanhMuc.Rows.Count > 1)
                idDM = (int.Parse(dgvDanhMuc.Rows[dgvDanhMuc.Rows.Count - 2].Cells[0].Value.ToString()) + 1);
            txtIDDM.Text = idDM.ToString();
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BTLTA.XoaDanhMuc(txtIDDM.Text, ref err);
                    LoadDataDM();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnSuaDM_Click(object sender, EventArgs e)
        {
            themDM = false;
            dgvDanhMuc_CellClick(null, null);
            txtTenDM.ResetText();
            btnSuaDM.Enabled = false;
            btnXemDM.Enabled = false;
            btnXoaDM.Enabled = false;
            btnLuuDM.Enabled = true;

        }

        private void btnXemDM_Click(object sender, EventArgs e)
        {
            LoadDataDM();
        }

        private void btnLuuDM_Click(object sender, EventArgs e)
        {
            if (themDM)
            {
                try
                {
                    BTLTA.ThemDanhMuc(txtIDDM.Text, txtTenDM.Text, ref err);
                    // Load lại DataGridView
                    LoadDataDM();
                    MessageBox.Show("Thêm thành công !");
                }
                catch (Exception err)
                {
                    error = err.Message;
                }
            }
            else
            {
                try
                {
                    BTLTA.SuaDanhMuc(txtIDDM.Text, txtTenDM.Text, ref err);
                    // Load lại DataGridView
                    LoadDataDM();

                }
                catch (Exception error)
                {
                    err = error.Message;
                }
                MessageBox.Show(err);
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvDanhMuc.CurrentCell.RowIndex;
                txtIDDM.Text = dgvDanhMuc.Rows[r].Cells[0].Value.ToString();
                txtTenDM.Text = dgvDanhMuc.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }
        #endregion

        #region TabBanAn
        private bool themB = false;

        private void LoadDataBanAn()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BTLBA.LayBanAn();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvBanAn.DataSource = dataTable;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
            txtIDB.ResetText();
            txtTenB.ResetText();
            txtTrangThaiB.ResetText();
            // không cho thao tác trên các nút lưu/hủy
            btnThemB.Enabled = true;
            btnSuaB.Enabled = true;
            btnXoaB.Enabled = true;
            btnLuuB.Enabled = false;
            btnXemB.Enabled = true;
            dgvDanhMuc_CellClick(null, null);
        }

        private void dgvBanAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvBanAn.CurrentCell.RowIndex;
                txtIDB.Text = dgvBanAn.Rows[r].Cells[0].Value.ToString();
                txtTenB.Text = dgvBanAn.Rows[r].Cells[1].Value.ToString();
                txtTrangThaiB.Text = dgvBanAn.Rows[r].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }


        private void btnThemB_Click(object sender, EventArgs e)
        {
            themB = true;
            btnThemB.Enabled = false;
            btnSuaB.Enabled = false;
            btnXemB.Enabled = false;
            btnLuuB.Enabled = true;
            txtTrangThaiB.ResetText();
            txtIDB.ResetText();
            txtTenB.ResetText();

            int idBan = 1;
            if (dgvBanAn.Rows.Count > 1)
                idBan = (int.Parse(dgvBanAn.Rows[dgvBanAn.Rows.Count - 2].Cells[0].Value.ToString()) + 1);
            txtIDB.Text = idBan.ToString();
        }

        private void btnXoaB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BTLBA.XoaBanAn(txtIDB.Text, ref err);
                    LoadDataBanAn();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnXemB_Click(object sender, EventArgs e)
        {
            LoadDataBanAn();
        }

        private void btnLuuB_Click(object sender, EventArgs e)
        {
            if (themB)
            {
                try
                {
                    BTLBA.ThemBanAn(txtIDB.Text, txtTenB.Text, txtTrangThaiB.Text, ref err);
                    // Load lại DataGridView
                    LoadDataBanAn();
                    // THông Báo
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception err)
                {
                    error = err.Message;
                }
            }
            else
            {
                try
                {
                    BTLBA.SuaBanAn(txtIDB.Text, txtTenB.Text, txtTrangThaiB.Text, ref err);
                    // Load lại DataGridView
                    LoadDataBanAn();
                    // THông Báo
                    MessageBox.Show("Sửa thành công");
                }
                catch (Exception err)
                {
                    error = err.Message;
                }
            }
        }

        private void btnSuaB_Click(object sender, EventArgs e)
        {
            themB = false;
            txtIDB.ResetText();
            txtTenB.ResetText();
            txtTrangThaiB.ResetText();
            btnSuaB.Enabled = false;
            btnXemB.Enabled = false;
            btnXoaB.Enabled = false;
            btnLuuB.Enabled = true;
            dgvBanAn_CellClick(null, null);
        }



        #endregion

        #region TabTaiKhoan

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            btnThemTK.Enabled = false;
            btnXoaTK.Enabled = false;
            btnReNewTK.Enabled = false;
            btnLuuTK.Enabled = true;
            btnHuyTK.Enabled = true;
            btnReloadTK.Enabled = true;

            txtMauKhauTK.ResetText();
            txtTenTK.ResetText();
            txtMaNVTK.ResetText();
            MessageBox.Show("Hãy chắc mã nhân viên bạn điền là đúng");
            txtMaNVTK.Enabled = true;

        }


        private void LoadTTTK()
        {
            txtMaNVTK.Enabled = false;
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BLDN.LayTK();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvTK.DataSource = dataTable;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvTK.CurrentCell.RowIndex;
                txtTenTK.Text = dgvTK.Rows[r].Cells[0].Value.ToString();
                txtMauKhauTK.Text = dgvTK.Rows[r].Cells[1].Value.ToString();
                txtMaNVTK.Text = dgvTK.Rows[r].Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            txtMaNVTK.Enabled = false;
            dgvTK_CellClick(null, null);
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BLDN.XoaTK(txtMaNVTK.Text.Trim(), ref err);
                    LoadTTTK();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnLuuTK_Click(object sender, EventArgs e)
        {
            BLDN.ThemTK(txtTenTK.Text.Trim(), txtMauKhauTK.Text.Trim(), txtMaNVTK.Text.Trim(), ref err);
            // Load lại DataGridView
            LoadTTTK();
            // THông Báo
            MessageBox.Show(err);
        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            btnLuuTK.Enabled = false;
            btnHuyTK.Enabled = false;
            btnThemTK.Enabled = true;
            btnXoaTK.Enabled = true;
            btnReNewTK.Enabled = true;
            btnReloadTK.Enabled = true;
        }

        private void btnReNewTK_Click(object sender, EventArgs e)
        {
            txtMaNVTK.Enabled = false;
            dgvTK_CellClick(null, null);
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn thay đổi ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    BLDN.RenewTK(txtMaNVTK.Text.Trim(), ref err);
                    LoadTTTK();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnReloadTK_Click(object sender, EventArgs e)
        {
            LoadTTTK();
        }


        #endregion

        #region TabNhanVien

        /// <summary>
        /// Load dữ liệu nhân viên.
        /// </summary>
        private void LoadDataNV()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BLNV.LayNhanVien();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView                
                dgvNhanVien.DataSource = dataTable;
                dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            }
            catch (Exception errr)
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
            btnHuyNV.Enabled = false;
            btnLuuNV.Enabled = false;

            btnReloadNV.Enabled = true;
            btnThemNV.Enabled = true;
            btnXoaNV.Enabled = true;

            //Tạm không cho phép nhập dữ liệu cho đến khi nhấn nút thêm
            txtMaNV.ReadOnly = true;
            txtHoNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            rdbNu.Enabled = false;
            txtDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dtbNgayNV.Enabled = false;
            dtbNgaySinh.Enabled = false;

            dgvNhanVien_CellClick(null, null);
        }
        private void LoadDataF()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BLTA.LayThucAn();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvThucAn.DataSource = dataTable;

                //Lấy dữ liệu loại thức đổ vào combo box
                cmbDanhMucF.DisplayMember = "TenLoaiThucAn";
                cmbDanhMucF.DataSource = BTLTA.LayDanhMuc().Tables[0];
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }

            txtFID.ResetText();
            txtFName.ResetText();
            txtSFname.ResetText();
            txtGiaF.ResetText();

            // không cho thao tác trên các nút lưu/hủy
            btnHuyF.Enabled = false;
            btnLuuF.Enabled = false;


            btnThemF.Enabled = true;
            btnXoaF.Enabled = true;
            btnSuaF.Enabled = true;
            dgvThucAn_CellClick(null, null);
        }




        private void btnThemNV_Click(object sender, EventArgs e)
        {
            btnThemNV.Enabled = false;

            btnReloadNV.Enabled = false;

            btnLuuNV.Enabled = true;
            btnHuyNV.Enabled = true;

            txtMaNV.ResetText();
            txtMaNV.Enabled = false;
            txtTenNV.ResetText();
            txtHoNV.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            txtHoNV.ResetText();
            dtbNgayNV.ResetText();
            dtbNgaySinh.ResetText();

            //Tạm không cho phép nhập dữ liệu cho đến khi nhấn nút thêm
            txtMaNV.ReadOnly = false;
            txtHoNV.ReadOnly = false;
            txtTenNV.ReadOnly = false;
            rdbNu.Enabled = true;
            txtDienThoai.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            dtbNgayNV.Enabled = true;
            dtbNgaySinh.Enabled = true;

            int idNV = 1;
            if (dgvNhanVien.Rows.Count > 1)
                idNV = (int.Parse(dgvNhanVien.Rows[dgvNhanVien.Rows.Count - 2].Cells[0].Value.ToString()) + 1);
            txtMaNV.Text = idNV.ToString();
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {

            MemoryStream pic = new MemoryStream();
            pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
            BLNV.ThemNhanVien(txtMaNV.Text, txtHoNV.Text.Trim(), txtTenNV.Text.Trim(), rdbNu.Checked, dtbNgayNV.Value,
           dtbNgaySinh.Value, txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), tenanh, ref err);
            //BLCHC.ThemNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), ref err);
            //BLTL.ThemNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), ref err);

            // Load lại DataGridView
            LoadDataNV();
            // THông Báo
            MessageBox.Show(err);
        }

        private void btnReloadNV_Click(object sender, EventArgs e)
        {
            LoadDataNV();
        }

        private void btnHuyNV_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            dgvNhanVien_CellClick(null, null);

            btnLuuNV.Enabled = false;
            btnHuyNV.Enabled = false;
            btnReloadNV.Enabled = true;
            btnThemNV.Enabled = true;

            //Tạm không cho phép nhập dữ liệu cho đến khi nhấn nút thêm
            txtMaNV.ReadOnly = true;
            txtHoNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            rdbNu.Enabled = false;
            txtDienThoai.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dtbNgayNV.Enabled = false;
            dtbNgaySinh.Enabled = false;
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //BLTL.XoaNV(txtMaNV.Text.Trim(), ref err);
                    //BLCHC.XoaNhanVien(txtMaNV.Text.Trim(), ref err);
                    BLNV.XoaNhanVien(txtMaNV.Text, ref err);
                    LoadDataNV();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
                MemoryStream ms = new MemoryStream((byte[])dgvNhanVien.CurrentRow.Cells["Anh"].Value);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {

            }
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
                tenanh = openFile.FileName;
            }
        }
        #endregion

        #region TabChamCong
        private void LoadDataCHC()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BLCHC.LayTT();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvChamCong.DataSource = dataTable;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
            txtMaNVCC.ResetText();
            txtTenNVCC.ResetText();
            dgvChamCong_CellClick(null, null);
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvChamCong.CurrentCell.RowIndex;
                txtMaNVCC.Text = dgvChamCong.Rows[r].Cells[0].Value.ToString();
                txtTenNVCC.Text = dgvChamCong.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (dtpTimein.Value.TimeOfDay > dtpTimeOut.Value.TimeOfDay)
            {
                MessageBox.Show("Nhập sai giờ vào và ra");
            }
            else
            {
                BLCHC.ChamCongNhanVien(txtMaNVCC.Text.Trim(), dtpTimein.Value.TimeOfDay, dtpTimeOut.Value.TimeOfDay, ref err);
                TimeSpan timein = new TimeSpan();
                TimeSpan timeout = new TimeSpan();

                BLTL.LayDuLieu(txtMaNVCC.Text.Trim(), ref timein, ref timeout);

                float Hour = -float.Parse(timein.Hours.ToString()) + float.Parse(timeout.Hours.ToString());
                float Minute = -float.Parse(timein.Minutes.ToString()) + float.Parse(timeout.Minutes.ToString());
                float Millisecond = -float.Parse(timein.Milliseconds.ToString()) + float.Parse(timeout.Milliseconds.ToString());
                Hour += Minute / 60 + Millisecond / 3600;
                float sotime = 0;
                BLTL.LaySoTime(txtMaNVCC.Text.Trim(), ref sotime);
                BLTL.TinhLuongNhanVien(txtMaNVCC.Text.Trim(), Hour + sotime, 0, ref error);
                LoadDataCHC();
                MessageBox.Show(err);
            }
        }


        private void btnBoChamCong_Click(object sender, EventArgs e)
        {
            BLCHC.BoChamCong(txtMaNVCC.Text.Trim(), ref err);
            LoadDataCHC();
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


        private void btnRestart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChamCong.Rows.Count - 1; i++)
            {
                BLCHC.BoChamCong(dgvChamCong.Rows[i].Cells[0].Value.ToString(), ref err);
            }
            LoadDataCHC();
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChamCong.Rows.Count - 1; i++)
            {
                BLCHC.BoChamCong(dgvChamCong.Rows[i].Cells[0].Value.ToString(), ref err);
            }
            LoadDataCHC();
        }
        #endregion

        #region TabTinhLuong
        private void LoadTL()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BLTL.LayTTTL();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvTinhLuong.DataSource = dataTable;
            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }
            txtTenL.ResetText();
            txtMaNVL.ResetText();
            nrdTangCa.Value = 0;
            txtThuong.Text = 0.ToString();
            btnTinhLuong.Enabled = true;
            label30.Text = dateTimePicker5.Value.Month.ToString();
            dgvTinhLuong_CellClick(null, null);
        }

        private void dgvTinhLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nrdTangCa.Value = 0;
            txtThuong.Text = 0.ToString();
            try
            {
                int r = dgvTinhLuong.CurrentCell.RowIndex;
                txtMaNVL.Text = dgvTinhLuong.Rows[r].Cells[0].Value.ToString();
                txtTenL.Text = dgvTinhLuong.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnReStartL_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTinhLuong.Rows.Count - 1; i++)
            {
                BLTL.ReStartL(dgvTinhLuong.Rows[i].Cells[0].Value.ToString(), ref err);
            }
            LoadTL();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            float Time = 0;
            BLTL.LaySoTime(txtMaNVL.Text.Trim(), ref Time);
            float Luong = Time * 14000 + float.Parse(nrdTangCa.Value.ToString()) * 7 * 14000 + float.Parse(txtThuong.Text);
            BLTL.TinhLuongNhanVien(txtMaNVL.Text.Trim(), Time, Luong, ref err);
            LoadTL();
        }



        #endregion

        #region TabTimKim


        private void btnTimkimF_Click(object sender, EventArgs e)
        {
            dgvThucAn.DataSource = BLTA.TimKimF(txtSFname.Text).Tables[0];
        }
        #endregion
        #region TabBaoCaoLuongNhanVien

        private void LoadDataLuongNV()
        {

            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = BCLNV.LayLuongNv();
                dataTable = ds.Tables[0];
                // đưa dữ liệu vào dataGridView
                dgvBaoCaoLuong.DataSource = dataTable;

            }
            catch (Exception errr)
            {
                MessageBox.Show(errr.Message);
            }



            dgvChamCong_CellClick(null, null);
        }






        #endregion
        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCaPheDataSet.DanhThu_Report' table. You can move, or remove it, as needed.
            this.DanhThu_ReportTableAdapter.Fill(this.QuanLyCaPheDataSet.DanhThu_Report, dtpNgayTaoHoaDon.Value, dtpNgayKetThucHoaDon.Value);
            this.reportViewer1.RefreshReport();
        }

        private void txtFID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNVCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvTinhLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void txtTenL_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
