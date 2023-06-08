using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class HoaDonDAO
    {
        //In hoa don
        public static DataTable CrysHD(HoaDonDTO hd)
        {
            string sql = "select hd.SoHD,NgayLap,ThanhTien,TenSP,GiaBan,DonGia,CTHD.SoLuong,CTHD.KhuyenMai,nv.HoTen,kh.HoTenKH,(CTHD.SoLuong*DonGia) as TTMH from CTHD,HoaDon hd,SanPham sp,NhanVien nv,KhachHang kh where sp.MaSP=CTHD.MaSP and nv.MaNV=hd.MaNV and kh.MaKH=hd.MaKH and hd.SoHD=CTHD.SoHD and hd.SoHD=" + hd.Sohd+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        //In thong ke
        public static DataTable CrysTK(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            string sql = "select hd.SoHD , kh.MaKH, HoTenKH, DiaChi, SDT, TenSP , CTHD.SoLuong , DonGia , (CTHD.SoLuong * DonGia) as ThanhTien , NgayLap from HoaDon hd, CTHD, KhachHang kh, SanPham sp where sp.MaSP=CTHD.MaSP and kh.MaKH=hd.MaKH and hd.SoHD=CTHD.SoHD and DaThanhToan = 0 and  NgayLap between '"+hd1.Ngaylap+" 00:00:00' and '"+hd2.Ngaylap+" 23:59:59' order by NgayLap";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        public static DataTable TTHD()
        {
            string sql = "select * from HoaDon";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTHD1()
        {
            string sql = "select hd.SoHD,nv.HoTen,kh.HoTenKH,NgayLap,ThanhTien,IIF(DaThanhToan=0,N'Đã thanh toán',N'Chưa thanh toán') as TrangThai,SUM(SoLuong) as SLMua from HoaDon hd,CTHD,KhachHang kh,NhanVien nv where hd.SoHD=CTHD.SoHD and hd.MaKH=kh.MaKH and hd.MaNV=nv.MaNV group by hd.SoHD,CTHD.SoHD,NgayLap,ThanhTien,DaThanhToan,nv.HoTen,kh.HoTenKH";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SearchHD(HoaDonDTO hd1,HoaDonDTO hd2)
        {
            string sql = "select hd.SoHD,nv.HoTen,kh.HoTenKH,NgayLap,ThanhTien,IIF(DaThanhToan=0,N'Đã thanh toán',N'Chưa thanh toán') as TrangThai,SUM(SoLuong) as SLMua from HoaDon hd,CTHD,KhachHang kh,NhanVien nv where hd.SoHD=CTHD.SoHD and hd.MaKH=kh.MaKH and hd.MaNV=nv.MaNV and NgayLap BETWEEN '"+hd1.Ngaylap+" 00:00:00' and '"+hd2.Ngaylap+" 23:59:59' group by hd.SoHD,CTHD.SoHD,NgayLap,ThanhTien,DaThanhToan,nv.HoTen,kh.HoTenKH";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTDH(HoaDonDTO hd)
        {
            string sql = "select TenSP,DonGia,CTHD.KhuyenMai,CTHD.SoLuong from CTHD,SanPham where CTHD.MaSP=SanPham.MaSP and SoHD="+hd.Sohd+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SoHD_Max()
        {
            string sql = "select top 1 SoHD from HoaDon order by SoHD desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTCTHD(HoaDonDTO hd)
        {
            string sql = "select * from CTHD where SoHD=" + hd.Sohd + "";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable DoanhThu(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            string sql = "select SUM(ThanhTien) as TongTien, Count(hd.SoHD) as SLDH from HoaDon hd  where DaThanhToan = 0 and NgayLap BETWEEN '"+hd1.Ngaylap+" 00:00:00' AND '"+hd2.Ngaylap+" 23:59:59' ";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable LoiNhuan(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            string sql = "select SUM(GiaNhap * CTHD.SoLuong) as GiaBan from SanPham sp,HoaDon hd,CTHD where sp.MaSP=CTHD.MaSP and hd.SoHD=CTHD.SoHD and NgayLap BETWEEN '"+hd1.Ngaylap+" 00:00:00' AND '"+hd2.Ngaylap+" 23:59:59'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable BieuDo(HoaDonDTO hd1, HoaDonDTO hd2)
        {
            string sql = "select CAST(NgayLap as date) as NgayLap ,FORMAT(SUM(ThanhTien),'#,##0') as TongTien  from HoaDon hd where DaThanhToan=0 and  NgayLap BETWEEN '"+hd1.Ngaylap+" 00:00:00' and '"+hd2.Ngaylap+" 23:59:59' Group by CAST(NgayLap as date)";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable SoHD()
        {
            string sql = "select Count(SoHD) as SoHD from HoaDon";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        public static DataTable TTKHHD(KhachHangDTO kh)
        {
            string sql = "select * from HoaDon where MaKH='"+kh.Makh+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTNVHD(NhanVienDTO nv)
        {
            string sql = "select * from HoaDon where MaNV='"+nv.Manv+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }

        public static void ThemHD(HoaDonDTO hd)
        {
            string sql = "insert into HoaDon values ("+hd.Sohd+",'"+hd.Ngaylap+"','"+hd.Makh+"','"+hd.Manv+"',"+hd.Thanhtien+","+hd.Tienkhachtra+","+hd.Dathanhtoan+")";
            KNCSDL.executeQuery(sql);
        }
        public static void ThemCTHD(HoaDonDTO hd)
        {
            string sql = "insert into CTHD values ("+hd.Stt+","+hd.Sohd+","+hd.Masp+","+hd.Dongia+","+hd.Khuyenmai+","+hd.Sl+")";
            KNCSDL.executeQuery(sql);
        }

        public static void XoaCTHD(HoaDonDTO hd)
        {
            string sql = "delete from CTHD where SoHD="+hd.Sohd+"";
            KNCSDL.executeQuery(sql);
        }
        public static void XoaHD(HoaDonDTO hd)
        {
            string sql = "delete from HoaDon where SoHD="+hd.Sohd+"";
            KNCSDL.executeQuery(sql);
        }
    }
}
