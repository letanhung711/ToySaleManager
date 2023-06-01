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
    class NCC_LoaiSPBUS
    {
        //loai san pham
        public static void CapNhat(NCC_LoaiSPDTO lsp)
        {
            try
            {
                NCC_LoaiSPDAO.CapNhat(lsp);
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Them(NCC_LoaiSPDTO lsp)
        {
            try
            {
                NCC_LoaiSPDAO.Them(lsp);
            }
            catch
            {
                MessageBox.Show("Thêm thông tin loại sản phẩm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void NgungKinhDoanh(NCC_LoaiSPDTO lsp)
        {
            try
            {
                NCC_LoaiSPDAO.NgungKinhDoanh(lsp);
            }
            catch
            {
                MessageBox.Show("Ngừng kinh doanh không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Nha cung cap
        public static void CapNhatNCC(NCC_LoaiSPDTO ncc)
        {
            try
            {
                NCC_LoaiSPDAO.CapNhatNCC(ncc);
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ThemNCC(NCC_LoaiSPDTO ncc)
        {
            try
            {
                NCC_LoaiSPDAO.ThemNCC(ncc);
            }
            catch
            {
                MessageBox.Show("Thêm thông tin nhà cung cấp không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void NgungHopTac(NCC_LoaiSPDTO ncc)
        {
            try
            {
                NCC_LoaiSPDAO.NgungHopTac(ncc);
            }
            catch
            {
                MessageBox.Show("Ngừng hợp tác không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
