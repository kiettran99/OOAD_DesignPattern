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
    class TinhLuong
    {
        private readonly DBMain db;

        public TinhLuong()
        {
            db = DBMain.getInstance();
        }

        public DataSet LayTTTL()
        {
            return db.ExecuteQueryDataSet("uspGetLayTTTL", CommandType.StoredProcedure);
            
        }

        public bool ThemNhanVien(string MaNV, string TenNV, ref string error)
        {
            string sqlString;
            sqlString = $"Insert into TinhLuong values('{MaNV}', N'{TenNV}',N'{0}',N'{0}')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        //public bool ThemNhanVien(
                
        //    string MaNV,
        //    string HoNV,
        //    string TenNV,
        //    bool Nu,
        //    DateTime NgaySinh,
        //    int SDT,
        //    DateTime NgayBD,
        //    byte HinhAnh,
        //    TimeSpan GioIn,
        //    TimeSpan GioOut,
        //    ref string error)

        //{
        //    return db.MyExecuteNonQuery("uspInsertNhanVien",CommandType.StoredProcedure,ref error,
        //        new SqlParameter("@MaNV",MaNV),
        //        new SqlParameter("@HoNV", HoNV),
        //        new SqlParameter("@TenNV", TenNV),
        //        new SqlParameter("@Nu", Nu),
        //        new SqlParameter("@NgaySinh", NgaySinh),
        //        new SqlParameter("@SDT", SDT),
        //        new SqlParameter("@NgayBD", NgayBD),
        //        new SqlParameter("@HinhAnh", HinhAnh),
        //        new SqlParameter("@GioIn", GioIn),
        //        new SqlParameter("@GioOut", GioOut));
        //}
            
       

        public bool TinhLuongNhanVien(string MaNV, float sogiolam,float luong, ref string error)
        {
            string sqlString;
            try
            {
                sqlString = "Update TinhLuong Set SoGioLam=N'" + sogiolam + "',Luong=N'" + luong + "' Where MaNV= '" + MaNV + "'";
            }
            catch (SqlException)
            {
                error = "Tính lương không được";
                return false;
            }
            error = "Tính lương thành công";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool ReStartL(string MaNV,ref string error)
        {
            string sqlString = "Update TinhLuong Set SoGioLam=N'" + 0+ "',Luong =N'" + 0 + "' Where MaNV= '" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);

        }
        
        public void LayDuLieu(string MaNV,ref TimeSpan dl1,ref TimeSpan dl2)
        {
            string sqlString1 = "Select GioIn from ChamCong where MaNV ='" + MaNV + "'";

            string sqlString2 = "Select GioOut from ChamCong where MaNV ='" + MaNV + "'";
            db.LayTime(sqlString1, sqlString2, CommandType.Text, ref dl1, ref dl2);

            return;



        }
        public bool XoaNV(string MaNV, ref string error)
        {
            //string sqlString = $"delete from TinhLuong where MaNV = '{MaNV}'";

            //return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);

            return db.MyExecuteNonQuery("uspDeleteNhanVien", CommandType.StoredProcedure, ref error, new SqlParameter("MaNV", MaNV));

        }

        public void LaySoTime(string MaNV, ref float SoTime)
        {
            string sqlString = "Select SoGioLam from TinhLuong where MaNV ='" + MaNV + "'";
            try { db.LaySoTime(sqlString, CommandType.Text, ref SoTime); }
            catch { }
            return;


            //return db.MyExecuteNonQuery("uspGetLaySoTime", CommandType.StoredProcedure,
            //    ref SoTime, new SqlParameter("MaNV", MaNV));

        }
    }
}
