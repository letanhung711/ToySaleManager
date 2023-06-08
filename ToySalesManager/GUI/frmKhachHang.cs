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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
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

        bool Check()
        {
            if (String.IsNullOrWhiteSpace(txtmakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(txthoten.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txthoten.Focus();
                return false;
            }
            if (txtsdt.TextLength < 10 || txtsdt.TextLength > 10 || String.IsNullOrWhiteSpace(txtsdt.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsdt.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                MessageBox.Show("Địa chỉ không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdiachi.Focus();
                return false;
            }
            if (rdnam.Checked==false && rdnu.Checked==false)
            {
                MessageBox.Show("Giới tính khách hàng chưa được chọn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        void TT_KH()
        {
            DataTable dt = new DataTable();
            dt = KhachHangDAO.TTKH();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                lvds.Items.Add(dt.Rows[i]["MaKH"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["HoTenKH"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["DiaChi"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GioiTinh"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayDangKy"].ToString());
            }
        }

        void SoKH()
        {
            DataTable dt = new DataTable();
            dt = KhachHangDAO.SoKH();
            lblsokh.Text = dt.Rows[0][0].ToString();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            TT_KH();
            SoKH();
        }

        private void lvds_Click(object sender, EventArgs e)
        {
            txtmakh.Text = lvds.SelectedItems[0].SubItems[0].Text;
            txthoten.Text= lvds.SelectedItems[0].SubItems[1].Text;
            txtsdt.Text= lvds.SelectedItems[0].SubItems[2].Text;
            txtdiachi.Text= lvds.SelectedItems[0].SubItems[3].Text;
            if (lvds.SelectedItems[0].SubItems[4].Text == "Nam")
                rdnam.Checked = true;
            else
                rdnu.Checked = true;
            dtngaydk.Text= lvds.SelectedItems[0].SubItems[5].Text;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmakh.Clear();
            txthoten.Clear();
            txtsdt.Clear();
            txtdiachi.Clear();
            rdnam.Checked = false;
            rdnu.Checked = false;
            dtngaydk.ResetText();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txttkkh.Clear();
            lvds.Items.Clear();
            TT_KH();
        }

        private void btnapdung_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txttkkh.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                KhachHangDTO kh = new KhachHangDTO();
                DataTable dt = new DataTable();
                kh.Hoten = txttkkh.Text;
                dt = KhachHangDAO.SearchKH(kh);
                lvds.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvds.Items.Add(dt.Rows[i]["MaKH"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["HoTenKH"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["SDT"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["DiaChi"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GioiTinh"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayDangKy"].ToString());
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtmakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                KhachHangDTO kh = new KhachHangDTO();
                kh.Makh = txtmakh.Text;
                dt = HoaDonDAO.TTKHHD(kh);
                if(dt.Rows.Count==0)
                {
                    KhachHangBUS.XoaKH(kh);
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng vì còn ràng buộc dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                lvds.Items.Clear();
                TT_KH();
                txtmakh.Clear();
                txthoten.Clear();
                txtsdt.Clear();
                txtdiachi.Clear();
                rdnam.Checked = false;
                rdnu.Checked = false;
                dtngaydk.ResetText();
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if(Check())
            {
                KhachHangDTO kh = new KhachHangDTO();
                kh.Makh = txtmakh.Text;
                kh.Hoten = txthoten.Text;
                kh.Sdt = txtsdt.Text;
                kh.Diachi = txtdiachi.Text;
                if (rdnam.Checked == true)
                    kh.Gioitinh = "0";
                else
                    kh.Gioitinh = "1";
                kh.Ngaydangky = dtngaydk.Value.ToString("MM/dd/yyyy");
                KhachHangBUS.CapNhatKH(kh);
                MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                lvds.Items.Clear();
                TT_KH();
                txtmakh.Clear();
                txthoten.Clear();
                txtsdt.Clear();
                txtdiachi.Clear();
                rdnam.Checked = false;
                rdnu.Checked = false;
                dtngaydk.ResetText();
            }
        }
    }
}
