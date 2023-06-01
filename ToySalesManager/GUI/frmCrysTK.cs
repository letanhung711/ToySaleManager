using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToySalesManager.DAO;
using ToySalesManager.DTO;

namespace ToySalesManager.GUI
{
    public partial class frmCrysTK : Form
    {
        public frmCrysTK()
        {
            InitializeComponent();
        }

        public string tungay, denngay;

        private void frmCrysTK_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            HoaDonDTO hd1 = new HoaDonDTO();
            HoaDonDTO hd2 = new HoaDonDTO();

            string dttungay = DateTime.Parse(tungay).ToString("MM/dd/yyyy");
            string dtdenngay = DateTime.Parse(denngay).ToString("MM/dd/yyyy");
            hd1.Ngaylap = dttungay;
            hd2.Ngaylap = dtdenngay;

            dt = HoaDonDAO.CrysTK(hd1, hd2);
            CrysTK cry = new CrysTK();
            cry.SetDataSource(dt);
            cry.SetParameterValue("TuNgay", tungay);
            cry.SetParameterValue("DenNgay", denngay);
            crysTK.ReportSource = cry;
        }
    }
}
