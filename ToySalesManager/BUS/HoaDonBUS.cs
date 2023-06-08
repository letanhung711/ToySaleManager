using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToySalesManager.DTO;
using ToySalesManager.DAO;

namespace ToySalesManager.BUS
{
    class HoaDonBUS
    {
        public static void ThemHD(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.ThemHD(hd);
            }
            catch(Exception)
            {
                MessageBox.Show("Thêm hóa đơn mới không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ThemCTHD(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.ThemCTHD(hd);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm chi tiết hóa đơn mới không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void XoaHD(HoaDonDTO hd)
        {
            try
            {
                HoaDonDAO.XoaCTHD(hd);
                HoaDonDAO.XoaHD(hd);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa hóa đơn không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
