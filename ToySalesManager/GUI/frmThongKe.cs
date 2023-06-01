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
    public partial class frmThongKe : Form
    {
        private string path = Environment.CurrentDirectory + @"\SanPham\";
        public frmThongKe()
        {
            InitializeComponent();
        }

        public void DoanhThu()
        {
            DataTable dt = new DataTable();
            DataTable dtgia = new DataTable();

            HoaDonDTO hd1 = new HoaDonDTO();
            HoaDonDTO hd2 = new HoaDonDTO();
            DateTime dtn = DateTime.Now;
            hd1.Ngaylap = dtn.ToString("MM/dd/yyyy");
            hd2.Ngaylap = dtn.ToString("MM/dd/yyyy");
            dt = HoaDonDAO.DoanhThu(hd1, hd2);
            dtgia = HoaDonDAO.LoiNhuan(hd1, hd2);

            if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][1].ToString() == "")
            {
                lblorder.Text = "0";
                lblrevenue.Text = "0 VND";
                lblprofit.Text = "0 VND";
            }
            else
            {
                int tongtien = int.Parse(dt.Rows[0][0].ToString());
                lblrevenue.Text = string.Format("{0:#,##0}", tongtien) + " VND";
                lblorder.Text = dt.Rows[0][1].ToString();
                int giabangoc = int.Parse(dtgia.Rows[0][0].ToString());
                int loinhuan = tongtien - giabangoc;
                lblprofit.Text = string.Format("{0:#,##0}", loinhuan) + " VND";
            }
        }
        public void BieuDo()
        {
            DataTable dt = new DataTable();
            HoaDonDTO hd1 = new HoaDonDTO();
            HoaDonDTO hd2 = new HoaDonDTO();

            DateTime dtn = DateTime.Now;
            hd1.Ngaylap = dtn.ToString("MM/dd/yyyy");
            hd2.Ngaylap = dtn.ToString("MM/dd/yyyy");
            dt = HoaDonDAO.BieuDo(hd1,hd2);

            if(dt.Rows.Count==0)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

                chart1.Series["Series1"].XValueMember = "NgayLap";
                chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                chart1.Series["Series1"].Points.AddXY(dtn, 0);
                chart1.Series["Series1"].Color = Color.FromArgb(250, 100, 0);
            }
            else
            {
                chart1.DataSource = dt;
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

                chart1.Series["Series1"].XValueMember = "NgayLap";
                chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                chart1.Series["Series1"].YValueMembers = "TongTien";
                chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chart1.Series["Series1"].Color = Color.FromArgb(250, 100, 0);
                //chart1.Series["Series1"].LabelFormat = "{0:#,##0} VND";
            }
        }

        public void LOAD_TOPSP()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.SPMUA_NhieuNhat();
          
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel pn = new Panel();
                pn.Width = 310; pn.Height = 100;
                pn.Dock = DockStyle.Top;
                pn.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pic = new PictureBox();
                pic.Width = 100; pic.Height = 100;

                try
                {
                    pic.Load(path + "sanpham" + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(path + "null.jpg");
                }

                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Dock = DockStyle.Left;

                Panel pnname = new Panel();
                pnname.Width = 200; pnname.Height = 100;
                pnname.Dock = DockStyle.Right;
                pnname.BackColor = Color.FromArgb(250, 100, 0);

                Label lblten = new Label();
                lblten.Text = dt.Rows[i][1].ToString();
                lblten.ForeColor = Color.White;
                lblten.TextAlign = ContentAlignment.MiddleCenter;
                lblten.Width = 200; lblten.Height = 60;
                lblten.Font = new System.Drawing.Font("Segoe UI", 10F,FontStyle.Bold);
                lblten.Location = new Point(0, 5);


                Label lblgia = new Label();
                lblgia.Text = string.Format("{0:#,##0 VND}", int.Parse(dt.Rows[i][2].ToString()));
                lblgia.ForeColor = Color.Red;
                lblgia.Location = new Point(50, 65);
                lblgia.TextAlign = ContentAlignment.MiddleCenter;
                lblgia.ForeColor = Color.White;
                lblgia.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);

                pn.Controls.Add(pic);
                pn.Controls.Add(pnname);

                pnname.Controls.Add(lblten);
                pnname.Controls.Add(lblgia);

                flptopsp.Controls.Add(pn);
            }
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            DoanhThu();
            BieuDo();
            LOAD_TOPSP();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DataTable dtbd = new DataTable();
            DataTable dtdthu = new DataTable();
            DataTable dtgia = new DataTable();
            HoaDonDTO hd1 = new HoaDonDTO();
            HoaDonDTO hd2 = new HoaDonDTO();

            hd1.Ngaylap = dtNgay1.Value.ToString("MM/dd/yyyy");
            hd2.Ngaylap = dtNgay2.Value.ToString("MM/dd/yyyy");
            dtbd = HoaDonDAO.BieuDo(hd1, hd2);
            dtdthu = HoaDonDAO.DoanhThu(hd1, hd2);
            dtgia = HoaDonDAO.LoiNhuan(hd1, hd2);

            if (dtbd.Rows.Count == 0)
            {
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

                chart1.Series["Series1"].XValueMember = "NgayLap";
                chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                //loi
                chart1.Series["Series1"].Points.AddXY(hd1.Ngaylap, 0);
                chart1.Series["Series1"].Points.AddXY(hd2.Ngaylap, 0);
                chart1.Series["Series1"].Color = Color.FromArgb(250, 100, 0);
            }
            else
            {
                chart1.DataSource = dtbd;
                chart1.ChartAreas["ChartArea1"].AxisY.Title = "Doanh Thu";
                chart1.ChartAreas["ChartArea1"].AxisX.Title = "Ngày Bán";

                chart1.Series["Series1"].XValueMember = "NgayLap";
                chart1.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;

                chart1.Series["Series1"].YValueMembers = "TongTien";
                chart1.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            }
            
            //doanhthu va loi nhuan
            if (dtdthu.Rows[0][0].ToString() == "" || dtdthu.Rows[0][1].ToString() == "")
            {
                lblorder.Text = "0";
                lblrevenue.Text = "0 VND";
                lblprofit.Text = "0 VND";
            }
            else
            {
                //doanh thu
                int tongtien = int.Parse(dtdthu.Rows[0][0].ToString());
                lblrevenue.Text = string.Format("{0:#,##0}", tongtien) + " VND";
                lblorder.Text = dtdthu.Rows[0][1].ToString();
                //loi nhuan
                int giabangoc = int.Parse(dtgia.Rows[0][0].ToString());
                int loinhuan = tongtien - giabangoc;
                lblprofit.Text = string.Format("{0:#,##0}", loinhuan) + " VND";
            }
        }

        private void btnXuatTK_Click(object sender, EventArgs e)
        {
            frmCrysTK rp = new frmCrysTK();
            rp.tungay = dtNgay1.Value.ToString("MM/dd/yyyy");
            rp.denngay = dtNgay2.Value.ToString("MM/dd/yyyy");
            rp.Show();
        }
    }
}
