--Lấy Tài Khoảng và Mật Khẩu của NV
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetTKMK_MaNV') IS NOT NULL
DROP PROC uspGetTKMK_MaNV
GO
CREATE PROCEDURE uspGetTKMK_MaNV
	@MaNV nvarchar(50)
AS
BEGIN
	select *

	from dbo.DangNhap
	where @MaNV=MaNV
END
GO
--TEST
EXEC uspGetTKMK_MaNV '1';