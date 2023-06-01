using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ToySalesManager.DAO;
using ToySalesManager.BUS;
using ToySalesManager.DTO;

namespace ToySalesManager.GUI
{
    public partial class frmQLNCC : Form
    {
        public frmQLNCC()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        bool Check()
        {
            if (String.IsNullOrWhiteSpace(txttenncc.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenncc.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return false;
            }

            if (txtsdt.TextLength < 10 || txtsdt.TextLength > 10 || String.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return false;
            }
            return true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void TT_NCC()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTNCC();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lvds.Items.Add(dt.Rows[i][0].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
            }
        }

        private void frmQLNCC_Load(object sender, EventArgs e)
        {
            TT_NCC();
        }

        private void lvds_Click(object sender, EventArgs e)
        {
            txtmancc.Text = lvds.SelectedItems[0].SubItems[0].Text;
            txttenncc.Text = lvds.SelectedItems[0].SubItems[1].Text;
            txtdiachi.Text= lvds.SelectedItems[0].SubItems[2].Text;
            txtsdt.Text= lvds.SelectedItems[0].SubItems[3].Text;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.MaNCC_Max();
            string maloai = dt.Rows[0][0].ToString();
            txtmancc.Text = (int.Parse(maloai) + 1).ToString();
            txttenncc.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                NCC_LoaiSPDTO ncc = new NCC_LoaiSPDTO();
                ncc.Mancc = txtmancc.Text;
                ncc.Tenncc = txttenncc.Text;
                ncc.Diachi = txtdiachi.Text;
                ncc.Sdt = txtsdt.Text;
                NCC_LoaiSPBUS.CapNhatNCC(ncc);
                lvds.Items.Clear();
                TT_NCC();
                txtmancc.Clear();
                txttenncc.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                NCC_LoaiSPDTO ncc = new NCC_LoaiSPDTO();
                ncc.Mancc = txtmancc.Text;
                ncc.Tenncc = txttenncc.Text;
                ncc.Diachi = txtdiachi.Text;
                ncc.Sdt = txtsdt.Text;
                NCC_LoaiSPBUS.ThemNCC(ncc);
                lvds.Items.Clear();
                TT_NCC();
                txtmancc.Clear();
                txttenncc.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
            }
        }

        private void btnNgungHopTac_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtmancc.Text))
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp cần ngưng hợp tác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                NCC_LoaiSPDTO ncc = new NCC_LoaiSPDTO();
                ncc.Mancc = txtmancc.Text;
                NCC_LoaiSPBUS.NgungHopTac(ncc);
                lvds.Items.Clear();
                TT_NCC();
                txtmancc.Clear();
                txttenncc.Clear();
                txtdiachi.Clear();
                txtsdt.Clear();
            }
        }
    }
}
