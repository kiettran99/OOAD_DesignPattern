using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCaPhe.DBLayer;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Build.Tasks;

namespace QuanLyCaPhe.BSLayer
{
    class ThucAn
    {
        DBMain dbMain = null;
        string err = "";
        public ThucAn()
        {
            dbMain = new DBMain();
        }

        public DataSet LayThucAn()
        {
            //return dbMain.ExecuteQueryDataSet("select *from ThucAn", CommandType.Text);

          return dbMain.ExecuteQueryDataSet("uspGetLayThucAn", CommandType.StoredProcedure);
        }

        public DataSet LayThucAnTheoLoai(string tenLoaiThucAn)
        {

            //return dbMain.ExecuteQueryDataSet($"select * from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn where TenLoaiThucAn = N'{tenLoaiThucAn}'", CommandType.Text);
            return dbMain.ExecuteQueryDataSet("uspGetLayThucAn_ByTenLoaiThucAn", CommandType.StoredProcedure, new SqlParameter("@TenLoaiThucAn", tenLoaiThucAn));
        }

        //public bool ThemThucAn(string MaThucAn, string DanhMuc, float Gia, string TenMon)
        //{
        //    string sqlString;
        //    try
        //    {
        //        sqlString = $"Insert into ThucAn values(N'{MaThucAn.Trim()}',  N'{TenMon.ToString()}', N'{DanhMuc.Trim()}', '{Gia}')";
        //        err = "Thêm thành công";
        //    }
        //    catch (SqlException)
        //    {
        //        err = "Thêm không được";
        //        return false;
        //    }

        //    return dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}
        

        public bool ThemThucAn(string MaThucAn, string DanhMuc, float Gia, string TenMon)
        {
            try
            {
                return dbMain.MyExecuteNonQuery("Create_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
                err = "Thêm thành công";
            }
            catch (SqlException err1)
            {
                err = err1.Message;
                return false;
            }
        }
        public bool SuaThucAn(string MaThucAn, string DanhMuc, float Gia, string TenMon)
        {
            bool f = false;
            try
            {
                f = dbMain.MyExecuteNonQuery("Update_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
                err = "Sửa thành công";
                return f;
            }
            catch (SqlException)
            {
                err = "Sửa không được";
                return f;
            }
        }
        //public bool SuaThucAn(ref string error,
        //   int IDHoaDon,
        //  int IDThucAn,
        // string TenThucAn,
        //int IDLoaiThucAn,
        //float Gia,
        //string TenLoaiThucAn,
        //int SoLuong)
        //{     
        //    return dbMain.MyExecuteNonQuery("uspUpdateThucAn", CommandType.StoredProcedure, ref error,
        //            new SqlParameter("@IDHoaDon", IDHoaDon),
        //            new SqlParameter("@IDThucAn", IDThucAn),
        //            new SqlParameter("@TenThucAn", TenThucAn),
        //            new SqlParameter("@IDLoaiThucAn", IDLoaiThucAn),
        //            new SqlParameter("@Gia", Gia),
        //            new SqlParameter("@TenLoaiThucAn", TenLoaiThucAn),
        //            new SqlParameter("@SoLuong", SoLuong));
        //}
        public bool XoaThucAn(string MaThucAn, ref string error)
        {
            //string sqlString = $"delete from ThucAn where IDThucAn = '{MaThucAn}'";
            //return dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);

            return dbMain.MyExecuteNonQuery("uspDeleteThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("IDThucAn", MaThucAn));
        }

        public int TimIDThucAn(string tenThucAn)
        {
            return Convert.ToInt32(dbMain.FirstRowQuery($"select * from dbo.ufnTimIDThucAn(N'{tenThucAn}')", CommandType.Text, ref err));
        }

        public int TimMaxIDThucAn()
        {
            return (int)dbMain.FirstRowQuery($"select * from dbo.ufnTimMaxIDThucAn()", CommandType.Text, ref err);
        }

        public DataSet TimKimF(string TenThucAn)
        {
            return dbMain.ExecuteQueryDataSet($"select * from dbo.ufnTimFThucAn(N'{TenThucAn}')", CommandType.Text);
        }
    }

}
