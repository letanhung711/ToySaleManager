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
using ToySalesManager.BUS;

namespace ToySalesManager.GUI
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        void SoHD()
        {
            DataTable dt = new DataTable();
            dt = HoaDonDAO.SoHD();
            lblsohd.Text = dt.Rows[0][0].ToString();
        }
        void TT_HD()
        {
            DataTable dt = new DataTable();
            dt = HoaDonDAO.TTHD1();
            for (int i=0;i<dt.Rows.Count;i++)
            {
                lvhd.Items.Add(dt.Rows[i][0].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][6].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][5].ToString());

            }
            lblsohd.Text = dt.Rows.Count.ToString();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            TT_HD();
            //SoHD();
        }

        private void lvhd_Click(object sender, EventArgs e)
        {
            lvdh.Items.Clear();
            HoaDonDTO hd = new HoaDonDTO();
            DataTable dt = new DataTable();
            hd.Sohd = int.Parse(lvhd.SelectedItems[0].SubItems[0].Text);
            dt = HoaDonDAO.TTDH(hd);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                lvdh.Items.Add(dt.Rows[i][0].ToString());
                lvdh.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvdh.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                lvdh.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
            }
            lblhd.Text = lvhd.SelectedItems[0].SubItems[0].Text;

            KhachHangDTO kh = new KhachHangDTO();
            DataTable dtkh = new DataTable();
            kh.Hoten= lvhd.SelectedItems[0].SubItems[1].Text;
            dtkh = KhachHangDAO.SearchKH(kh);

            txtkh.Text = dtkh.Rows[0][1].ToString();
            txtdiachi.Text = dtkh.Rows[0][3].ToString();
            txtsdt.Text = dtkh.Rows[0][2].ToString();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            lvdh.Items.Clear();
            lvhd.Items.Clear();
            TT_HD();
            txtkh.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            lblhd.Text = "0";
            dtngay1.ResetText();
            dtngay2.ResetText();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            HoaDonDTO hd1 = new HoaDonDTO();
            HoaDonDTO hd2 = new HoaDonDTO();
            DataTable dt = new DataTable();
            hd1.Ngaylap = dtngay1.Value.ToString("MM/dd/yyyy");
            hd2.Ngaylap = dtngay2.Value.ToString("MM/dd/yyyy");
            dt = HoaDonDAO.SearchHD(hd1, hd2);
            lvhd.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvhd.Items.Add(dt.Rows[i][0].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][6].ToString());
                lvhd.Items[i].SubItems.Add(dt.Rows[i][5].ToString());

            }
            lvdh.Items.Clear();
            txtkh.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            lblhd.Text = "0";
            lblsohd.Text = dt.Rows.Count.ToString();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if(int.Parse(lblhd.Text)==0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmCrysHD rp = new frmCrysHD();
                rp.sohd = int.Parse(lblhd.Text);
                rp.Show();
            }
        }
    }
}
