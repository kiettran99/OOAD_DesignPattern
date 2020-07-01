use master
drop database if exists QuanLyCaPhe
create database QuanLyCaPhe
go
use QuanLyCaPhe

go

drop table if exists ThanhPho
drop table if exists KhachHang

create table ThanhPho (
	MaThanhPho int,
	TenThanhPho nvarchar(20),
	primary key(MaThanhPho)
)

delete from ThanhPho

insert into ThanhPho values('1',N'Mỹ Tho')
insert into ThanhPho values('2',N'Trà Vinh')
insert into ThanhPho values('3',N'Bến Tre')
insert into ThanhPho values('6',N'Hồ Chí Minh')

create table KhachHang (
	MaKH int not null,
	HoKH nvarchar(20),
	TenKH nvarChar(20),
	GioiTinh nvarchar(10),
	NgaySinh date,
	SDT int,
	DiaChi nvarchar(30),
	MaThanhPho int,
	primary key(MaKH),
	constraint FK_KhachHang_ThanhPho foreign key (MaThanhPho) references ThanhPho(MaThanhPho)
)

insert into KhachHang values(153165, N'Nguyen ', N'Huy', N'Nam', '1997-12-05', '0904567841', N'92 Hai Ba Trung Ho Chi Minh', '1')
insert into KhachHang values(222415, N'Nguyen ', N'Huy', N'Võ', '1998-11-11', '0904567841', N'Gò Vấp Ho Chi Minh', '2')
insert into KhachHang values(123455, N'Nguyen ', N'Thị', N'Cúc', '1997-12-05', '0904567841', N'9 Hoàng Diệu 2 Ho Chi Minh', '3')

create table NhanVien(
	MaNV int not null,
	HoNV nvarchar(20),
	TenNV nvarchar(20),
	Nu		bit,
	NgaySinh date,
	SDT int,
	DiaChi nvarchar(30),
	NgayBD datetime,
	HinhAnh image,

	primary key(MaNV)
)

drop table if exists NhanVien_HoaDon_KhachHang
create table NhanVien_HoaDon_KhachHang(
	IDHoaDon int not null,
	MaNV int,
	TenNV nvarchar(20),
	TenKH nvarChar(20),
	NgayBan datetime,
	ThanhTien float,
	primary key (IDHoaDon)
)


create table DangNhap(
	TaiKhoan nvarchar(20),
	MatKhau nvarchar(20),
	MaNV int,
	primary key(TaiKhoan)
)
insert into DangNhap values(N'admin',N'admin','0');
insert into DangNhap values(N'nv1',N'nv1','1');

create table BanAn(
	IDBanAn int not null,					
	TenBan nvarchar(100) not null default N'Không có tên',
	TinhTrang nvarchar(100) not null default N'Trống',	-- Ban dang trong hay dang nguoi
	primary key (IDBanAn)
)

create table LoaiThucAn(
	IDLoaiThucAn int not null,
	TenLoaiThucAn nvarchar(100) not null default N'Không có tên',
	primary key (IDLoaiThucAn)
)
insert into LoaiThucAn values(10,N'Trái Cây')
insert into LoaiThucAn values(23,N'Sinh Tố')
insert into LoaiThucAn values(20,N'Nước')
insert into LoaiThucAn values(21,N'Ăn Vặt')

create table ThucAn(
	IDThucAn int not null,
	TenThucAn nvarchar(100) not null default N'Không có tên',
	IDLoaiThucAn int not null,
	Gia float default 0,
	primary key (IDThucAn),
	foreign key (IDLoaiThucAn) references LoaiThucAn(IDLoaiThucAn)
)
insert into ThucAn values(10,N'Trái Cây Tô',10,'100000')
insert into ThucAn values(23,N'Sinh Tố Bơ',23,'200000')
insert into ThucAn values(20,N'Cafe sữa đá',20,'300000')
insert into ThucAn values(21,N'Trứng chiên',21,'10000')
insert into ThucAn values(19,N'Khoai tây chiên',21,'10000')


create table HoaDon(
	IDHoaDon int not null,
	NgayTaoHoaDon datetime not null,
	NgayKetThucHoaDon datetime,
	IDBanAn int not null,
	TongTien float default 0,
	GiamGia int default 0,
	TinhTrang bit not null default 0, -- Tinh trang thanh toan hoa don
	primary key (IDHoaDon),
	foreign key (IDBanAn) references BanAn(IDBanAn)
)

