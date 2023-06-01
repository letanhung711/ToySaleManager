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
    class NhanVienBUS
    {
        public static void Them(NhanVienDTO dk)
        {
            try
            {
                NhanVienDAO.ThemNhanVien(dk);
            }
            catch (Exception)
            {
                MessageBox.Show("Đăng ký không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CapnhatNV(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.CapNhatNV(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CapnhatAnh(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.CapNhatAnh(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void CapnhatMK(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.CapNhatMK(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //form nhanvien
        public static void CapnhatNv(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.CapNhatNv(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void XoaNV(NhanVienDTO nv)
        {
            try
            {
                NhanVienDAO.XoaNV(nv);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa nhân viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
