using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToySalesManager.GUI;
using ToySalesManager.DAO;
using ToySalesManager.BUS;
using ToySalesManager.DTO;
using System.IO;

namespace ToySalesManager.GUI
{
    public partial class frmQLSanPham : Form
    {
        string imglocation = "";
        private string path = Environment.CurrentDirectory + @"\SanPham\";

        public frmQLSanPham()
        {
            InitializeComponent();
        }

        void RefeshText()
        {
            txttensp.Clear();
            txtgiaban.Clear();
            txtgianhap.Clear();
            txtkhuyenmai.Clear();
            txtloinhuan.Clear();
            txtsoluong.Clear();
            dtngaysx.Text = "";
            dtngayhethan.Text = "";
            cbloaisp.ResetText();
            cbncc.ResetText();
            cbdvt.ResetText();
            picanhsp.Image = null;
        }

        bool Check()
        {
            if (lblmasp.Text=="...")
            {
                MessageBox.Show("Chưa tạo mã sản phẩm mới.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(txttensp.Text))
            {
                MessageBox.Show("Tên sản phẩm không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensp.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtkhuyenmai.Text))
            {
                MessageBox.Show("Khuyến mãi không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhuyenmai.Focus();
                return false;
            }
            if ((int.Parse(txtkhuyenmai.Text)) > 100)
            {
                MessageBox.Show("Khuyến mãi không được quá 100%.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtkhuyenmai.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtgianhap.Text))
            {
                MessageBox.Show("Giá nhập không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgianhap.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtloinhuan.Text))
            {
                MessageBox.Show("Lợi nhuận không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtloinhuan.Focus();
                return false;
            }
            if (picanhsp.Image==null)
            {
                MessageBox.Show("Ảnh sản phẩm không được bỏ trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtkhuyenmai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtloinhuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void picLoaiSP_Click(object sender, EventArgs e)
        {
            frmQLLoaiSP fr = new frmQLLoaiSP();
            fr.Show();
        }

        private void picNCC_Click(object sender, EventArgs e)
        {
            frmQLNCC fr = new frmQLNCC();
            fr.Show();
        }

        void Combobox_LoaiSP()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTLoaiSP();
            cbloaisp.DataSource = dt;
            cbloaisp.DisplayMember = "TenloaiSP";
            cbloaisp.ValueMember = "MaloaiSP";
        }
        void Combobox_SearchloaiSP()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTLoaiSP();
            cbSearchlsp.DataSource = dt;
            cbSearchlsp.DisplayMember = "TenloaiSP";
            cbSearchlsp.ValueMember = "MaloaiSP";
        }

        void Combobox_NCC()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTNCC();
            cbncc.DataSource = dt;
            cbncc.DisplayMember = "TenNCC";
            cbncc.ValueMember = "MaNCC";
        }
        void Combobox_SearchNCC()
        {
            DataTable dt = new DataTable();
            dt = NCC_LoaiSPDAO.TTNCC();
            cbSearchncc.DataSource = dt;
            cbSearchncc.DisplayMember = "TenNCC";
            cbSearchncc.ValueMember = "MaNCC";
        }

        void TT_SanPham()
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.TTSP();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                lvds.Items.Add(dt.Rows[i]["MaSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["MaloaiSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["DVT"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["MaNCC"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySX"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayHetHan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaBan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaNhap"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["LoiNhuan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["KhuyenMai"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
            }
        }

        private void frmQLSanPham_Load(object sender, EventArgs e)
        {
            TT_SanPham();
            Combobox_LoaiSP();
            Combobox_NCC();
            Combobox_SearchloaiSP();
            Combobox_SearchNCC();

            cbSearchlsp.ResetText();
            cbSearchncc.ResetText();
            txtSearchSP.Focus();

            //DVT
            cbdvt.Items.Add("Hộp");
            cbdvt.Items.Add("Cái");
            cbdvt.Items.Add("Túi");
        }

        private void lvds_Click(object sender, EventArgs e)
        {
            lblmasp.Text = lvds.SelectedItems[0].SubItems[0].Text;
            txttensp.Text= lvds.SelectedItems[0].SubItems[1].Text;
            txtkhuyenmai.Text= lvds.SelectedItems[0].SubItems[11].Text;
            txtgianhap.Text= lvds.SelectedItems[0].SubItems[9].Text;
            txtloinhuan.Text= lvds.SelectedItems[0].SubItems[10].Text;
            txtgiaban.Text= lvds.SelectedItems[0].SubItems[8].Text;
            txtsoluong.Text= lvds.SelectedItems[0].SubItems[7].Text;
            cbdvt.Text= lvds.SelectedItems[0].SubItems[3].Text;
            dtngaysx.Text= lvds.SelectedItems[0].SubItems[5].Text;
            dtngayhethan.Text= lvds.SelectedItems[0].SubItems[6].Text;

            DataTable dtlsp=new DataTable();
            dtlsp = SanPhamDAO.TenloaiSPtheoMa(lvds.SelectedItems[0].SubItems[2].Text);
            cbloaisp.Text = dtlsp.Rows[0][0].ToString();

            DataTable dtncc = new DataTable();
            dtncc = SanPhamDAO.TenNCCtheoMa(lvds.SelectedItems[0].SubItems[4].Text);
            cbncc.Text = dtncc.Rows[0][0].ToString();
            //image
            try
            {
                picanhsp.Load(path + lvds.SelectedItems[0].SubItems[12].Text);
            }
            catch
            {
                picanhsp.Load(path + "null.jpg");
            }
        }

        private void picanhsp_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                picanhsp.ImageLocation = imglocation;
            }
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.Masp = int.Parse(lblmasp.Text);
                sp.Maloaisp = int.Parse(cbloaisp.SelectedValue.ToString());
                sp.Mancc = int.Parse(cbncc.SelectedValue.ToString());
                sp.Gianhap = int.Parse(txtgianhap.Text);
                sp.Khuyenmai = int.Parse(txtkhuyenmai.Text);
                sp.Loinhuan = int.Parse(txtloinhuan.Text);
                //gia ban
                int gia = 0;
                gia = (int.Parse(txtgianhap.Text) / (100 - (int.Parse(txtloinhuan.Text)))) * 100;
                sp.Giaban = gia;

                sp.Tensp = txttensp.Text;
                sp.Dvt = cbdvt.SelectedItem.ToString();
                sp.Ngaysx = dtngaysx.Value.ToString("MM/dd/yyyy");
                sp.Ngayhethan = dtngayhethan.Value.ToString("MM/dd/yyyy");
                //images
                try
                {
                    picanhsp.Load(Environment.CurrentDirectory + @"\SanPham\null.jpg");
                    File.Delete(path + "sanpham" + lblmasp.Text + ".jpg");
                }
                catch { }

                try
                {
                    string namepic = "sanpham" + lblmasp.Text + ".jpg"; //tên ảnh muốn lưu
                    File.Copy(imglocation, Path.Combine(path, namepic), true); //copy ảnh vào bin/debug/...
                    picanhsp.Load(path + "sanpham" + lblmasp.Text + ".jpg"); //load ảnh mới lưu
                }
                catch { }

                SanPhamBUS.CapnhatSP(sp);
                lvds.Items.Clear();
                TT_SanPham();
                MessageBox.Show("Cập nhật thông tin sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = SanPhamDAO.MaSP_MAX();
            string masp = dt.Rows[0][0].ToString();
            lblmasp.Text = (int.Parse(masp) + 1).ToString();
            RefeshText();
            txttensp.Focus();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.Masp = int.Parse(lblmasp.Text);
                sp.Maloaisp = int.Parse(cbloaisp.SelectedValue.ToString());
                sp.Mancc = int.Parse(cbncc.SelectedValue.ToString());
                sp.Gianhap = int.Parse(txtgianhap.Text);
                sp.Khuyenmai = int.Parse(txtkhuyenmai.Text);
                sp.Loinhuan = int.Parse(txtloinhuan.Text);
                sp.Soluong = 0;
                //gia ban
                int gia = 0;
                gia = (int.Parse(txtgianhap.Text) / (100 - (int.Parse(txtloinhuan.Text)))) * 100;
                sp.Giaban = gia;

                sp.Tensp = txttensp.Text;
                sp.Dvt = cbdvt.SelectedItem.ToString();
                sp.Ngaysx = dtngaysx.Value.ToString("MM/dd/yyyy");
                sp.Ngayhethan = dtngayhethan.Value.ToString("MM/dd/yyyy");
                //images
                string namepic = "sanpham" + lblmasp.Text + ".jpg"; //tên ảnh muốn lưu
                File.Copy(imglocation, Path.Combine(path, namepic), true); //copy ảnh vào bin/debug/...
                picanhsp.Load(path + "sanpham" + lblmasp.Text + ".jpg"); //load ảnh mới lưu
                sp.Hinh = namepic;

                SanPhamBUS.ThemSP(sp);
                lvds.Items.Clear();
                TT_SanPham();
                MessageBox.Show("Thêm sản phẩm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnngungkinhdoanh_Click(object sender, EventArgs e)
        {
            if (lblmasp.Text != "...")
            {
                SanPhamDTO sp = new SanPhamDTO();
                sp.Masp = int.Parse(lblmasp.Text);
                SanPhamBUS.NgungKinhDoanh(sp);
                lvds.Items.Clear();
                TT_SanPham();
                try
                {
                    picanhsp.Load(Environment.CurrentDirectory + @"\SanPham\null.jpg");
                    File.Delete(path + "sanpham" + lblmasp.Text + ".jpg");
                }
                catch { }
                lblmasp.Text = "...";
                RefeshText();
                MessageBox.Show("Ngừng kinh doanh sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần ngừng kinh doanh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SanPhamDTO sp = new SanPhamDTO();
            DataTable dt = new DataTable();
            sp.Tensp = txtSearchSP.Text;
            lvds.Items.Clear();
            dt = SanPhamDAO.SearchSPbyMaSP(sp);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvds.Items.Add(dt.Rows[i]["MaSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["MaloaiSP"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["DVT"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["MaNCC"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySX"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayHetHan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaBan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaNhap"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["LoiNhuan"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["KhuyenMai"].ToString());
                lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
            }
        }

        private void btnRefeshSearch_Click(object sender, EventArgs e)
        {
            txtSearchSP.Clear();
            cbSearchlsp.ResetText();
            cbSearchncc.ResetText();
            lvds.Items.Clear();
            TT_SanPham();
        }

        private void cbSearchlsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchlsp.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cbSearchncc.ResetText();
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                sp.Maloaisp = int.Parse(cbSearchlsp.SelectedValue.ToString());
                dt = SanPhamDAO.SearchSPbyMaloaiSP(sp);
                lvds.Items.Clear();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvds.Items.Add(dt.Rows[i]["MaSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["MaloaiSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["DVT"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["MaNCC"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySX"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayHetHan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaBan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaNhap"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["LoiNhuan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["KhuyenMai"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
                }
            }
        }

        private void cbSearchncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearchncc.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                cbSearchlsp.ResetText();
                DataTable dt = new DataTable();
                SanPhamDTO sp = new SanPhamDTO();
                sp.Mancc = int.Parse(cbSearchncc.SelectedValue.ToString());
                dt = SanPhamDAO.SearchSPbyMaNCC(sp);
                lvds.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvds.Items.Add(dt.Rows[i]["MaSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["MaloaiSP"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["DVT"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["MaNCC"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgaySX"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["NgayHetHan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaBan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["GiaNhap"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["LoiNhuan"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["KhuyenMai"].ToString());
                    lvds.Items[i].SubItems.Add(dt.Rows[i]["Hinh"].ToString());
                }
            }
        }
    }
}
