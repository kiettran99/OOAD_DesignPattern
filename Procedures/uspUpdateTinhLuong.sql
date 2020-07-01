--Cập nhật Nhân Viên từ bảng NhanVien thông qua MANV
GO
USE QuanLyCaPhe;
GO
IF OBJECT_ID('uspUpdateTinhLuong') IS NOT NULL
	DROP PROC uspUpdateTinhLuong;
GO
CREATE PROCEDURE uspUpdateTinhLuong
	@SoGioLam int,
	@Luong float,
	@MaNV int,
	@TenNV nvarchar(100)
AS
	IF @MaNV is null 
	THROW 50001,'MaNV Không Được Phép NULL!',1;
	IF @TenNV is null OR @TenNV = ''
	THROW 50001,'HoNV Không Được Để Trống!',1;
	IF @SoGioLam < 1
	THROW 50001,'Gia phải lớn hơn',1;
	IF @Luong < 1
	THROW 50001,'Gia phải lớn hơn',1;
	UPDATE TinhLuong
		SET 
		Luong=@Luong,
		SoGioLam=@SoGioLam
			WHERE MaNV =	@MaNV
		COMMIT
	