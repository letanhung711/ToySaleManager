using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToySalesManager.DAO;
using ToySalesManager.DTO;
using System.Windows.Forms;

namespace ToySalesManager.BUS
{
    class KhachHangBUS
    {
        public static void CapNhatKH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.CapNhatKH(kh);
            }
            catch(Exception)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void XoaKH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.XoaKH(kh);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa khách hàng không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ThemKH(KhachHangDTO kh)
        {
            try
            {
                KhachHangDAO.ThemKH(kh);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm khách hàng mới không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
