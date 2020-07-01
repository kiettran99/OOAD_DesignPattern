USE QuanLyCaPhe
GO
IF OBJECT_ID('uspDeleteNhanVien') IS NOT NULL
	DROP PROC uspDeleteNhanVien
GO
CREATE PROCEDURE uspDeleteNhanVien
	@MaNV nvarchar(50)
AS
	--Kiểm Soát Lỗi
	
	DELETE FROM NhanVien WHERE MaNV = @MaNV
--Test
EXEC uspDeleteNhanVien '1'