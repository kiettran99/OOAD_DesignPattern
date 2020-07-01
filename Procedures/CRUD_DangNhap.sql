use QuanLyCaPhe
go
--1. Tạo Tài Khoản
drop procedure if exists Create_DangNhap
go

create procedure Create_DangNhap @TaiKhoan nvarchar(20),
	@MatKhau nvarchar(20),
	@MaNV int
as
begin
	insert into DangNhap values(@TaiKhoan, @MatKhau, @MaNV)
end
go

--2. Đọc Tài Khoản
drop procedure if exists Read_DangNhap
go

create procedure Read_DangNhap
as
begin
	select * from DangNhap
end
go

drop procedure if exists Read_DangNhap_ID
go

create procedure Read_DangNhap_ID @TaiKhoan nvarchar(20)
as
begin
	select *
	from DangNhap
	where TaiKhoan = @TaiKhoan
end
go

--3. Sửa Đăng Nhập
drop procedure if exists Update_DangNhap
go

create procedure Update_DangNhap @MaNV nvarchar(20),
	@MatKhau nvarchar(20)
as
begin
	update DangNhap
	set MatKhau = @MatKhau
	where MaNV = @MaNV
end
go

--4. Xóa Tài Khoản
drop procedure if exists Delete_DangNhap
go

create procedure Delete_DangNhap @MaNV nvarchar(20)
as
begin
	delete from DangNhap 
	where MaNV = @MaNV
end
go

--5. Cấp Lại Tài Khoản
drop procedure if exists Renew_DangNhap
go

create procedure Renew_DangNhap @MaNV nvarchar(20)
as
begin
	update DangNhap
	set MatKhau = N'123'
	where MaNV = @MaNV
end
go

--Sử dụng function để kiếm tra xem Tài Khoản đăng nhập đúng chưa -> trả về boolean
--Sử dụng trigger nếu người dùng vừa mới tạo tài khoản được thêm dữ liệu vào khách hàng hoặc nhân viên