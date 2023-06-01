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
    public partial class frmNhaphang : Form
    {
        private string mancc;
        private int sl;
        public frmNhaphang()
        {
            InitializeComponent();
        }

        private string manv;
        public frmNhaphang(string Ma_nv)
        {
            InitializeComponent();
            this.manv = Ma_nv;
        }

        void Combobox_LoaiSP()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTLoaiSP();
            cbloaisp.DataSource = dt;
            cbloaisp.DisplayMember = "TenloaiSP";
            cbloaisp.ValueMember = "MaloaiSP";
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbloaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloaisp.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                sp.Maloaisp = int.Parse(cbloaisp.SelectedValue.ToString());
                dt = SanPhamDAO.SearchSPbyMaloaiSP(sp);
                lvdsSP.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvdsSP.Items.Add(dt.Rows[i]["MaSP"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["MaloaiSP"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["DVT"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["MaNCC"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["NgaySX"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["NgayHetHan"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["GiaBan"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["GiaNhap"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["LoiNhuan"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["KhuyenMai"].ToString());
                    lvdsSP.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
                }
            }
        }

        public void TTPCN()
        {
            NhapHangDTO nh = new NhapHangDTO();
            DataTable dt = new DataTable();
            nh.Trangthai = "Chưa nhập";
            dt = NhapHangDAO.TTPCN(nh);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lvdsPhieuchuanhap.Items.Add(dt.Rows[i][0].ToString());
                lvdsPhieuchuanhap.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvdsPhieuchuanhap.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                lvdsPhieuchuanhap.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
                lvdsPhieuchuanhap.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
            }
        }

        private void frmNhaphang_Load(object sender, EventArgs e)
        {
            Combobox_LoaiSP();
            cbloaisp.ResetText();
            TTPCN();

            if (lvdsPhieuchuanhap.Items.Count > 0)
            {
                btnXacnhannhap.Enabled = true;
                btnxoa.Enabled = true;
            }
        }

        private void lvdsSP_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = lvdsSP.SelectedItems[0].SubItems[0].Text;
            txtTenSp.Text= lvdsSP.SelectedItems[0].SubItems[1].Text;
            txtgianhap.Text = lvdsSP.SelectedItems[0].SubItems[9].Text;
            mancc= lvdsSP.SelectedItems[0].SubItems[4].Text;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtSL.Text))
            {
                MessageBox.Show("Số lượng không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSL.Focus();
            }
            else
            {
                int stt = lvds.Items.Count;
                stt++;
                lvds.Items.Add(stt.ToString());
                lvds.Items[stt - 1].SubItems.Add(txtTenSp.Text);
                lvds.Items[stt - 1].SubItems.Add(txtgianhap.Text);
                lvds.Items[stt - 1].SubItems.Add(txtSL.Text);
                lvds.Items[stt - 1].SubItems.Add(mancc);

                txtMaSP.Clear();
                txtTenSp.Clear();
                txtgianhap.Clear();
                txtSL.Clear();
                btnluu.Enabled = true;
                btnhuy.Enabled = true;
            }
        }

        private void btntaophieu_Click(object sender, EventArgs e)
        {
            lbltb.Visible = true;
            cbloaisp.Enabled = true;
            btnthem.Enabled = true;
            btntaophieu.Enabled = false;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            try
            {
                lvds.Items.RemoveAt(lvds.SelectedIndices[0]);
                for (int i = 0; i < lvds.Items.Count; i++)
                {
                    if ((lvds.Items[i].Index + 1) != Convert.ToInt32(lvds.Items[i].SubItems[0].Text))
                        lvds.Items[i].SubItems[0].Text = Convert.ToString(++i);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm cần hủy.", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            //them phieu nhap
            NhapHangDTO nh = new NhapHangDTO();
            DataTable dt = new DataTable();
            dt = NhapHangDAO.TTPN();
            int sopn = dt.Rows.Count;

            if (sopn == 0)
            {
                nh.Maphieu = 1;
            }
            else
            {
                dt = NhapHangDAO.PN_Max();
                string maphieu = dt.Rows[0][0].ToString();
                nh.Maphieu= int.Parse(maphieu) + 1;
            }
            DateTime dateNow = DateTime.Now;
            nh.Ngaylap = dateNow.ToString("MM/dd/yyyy");
            nh.Mancc = int.Parse(mancc);
            nh.Manv = manv;
            nh.Trangthai = "Chưa nhập";
            NhapHangBUS.themPhieuNhap(nh);

            //them sp vao ctPhieuNhap
            DataTable dtsp = new DataTable();

            for (int i = 0; i < lvds.Items.Count; i++)
            {
                nh.Stt = int.Parse(lvds.Items[i].SubItems[0].Text);
                nh.Maphieu = nh.Maphieu;
                
                dtsp = NhapHangDAO.MaSPtheoTenSP(lvds.Items[i].SubItems[1].Text);
                for (int j = 0; j < dtsp.Rows.Count; j++)
                {
                    nh.Masp = int.Parse(dtsp.Rows[j][0].ToString());
                }
                nh.Sl = int.Parse(lvds.Items[i].SubItems[3].Text);
                nh.Gianhap = int.Parse(lvds.Items[i].SubItems[2].Text);
                NhapHangBUS.themCTPhieuNhap(nh);
            }
            lvdsPhieuchuanhap.Items.Clear();
            TTPCN();

            btnXacnhannhap.Enabled = true;
            btnxoa.Enabled = true;
            btntaophieu.Enabled = true;
            lbltb.Visible = false;
            btnthem.Enabled = false;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            cbloaisp.ResetText();
            cbloaisp.Enabled = false;
            lvdsSP.Items.Clear();
            lvds.Items.Clear();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                NhapHangDTO nh = new NhapHangDTO();
                nh.Maphieu = int.Parse(lvdsPhieuchuanhap.SelectedItems[0].SubItems[0].Text);
                NhapHangBUS.xoaPhieuNhap(nh);
                lvdsPhieuchuanhap.Items.Clear();
                TTPCN();
                if (lvdsPhieuchuanhap.Items.Count == 0)
                {
                    btnXacnhannhap.Enabled = false;
                    btnxoa.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng phiếu nhập cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXacnhannhap_Click(object sender, EventArgs e)
        {
            try
            {
                NhapHangDTO nh = new NhapHangDTO();
                SanPhamDTO sp = new SanPhamDTO();
                nh.Maphieu = int.Parse(lvdsPhieuchuanhap.SelectedItems[0].SubItems[0].Text);

                DataTable dt = new DataTable();
                dt = NhapHangDAO.TTCTPN(nh);

                DataTable dtsp = new DataTable();
                dtsp = SanPhamDAO.TTSP();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dtsp.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["MaSP"].ToString() == dtsp.Rows[j]["MaSP"].ToString())
                        {
                            sl = int.Parse(dt.Rows[i]["SoLuong"].ToString()) + int.Parse(dtsp.Rows[j]["SoLuong"].ToString());
                            sp.Masp = int.Parse(dt.Rows[i]["MaSP"].ToString());
                            sp.Soluong = sl;
                            NhapHangBUS.capnhatsl(sp);
                        }
                    }
                }
                nh.Trangthai = "Đã nhập";
                NhapHangBUS.capnhatPhieuNhap(nh);
                MessageBox.Show("Nhập sản phẩm vào kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                lvdsPhieuchuanhap.Items.Clear();
                TTPCN();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn dòng phiếu nhập cần nhập vào kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
