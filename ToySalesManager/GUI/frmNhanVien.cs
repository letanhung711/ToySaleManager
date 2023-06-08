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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
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
                MessageBox.Show("Họ tên nhân viên không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return false;
            }
            if (txtsdt.TextLength < 10 || txtsdt.TextLength > 10 || String.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return false;
            }
            if (rdnam.Checked == false && rdnu.Checked == false)
            {
                MessageBox.Show("Giới tính nhân viên chưa được chọn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            return true;
        }

        void TT_NV()
        {
            DataTable dt = new DataTable();
            dt = NhanVienDAO.TTNV();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                lvds.Items.Add(dt.Rows[i]["MaNV"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["HoTen"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySinh"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GioiTinh"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["DiaChi"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["Email"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["MatKhau"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["Quyen"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            TT_NV();
            cbcv.Items.Add("Quản lý");
            cbcv.Items.Add("Nhân viên");
        }

        private void lvds_Click(object sender, EventArgs e)
        {
            txtmanv.Text = lvds.SelectedItems[0].SubItems[0].Text;
            txthoten.Text= lvds.SelectedItems[0].SubItems[1].Text;
            txtsdt.Text= lvds.SelectedItems[0].SubItems[2].Text;
            dtngaysinh.Text= lvds.SelectedItems[0].SubItems[3].Text;
            if (lvds.SelectedItems[0].SubItems[4].Text == "Nam")
                rdnam.Checked = true;
            else
                rdnu.Checked = true;
            txtdiachi.Text= lvds.SelectedItems[0].SubItems[5].Text;
            txtemail.Text= lvds.SelectedItems[0].SubItems[6].Text;
            txtmk.Text= lvds.SelectedItems[0].SubItems[7].Text;
            cbcv.Text= lvds.SelectedItems[0].SubItems[8].Text;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmanv.Clear();
            txthoten.Clear();
            txtsdt.Clear();
            txtdiachi.Clear();
            txtemail.Clear();
            txtmk.Clear();
            rdnam.Checked = false;
            rdnu.Checked = false;
            cbcv.Text = "";
            dtngaysinh.ResetText();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                NhanVienDTO nv = new NhanVienDTO();
                nv.Manv = txtmanv.Text;
                nv.Hoten = txthoten.Text;
                nv.Sdt = txtsdt.Text;
                nv.Ngaysinh = dtngaysinh.Value.ToString("MM/dd/yyyy");
                nv.Diachi = txtdiachi.Text;
                nv.Email = txtemail.Text;
                nv.Quyen = cbcv.SelectedItem.ToString();
                if (rdnam.Checked == true)
                    nv.Gioitinh = 0;
                else
                    nv.Gioitinh = 1;
                NhanVienBUS.CapnhatNv(nv);
                MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                lvds.Items.Clear();
                TT_NV();
                txtmanv.Clear();
                txthoten.Clear();
                txtsdt.Clear();
                txtdiachi.Clear();
                txtemail.Clear();
                txtmk.Clear();
                rdnam.Checked = false;
                rdnu.Checked = false;
                cbcv.Text = "";
                dtngaysinh.ResetText();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtmanv.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                NhanVienDTO nv = new NhanVienDTO();
                nv.Manv = txtmanv.Text;
                dt = HoaDonDAO.TTNVHD(nv);
                if (dt.Rows.Count == 0)
                {
                    NhanVienBUS.XoaNV(nv);
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Không thể xóa nhân viên vì còn ràng buộc dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                lvds.Items.Clear();
                TT_NV();
                txtmanv.Clear();
                txthoten.Clear();
                txtsdt.Clear();
                txtdiachi.Clear();
                txtemail.Clear();
                txtmk.Clear();
                rdnam.Checked = false;
                rdnu.Checked = false;
                cbcv.Text = "";
                dtngaysinh.ResetText();
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txttknv.Clear();
            lvds.Items.Clear();
            TT_NV();
        }

        private void btnapdung_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txttknv.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                NhanVienDTO nv = new NhanVienDTO();
                DataTable dt = new DataTable();
                nv.Hoten = txttknv.Text;
                dt = NhanVienDAO.TTNV_TenNV(nv);
                lvds.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvds.Items.Add(dt.Rows[i]["MaNV"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["HoTen"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySinh"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GioiTinh"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["DiaChi"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["Email"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["MatKhau"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["Quyen"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
                }
            }
        }
    }
}
