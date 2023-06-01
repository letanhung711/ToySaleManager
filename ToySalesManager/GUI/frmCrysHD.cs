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
    public partial class frmCrysHD : Form
    {
        public int sohd;
        public frmCrysHD()
        {
            InitializeComponent();
        }

        private void frmCrysHD_Load(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO();
            DataTable dt = new DataTable();
            hd.Sohd = sohd;
            dt = HoaDonDAO.CrysHD(hd);
            CrysHD cry = new CrysHD();
            cry.SetDataSource(dt);
            crysHD.ReportSource = cry;
        }
    }
}
