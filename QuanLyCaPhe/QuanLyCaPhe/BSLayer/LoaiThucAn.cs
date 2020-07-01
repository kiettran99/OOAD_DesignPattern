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
    public class LoaiThucAn
    {
        DBMain dbMain = null;
        string err = "";

        public LoaiThucAn()
        {
            dbMain = new DBMain();
        }

        public DataSet LayLoaiThucAn()
        {
            return dbMain.ExecuteQueryDataSet("select *from LoaiThucAn", CommandType.Text);
        }

        public DataSet LayDanhMuc()
        {
            return dbMain.ExecuteQueryDataSet("Read_LoaiThucAn", CommandType.StoredProcedure);
        }

        public string TimIDTheoTenLoaiThucAn(string TenLoaiThucAn)
        {
            return dbMain.FirstRowQuery($"select * from dbo.ufnTimIDTheoTenLoaiThucAn(N'{TenLoaiThucAn}')", CommandType.Text, ref err).ToString();
        }

        public bool ThemDanhMuc(string MaDanhMuc, string TenDanhMuc, ref string error)
        {
            try
            {
                return dbMain.MyExecuteNonQuery("Create_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc), new SqlParameter("@TenLoaiThucAn", TenDanhMuc));
            }
            catch (SqlException err)
            {
                error = err.Message;
                return false;
            }
        }
        public bool SuaDanhMuc(string MaDanhMuc, string TenDanhMuc, ref string error)
        {
            bool f = false;
            try
            {
                f = dbMain.MyExecuteNonQuery("Update_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc), new SqlParameter("@TenLoaiThucAn", TenDanhMuc));
                error = "Sửa thành công";
                return f;
            }
            catch (SqlException)
            {
                error = "Sửa không được";
                return f;
            }


        }
        public bool XoaDanhMuc(string MaDanhMuc, ref string error)
        {
            //string sqlString = $"delete from LoaiThucAn where MaThucAn = '{MaDanhMuc}'";
            //return dbMain.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            return dbMain.MyExecuteNonQuery("Delete_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc));
        }
    }
}
