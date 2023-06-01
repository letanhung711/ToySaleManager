using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToySalesManager.DAO;
using ToySalesManager.DTO;

namespace ToySalesManager.BUS
{
    class SanPhamBUS
    {
        public static void CapnhatSP(SanPhamDTO sp)
        {
            try
            {
                SanPhamDAO.CapNhatSP(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thông tin sản phẩm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ThemSP(SanPhamDTO sp)
        {
            try
            {
                SanPhamDAO.ThemSP(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm sản phẩm mới không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void NgungKinhDoanh(SanPhamDTO sp)
        {
            try
            {
                SanPhamDAO.NgungKinhDoanh(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngừng kinh doanh sản phẩm này không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
