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
using ToySalesManager.GUI;
using ToySalesManager.DTO;
using ToySalesManager.DAO;

namespace ToySalesManager
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void linklblregister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister fr = new frmRegister();
            fr.ShowDialog();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            NhanVienDTO lg = new NhanVienDTO();
            lg.Manv = txtusername.Text.ToUpper();
            lg.Matkhau = txtpassword.Text;
            DataTable dt = new DataTable();
            dt = NhanVienDAO.TK_MK(lg);
            int sodong = dt.Rows.Count;
            if (sodong == 1)
            {
                frmHome menu = new frmHome(dt.Rows[0][0].ToString(), dt.Rows[0][8].ToString(), dt.Rows[0][9].ToString());
                MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.\n\nVui lòng nhập lại!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtusername.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '*')
            {
                btnHien.BringToFront();
                txtpassword.PasswordChar = '\0';
            }
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            if (txtpassword.PasswordChar == '\0')
            {
                btnAn.BringToFront();
                txtpassword.PasswordChar = '*';
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
