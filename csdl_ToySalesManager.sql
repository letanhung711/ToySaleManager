Create database ToySalesManager
go

use ToySalesManager
go

create table NCC
(
	MaNCC		int primary key,
	TenNCC		nvarchar(50),
	DiaChi		nvarchar(200),
	SDT			varchar(20),
	NgungHopTac	bit
)
go
create table LoaiSP
(
	MaloaiSP	int primary key,
	TenloaiSP	nvarchar(50),
	NgungKinhDoanh	bit
)
go
create table SanPham
(
	MaSP		int primary key,
	TenSP		nvarchar(200),
	MaloaiSP	int,
	DVT			nvarchar(20),
	MaNCC		int,
	NgaySX		datetime,
	NgayHetHan	datetime,
	SoLuong		int,
	GiaBan		int,
	GiaNhap		int,
	LoiNhuan	int,
	KhuyenMai	int,
	Hinh		varchar(50),
	NgungKinhDoanh	bit	
	CONSTRAINT fk_SP_LoaiSP FOREIGN KEY (MaloaiSP) REFERENCES LoaiSP (MaloaiSP),
	CONSTRAINT fk_SP_NCC FOREIGN KEY (MaNCC) REFERENCES NCC (MaNCC)
)
go
create table NhanVien
(
	MaNV		varchar(10) primary key,
	HoTen		nvarchar(50),
	SDT			varchar(20),
	NgaySinh	datetime,
	GioiTinh	bit,
	Diachi		nvarchar(200),
	Email		varchar(50),
	Hinh		varchar(50),
	Matkhau		varchar(10),
	Quyen		nvarchar(20),
	DaThoiViec	bit
)
go
create table KhachHang
(
	MaKH		varchar(10) primary key,
	HoTenKH		nvarchar(50),
	SDT			varchar(20),
	DiaChi		nvarchar(200),
	GioiTinh	bit,
	NgayDangKy	datetime,
	DaXoa		bit
)
go
create table HoaDon
(
	SoHD		int primary key,
	NgayLap		datetime,
	MaKH		varchar(10),
	MaNV		varchar(10),
	ThanhTien	int,
	TienKhachTra	int,
	DaThanhToan	bit
	CONSTRAINT fk_HD_KH FOREIGN KEY (MaKH) REFERENCES KhachHang (MaKH),
	CONSTRAINT fk_HD_NV FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV)
)
go
create table CTHD
(
	STT			int,
	SoHD		int,
	MaSP		int,
	DonGia		int,
	KhuyenMai	int,
	SoLuong		int
	CONSTRAINT fk_CTHD_SP FOREIGN KEY (MaSP) REFERENCES SanPham (MaSP),
	CONSTRAINT fk_CTHD_HD FOREIGN KEY (SoHD) REFERENCES HoaDon (SoHD)
)
go
create table PhieuNhap
(
	MaPhieu		int primary key,
	NgayLap		datetime,
	MaNCC		int,
	MaNV		varchar(10),
	Trangthai	nvarchar(50)
	CONSTRAINT fk_PhieuNhap_NCC FOREIGN KEY (MaNCC) REFERENCES NCC (MaNCC),
	CONSTRAINT fk_PhieuNhap_NV FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV)
)
go
create table CTPhieuNhap
(
	STT				int,
	MaPhieu			int,
	MaSP			int,
	SoLuong			int,
	GiaNhap			int
	CONSTRAINT fk_CTPhieuNhap_PhieuNhap FOREIGN KEY (MaPhieu) REFERENCES PhieuNhap (MaPhieu),
	CONSTRAINT fk_CTPhieuNhap_SP FOREIGN KEY (MaSP) REFERENCES SanPham (MaSP)
)
go

-------------Add---------------------

