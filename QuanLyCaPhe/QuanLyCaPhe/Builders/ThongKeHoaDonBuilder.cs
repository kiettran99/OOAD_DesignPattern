using QuanLyCaPhe.BSLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPhe.Builders
{
    public class ThongKeHoaDonBuilder
    {
        private int iDHoaDon;
        private int maNV;
        private string tenNV;
        private string tenKH;
        private DateTime ngayBan;
        private float thanhTien;

        public ThongKeHoaDonBuilder taoIDHoaDon(int iDHoaDon)
        {
            this.iDHoaDon = iDHoaDon;
            return this;
        }

        public ThongKeHoaDonBuilder taoMaNV(int maNV)
        {
            this.maNV = maNV;
            return this;
        }
        public ThongKeHoaDonBuilder taoTenNV(string tenNV)
        {
            this.tenNV = tenNV;
            return this;
        }
        public ThongKeHoaDonBuilder taotenKH(string tenKH)
        {
            this.tenKH = tenKH;
            return this;
        }
        public ThongKeHoaDonBuilder taoNgayBan(DateTime ngayBan)
        {
            this.ngayBan = ngayBan;
            return this;
        }
        public ThongKeHoaDonBuilder taoThanhTien(float thanhTien)
        {
            this.thanhTien = thanhTien;
            return this;
        }

        public ThongKeHoaDon Build()
        {
            return new ThongKeHoaDon(iDHoaDon,maNV, tenNV,tenKH, ngayBan, thanhTien);
        }
    }
}
