--Cập nhật Nhân Viên từ bảng NhanVien thông qua MANV
GO
USE QuanLyCaPhe;
GO
IF OBJECT_ID('uspUpdateNhanVien') IS NOT NULL
	DROP PROC uspUpdateNhanVien;
GO
CREATE PROCEDURE uspUpdateNhanVien
	@MaNV				nvarchar(50),		    --1.MaNV
	@TenNV	nvarchar(50),	
	@HoNV			nvarchar(50),			--2.HoVaTenNV
	@Nu			nvarchar(50),			--3.GioiTinh
	@SDT int,
	@NgaySinh			datetime,				--4.NgaySinh
	@DiaChi			nvarchar(50),			--5.NoiSinh
	@NgayBD  datetime,
	@HinhAnh image
AS
	IF @MaNV is null 
	THROW 50001,'MaNV Không Được Phép NULL!',1;
	IF @HoNV is null OR @HoNV = ''
	THROW 50001,'HoNV Không Được Để Trống!',1;
	IF @TenNV is null OR @TenNV = ''
	THROW 50001,'HoNV Không Được Để Trống!',1;
	IF @NgaySinh IS NULL OR @NgaySinh >= GETDATE()
	THROW 50001,'Ngày Sinh Không Được Lớn Hơn Ngày Hiện Tại!',1; 
	IF @DiaChi is null OR @DiaChi = ''
	THROW 50001,'NoiSinh Không Được Để Trống!',1;
	IF @Nu is null OR @Nu = ''
	THROW 50001,'Gioi Tinh Không Được Để Trống!',1;
	UPDATE NHANVIEN
		SET MaNV	=	@MaNV,
			HoNV	=	@HoNV, 
			TenNV	=	@TenNV,
			Nu		=	@Nu, 
			NgaySinh=	@NgaySinh,
			DiaChi	=	@DiaChi,
			SDT		=	@SDT,
			NgayBD=@NgayBD,
			HinhAnh=@HinhAnh
			WHERE MaNV		=	@MaNV
		COMMIT

