using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToySalesManager.DAO;
using ToySalesManager.DTO;
using ToySalesManager.BUS;

namespace ToySalesManager.GUI
{
    public partial class frmThietlap : Form
    {
        string imglocation = "";
        private string path = Environment.CurrentDirectory + @"\Image\";
        public frmThietlap()
        {
            InitializeComponent();
        }

        private string manv;
        public frmThietlap(string ma_nv) : this()
        {
            this.manv = ma_nv;
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //hàm kiểm tra mail
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        bool Check()
        {
            if (String.IsNullOrWhiteSpace(txthoten.Text))
            {
                MessageBox.Show("Họ và tên không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Địa chỉ không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
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
            return true;
        }
        bool checkMK()
        {
            if (String.IsNullOrWhiteSpace(txtmkhientai.Text))
            {
                MessageBox.Show("Mật khẩu hiện tại không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmkhientai.Focus();
                return false;
            }

            if (txtmkmoi.Text.Length < 6 || String.IsNullOrWhiteSpace(txtmkmoi.Text))
            {
                MessageBox.Show("Mật khẩu không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmkmoi.Focus();
                lbl8.Visible = true;
                lblgoiy.Visible = true;
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtnhaplaimk.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnhaplaimk.Focus();
                return false;
            }
            return true;
        }

        void TTNV()
        {
            DataTable dt = new DataTable();
            NhanVienDTO nv = new NhanVienDTO();
            nv.Manv = manv;
            dt =NhanVienDAO.TTNV_MaNV(nv);
            txtmanv.Text = dt.Rows[0]["MaNV"].ToString();
            txthoten.Text= dt.Rows[0]["HoTen"].ToString();
            txtdiachi.Text= dt.Rows[0]["Diachi"].ToString();
            txtemail.Text= dt.Rows[0]["Email"].ToString();
            txtsdt.Text= dt.Rows[0]["SDT"].ToString();
            dtngaysinh.Text= dt.Rows[0]["NgaySinh"].ToString();
            if (dt.Rows[0]["GioiTinh"].ToString() == "False")
                rdnam.Checked = true;
            else
                rdnu.Checked = true;

        }

        private void frmThietlap_Load(object sender, EventArgs e)
        {
            TTNV();
            try
            {
                picanh.Load(path + txtmanv.Text + ".jpg");
            }
            catch
            {
                picanh.Load(path + "null.jpg");
            }
        }

        private void picanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                picanh.ImageLocation = imglocation;
            }
        }

        private void btncapnhatanh_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVienDTO nv = new NhanVienDTO();
                picanh.Load(path + "null.jpg");   // Nếu tồn tại ảnh cũ thì phải load ảnh trung gian lên r mới cập nhật
                string namepic = txtmanv.Text + ".jpg";     // Tên ảnh muốn lưu
                nv.Manv = txtmanv.Text;
                nv.Hinh = namepic;
                NhanVienBUS.CapnhatAnh(nv);
                File.Copy(imglocation, Path.Combine(path, namepic), true);  // copy cái ảnh kia vào đường dẫn ./bin/debug/..
                picanh.Load(path + txtmanv.Text + ".jpg");    // load ảnh mới lưu lên
                MessageBox.Show("Cập nhật ảnh thành công.", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch
            {
                picanh.Load(path + txtmanv.Text + ".jpg");
                MessageBox.Show("Nhấn vào ảnh đại diện nếu bạn muốn cập nhật ảnh", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if(Check())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.Manv = txtmanv.Text;
                nv.Hoten = txthoten.Text;
                nv.Sdt = txtsdt.Text;
                nv.Diachi = txtdiachi.Text;
                nv.Email = txtemail.Text;
                nv.Ngaysinh = dtngaysinh.Value.ToString();
                if (rdnam.Checked == true)
                    nv.Gioitinh = 0;
                else
                    nv.Gioitinh = 1;
                NhanVienBUS.CapnhatNV(nv);
                MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TTNV();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(checkMK())
            {
                DataTable dt = new DataTable();
                NhanVienDTO nv = new NhanVienDTO();
                nv.Manv = txtmanv.Text;
                dt = NhanVienDAO.TTNV_MaNV(nv);
                if (dt.Rows[0]["Matkhau"].ToString() == txtmkhientai.Text)
                {
                    if (String.Compare(txtmkmoi.Text, txtnhaplaimk.Text) == 0)
                    {
                        nv.Matkhau = txtmkmoi.Text;
                        NhanVienBUS.CapnhatMK(nv);
                        MessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        lbl8.Visible = false;
                        lblgoiy.Visible = false;
                        txtmkhientai.Clear();
                        txtmkmoi.Clear();
                        txtnhaplaimk.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Nhập lại mật khẩu không trùng khớp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtnhaplaimk.Focus();
                    }
                }
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            txtmkhientai.Clear();
            txtmkmoi.Clear();
            txtnhaplaimk.Clear();
            lbl8.Visible = false;
            lblgoiy.Visible = false;
        }  
    }
}
