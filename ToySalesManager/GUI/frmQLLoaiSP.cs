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
using System.Runtime.InteropServices;

namespace ToySalesManager.GUI
{
    public partial class frmQLLoaiSP : Form
    {
        public frmQLLoaiSP()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool Check()
        {
            if (String.IsNullOrWhiteSpace(txtTenLoaiSP.Text))
            {
                MessageBox.Show("Tên loại sản phẩm không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiSP.Focus();
                return false;
            }
            return true;
        }

        public void TT_LoaiSP()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTLoaiSP();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lvds.Items.Add(dt.Rows[i][0].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        private void frmQLLoaiSP_Load(object sender, EventArgs e)
        {
            TT_LoaiSP();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.MaloaiSP_Max();
            string maloai = dt.Rows[0][0].ToString();
            txtMaloai.Text = (int.Parse(maloai) + 1).ToString();
            txtTenLoaiSP.Clear();
        }

        private void lvds_Click(object sender, EventArgs e)
        {
            txtMaloai.Text = lvds.SelectedItems[0].SubItems[0].Text;
            txtTenLoaiSP.Text= lvds.SelectedItems[0].SubItems[1].Text;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                NCC_LoaiSPDTO lsp = new NCC_LoaiSPDTO();
                lsp.Maloaisp = txtMaloai.Text;
                lsp.Tenloaisp = txtTenLoaiSP.Text;
                NCC_LoaiSPBUS.CapNhat(lsp);
                lvds.Items.Clear();
                TT_LoaiSP();
                txtMaloai.Clear();
                txtTenLoaiSP.Clear();
            }  
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                NCC_LoaiSPDTO lsp = new NCC_LoaiSPDTO();
                lsp.Maloaisp = txtMaloai.Text;
                lsp.Tenloaisp = txtTenLoaiSP.Text;
                NCC_LoaiSPBUS.Them(lsp);
                lvds.Items.Clear();
                TT_LoaiSP();
                txtMaloai.Clear();
                txtTenLoaiSP.Clear();
            }
        }

        private void btnNgungKD_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMaloai.Text))
            {
                MessageBox.Show("Bạn chưa chọn loại sản phẩm cần ngưng kinh doanh.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                NCC_LoaiSPDTO lsp = new NCC_LoaiSPDTO();
                lsp.Maloaisp = txtMaloai.Text;
                NCC_LoaiSPBUS.NgungKinhDoanh(lsp);
                lvds.Items.Clear();
                TT_LoaiSP();
                txtMaloai.Clear();
                txtTenLoaiSP.Clear();
            }
        }
    }
}
