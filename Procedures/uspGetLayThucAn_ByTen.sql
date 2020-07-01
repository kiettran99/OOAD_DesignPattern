--Lấy Thức Ăn 
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetLayThucAn_ByTen') IS NOT NULL
DROP PROC uspGetLayThucAn_ByTen
GO
CREATE PROC uspGetLayThucAn_ByTen
	@TenThucAn nvarchar(50)
AS
BEGIN
	SELECT DISTINCT TenThucAn
	FROM dbo.ThucAn
	WHERE TenThucAn=@TenThucAn
END
--GO
EXEC uspGetLayThucAn_ByTen 'Trái Cây Tô';