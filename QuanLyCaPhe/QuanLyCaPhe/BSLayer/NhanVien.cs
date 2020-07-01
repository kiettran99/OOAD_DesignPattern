using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCaPhe.DBLayer;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyCaPhe.BSLayer
{
    class NhanVien
    {
        DBMain dbMain = null;

        public NhanVien()
        {
            dbMain = new DBMain();
        }

        public DataSet LayNhanVien()
        {
            //return dbMain.ExecuteQueryDataSet("select *from NhanVien", CommandType.Text);

            return dbMain.ExecuteQueryDataSet("uspGetNhanVien_ByTenNV", CommandType.StoredProcedure);
        }

        public DataSet LayNhanVienTheoID(int MaNV)
        {
            return dbMain.ExecuteQueryDataSet($"select * from NhanVien where MaNV = {MaNV}", CommandType.Text);
        } 

        public bool SuaNhanVien(string MaNV, string Ho, string TenNV, bool Nu, DateTime NgayNV, DateTime NgaySinh, string DiaChi, string SDT, ref string error)
        {
            string sqlString;
            try
            {
                sqlString = "Update NhanVien Set HoNV=N'" + Ho + "',TenNV=N'" + TenNV +
                "',Nu='" + Nu + "',NgayBD='" + NgayNV + "',NgaySinh='" + NgaySinh +
                "',DiaChi=N'" + DiaChi + "',SDT='" + SDT + "' Where MaNV= '" + MaNV + "'";
            }
            catch (SqlException)
            {
                error = "Sửa không được";
                return false;
            }
            error = "Sửa thành công";
            return dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool SuaNhanVien(
           string MaNV,
           string HoNV,
           string TenNV,
           bool Nu,
           DateTime NgaySinh,
           int SDT,
           DateTime NgayBD,
           byte HinhAnh,
           TimeSpan GioIn,
           TimeSpan GioOut,
           ref string error)
        {

            return dbMain.MyExecuteNonQuery("uspUpdateNhanVien", CommandType.StoredProcedure, ref error,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@HoNV", HoNV),
                new SqlParameter("@TenNV", TenNV),
                new SqlParameter("@Nu", Nu),
                new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@NgayBD", NgayBD),
                new SqlParameter("@HinhAnh", HinhAnh),
                new SqlParameter("@GioIn", GioIn),
                new SqlParameter("@GioOut", GioOut));


        }
        public void LayTKMK(string MaNV, ref string TK, ref string MK)
        {
            string sqlString;
            try
            {
                sqlString = "Select TaiKhoan From DangNhap where MaNV = N'" + MaNV + "'";
                dbMain.LayTKMK(sqlString, CommandType.Text, ref TK);
                sqlString = "Select MatKhau From DangNhap where MaNV=N'" + MaNV + "'";
                dbMain.LayTKMK(sqlString, CommandType.Text, ref MK);
            }
            catch
            {

            }

        }

        public bool ThemNhanVien(string MaNV, string Ho, string TenNV, bool Nu, DateTime NgayNV, DateTime NgaySinh, string DiaChi, string SDT, string hinhanh, ref string error)
        {
            string sqlString;
            try
            {
                if (hinhanh.Length > 0)
                    sqlString = $"Insert into NhanVien values('{MaNV.Trim()}', N'{Ho.Trim()}', N'{TenNV.Trim()}', N'{Nu}', N'{NgaySinh.ToString("yyyy-MM-dd")}', N'{SDT.Trim()}', N'{DiaChi.Trim()}', N'{NgayNV.ToString("yyyy-MM-dd HH:mm:ss")}',"
                    + $"(select BulkColumn from Openrowset(Bulk'{hinhanh}',single_Blob) as Image))";
                else
                    sqlString = $"Insert into NhanVien values('{MaNV.Trim()}', N'{Ho.Trim()}', N'{TenNV.Trim()}', N'{Nu}', N'{NgaySinh.ToString("yyyy-MM-dd")}', N'{SDT.Trim()}', N'{DiaChi.Trim()}', N'{NgayNV.ToString("yyyy-MM-dd HH:mm:ss")}', null)";

                if (dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref error) == true)
                {
                    error = "Thêm thành công";
                }
            }
            catch (SqlException)
            {
                error = "Thêm không được";
                return false;
            }
            return true;
        }

        //public bool ThemNhanVien(string MaNV,
        //    string HoNV,
        //    string TenNV,
        //    bool Nu,
        //    DateTime NgaySinh,
        //    string DiaChi,
        //    DateTime NgayBD,
        //    string SDT,

        //    string HinhAnh,

        //    ref string error)

        //{
        //    return dbMain.MyExecuteNonQuery("uspInsertNhanVien", CommandType.StoredProcedure, ref error,
        //        new SqlParameter("@MaNV", MaNV),
        //        new SqlParameter("@HoNV", HoNV),
        //        new SqlParameter("@TenNV", TenNV),
        //        new SqlParameter("@Nu", Nu),
        //        new SqlParameter("@NgaySinh", NgaySinh),
        //        new SqlParameter ("@DiaChi",DiaChi),
        //        new SqlParameter("@SDT", SDT),
        //        new SqlParameter("@NgayBD", NgayBD),
        //        new SqlParameter("@HinhAnh", HinhAnh)
        //      );
        //}


        public bool XoaNhanVien(string MaNV, ref string error)
        {

            //string sqlString = $"delete from NhanVien where MaNV = '{MaNV}'";

            //return dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            return dbMain.MyExecuteNonQuery("uspDeleteNhanVien", CommandType.StoredProcedure, ref error, new SqlParameter("MaNV", MaNV));
        }
    }
}
