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
using ToySalesManager.GUI;

namespace ToySalesManager.GUI
{
    public partial class frmHome : Form
    {
        private Button curtenButton;
        private Form activeForm;
        private bool isThoat = true;

        private string manv;
        private string matkhau;
        private string quyen;
        private string path = Environment.CurrentDirectory + @"\Image\";
        public frmHome()
        {
            InitializeComponent();
        }

        //design buton
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (curtenButton != (Button)btnSender)
                {
                    DisableButton();
                    curtenButton = (Button)btnSender;
                    curtenButton.BackColor = Color.FromArgb(250, 150, 0);
                }
            }
        }
        private void DisableButton()
        {
            foreach(Control prevBtn in panel1.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(250, 100, 0);
                }
            }
        }
        //------------------------------------------------------------

        public frmHome(string Manv, string Matkhau, string Quyen)
        {
            InitializeComponent();
            this.manv = Manv;
            this.matkhau = Matkhau;
            this.quyen = Quyen;
        }
        
        void showInformation()
        {
            DataTable dt = new DataTable();
            dt = NhanVienDAO.TenTheoManv(manv);
            lblnv.Text = dt.Rows[0][0].ToString();
            lblchucvu.Text = quyen;
            try
            {
                picanhNV.Load(path + manv + ".jpg");
            }
            catch
            {
                picanhNV.Load(path + "null.jpg");
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(childForm);
            this.pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            if (quyen == "Nhân viên")
            {
                btnNhanVien.Visible = false;
                btnNhaphang.Visible = false;
            }
            showInformation();
            OpenChildForm(new frmThongKe());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
            {
                Application.Exit();
            }
        }

        private void btnlogOut_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn đăng xuất tài khoản này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                isThoat = false;
                this.Close();
                Form1 login = new Form1();
                login.Show();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            ActivateButton(sender);
        }

        private void btnBanSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBanSanPham(manv));
            ActivateButton(sender);
        }

        private void btnQlSp_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLSanPham());
            ActivateButton(sender);
        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaphang(manv));
            ActivateButton(sender);
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHoaDon());
            ActivateButton(sender);
        }

        private void btnKhachHang_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            ActivateButton(sender);
        }

        private void btnNhanVien_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            ActivateButton(sender);
        }

        private void btnThietLap_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmThietlap(manv));
            ActivateButton(sender);
        }
    }
}
