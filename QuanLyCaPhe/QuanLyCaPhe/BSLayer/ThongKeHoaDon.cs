using QuanLyCaPhe.DBLayer;
using System;
using System.Data;

namespace QuanLyCaPhe.BSLayer
{
    public class ThongKeHoaDon
    {
        string err = "";
        private readonly DBMain db;

        private int iDHoaDon;
        private int maNV;
        private string tenNV;
        private string tenKH;
        private DateTime ngayBan;
        private float thanhTien;

        public int IDHoaDon { get; set; }
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string TenKH { get; set; }
        public DateTime NgayBan { get; set; }
        public float ThanhTien { get; set; }

        public ThongKeHoaDon()
        {
            db = DBMain.getInstance();
        }

        public ThongKeHoaDon(int iDHoaDon,
        int maNV,
        string tenNV,
        string tenKH,
        DateTime ngayBan,
        float thanhTien)
        {
            this.iDHoaDon = iDHoaDon;
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.tenKH = tenKH;
            this.ngayBan = ngayBan;
            this.thanhTien = thanhTien;
            db = DBMain.getInstance();
        }

        public DataSet LayThongKeHoaDon()
        {
            return db.ExecuteQueryDataSet("select * from view_HoaDonBan", CommandType.Text);
        }

        public DataSet LayThongKeHoaDonTheoNhanVien()
        {
            return db.ExecuteQueryDataSet($"select IDHoaDon, TenNV, TenKH, NgayBan, ThanhTien from NhanVien_HoaDon_KhachHang where MaNV = {maNV}", CommandType.Text);
        }

        public void ThemThongKeHoaDon()
        {
            db.MyExecuteNonQuery($"insert into NhanVien_HoaDon_KhachHang values({iDHoaDon}, {maNV}, N'{tenNV}', N'{tenKH}', N'{ngayBan.ToString("yyyy-MM-dd HH:mm:ss")}', {thanhTien})", CommandType.Text, ref err);
        }

    }
}
