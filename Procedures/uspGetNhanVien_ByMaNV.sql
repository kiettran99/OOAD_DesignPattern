--Lấy Nhân Viên Dùng MaNV 
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetNhanVien_ByMaNV') IS NOT NULL
DROP PROC uspGetNhanVien_ByMaNV
GO
CREATE PROCEDURE uspGetNhanVien_ByMaNV
	@MaNV nvarchar(50)
AS
BEGIN
	select *

	from dbo.NhanVien
	where @MaNV=MaNV
END
GO
--TEST
EXEC uspGetNhanVien_ByMaNV '1';