--Table Nhan Vien
insert into NhanVien([MaNV],[HoTen],[GioiTinh],[NgaySinh],[SDT],[Email],[Diachi],[Matkhau],[Quyen],[DaThoiViec]) values (
	'NV1',
	N'Lê Văn A',
	0,
	'3/18/2000',
	'0838654789',
	'levana@gmail.com',
	N'Châu Thành, Tiền Giang',
	'admin123',
	N'Quản lý',
	0
) 
insert into NhanVien([MaNV],[HoTen],[GioiTinh],[NgaySinh],[SDT],[Email],[Diachi],[Matkhau],[Quyen],[DaThoiViec]) values (
	'NV2',
	N'Nguyễn Tấn B',
	0,
	'5/27/2002',
	'0546782123',
	'nguyentanb@gmail.com',
	N'Cai Lậy, Tiền Giang',
	'users123',
	N'Nhân viên',
	0
)
--Table Loai San Pham
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (1,N'Đồ chơi LEGO',0)
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (2,N'Đồ chơi lắp ráp',0)
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (3,N'Đồ chơi giáo dục',0)
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (4,N'Đồ chơi vận động thể chất',0)
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (5,N'Đồ chơi nghề nghiệp',0)
insert into LoaiSP([MaloaiSP],[TenloaiSP],[NgungKinhDoanh]) values (6,N'Đồ chơi búp bê',0)
--Table Nha cung cap
insert into NCC([MaNCC],[TenNCC],[DiaChi],[SDT],[NgungHopTac]) values (1,N'Tổng hợp',N'Tiền Giang','0342567498',0)
--Table San pham
insert into SanPham values (1,N'Tàu Tuần Tra Cảnh Sát',1,N'Hộp',1,'5/27/2019','8/13/2030',98,1518300,1125000,50,10,'sanpham1.jpg',0)
insert into SanPham values (2,N'Đồ chơi rút gỗ loại lớn 48 miếng',3,N'Hộp',1,'4/14/2023','4/14/2023',6,104200,99000,5,0,'sanpham2.jpg',0)
insert into SanPham values (3,N'21303 LEGO® IDEAS WALL•E',1,N'Hộp',1,'4/14/2023','4/14/2023',10,5789400,5500000,5,10,'sanpham3.jpg',0)
insert into SanPham values (4,N'Đồ chơi Bác sĩ HT3287',5,N'Túi',1,'4/14/2023','4/14/2023',55,58700,57000,3,5,'sanpham4.jpg',0)
insert into SanPham values (5,N'Siêu Xe Ferrari 812',2,N'Hộp',1,'4/14/2023','4/14/2023',110,841000,799000,5,0,'sanpham5.jpg',0)
insert into SanPham values (6,N'Xe lắc Holla HL-02190',4,N'Cái',1,'4/14/2023','4/14/2023',45,473600,450000,5,10,'sanpham6.jpg',0)
insert into SanPham values (7,N'Đồ chơi lật đật VBC-2211A',6,N'Cái',1,'4/14/2023','4/14/2023',70,126500,124000,2,5,'sanpham7.jpg',0)
insert into SanPham values (8,N'Bộ cờ Nhà Hufflepuff',2,N'Hộp',1,'4/14/2023','4/14/2023',35,1181700,1099000,7,10,'sanpham8.jpg',0)
insert into SanPham values (9,N'Đồ chơi túi gạch xây nhà HT7883',5,N'Túi',1,'4/14/2023','4/14/2023',43,170100,165000,3,3,'sanpham9.jpg',0)
insert into SanPham values (10,N'Bảng gỗ ghép chữ viết hoa Tiếng Việt',3,N'Túi',1,'4/14/2023','4/14/2023',89,60200,59000,2,0,'sanpham10.jpg',0)
insert into SanPham values (11,N'LEGO® SPIDER-MAN™: WEB WARRIORS ULTIMATE BRIDGE BATTLE',1,N'Hộp',1,'4/14/2023','4/14/2023',67,3418200,3179000,7,5,'sanpham11.jpg',0)
insert into SanPham values (12,N'Cầu trượt khủng long bạo chúa Toys House',4,N'Cái',1,'4/14/2023','4/14/2023',24,1665600,1599000,4,3,'sanpham12.jpg',0)
insert into SanPham values (13,N'Hộp búp bê Anna & Elsa',6,N'Hộp',1,'4/14/2023','4/14/2023',80,144800,142000,2,0,'sanpham13.jpg',0)
insert into SanPham values (14,N'Bộ lắp ráp điều hành trạm sửa xe',2,N'Hộp',1,'4/14/2023','4/14/2023',110,714700,679000,5,20,'sanpham14.jpg',0)
insert into SanPham values (15,N'Búp bê Barbie nghề nghiệp - Lính cứu hỏa GFX29/GFX23',6,N'Cái',1,'4/14/2023','4/14/2023',65,339300,319000,6,15,'sanpham15.jpg',0)
insert into SanPham values (16,N'Thú nhún bơm hơi hình con lừa Toys House',4,N'Cái',1,'4/14/2023','4/14/2023',57,367300,360000,2,4,'sanpham16.jpg',0)
insert into SanPham values (17,N'Đồ chơi vải Lalala Baby hình khối Travel block',3,N'Hộp',1,'4/14/2023','4/14/2023',89,275200,267000,3,0,'sanpham17.jpg',0)
insert into SanPham values (18,N'Trại cứu hộ động vật hoang dã',1,N'Hộp',1,'4/14/2023','4/14/2023',110,2487700,2239000,10,20,'sanpham18.jpg',0)
insert into SanPham values (19,N'Nhà Lướt Sóng Bãi Biển',1,N'Hộp',1,'4/14/2023','4/14/2023',34,1363700,1091000,20,5,'sanpham19.jpg',0)
insert into SanPham values (20,N'Đồ chơi bác sĩ No.660-16',5,N'Túi',1,'4/14/2023','4/14/2023',91,164900,160000,3,0,'sanpham20.jpg',0)
insert into SanPham values (21,N'Găng Tay Vô Cực',2,N'Hộp',1,'4/14/2023','4/14/2023',53,3221100,2899000,10,30,'sanpham21.jpg',0)
insert into SanPham values (22,N'Đồ chơi lắp ráp Vecto DIY - Xe tăng',2,N'Cái',1,'4/14/2023','4/14/2023',48,205100,199000,3,0,'sanpham22.jpg',0)
insert into SanPham values (23,N'Ván trượt Penny',4,N'Cái',1,'4/14/2023','4/14/2023',115,356800,339000,5,0,'sanpham23.jpg',0)
insert into SanPham values (24,N'Bộ màu vẽ hộp gỗ cao cấp Colormate',3,N'Hộp',1,'4/14/2023','4/14/2023',37,429300,395000,8,40,'sanpham24.jpg',0)
insert into SanPham values (25,N'Bộ trống đồ chơi Jazz Drum Toyshouse 3303',5,N'Túi',1,'4/14/2023','4/14/2023',18,100000,98000,2,25,'sanpham25.jpg',0)

