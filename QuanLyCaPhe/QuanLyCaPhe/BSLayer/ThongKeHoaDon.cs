using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCaPhe.DBLayer;

namespace QuanLyCaPhe.BSLayer
{
    public class ThongKeHoaDon
    {
        string err = "";

        public DataSet LayThongKeHoaDon()
        {
            return DBMain.getInstance().ExecuteQueryDataSet("select * from view_HoaDonBan", CommandType.Text);
        }

        public DataSet LayThongKeHoaDonTheoNhanVien(int MaNhanVien)
        {
            return DBMain.getInstance().ExecuteQueryDataSet($"select IDHoaDon, TenNV, TenKH, NgayBan, ThanhTien from NhanVien_HoaDon_KhachHang where MaNV = {MaNhanVien}", CommandType.Text);
        }

        public void ThemThongKeHoaDon(int IDHoaDon, int MaNV, string TenNV, string TenKH, DateTime NgayBan, float ThanhTien)
        {
            DBMain.getInstance().MyExecuteNonQuery($"insert into NhanVien_HoaDon_KhachHang values({IDHoaDon}, {MaNV}, N'{TenNV}', N'{TenKH}', N'{NgayBan.ToString("yyyy-MM-dd HH:mm:ss")}', {ThanhTien})", CommandType.Text, ref err);
        }

    }
}
