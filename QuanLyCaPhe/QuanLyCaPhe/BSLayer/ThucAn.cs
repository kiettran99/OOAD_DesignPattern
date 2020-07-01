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

        string err = "";
        public ThucAn()
        {

        }

        public DataSet LayThucAn()
        {
            //return DBMain.getInstance().ExecuteQueryDataSet("select *from ThucAn", CommandType.Text);

            return DBMain.getInstance().ExecuteQueryDataSet("uspGetLayThucAn", CommandType.StoredProcedure);
        }

        public DataSet LayThucAnTheoLoai(string tenLoaiThucAn)
        {

            //return DBMain.getInstance().ExecuteQueryDataSet($"select * from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn where TenLoaiThucAn = N'{tenLoaiThucAn}'", CommandType.Text);
            return DBMain.getInstance().ExecuteQueryDataSet("uspGetLayThucAn_ByTenLoaiThucAn", CommandType.StoredProcedure, new SqlParameter("@TenLoaiThucAn", tenLoaiThucAn));
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

        //    return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}


        public bool ThemThucAn(string MaThucAn, string DanhMuc, float Gia, string TenMon)
        {
            try
            {
                return DBMain.getInstance().MyExecuteNonQuery("Create_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
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
                f = DBMain.getInstance().MyExecuteNonQuery("Update_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
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
        //    return DBMain.getInstance().MyExecuteNonQuery("uspUpdateThucAn", CommandType.StoredProcedure, ref error,
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
            //return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);

            return DBMain.getInstance().MyExecuteNonQuery("uspDeleteThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("IDThucAn", MaThucAn));
        }

        public bool XoaThucAnTheoLoai(string MaDanhMuc, ref string error)
        {
            return DBMain.getInstance().MyExecuteNonQuery($"delete from ThucAn where IDLoaiThucAn={MaDanhMuc}", CommandType.Text, ref error);
        }

        public int TimIDThucAn(string tenThucAn)
        {
            return Convert.ToInt32(DBMain.getInstance().FirstRowQuery($"select * from dbo.ufnTimIDThucAn(N'{tenThucAn}')", CommandType.Text, ref err));
        }

        public int TimMaxIDThucAn()
        {
            return (int)DBMain.getInstance().FirstRowQuery($"select * from dbo.ufnTimMaxIDThucAn()", CommandType.Text, ref err);
        }

        public DataSet TimKimF(string TenThucAn)
        {
            return DBMain.getInstance().ExecuteQueryDataSet($"select * from dbo.ufnTimFThucAn(N'{TenThucAn}')", CommandType.Text);
        }
    }

}
