using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ToySalesManager.DTO;

namespace ToySalesManager.DAO
{
    class NCC_LoaiSPDAO
    {
        //Loai san pham
        public static DataTable TTLoaiSP()
        {
            string sql = "select * from LoaiSP";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable MaloaiSP_Max()
        {
            string sql = "select top 1 MaloaiSP from LoaiSP order by MaloaiSP desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static void CapNhat(NCC_LoaiSPDTO lsp)
        {
            string sql = "update LoaiSP set TenloaiSP=N'"+lsp.Tenloaisp+"' where MaloaiSP="+lsp.Maloaisp+"";
            KNCSDL.executeQuery(sql);
        }
        public static void Them(NCC_LoaiSPDTO lsp)
        {
            string sql = "insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values ("+lsp.Maloaisp+",N'"+lsp.Tenloaisp+"',0)";
            KNCSDL.executeQuery(sql);
        }
        public static void NgungKinhDoanh(NCC_LoaiSPDTO lsp)
        {
            string sql = "delete from LoaiSP where MaloaiSP="+lsp.Maloaisp+"";
            KNCSDL.executeQuery(sql);
        }
        //NCC
        public static DataTable TTNCC()
        {
            string sql = "select * from NCC";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static DataTable MaNCC_Max()
        {
            string sql = "select top 1 MaNCC from NCC order by MaNCC desc";
            DataTable dt = new DataTable();
            dt = KNCSDL.readData(sql);
            return dt;
        }
        public static void CapNhatNCC(NCC_LoaiSPDTO ncc)
        {
            string sql = "update NCC set TenNCC=N'"+ncc.Tenncc+"',DiaChi=N'"+ncc.Diachi+"',SDT='"+ncc.Sdt+"' where MaNCC="+ncc.Mancc+"";
            KNCSDL.executeQuery(sql);
        }
        public static void ThemNCC(NCC_LoaiSPDTO ncc)
        {
            string sql = "insert into NCC([MaNCC],[TenNCC],[DiaChi],[SDT],[NgungHopTac]) values ("+ncc.Mancc+",N'"+ncc.Tenncc+"',N'"+ncc.Diachi+"','"+ncc.Sdt+"',0)";
            KNCSDL.executeQuery(sql);
        }
        public static void NgungHopTac(NCC_LoaiSPDTO ncc)
        {
            string sql = "delete from NCC where MaNCC="+ncc.Mancc+"";
            KNCSDL.executeQuery(sql);
        }
    }
}
