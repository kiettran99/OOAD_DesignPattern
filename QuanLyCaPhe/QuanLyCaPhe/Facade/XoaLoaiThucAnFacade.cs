using QuanLyCaPhe.BSLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPhe.Facade
{
    class XoaLoaiThucAnFacade
    {
        private LoaiThucAn loaiThucAn;
        private ThucAn thucAn;

        public XoaLoaiThucAnFacade(LoaiThucAn loaiThucAn, ThucAn thucAn)
        {
            this.loaiThucAn = loaiThucAn;
            this.thucAn = thucAn;
        }

        public bool XoaLoaiThucAn(string MaDanhMuc, ref string error)
        {
            bool isSuccess = false;

            //Xóa các thức ăn thuộc loại danh mục đang muốn xóa.
            isSuccess = this.thucAn.XoaThucAnTheoLoai(MaDanhMuc, ref error);

            //Xóa loại thức ăn khi tất cả món ăn vừa được xóa.
            isSuccess = this.loaiThucAn.XoaDanhMuc(MaDanhMuc, ref error);

            return isSuccess;
        }
    }
}
