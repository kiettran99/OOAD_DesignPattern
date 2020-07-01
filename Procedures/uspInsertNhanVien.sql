--Thêm Nhân Viên
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspInsertNhanVien') IS NOT NULL
DROP PROC uspInsertNhanVien
GO
CREATE PROCEDURE uspInsertNhanVien
		@MaNV		nvarchar(50)=NULL,		--1.MaNV
		@HoNV	nvarchar(50),			--2.HoVaTenNV
		@TenNV	nvarchar(50),
		@Nu	bit,			--3.GioiTinh
		@NgaySinh	datetime,				--4.NgaySinh
		@SDT  int,
		@DiaChi	nvarchar(255),		--6.DiaChiHienTai
		@NgayBD	datetime,
		@HinhAnh image,
		@GioIn time,
		@GioOut time
AS
BEGIN	
		IF EXISTS (SELECT * FROM NHANVIEN WHERE MaNV=@MaNV)
	THROW 50001,'MÃ NHÂN VIÊN Này Đã Tồn Tại!',1;
	IF LEN(@MaNV) <> 5
	THROW 50001,'MÃ NHÂN VIÊN Phải Có 5 Ký Tự!',1;
	IF @HoNV is null OR @HoNV = ''
	THROW 50001,'HoVaTenNV Không Được Để Trống!',1;
	IF @TenNV is null OR @TenNV = ''
	THROW 50001,'HoVaTenNV Không Được Để Trống!',1;
		IF @TenNV is null OR @TenNV = ''
	THROW 50001,'HoVaTenNV Không Được Để Trống!',1;
	IF @NgaySinh IS NULL OR @NgaySinh >= GETDATE()
	THROW 50001,'Ngày Sinh Không Được Lớn Hơn Ngày Hiện Tại!',1; 
	IF @DiaChi is null OR @DiaChi = ''
	THROW 50001,'DiaChiHienTai Không Được Để Trống!',1;
	--IF @HinhAnh is null OR @HinhAnh = ''
	--THROW 50001,'ANHNV Không Được Phép NULL, Vui Lòng Chọn Ảnh Đại Diện!',1; 
	IF @NgayBD IS NULL OR @NgayBD >= GETDATE()
	THROW 50001,'Ngày Sinh Không Được Lớn Hơn Ngày Hiện Tại!',1; 
	
	BEGIN TRANSACTION
	BEGIN TRY
		INSERT dbo.ChamCong 
		VALUES (@MaNV,@TenNV, @GioIn, @GioOut);
		INSERT dbo.NhanVien
		VALUES (@MaNV,@HoNV,@TenNV,@Nu,@NgaySinh,@SDT,@DiaChi,@NgayBD,@HinhAnh);
		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
END
