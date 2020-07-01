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
    class ChamCong
    {
        public ChamCong()
        {

        }

        public DataSet LayTT()
        {
            return DBMain.getInstance().ExecuteQueryDataSet("select * from ChamCong", CommandType.Text);
        }
        public bool ThemNhanVien(string MaNV,  string TenNV, ref string error)
        {
            string sqlString;           
            sqlString = $"Insert into ChamCong values('{MaNV}', N'{TenNV}',N'{0:0:0}',N'{0:0:0}')";          
            return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool XoaNhanVien(string MaNV, ref string error)
        {
            string sqlString = $"delete from ChamCong where MaNV = '{MaNV}'";
            return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }

        public bool ChamCongNhanVien(string MaNV, TimeSpan timein,TimeSpan timeout,  ref string error)
        {
            
            string sqlString;
            try
            {
                sqlString = "Update ChamCong Set GioIn=N'" + timein + "',GioOut=N'" + timeout +"' Where MaNV= '" + MaNV + "'";
            }
            catch (SqlException)
            {
                error = "Sửa không được";
                return false;
            }
            error = "Sửa thành công";
            return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool BoChamCong(string MaNV,ref string err)
        {
            TimeSpan time = new TimeSpan();
            time = TimeSpan.Zero;
            string sqlString = "Update ChamCong Set GioIn=N'" + time + "',GioOut=N'" + time + "' Where MaNV= '" + MaNV + "'";
            return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
      
    }
}