--Hoa don (n,n) ThucAn
create table ChiTietHoaDon(
	IDHoaDon int not null,
	IDThucAn int not null,
	SoLuong int not null default 0 ,
	primary key (IDHoaDon, IDThucAn),
	foreign key (IDHoaDon) references HoaDon(IDHoaDon),
	foreign key (IDThucAn) references ThucAn(IDThucAn)
)

--Cham Cong
create table ChamCong(
	MaNV int not null ,
	TenNV nvarchar(20),
	GioIn time,
	GioOut	time,
	primary key (MaNV),
	foreign key (MaNV) references NhanVien(MaNV)	
)
-- tính lương
create table TinhLuong(
	MaNV int  not null,
	TenNV nvarchar(20),
	SoGioLam float,
	Luong float,
	primary key(MaNV),
	foreign key (MaNV) references ChamCong(MaNV)
)
delete from NhanVien_HoaDon_KhachHang
delete from KhachHang
delete from  NhanVien
delete from ThanhPho
delete from DangNhap
delete from ChamCong
delete from TinhLuong
delete from ChiTietHoaDon
delete from HoaDon

delete from BanAn
delete from LoaiThucAn
delete from ThucAn

/*
--Query Tạo csdl bàn ăn
declare @i int = 0

while @i <= 20
begin
	insert into BanAn(IDBanAn, TenBan) 
	values(cast(@i as nvarchar(100)) , N'Bàn' + cast(@i as nvarchar(100)))
	set @i = @i + 1
end

select * from BanAn

--Tạo CSDL Thức Ăn

declare @iCFood int = 0

while @iCFood <= 20
begin
	insert into LoaiThucAn values(cast(@iCFood as int), N'Loại ' + cast(@iCFood as nvarchar(100)))
	set @iCFood = @iCFood + 1
end

select * from LoaiThucAn

declare @iFood int = 0
while @iFood <= 20
begin
	insert into ThucAn values(cast(@iFood as int), N'Thức ăn  ' + cast(@iFood as nvarchar(100)),cast(@iFood as int) , cast(@iFood * 20000 as nvarchar(100)))
	set @iFood = @iFood + 1
end

select * from ThucAn

insert into BanAn values(21, 'Bàn thứ 21', 'Không trống')
*/

-- thêm category

--Query Tạo csdl bàn ăn
declare @i int = 0

while @i <= 20
begin
	insert into BanAn(IDBanAn, TenBan) 
	values(cast(@i as nvarchar(100)) , N'Bàn' + cast(@i as nvarchar(100)))
	set @i = @i + 1
end

select * from BanAn

--INSERT LoaiThucAn     
--VALUES  ( 1 , N'Hải sản'
--          )
--INSERT LoaiThucAn
--VALUES  ( 2, N'Nông sản' )

--INSERT LoaiThucAn
--VALUES  ( 3, N'Lâm sản' )

--INSERT LoaiThucAn
--VALUES  ( 4, N'Sản sản' )

--INSERT LoaiThucAn
--VALUES  (5, N'Nước' )

---- thêm món ăn
--INSERT ThucAn
--VALUES  ( 1, N'Mực một nắng nước sa tế', 
--          1, -- idCategory - int
--          120000)
--INSERT ThucAn
--VALUES  ( 2, N'Nghêu hấp xả', 1, 50000)
--INSERT ThucAn
--VALUES  ( 3, N'Dú dê nướng sữa', 2, 60000)
--INSERT ThucAn
--VALUES  ( 4, N'Heo rừng nướng muối ớt', 3, 75000)
--INSERT ThucAn
--VALUES  ( 5, N'Cơm chiên mushi', 4, 999999)
--INSERT ThucAn
--VALUES  ( 6, N'7Up', 5, 15000)
--INSERT ThucAn
--VALUES  ( 7, N'Cafe', 5, 12000)

---- thêm bill
INSERT	HoaDon
VALUES  ( 5,
			GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          3 , -- idTable - int
		  0,
		  0,
          0  -- status - int
        )
        
