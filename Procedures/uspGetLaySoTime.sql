--Lấy SoTime
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetLaySoTime') IS NOT NULL
DROP PROC uspGetLaySoTime
GO
CREATE PROC uspGetLaySoTime
	@MaNV nvarchar(50)
AS
BEGIN
	SELECT DISTINCT TenNV
	FROM dbo.TinhLuong
	WHERE MaNV=@MaNV
END
--GO
EXEC uspGetLaySoTime '1';