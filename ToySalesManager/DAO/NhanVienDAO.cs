using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class NhanVienDAO
    {
        public static DataTable TTNV_MaNV(NhanVienDTO nv)
        {
            string sql = "select * from NhanVien where MaNV like '%"+nv.Manv+"%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TenTheoManv(string manv)
        {
            string sql = "select HoTen from NhanVien where MaNV='"+manv+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        //Register
        public static DataTable MaNVMax()
        {
            string sql = "select top 1 MaNV from NhanVien order by MaNV desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static void ThemNhanVien(NhanVienDTO dk)
        {
            string sql = "insert into NhanVien([MaNV],[HoTen],[SDT],[Email],[Matkhau],[Quyen],[DaThoiViec]) values ('"+dk.Manv+"',N'"+dk.Hoten+"','"+dk.Sdt+"','"+dk.Email+"','"+dk.Matkhau+"',N'Nhân viên',0)";
            KNCSDL.executeQuery(sql);
        }
        //Login
        public static DataTable TK_MK(NhanVienDTO lg)
        {
            string sql = "select * from NhanVien where MaNV='"+lg.Manv+"' and Matkhau='"+lg.Matkhau+"'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        //Thiết lập
        public static void CapNhatNV(NhanVienDTO nv)
        {
            string sql = "update NhanVien set HoTen=N'"+nv.Hoten+"',SDT='"+nv.Sdt+"',NgaySinh='"+nv.Ngaysinh+"',GioiTinh="+nv.Gioitinh+",Diachi=N'"+nv.Diachi+"',Email='"+nv.Email+"' where MaNV='"+nv.Manv+"'";
            KNCSDL.executeQuery(sql);
        }
        public static void CapNhatAnh(NhanVienDTO nv)
        {
            string sql = "update NhanVien set Hinh='"+nv.Hinh+"' where MaNV='" + nv.Manv + "'";
            KNCSDL.executeQuery(sql);
        }
        public static void CapNhatMK(NhanVienDTO nv)
        {
            string sql = "update NhanVien set Matkhau='"+nv.Matkhau+"' where MaNV='" + nv.Manv + "'";
            KNCSDL.executeQuery(sql);
        }
        //form NhanVien
        public static DataTable TTNV()
        {
            string sql = "select MaNV,HoTen,SDT,NgaySinh,IIF(GioiTinh=0,'Nam','Nữ') as GioiTinh,Diachi,Email,Hinh,Matkhau,Quyen,DaThoiViec from NhanVien";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable TTNV_TenNV(NhanVienDTO nv)
        {
            string sql = "select MaNV,HoTen,SDT,NgaySinh,IIF(GioiTinh=0,'Nam','Nữ') as GioiTinh,Diachi,Email,Hinh,Matkhau,Quyen,DaThoiViec from NhanVien where HoTen like N'%" + nv.Hoten + "%'";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static void CapNhatNv(NhanVienDTO nv)
        {
            string sql = "update NhanVien set HoTen=N'" + nv.Hoten + "',SDT='" + nv.Sdt + "',NgaySinh='" + nv.Ngaysinh + "',GioiTinh=" + nv.Gioitinh + ",Diachi=N'" + nv.Diachi + "',Email='" + nv.Email + "',Quyen=N'"+nv.Quyen+"' where MaNV='" + nv.Manv + "'";
            KNCSDL.executeQuery(sql);
        }
        public static void XoaNV(NhanVienDTO nv)
        {
            string sql = "delete from NhanVien where MaNV='"+nv.Manv+"'";
            KNCSDL.executeQuery(sql);
        }
    }
}
