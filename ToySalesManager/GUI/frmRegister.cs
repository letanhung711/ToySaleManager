using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ToySalesManager.DAO;
using ToySalesManager.DTO;
using ToySalesManager.BUS;

namespace ToySalesManager.GUI
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        //hàm kiểm tra mail
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        bool Check()
        {
            if (String.IsNullOrWhiteSpace(txthoten.Text))
            {
                MessageBox.Show("Họ và tên không được bỏ trống.", "Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txthoten.Focus();
                return false;
            }

            if (!IsEmail(txtemail.Text) || String.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Email không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return false;
            }
                
            if (txtsdt.TextLength < 10 || txtsdt.TextLength > 10 || String.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return false;
            }

            if (txtpassword.Text.Length < 6 || String.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Mật khẩu không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtpassword.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResetPassword.Focus();
                return false;
            }
            return true;
        }

        void Manv_Max()
        {
            DataTable dt = new DataTable();
            dt = NhanVienDAO.MaNVMax();
            string manv = dt.Rows[0][0].ToString();
            txtmanv.Text = (int.Parse(manv.Substring(manv.Length - 1, 1)) + 1).ToString("NV0");
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            Manv_Max();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                //Them dang ky moi
                NhanVienDTO dk = new NhanVienDTO();
                dk.Manv = txtmanv.Text;
                dk.Hoten = txthoten.Text;
                dk.Email = txtemail.Text;
                dk.Sdt = txtsdt.Text;
                if (String.Compare(txtpassword.Text, txtResetPassword.Text) == 0)
                {
                    dk.Matkhau = txtpassword.Text;
                    NhanVienBUS.Them(dk);
                    MessageBox.Show("Đăng ký tài khoản thành công.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtResetPassword.Focus();
                }
            }
        }
    }
}
