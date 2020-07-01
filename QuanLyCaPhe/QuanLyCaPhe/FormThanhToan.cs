using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaPhe
{
    public partial class FormThanhToan : Form
    {
        public int idHD;

        public FormThanhToan()
        {
            InitializeComponent();
        }

        public FormThanhToan(int idhoadon)
        {
            InitializeComponent();
            this.idHD = idhoadon;
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyCaPheDataSet.ChiTietHoaDon_Report' table. You can move, or remove it, as needed.
            this.ChiTietHoaDon_ReportTableAdapter.Fill(this.QuanLyCaPheDataSet.ChiTietHoaDon_Report, idHD);

            this.reportViewer1.RefreshReport();
        }
    }
}
