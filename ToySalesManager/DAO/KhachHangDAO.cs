using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class KhachHangDAO
    {
        public static DataTable TTKH()
        {
            string sql = "select MaKH,HoTenKH,SDT,DiaChi,IIF(GioiTinh=0,N'Nam',N'Nữ') as Gioitinh,NgayDangKy from KhachHang";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable MaKH_Max()
        {
            string sql = "select top 1 MaKH from KhachHang order by MaKH desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SearchKH(KhachHangDTO kh)
        {
            string sql = "select MaKH,HoTenKH,SDT,DiaChi,IIF(GioiTinh=0,N'Nam',N'Nữ') as Gioitinh,NgayDangKy from KhachHang where HoTenKH like N'%"+kh.Hoten+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SoKH()
        {
            string sql = "select Count(MaKH) as SoKH from KhachHang";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static void CapNhatKH(KhachHangDTO kh)
        {
            string sql = "update KhachHang set HoTenKH=N'"+kh.Hoten+"',SDT='"+kh.Sdt+"',DiaChi=N'"+kh.Diachi+"',GioiTinh="+kh.Gioitinh+",NgayDangKy='"+kh.Ngaydangky+"',DaXoa=0 where MaKH='"+kh.Makh+"'";
            KNCSDL.executeQuery(sql);
        }
        public static void XoaKH(KhachHangDTO kh)
        {
            string sql = "delete from KhachHang where MaKH='"+kh.Makh+"'";
            KNCSDL.executeQuery(sql);
        }
        public static void ThemKH(KhachHangDTO kh)
        {
            string sql = "insert into KhachHang([MaKH],[HoTenKH],[SDT],[NgayDangKy],[DaXoa]) values ('" + kh.Makh+"',N'"+kh.Hoten+"','"+kh.Sdt+"','"+kh.Ngaydangky+"',0)";
            KNCSDL.executeQuery(sql);
        }
    }
}
