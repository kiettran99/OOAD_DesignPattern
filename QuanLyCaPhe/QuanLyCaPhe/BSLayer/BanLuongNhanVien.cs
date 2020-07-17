using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCaPhe.DBLayer;
namespace QuanLyCaPhe.BSLayer
{
  public  class BanLuongNhanVien
    {
        private readonly DBMain db;

        public BanLuongNhanVien()
        {
            db = DBMain.getInstance();
        }

        public DataSet LayLuongNv()
        {
            return db.ExecuteQueryDataSet("select * from view_BanLuongChoNhanVien", CommandType.Text);

        }

    }
}
