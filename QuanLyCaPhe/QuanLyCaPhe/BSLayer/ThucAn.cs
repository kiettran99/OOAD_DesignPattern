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
        private readonly DBMain db;
        public ThucAn()
        {
            db = DBMain.getInstance();
        }

        public DataSet LayThucAn()
        {
            return db.ExecuteQueryDataSet("select * from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn where ThucAn.isDelete = 0", CommandType.Text);

            //return db.ExecuteQueryDataSet("uspGetLayThucAn", CommandType.StoredProcedure);
        }

        public DataSet LayThucAnTheoLoai(string tenLoaiThucAn)
        {

            return db.ExecuteQueryDataSet($"select * from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn where TenLoaiThucAn = N'{tenLoaiThucAn}' and ThucAn.isDelete = 0", CommandType.Text);
            //return db.ExecuteQueryDataSet("uspGetLayThucAn_ByTenLoaiThucAn", CommandType.StoredProcedure, new SqlParameter("@TenLoaiThucAn", tenLoaiThucAn));
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

        //    return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        //}


        public bool ThemThucAn(string MaThucAn, string DanhMuc, float Gia, string TenMon)
        {
            try
            {
                if (db.FirstRowQuery($"select * from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn where ThucAn.isDelete = 1 and ThucAn.TenThucAn = N'{TenMon}'", CommandType.Text, ref err) != null)
                {
                    return db.MyExecuteNonQuery($"update ThucAn set isDelete = 0 where TenThucAn = N'{TenMon}'", CommandType.Text, ref err);
                }
                else
                {
                    err = "Thêm thành công";
                    return db.MyExecuteNonQuery("Create_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
                }                    
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
                f = db.MyExecuteNonQuery("Update_ThucAn", CommandType.StoredProcedure, ref err, new SqlParameter("@IDThucAn", MaThucAn), new SqlParameter("@IDLoaiThucAn", DanhMuc), new SqlParameter("@Gia", Gia), new SqlParameter("@TenMonAn", TenMon));
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
        //    return db.MyExecuteNonQuery("uspUpdateThucAn", CommandType.StoredProcedure, ref error,
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
            string sqlString = $"update ThucAn set isDelete = 1 where IDThucAn = {MaThucAn}";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            //return db.MyExecuteNonQuery("uspDeleteThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("IDThucAn", MaThucAn));
        }

        public bool XoaThucAnTheoLoai(string MaDanhMuc, ref string error)
        {
            return db.MyExecuteNonQuery($"update ThucAn set isDelete = 1 where IDLoaiThucAn={MaDanhMuc}", CommandType.Text, ref error);
        }

        public int TimIDThucAn(string tenThucAn)
        {
            return Convert.ToInt32(db.FirstRowQuery($"select * from dbo.ufnTimIDThucAn(N'{tenThucAn}')", CommandType.Text, ref err));
        }

        public int TimMaxIDThucAn()
        {
            return (int)db.FirstRowQuery($"select * from dbo.ufnTimMaxIDThucAn()", CommandType.Text, ref err);
        }

        public DataSet TimKimF(string TenThucAn)
        {
            return db.ExecuteQueryDataSet($"select * from dbo.ufnTimFThucAn(N'{TenThucAn}')", CommandType.Text);
        }
    }

}
