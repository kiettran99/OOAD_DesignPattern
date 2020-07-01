USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetNhanVien_ByTenNV') IS NOT NULL
DROP PROC uspGetNhanVien_ByTenNV
GO
CREATE PROC uspGetNhanVien_ByTenNV

AS
BEGIN
	SELECT * 
	FROM NhanVien

END
--TEST
EXEC uspGetNhanVien_ByTenNV 