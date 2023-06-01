using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class SanPhamDAO
    {
        public static DataTable TTSP()
        {
            string sql = "select * from SanPham";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable MaSP_MAX()
        {
            string sql = "select top 1 MaSP from SanPham order by MaSP desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TenloaiSPtheoMa(string maloaisp)
        {
            string sql = "select TenloaiSP from LoaiSP where MaloaiSP="+maloaisp+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TenNCCtheoMa(string mancc)
        {
            string sql = "select TenNCC from NCC where MaNCC="+mancc+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SearchSPbyMaSP(SanPhamDTO sp)
        {
            string sql = "select * from SanPham where TenSP like N'%"+sp.Tensp+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SearchSPbyMaloaiSP(SanPhamDTO sp)
        {
            string sql = "select * from SanPham where MaloaiSP="+sp.Maloaisp+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SearchSPbyMaNCC(SanPhamDTO sp)
        {
            string sql = "select * from SanPham where MaNCC=" + sp.Mancc + "";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        public static DataTable TTSP_MaSP(SanPhamDTO sp)
        {
            string sql = "select MaSP,TenSP,KhuyenMai,GiaBan from SanPham where MaSP = "+sp.Masp+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SPMUA_NhieuNhat()
        {
            string sql = "select top 3 sp.MaSP , Tensp , GiaBan ,SUM(CTHD.SoLuong) as SL  from CTHD,HoaDon hd,SanPham sp where sp.MaSP=CTHD.MaSP and hd.SoHD=CTHD.SoHD group by sp.MaSP,TenSP,GiaBan order by SL desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        public static void CapNhatSP(SanPhamDTO sp)
        {
            string sql = "update SanPham set TenSP=N'"+sp.Tensp+"',MaloaiSP="+sp.Maloaisp+",DVT=N'"+sp.Dvt+"',MaNCC="+sp.Mancc+",NgaySX='"+sp.Ngaysx+"',NgayHetHan='"+sp.Ngayhethan+"',GiaBan="+sp.Giaban+",GiaNhap="+sp.Gianhap+",LoiNhuan="+sp.Loinhuan+",KhuyenMai="+sp.Khuyenmai+" where MaSP="+sp.Masp+"";
            KNCSDL.executeQuery(sql);
        }
        public static void ThemSP(SanPhamDTO sp)
        {
            string sql = "insert into SanPham values ("+sp.Masp+",N'"+sp.Tensp+"',"+sp.Maloaisp+",N'"+sp.Dvt+"',"+sp.Mancc+",'"+sp.Ngaysx+"','"+sp.Ngayhethan+"',"+sp.Soluong+","+sp.Giaban+","+sp.Gianhap+","+sp.Loinhuan+","+sp.Khuyenmai+",'"+sp.Hinh+"',0)";
            KNCSDL.executeQuery(sql);
        }
        public static void NgungKinhDoanh(SanPhamDTO sp)
        {
            string sql = "delete from SanPham where MaSP="+sp.Masp+"";
            KNCSDL.executeQuery(sql);
        }
    }
}