--INSERT	HoaDon
--VALUES  (6, GETDATE() , -- DateCheckIn - date
--          NULL , -- DateCheckOut - date
--		   0,
--		  0,
--          4, -- idTable - int
--          0  -- status - int
--        )
--INSERT	HoaDon
--VALUES  (7, GETDATE() , -- DateCheckIn - date
--          GETDATE() , -- DateCheckOut - date
--          5 , -- idTable - int
--		   0,
--		  0,
--          1  -- status - int
--        )

---- thêm bill infoHoaDon
--INSERT	ChiTietHoaDon
--VALUES  ( 5, -- idBill - int
--          1, -- idFood - int
--          2  -- count - int
--          )
--INSERT	ChiTietHoaDon
--VALUES  ( 5, -- idBill - int
--          3, -- idFood - int
--          4  -- count - int
--          )
--INSERT	ChiTietHoaDon
--VALUES  ( 5, -- idBill - int
--          5, -- idFood - int
--          1  -- count - int
--          )
--INSERT	ChiTietHoaDon
--VALUES  ( 6, -- idBill - int
--          1, -- idFood - int
--          2  -- count - int
--          )
--INSERT	ChiTietHoaDon
--VALUES  ( 6, -- idBill - int
--          6, -- idFood - int
--          2  -- count - int
--          )
--INSERT	ChiTietHoaDon
--VALUES  ( 7, -- idBill - int
--          5, -- idFood - int
--          2  -- count - int
--        )

--		select * from DangNhap
--		select * from NhanVien

		insert into DangNhap values('admin', 'admin', 0);
		insert into DangNhap values('nv1', 'nv1', 1);
--		insert into NhanVien values(1, 'Nguyen Xuan', 'Huy', 0, '1997-12-05', '0904567841', '92 Hai Ba Trung Ho Chi Minh' )

delete from ThucAn

insert into ThucAn values(1, 'Xoài', 10, 2000)
insert into ThucAn values(2, N'Ổi', 10, 3000)
insert into ThucAn values(3, 'Đào', 10, 2000)

insert into ThucAn values(4, '7UP', 20, 5000)
insert into ThucAn values(5, 'Pepsi', 20, 6000)
insert into ThucAn values(6, 'Coca-cola', 20, 7000)

insert into ThucAn values(7, 'Oshi Cay', 21, 2000)
insert into ThucAn values(8, N'Cơm Rang Khô', 21, 6000)
insert into ThucAn values(9, N'Bánh tráng trộn', 21, 7000)

insert into ThucAn values(10, N'Sinh Tố Xoài', 23, 10000)
insert into ThucAn values(11, N'Rau má', 23, 120000)
insert into ThucAn values(12, N'Bánh tráng trộn', 23, 130000)

insert into ThucAn values(13, N'Cà phê sữa', 20, 20000)
insert into ThucAn values(14, N'Cà phê trung nguyên', 20, 250000)
insert into ThucAn values(15, N'Cà phê đặc biệt', 20, 30000)
insert into ThucAn values(16, N'Hồng trà', 20, 15000)
insert into ThucAn values(17, N'Matcha Latte', 20, 25000)

drop proc if exists DanhThu_Report
go

create proc DanhThu_Report
@ngayTaoHoaDon date, @ngayKetThucHoaDon date
as
begin
	select IDHoaDon, TenBan, NgayTaoHoaDon, NgayKetThucHoaDon, GiamGia,TongTien
	 from HoaDon join BanAn on HoaDon.IDBanAn = BanAn.IDBanAn 
	where HoaDon.TinhTrang = 1 and cast(NgayTaoHoaDon as date) >= @ngayTaoHoaDon and cast(NgayKetThucHoaDon as date) <= @ngayKetThucHoaDon
end
go

drop proc if exists ChiTietHoaDon_Report
go
create proc ChiTietHoaDon_Report
@IDHoaDon int
as
begin
	select * from ChiTietHoaDon join ThucAn on ChiTietHoaDon.IDThucAn = ThucAn.IDThucAn join HoaDon on HoaDon.IDHoaDon = ChiTietHoaDon.IDHoaDon join BanAn on BanAn.IDBanAn = HoaDon.IDBanAn where HoaDon.IDHoaDon = @IDHoaDon
end
go