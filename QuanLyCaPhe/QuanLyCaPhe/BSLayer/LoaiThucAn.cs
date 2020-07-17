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
        string err = "";
        private readonly DBMain db;

        public LoaiThucAn()
        {
            db = DBMain.getInstance();
        }

        public DataSet LayLoaiThucAn()
        {
            return db.ExecuteQueryDataSet("select *from LoaiThucAn where isDelete = 0", CommandType.Text);
        }

        public DataSet LayDanhMuc()
        {
            return db.ExecuteQueryDataSet("Read_LoaiThucAn", CommandType.StoredProcedure);
        }

        public string TimIDTheoTenLoaiThucAn(string TenLoaiThucAn)
        {
            return db.FirstRowQuery($"select * from dbo.ufnTimIDTheoTenLoaiThucAn(N'{TenLoaiThucAn}')", CommandType.Text, ref err).ToString();
        }

        public object MaxID()
        {
            return db.FirstRowQuery($"select max(IDLoaiThucAN) from LoaiThucAn", CommandType.Text, ref err);
        }

        public bool ThemDanhMuc(string MaDanhMuc, string TenDanhMuc, ref string error)
        {
            try
            {
                if (db.FirstRowQuery($"select * from LoaiThucAn where isDelete = 1 and TenLoaiThucAn = N'{TenDanhMuc}'", CommandType.Text, ref error) != null)
                {
                    return db.MyExecuteNonQuery($"update LoaiThucAn set isDelete = 0 where TenLoaiThucAn = N'{TenDanhMuc}'", CommandType.Text, ref error);
                }
                else
                {
                    return db.MyExecuteNonQuery("Create_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc), new SqlParameter("@TenLoaiThucAn", TenDanhMuc), new SqlParameter("@isDelete", false));
                }
          
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
                f = db.MyExecuteNonQuery("Update_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc), new SqlParameter("@TenLoaiThucAn", TenDanhMuc));
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
            return db.MyExecuteNonQuery($"update LoaiThucAn set isDelete = 1 where IDLoaiThucAn ={MaDanhMuc}", CommandType.Text, ref error);
           // return db.MyExecuteNonQuery("Delete_LoaiThucAn", CommandType.StoredProcedure, ref error, new SqlParameter("@IDLoaiThucAn", MaDanhMuc));
        }
    }
}
