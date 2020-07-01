use QuanLyCaPhe
go
--1. Tạo Khách Hàng
drop procedure if exists Create_KhachHang
go

create procedure Create_KhachHang @MaKH int,
	@HoKH nvarchar(20),
	@TenKH nvarChar(20),
	@GioiTinh nvarchar(10),
	@NgaySinh date,
	@SDT int,
	@DiaChi nvarchar(30),
	@MaThanhPho int 
as
begin
	insert into KhachHang values(@MaKH, @HoKH, @TenKH, @GioiTinh, @NgaySinh, @SDT, @DiaChi, @MaThanhPho)
end
go

--2. Đọc Khách Hàng
drop procedure if exists Read_KhachHang
go

create procedure Read_KhachHang
as
begin
	select MaKH, HoKH, TenKH, GioiTinh, NgaySinh, SDT, DiaChi, TenThanhPho from KhachHang join ThanhPho on KhachHang.MaThanhPho = ThanhPho.MaThanhPho
end							   
go

drop procedure if exists Read_KhachHang_ID
go

create procedure Read_KhachHang_ID @MaKH int
as
begin
	select * 
	from KhachHang
	where MaKH = @MaKH
end
go

--3. Sửa Khách Hàng
drop procedure if exists Update_KhachHang
go

create procedure Update_KhachHang @MaKH int,
	@HoKH nvarchar(20),
	@TenKH nvarChar(20),
	@GioiTinh nvarchar(10),
	@NgaySinh date,
	@SDT int,
	@DiaChi nvarchar(30),
	@MaThanhPho int 
as
begin
	update KhachHang
	set HoKH = @HoKH, TenKH = @TenKH, GioiTinh = @GioiTinh,
	NgaySinh = @NgaySinh, SDT = @SDT, DiaChi = @DiaChi, MaThanhPho = @MaThanhPho
	where MaKH = @MaKH
end
go

--4. Xóa Khách Hàng
drop procedure if exists Delete_KhachHang
go

create procedure Delete_KhachHang @MaKH int
as
begin
	delete from KhachHang 
	where MaKH = @MaKH
end
go