--Table Khach Hang
insert into KhachHang values ('KH1',N'Lê Tấn Hưng','0845324645',N'Châu Thành,Tiền Giang',0,'5/7/2023',0)
insert into KhachHang values ('KH2',N'Nguyễn Ngọc Sang','0845324645',N'TP.Mỹ Tho',0,'5/7/2023',0)

--Table Hoa Don
--table1
insert into HoaDon values (1,'5/8/2023','KH1','NV1',461000,500000,0)
	--Table CTHD
	insert into CTHD values (1,1,23,356800,0,1)
	insert into CTHD values (2,1,2,104200,0,1)
--table2
insert into HoaDon values (2,'5/10/2023','KH2','NV1',1034380,1100000,0)
	--Table CTHD
	insert into CTHD values (1,2,13,144800,0,1)
	insert into CTHD values (2,2,17,275200,0,1)
	insert into CTHD values (3,2,23,356800,0,1)
	insert into CTHD values (4,2,24,257580,0,1)
--table3
insert into HoaDon values (3,'5/15/2023','KH1','NV1',5210460,5300000,0)
	--Table CTHD
	insert into CTHD values (1,3,3,5210460,0,1)


--truy van
select * from NhanVien
select * from HoaDon
select * from CTHD

select SUM(ThanhTien) as TongTien, Count(hd.SoHD) as SLDH from HoaDon hd  where DaThanhToan = 0 and MONTH(NgayLap) = 5 and YEAR(NgayLap) = 2023


select top 5 sp.MaSP , Tensp , GiaBan ,SUM(CTHD.SoLuong) as SL  from CTHD,HoaDon hd,SanPham sp where sp.MaSP=CTHD.MaSP and hd.SoHD=CTHD.SoHD group by sp.MaSP,TenSP,GiaBan order by SL desc


select CAST(NgayLap as date) as NgayLap ,SUM(ThanhTien) as TongTien  from HoaDon hd where DaThanhToan=0 and  NgayLap BETWEEN '5/14/2023 00:00:00' and '5/14/2023 23:59:59' Group by CAST(NgayLap as date)

select * from HoaDon
select * from CTHD
select * from SanPham

select hd.SoHD,NgayLap,ThanhTien,TenSP,GiaBan,DonGia,CTHD.SoLuong,CTHD.KhuyenMai,nv.HoTen,kh.HoTenKH,(CTHD.SoLuong*DonGia) as TTMH from CTHD,HoaDon hd,SanPham sp,NhanVien nv,KhachHang kh where sp.MaSP=CTHD.MaSP and nv.MaNV=hd.MaNV and kh.MaKH=hd.MaKH and hd.SoHD=CTHD.SoHD and hd.SoHD=2

select hd.SoHD,nv.HoTen,kh.HoTenKH,NgayLap,ThanhTien,IIF(DaThanhToan=0,N'Đã thanh toán',N'Chưa thanh toán') as TrangThai,SUM(SoLuong) as SLMua from HoaDon hd,CTHD,KhachHang kh,NhanVien nv where hd.SoHD=CTHD.SoHD and hd.MaKH=kh.MaKH and hd.MaNV=nv.MaNV and NgayLap BETWEEN '5/10/2023 00:00:00' and '5/10/2023 23:59:59' group by hd.SoHD,CTHD.SoHD,NgayLap,ThanhTien,DaThanhToan,nv.HoTen,kh.HoTenKH


select hd.SoHD , kh.MaKH, HoTenKH, DiaChi, SDT, TenSP , CTHD.SoLuong , DonGia , (CTHD.SoLuong * DonGia) as ThanhTien , NgayLap from HoaDon hd, CTHD, KhachHang kh, SanPham sp where sp.MaSP=CTHD.MaSP and kh.MaKH=hd.MaKH and hd.SoHD=CTHD.SoHD and DaThanhToan = 0 and  NgayLap between '5/1/2023 00:00:00' and '5/20/2023 23:59:59' order by NgayLap
