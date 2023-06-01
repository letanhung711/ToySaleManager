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
    public partial class frmBanSanPham : Form
    {
        private int sl;
        private string path = Environment.CurrentDirectory + @"\SanPham\";
        public frmBanSanPham()
        {
            InitializeComponent();
        }

        private string manv;
        public frmBanSanPham(string Ma_nv)
        {
            InitializeComponent();
            this.manv = Ma_nv;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttienkhtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // hàm kiểm tra số lượng
        int Kiemtra(string masp)
        {
            int sodong = lvgiohang.Items.Count;
            for (int i = 0; i < sodong; i++)
                if (masp == lvgiohang.Items[i].SubItems[5].Text)
                    return i;
            return -1;
        }

        void Combobox_LoaiSP()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTLoaiSP();
            cbloaisp.DataSource = dt;
            cbloaisp.DisplayMember = "TenloaiSP";
            cbloaisp.ValueMember = "MaloaiSP";
        }

        void Combobox_NCC()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTNCC();
            cbncc.DataSource = dt;
            cbncc.DisplayMember = "TenNCC";
            cbncc.ValueMember = "MaNCC";
        }

        void TongHD()
        {
            double tonghd = 0;
            for (int i = 0; i < lvgiohang.Items.Count; i++)
            {
                tonghd += double.Parse(string.Format("{0:D}", lvgiohang.Items[i].SubItems[4].Text));
            }
            lbltongHD.Text = string.Format("{0:#,##0} VND", tonghd);
        }

        public void Load_dsSP()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTSP();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel p = new Panel();
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Margin = new Padding(5, 5, 10, 5);
                p.Width = 145; p.Height = 185;
                
                //ten sp
                Label ten = new Label();
                ten.Height = 30;
                ten.Text = dt.Rows[i][1].ToString();
                ten.Dock = DockStyle.Top;
                ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                ten.ForeColor = Color.Black;
                ten.Font = new System.Drawing.Font("Segoe UI", 8.25F);

                //gia chua tinh km
                Label gia = new Label();
                gia.Height = 10;
                gia.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                gia.Dock = DockStyle.Bottom;
                gia.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                gia.ForeColor = Color.Black;
                gia.Font = new System.Drawing.Font("Segoe UI", 7F,(System.Drawing.FontStyle.Strikeout));

                //gia da tinh km
                Label giakm = new Label();
                if (int.Parse(dt.Rows[i][11].ToString()) == 0)
                {
                    giakm.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                }
                else
                {
                    int sokm = (100 - (int.Parse(dt.Rows[i][11].ToString()))) % 100;
                    long giadakm = (long.Parse(dt.Rows[i][8].ToString()) * sokm) / 100;
                    giakm.Text = string.Format("{0:n0} VND", giadakm);
                }
                giakm.Height = 20;
                giakm.Dock = DockStyle.Bottom;
                giakm.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                giakm.ForeColor = Color.FromArgb(250, 100, 0);

                //anh sp
                PictureBox pic = new PictureBox();
                pic.Width = 140; pic.Height = 100; // set kích thước của ảnh
                try
                {
                    pic.Load(path +"sanpham"+ dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(path + "null.jpg");
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Top;
                pic.Tag = dt.Rows[i][0].ToString();
                pic.Click += new EventHandler(Onclick); // sự kiện click

                //so luong sp
                Label sl = new Label();
                sl.Height = 20;
                sl.Text = "Sẵn có: " + dt.Rows[i][7].ToString();
                sl.Dock = DockStyle.Bottom;
                sl.TextAlign = ContentAlignment.MiddleRight;   // căn chữ
                sl.ForeColor = Color.Black;
                sl.Font = new System.Drawing.Font("Segoe UI",7F);
                //khuyen mai
                Label km = new Label();
                km.Left = 110;
                km.Size = new Size(30, 30);
                km.Text = dt.Rows[i][11].ToString()+"%";
                km.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                km.ForeColor = Color.White;
                km.BackColor = Color.Red;
                km.Font = new System.Drawing.Font("Segoe UI", 8.25F,(System.Drawing.FontStyle.Bold));

                p.Controls.Add(ten);    // add tên vào panel
                p.Controls.Add(gia);    // add giá vào panel
                p.Controls.Add(giakm);  // add giá da km vào panel
                p.Controls.Add(pic);    // add tên vào panel
                p.Controls.Add(sl);     // add sl vào panel
                pic.Controls.Add(km);   // add km vào panel
                flpSanpham.Controls.Add(p);  // add panel vào FlowlayoutPanel
            }
        }

        public void Onclick(object sender, EventArgs e)
        {
            string masp = ((PictureBox)sender).Tag.ToString();  // trả về mã sản phẩm khi click vào ảnh sp
            SanPhamDTO sp = new SanPhamDTO();
            sp.Masp = int.Parse(masp);
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTSP_MaSP(sp);
            int stt = lvgiohang.Items.Count;
            stt++;

            string tensp = dt.Rows[0][1].ToString();
            int soluong;
            string khuyenmai = dt.Rows[0][2].ToString();
            long dongia;

            if(int.Parse(khuyenmai)==0)
            {
                dongia= long.Parse(dt.Rows[0][3].ToString());
            }
            else
            {
                int sokm = (100 - (int.Parse(dt.Rows[0][2].ToString()))) % 100;
                long giadakm = (long.Parse(dt.Rows[0][3].ToString()) * sokm) / 100;
                dongia = giadakm;
            }

            if (Kiemtra(masp) == -1)
            {
                soluong = 1;
                lvgiohang.Items.Add(tensp);
                lvgiohang.Items[stt - 1].SubItems.Add(string.Format("{0:n0}", dongia));
                lvgiohang.Items[stt - 1].SubItems.Add(khuyenmai);
                lvgiohang.Items[stt - 1].SubItems.Add(soluong.ToString());
                lvgiohang.Items[stt - 1].SubItems.Add(string.Format("{0:n0}", (soluong * dongia)));
                lvgiohang.Items[stt - 1].SubItems.Add(masp);
            }
            else
            {
                int i = Kiemtra(masp);
                soluong = int.Parse(lvgiohang.Items[i].SubItems[3].Text);
                soluong++;
                lvgiohang.Items[i].SubItems[3].Text = soluong.ToString();

                lvgiohang.Items[i].SubItems[4].Text = string.Format("{0:n0}", (soluong * dongia));
                lvgiohang.Items[i].SubItems.Add(masp);
            }
            //tong hoa don
            TongHD();
        }

        private void frmBanSanPham_Load(object sender, EventArgs e)
        {
            Combobox_LoaiSP();
            Combobox_NCC();
            flpSanpham.Controls.Clear();
            Load_dsSP();

            cbloaisp.ResetText();
            cbncc.ResetText();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SanPhamDTO sp = new SanPhamDTO();
            sp.Tensp = txtsearchSP.Text;
            dt = SanPhamDAO.SearchSPbyMaSP(sp);
            flpSanpham.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel p = new Panel();
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Margin = new Padding(5, 5, 10, 5);
                p.Width = 145; p.Height = 185;

                //ten sp
                Label ten = new Label();
                ten.Height = 30;
                ten.Text = dt.Rows[i][1].ToString();
                ten.Dock = DockStyle.Top;
                ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                ten.ForeColor = Color.Black;
                ten.Font = new System.Drawing.Font("Segoe UI", 8.25F);

                //gia chua tinh km
                Label gia = new Label();
                gia.Height = 10;
                gia.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                gia.Dock = DockStyle.Bottom;
                gia.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                gia.ForeColor = Color.Black;
                gia.Font = new System.Drawing.Font("Segoe UI", 7F, (System.Drawing.FontStyle.Strikeout));

                //gia da tinh km
                Label giakm = new Label();
                if (int.Parse(dt.Rows[i][11].ToString()) == 0)
                {
                    giakm.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                }
                else
                {
                    int sokm = (100 - (int.Parse(dt.Rows[i][11].ToString()))) % 100;
                    long giadakm = (long.Parse(dt.Rows[i][8].ToString()) * sokm) / 100;
                    giakm.Text = string.Format("{0:n0} VND", giadakm);
                }
                giakm.Height = 20;
                giakm.Dock = DockStyle.Bottom;
                giakm.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                giakm.ForeColor = Color.FromArgb(250, 100, 0);

                //anh sp
                PictureBox pic = new PictureBox();
                pic.Width = 140; pic.Height = 100; // set kích thước của ảnh
                try
                {
                    pic.Load(path + "sanpham" + dt.Rows[i]["MaSP"] + ".jpg");
                }
                catch
                {
                    pic.Load(path + "null.jpg");
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Dock = DockStyle.Top;
                pic.Tag = dt.Rows[i][0].ToString();
                pic.Click += new EventHandler(Onclick); // sự kiện click

                //so luong sp
                Label sl = new Label();
                sl.Height = 20;
                sl.Text = "Sẵn có: " + dt.Rows[i][7].ToString();
                sl.Dock = DockStyle.Bottom;
                sl.TextAlign = ContentAlignment.MiddleRight;   // căn chữ
                sl.ForeColor = Color.Black;
                sl.Font = new System.Drawing.Font("Segoe UI", 7F);
                //khuyen mai
                Label km = new Label();
                km.Left = 110;
                km.Size = new Size(30, 30);
                km.Text = dt.Rows[i][11].ToString() + "%";
                km.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                km.ForeColor = Color.White;
                km.BackColor = Color.Red;
                km.Font = new System.Drawing.Font("Segoe UI", 8.25F, (System.Drawing.FontStyle.Bold));

                p.Controls.Add(ten);    // add tên vào panel
                p.Controls.Add(gia);    // add giá vào panel
                p.Controls.Add(giakm);  // add giá da km vào panel
                p.Controls.Add(pic);    // add tên vào panel
                p.Controls.Add(sl);     // add sl vào panel
                pic.Controls.Add(km);   // add km vào panel
                flpSanpham.Controls.Add(p);  // add panel vào FlowlayoutPanel
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtsearchSP.Clear();
            cbloaisp.ResetText();
            cbncc.ResetText();
            flpSanpham.Controls.Clear();
            Load_dsSP();
        }

        private void txttienkhtra_TextChanged(object sender, EventArgs e)
        {
            double tienthua = 0;
            string tonghd = lbltongHD.Text.Replace(",", "").Replace(" VND", "");
            
            if(txttienkhtra.Text == "")
            {
                return;
            }
            else
            {
                int tienkhtra = int.Parse(txttienkhtra.Text);
                tienthua = tienkhtra - int.Parse(tonghd);
                txttienthua.Text = string.Format("{0:n0}", tienthua);
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            try
            {
                lvgiohang.Items.RemoveAt(lvgiohang.SelectedIndices[0]);
                TongHD();

            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void cbloaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloaisp.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cbncc.ResetText();
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                sp.Maloaisp = int.Parse(cbloaisp.SelectedValue.ToString());
                dt = SanPhamDAO.SearchSPbyMaloaiSP(sp);
                flpSanpham.Controls.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel p = new Panel();
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Margin = new Padding(5, 5, 10, 5);
                    p.Width = 145; p.Height = 185;

                    //ten sp
                    Label ten = new Label();
                    ten.Height = 30;
                    ten.Text = dt.Rows[i][1].ToString();
                    ten.Dock = DockStyle.Top;
                    ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    ten.ForeColor = Color.Black;
                    ten.Font = new System.Drawing.Font("Segoe UI", 8.25F);

                    //gia chua tinh km
                    Label gia = new Label();
                    gia.Height = 10;
                    gia.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                    gia.Dock = DockStyle.Bottom;
                    gia.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    gia.ForeColor = Color.Black;
                    gia.Font = new System.Drawing.Font("Segoe UI", 7F, (System.Drawing.FontStyle.Strikeout));

                    //gia da tinh km
                    Label giakm = new Label();
                    if (int.Parse(dt.Rows[i][11].ToString()) == 0)
                    {
                        giakm.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                    }
                    else
                    {
                        int sokm = (100 - (int.Parse(dt.Rows[i][11].ToString()))) % 100;
                        long giadakm = (long.Parse(dt.Rows[i][8].ToString()) * sokm) / 100;
                        giakm.Text = string.Format("{0:n0} VND", giadakm);
                    }
                    giakm.Height = 20;
                    giakm.Dock = DockStyle.Bottom;
                    giakm.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                    giakm.ForeColor = Color.FromArgb(250, 100, 0);

                    //anh sp
                    PictureBox pic = new PictureBox();
                    pic.Width = 140; pic.Height = 100; // set kích thước của ảnh
                    try
                    {
                        pic.Load(path + "sanpham" + dt.Rows[i]["MaSP"] + ".jpg");
                    }
                    catch
                    {
                        pic.Load(path + "null.jpg");
                    }
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Dock = DockStyle.Top;
                    pic.Tag = dt.Rows[i][0].ToString();
                    pic.Click += new EventHandler(Onclick); // sự kiện click

                    //so luong sp
                    Label sl = new Label();
                    sl.Height = 20;
                    sl.Text = "Sẵn có: " + dt.Rows[i][7].ToString();
                    sl.Dock = DockStyle.Bottom;
                    sl.TextAlign = ContentAlignment.MiddleRight;   // căn chữ
                    sl.ForeColor = Color.Black;
                    sl.Font = new System.Drawing.Font("Segoe UI", 7F);
                    //khuyen mai
                    Label km = new Label();
                    km.Left = 110;
                    km.Size = new Size(30, 30);
                    km.Text = dt.Rows[i][11].ToString() + "%";
                    km.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    km.ForeColor = Color.White;
                    km.BackColor = Color.Red;
                    km.Font = new System.Drawing.Font("Segoe UI", 8.25F, (System.Drawing.FontStyle.Bold));

                    p.Controls.Add(ten);    // add tên vào panel
                    p.Controls.Add(gia);    // add giá vào panel
                    p.Controls.Add(giakm);  // add giá da km vào panel
                    p.Controls.Add(pic);    // add tên vào panel
                    p.Controls.Add(sl);     // add sl vào panel
                    pic.Controls.Add(km);   // add km vào panel
                    flpSanpham.Controls.Add(p);  // add panel vào FlowlayoutPanel
                }
            }
        }

        private void cbncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbncc.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cbloaisp.ResetText();
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                sp.Mancc = int.Parse(cbncc.SelectedValue.ToString());
                dt = SanPhamDAO.SearchSPbyMaNCC(sp);
                flpSanpham.Controls.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel p = new Panel();
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Margin = new Padding(5, 5, 10, 5);
                    p.Width = 145; p.Height = 185;

                    //ten sp
                    Label ten = new Label();
                    ten.Height = 30;
                    ten.Text = dt.Rows[i][1].ToString();
                    ten.Dock = DockStyle.Top;
                    ten.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    ten.ForeColor = Color.Black;
                    ten.Font = new System.Drawing.Font("Segoe UI", 8.25F);

                    //gia chua tinh km
                    Label gia = new Label();
                    gia.Height = 10;
                    gia.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                    gia.Dock = DockStyle.Bottom;
                    gia.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    gia.ForeColor = Color.Black;
                    gia.Font = new System.Drawing.Font("Segoe UI", 7F, (System.Drawing.FontStyle.Strikeout));

                    //gia da tinh km
                    Label giakm = new Label();
                    if (int.Parse(dt.Rows[i][11].ToString()) == 0)
                    {
                        giakm.Text = string.Format("{0:n0} VND", long.Parse(dt.Rows[i][8].ToString()));
                    }
                    else
                    {
                        int sokm = (100 - (int.Parse(dt.Rows[i][11].ToString()))) % 100;
                        long giadakm = (long.Parse(dt.Rows[i][8].ToString()) * sokm) / 100;
                        giakm.Text = string.Format("{0:n0} VND", giadakm);
                    }
                    giakm.Height = 20;
                    giakm.Dock = DockStyle.Bottom;
                    giakm.TextAlign = ContentAlignment.MiddleCenter; // căn chữ
                    giakm.ForeColor = Color.FromArgb(250, 100, 0);

                    //anh sp
                    PictureBox pic = new PictureBox();
                    pic.Width = 140; pic.Height = 100; // set kích thước của ảnh
                    try
                    {
                        pic.Load(path + "sanpham" + dt.Rows[i]["MaSP"] + ".jpg");
                    }
                    catch
                    {
                        pic.Load(path + "null.jpg");
                    }
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Dock = DockStyle.Top;
                    pic.Tag = dt.Rows[i][0].ToString();
                    pic.Click += new EventHandler(Onclick); // sự kiện click

                    //so luong sp
                    Label sl = new Label();
                    sl.Height = 20;
                    sl.Text = "Sẵn có: " + dt.Rows[i][7].ToString();
                    sl.Dock = DockStyle.Bottom;
                    sl.TextAlign = ContentAlignment.MiddleRight;   // căn chữ
                    sl.ForeColor = Color.Black;
                    sl.Font = new System.Drawing.Font("Segoe UI", 7F);
                    //khuyen mai
                    Label km = new Label();
                    km.Left = 110;
                    km.Size = new Size(30, 30);
                    km.Text = dt.Rows[i][11].ToString() + "%";
                    km.TextAlign = ContentAlignment.MiddleCenter;   // căn chữ
                    km.ForeColor = Color.White;
                    km.BackColor = Color.Red;
                    km.Font = new System.Drawing.Font("Segoe UI", 8.25F, (System.Drawing.FontStyle.Bold));

                    p.Controls.Add(ten);    // add tên vào panel
                    p.Controls.Add(gia);    // add giá vào panel
                    p.Controls.Add(giakm);  // add giá da km vào panel
                    p.Controls.Add(pic);    // add tên vào panel
                    p.Controls.Add(sl);     // add sl vào panel
                    pic.Controls.Add(km);   // add km vào panel
                    flpSanpham.Controls.Add(p);  // add panel vào FlowlayoutPanel
                }
            }
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            DateTime dtn = DateTime.Now;   // lấy ngày giờ ở hiện tại
            HoaDonDTO hd = new HoaDonDTO();
            KhachHangDTO kh = new KhachHangDTO();
            SanPhamDTO sp = new SanPhamDTO();

            //Khách Hàng
            DataTable dtkh = new DataTable();
            dtkh = KhachHangDAO.TTKH();
            int stt_kh = dtkh.Rows.Count;

            if (stt_kh == 0)
            {
                kh.Makh = "KH1";
            }
            else
            {
                dtkh = KhachHangDAO.MaKH_Max();
                string makh = dtkh.Rows[0][0].ToString();
                kh.Makh = (int.Parse(makh.Substring(makh.Length - 1, 1)) + 1).ToString("KH0");
            }
            kh.Hoten = txttenKH.Text;
            kh.Sdt = txtSDT.Text;
            kh.Ngaydangky = dtn.ToString("MM/dd/yyyy");
            KhachHangBUS.ThemKH(kh);

            //HoaDon
            DataTable dthd = new DataTable();
            dthd = HoaDonDAO.TTHD();
            int stt_hd = dthd.Rows.Count;

            if (stt_hd == 0)
            {
                hd.Sohd = 1;
            }
            else
            {
                dthd = HoaDonDAO.SoHD_Max();
                string sohd = dthd.Rows[0][0].ToString();
                hd.Sohd = int.Parse(sohd) + 1;
            }
            hd.Ngaylap= dtn.ToString("MM/dd/yyyy");
            hd.Makh = kh.Makh;
            hd.Manv = manv;
            hd.Thanhtien = int.Parse(lbltongHD.Text.Replace(",", "").Replace(" VND", ""));
            hd.Tienkhachtra = int.Parse(txttienkhtra.Text);
            if (chkdathanhtoan.Checked == true)
                hd.Dathanhtoan = 0;
            else
                hd.Dathanhtoan = 1;
           HoaDonBUS.ThemHD(hd);

            //CTHD
            int stt = 1;
            for(int i=0;i<lvgiohang.Items.Count;i++)
            {
                hd.Stt = stt;
                hd.Masp= int.Parse(lvgiohang.Items[i].SubItems[5].Text);
                hd.Dongia= int.Parse(lvgiohang.Items[i].SubItems[1].Text.Replace(",", ""));
                hd.Khuyenmai= int.Parse(lvgiohang.Items[i].SubItems[2].Text);
                hd.Sl= int.Parse(lvgiohang.Items[i].SubItems[3].Text);
                HoaDonBUS.ThemCTHD(hd);
                stt++;
            }

            //Cập nhật lại số lượng sản phẩm
            DataTable dt = new DataTable();
            dt = HoaDonDAO.TTCTHD(hd);

            DataTable dtsp = new DataTable();
            dtsp = SanPhamDAO.TTSP();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dtsp.Rows.Count; j++)
                {
                    if (dt.Rows[i]["MaSP"].ToString() == dtsp.Rows[j]["MaSP"].ToString())
                    {
                        sl = int.Parse(dtsp.Rows[j]["SoLuong"].ToString()) - int.Parse(dt.Rows[i]["SoLuong"].ToString());
                        sp.Masp = int.Parse(dt.Rows[i]["MaSP"].ToString());
                        sp.Soluong = sl;
                        NhapHangBUS.capnhatsl(sp);
                    }
                }
            }
            
            MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txttenKH.Clear();
            txtSDT.Clear();
            lvgiohang.Items.Clear();
            lbltongHD.Text = "0 VND";
            txttienkhtra.Clear();
            txttienthua.Clear();
            chkdathanhtoan.Checked = false;
            flpSanpham.Controls.Clear();
            Load_dsSP();
        }
    }
}
