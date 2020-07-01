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
    class KhachHang
    {

        public KhachHang()
        {

        }

        public DataSet LayKhachHang()
        {
            //string strSQL = "select * from KhachHang";
            //return DBMain.getInstance().ExecuteQueryDataSet(strSQL, CommandType.Text);
            return DBMain.getInstance().ExecuteQueryDataSet("Read_KhachHang", CommandType.StoredProcedure);

        }

        public bool ThemKhachHang(string maKhachHang, string hoKhachHang, string tenKhachHang, string soDienThoai, string diachi, string gioiTinh, DateTime ngaySinh, int MaThanhPho, ref string error)
        {
            //string strSQL = $"insert into KhachHang values('{maKhachHang.Trim()}', '{hoKhachHang.Trim()}', '{tenKhachHang.Trim()}', '{gioiTinh.Trim()}','{ngaySinh.ToShortDateString()}', '{soDienThoai.Trim()}', '{diachi.Trim()}')";
            //return DBMain.getInstance().MyExecuteNonQuery(strSQL, CommandType.Text, ref error);
            return DBMain.getInstance().MyExecuteNonQuery("Create_KhachHang", CommandType.StoredProcedure, ref error, new SqlParameter("@MaKH", maKhachHang),
                new SqlParameter("@HoKH", hoKhachHang), new SqlParameter("@TenKH", tenKhachHang),
                new SqlParameter("@GioiTinh", gioiTinh), new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@SDT", soDienThoai), new SqlParameter("@DiaChi", diachi), new SqlParameter("@MaThanhPho", MaThanhPho));
        }

        public bool SuaKhachHang(string maKhachhang, string hoKhachHang, string tenKhachHang, string soDienThoai, string diachi, string gioiTinh, DateTime ngaySinh, int MaThanhPho, ref string error)
        {
            //string strSQL = $"update KhachHang set HoKH = '{hoKhachHang}', TenKH = '{tenKhachHang}', GioiTinh = '{gioiTinh}', NgaySinh = '{ngaySinh.ToShortDateString()}', SDT = '{soDienThoai}', DiaChi = '{diachi}' where MAKH = '{maKhachhang}'";
            //return DBMain.getInstance().MyExecuteNonQuery(strSQL, CommandType.Text, ref error);
            return DBMain.getInstance().MyExecuteNonQuery("Update_KhachHang", CommandType.StoredProcedure, ref error, new SqlParameter("@MaKH", maKhachhang),
                new SqlParameter("@HoKH", hoKhachHang), new SqlParameter("@TenKH", tenKhachHang),
                new SqlParameter("@GioiTinh", gioiTinh), new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@SDT", soDienThoai), new SqlParameter("@DiaChi", diachi), new SqlParameter("@MaThanhPho", MaThanhPho));
        }

        public bool XoaKhachHang(string MaKhachHang, ref string error)
        {
            //string sqlString = "Delete From KhachHang Where MaKH='" + MaKhachHang + "'";
            //return DBMain.getInstance().MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
            return DBMain.getInstance().MyExecuteNonQuery("Update_KhachHang", CommandType.StoredProcedure, ref error, new SqlParameter("@MaKH", MaKhachHang));
        }
    }
}
