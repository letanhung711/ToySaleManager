using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class NhapHangDAO
    {
        public static DataTable TTPN()
        {
            string sql = "select * from PhieuNhap";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTCTPN(NhapHangDTO nh)
        {
            string sql = "select * from CTPhieuNhap where MaPhieu="+nh.Maphieu+"";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTPCN(NhapHangDTO nh)
        {
            string sql = "select * from PhieuNhap where Trangthai=N'"+nh.Trangthai+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable PN_Max()
        {
            string sql = "select top 1 MaPhieu from PhieuNhap order by MaPhieu desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable MaSPtheoTenSP(string tensp)
        {
            string sql = "select MaSP from SanPham where TenSP=N'"+tensp+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        //
        public static void themPhieuNhap(NhapHangDTO nh)
        {
            string sql = "insert into PhieuNhap([MaPhieu],[NgayLap],[MaNCC],[MaNV],[Trangthai]) values("+nh.Maphieu+",'"+nh.Ngaylap+"',"+nh.Mancc+",'"+nh.Manv+"',N'"+nh.Trangthai+"')";
            KNCSDL.executeQuery(sql);
        }
        public static void themCTPhieuNhap(NhapHangDTO nh)
        {
            string sql = "insert into CTPhieuNhap([STT],[MaPhieu],[MaSP],[SoLuong],[GiaNhap]) values ("+nh.Stt+","+nh.Maphieu+","+nh.Masp+","+nh.Sl+","+nh.Gianhap+")";
            KNCSDL.executeQuery(sql);
        }
        public static void xoaPhieuNhap(NhapHangDTO nh)
        {
            string sql = "delete from PhieuNhap where MaPhieu="+nh.Maphieu+"";
            KNCSDL.executeQuery(sql);
        }
        public static void xoaCTPhieuNhap(NhapHangDTO nh)
        {
            string sql = "delete from CTPhieuNhap where MaPhieu="+nh.Maphieu+"";
            KNCSDL.executeQuery(sql);
        }
        public static void capnhatPhieuNhap(NhapHangDTO nh)
        {
            string sql = "update PhieuNhap set Trangthai=N'"+nh.Trangthai+"' where MaPhieu="+nh.Maphieu+"";
            KNCSDL.executeQuery(sql);
        }
        public static void capnhatsl(SanPhamDTO sp)
        {
            string sql = "update SanPham set SoLuong="+sp.Soluong+" where MaSP="+sp.Masp+"";
            KNCSDL.executeQuery(sql);
        }
    }
}
