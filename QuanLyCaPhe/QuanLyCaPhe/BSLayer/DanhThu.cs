using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCaPhe.DBLayer;
using System.Data;

namespace QuanLyCaPhe.BSLayer
{
    public class DanhThu
    {
        private DateTime ngayTaoHoaDon;
        private DateTime ngayKetThucHoaDon;
        private readonly DBMain db;

        public DanhThu()
        {
            db = DBMain.getInstance();
        }

        public DanhThu(DateTime ngayTaoHoaDon, DateTime ngayKetThucHoaDon)
        {
            db = DBMain.getInstance();
            this.ngayTaoHoaDon = ngayTaoHoaDon;
            this.ngayKetThucHoaDon = ngayKetThucHoaDon;
        }

        public DateTime NgayTaoHoaDon
        {
            get
            {
                return this.ngayTaoHoaDon;
            }
            set
            {
                this.ngayTaoHoaDon = value;
            }
        }

        public DateTime NgayKetThucHoaDon
        {
            get
            {
                return this.ngayKetThucHoaDon;
            }
            set
            {
                this.ngayKetThucHoaDon = value;
            }
        }

        /// <summary>
        /// Lấy danh sách danh thu
        /// </summary>
        /// <param name="idBan"></param>
        public DataSet LayDanhThu()
        {
            string strSQL = $"select IDHoaDon, TenBan, NgayTaoHoaDon, NgayKetThucHoaDon, GiamGia,TongTien from HoaDon join BanAn on HoaDon.IDBanAn = BanAn.IDBanAn where HoaDon.TinhTrang = 1 and cast(NgayTaoHo" +
                $"aDon as date) >= '{ngayTaoHoaDon.Year}-{ngayTaoHoaDon.Month}-{ngayTaoHoaDon.Day}' and cast(NgayKetthucHoaDon as Date) <= '{ngayKetThucHoaDon.Year}-{ngayKetThucHoaDon.Month}-{ngayKetThucHoaDon.Day} '";
            return db.ExecuteQueryDataSet(strSQL, CommandType.Text);
        }     
        
    }
}
