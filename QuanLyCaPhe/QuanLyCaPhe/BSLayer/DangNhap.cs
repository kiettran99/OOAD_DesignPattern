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
    class DangNhap
    {
        string err = "";

        public DangNhap()
        {

        }

        public int TimMaNVTheoTaiKhoan(string taikhoan)
        {
            return (int)DBMain.getInstance().FirstRowQuery($"select MaNV from DangNhap where TaiKhoan = N'{taikhoan}'", CommandType.Text, ref err);
        }

        public bool KiemTra(string tk, string mk, ref string err, ref int MaNV)
        {
            string sqlstring = "Select Count(*) From DangNhap Where TaiKhoan = '" + tk + "'" + "AND MatKhau='" + mk + "'";
            if (DBMain.getInstance().CheckThongTin(sqlstring, CommandType.Text, ref err) == false)
            {
                err = "Tài khoản hoặc mật khẩu không đúng. Vui Long Thử Lại";
                return false;
            }
            else
            {
                err = "Đăng nhập thành công";
                sqlstring = "Select MaNV From DangNhap where TaiKhoan='" + tk + "'";
                DBMain.getInstance().LayMa(sqlstring, CommandType.Text, ref MaNV);

            }

            return true;
        }
        public DataSet LayTK()
        {
            //return DBMain.getInstance().ExecuteQueryDataSet("select *from DangNhap", CommandType.Text);
            return DBMain.getInstance().ExecuteQueryDataSet("Read_DangNhap", CommandType.StoredProcedure);
        }


        public bool ThemTK(string TenTK, string Pass, string MaNV, ref string error)
        {
            string sqlString;
            try
            {
                sqlString = $"Insert into DangNhap values('{TenTK}', N'{Pass}', N'{MaNV}')";
            }
            catch (SqlException)
            {
                error = "Thêm không được";
                return false;
            }
            error = "Thêm thành công";
            return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool XoaTK(string MaNV, ref string error)
        {
            //string sqlString = $"delete from DangNhap where MaNV = '{MaNV}'";
            //return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            return DBMain.getInstance().MyExecuteNonQuery("Delete_DangNhap", CommandType.StoredProcedure, ref error, new SqlParameter("@MaNV", MaNV));
        }
        public bool RenewTK(string MaNV, ref string error)
        {
            //string sqlString;
            try
            {
                //sqlString = "Update DangNhap Set MatKhau=N'" + 123 +
                //  "' Where MaNV= '" + MaNV + "'";
                error = "Sửa thành công";
                return DBMain.getInstance().MyExecuteNonQuery("Renew_DangNhap", CommandType.StoredProcedure, ref error, new SqlParameter("@MaNV", MaNV));
            }
            catch (SqlException)
            {
                error = "Sửa không được";
                return false;
            }
        }
        public bool SuaPass(string MaNV,string Pass, ref string error)
        {
            //string sqlString;
            try
            {
                //sqlString = "Update DangNhap Set MatKhau=N'" + Pass +
                //  "' Where MaNV= '" + MaNV + "'";
                error = "Sửa thành công";
            }
            catch (SqlException)
            {
                error = "Sửa không được";
                return false;
            }
            return DBMain.getInstance().MyExecuteNonQuery("Update_DangNhap", CommandType.StoredProcedure, ref error, new SqlParameter("@MaNV", MaNV), new SqlParameter("@MatKhau", Pass));
        }
    }
}
