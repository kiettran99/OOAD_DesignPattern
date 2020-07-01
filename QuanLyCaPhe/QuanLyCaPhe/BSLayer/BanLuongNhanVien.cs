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

        public BanLuongNhanVien()
        {
           
        }

        public DataSet LayLuongNv()
        {
            return DBMain.getInstance().ExecuteQueryDataSet("select * from view_BanLuongChoNhanVien", CommandType.Text);

        }

    }
}
