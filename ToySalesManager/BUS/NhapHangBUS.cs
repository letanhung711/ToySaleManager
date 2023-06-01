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
    class NhapHangBUS
    {
        public static void themPhieuNhap(NhapHangDTO nh)
        {
            try
            {
                NhapHangDAO.themPhieuNhap(nh);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm phiếu nhập không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void themCTPhieuNhap(NhapHangDTO nh)
        {
            try
            {
                NhapHangDAO.themCTPhieuNhap(nh);
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm chi tiết phiếu nhập không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void xoaPhieuNhap(NhapHangDTO nh)
        {
            try
            {
                NhapHangDAO.xoaCTPhieuNhap(nh);
                NhapHangDAO.xoaPhieuNhap(nh);
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa phiếu nhập không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void capnhatPhieuNhap(NhapHangDTO nh)
        {
            try
            {
                NhapHangDAO.capnhatPhieuNhap(nh);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập sản phẩm vào kho không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void capnhatsl(SanPhamDTO sp)
        {
            try
            {
                NhapHangDAO.capnhatsl(sp);
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật số lượng sản phẩm vào kho không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
