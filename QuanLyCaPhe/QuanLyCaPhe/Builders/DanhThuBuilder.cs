using QuanLyCaPhe.BSLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPhe.Builders
{
    public class DanhThuBuilder
    {
        private DateTime ngayTaoHoaDon;
        private DateTime ngayKetThucHoaDon;

        public DanhThuBuilder TaoNgayTaoHoaDon(DateTime ngayTaoHoaDon)
        {
            this.ngayTaoHoaDon = ngayTaoHoaDon;
            return this;
        }

        public DanhThuBuilder TaoNgayKetThucHoaDon(DateTime ngayKetThucHoaDon)
        {
            this.ngayKetThucHoaDon = ngayKetThucHoaDon;
            return this;
        }

        public DanhThu Build()
        {
            return new DanhThu(ngayTaoHoaDon, ngayKetThucHoaDon);
        }
    }
}
