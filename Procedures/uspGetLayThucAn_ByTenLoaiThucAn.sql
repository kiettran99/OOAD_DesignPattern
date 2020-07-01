--Lấy Thức Ăn Theo Loại 
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetLayThucAn_ByTenLoaiThucAn') IS NOT NULL
DROP PROC uspGetLayThucAn_ByTenLoaiThucAn
GO
CREATE PROC uspGetLayThucAn_ByTenLoaiThucAn
	@TenLoaiThucAn nvarchar(50)
AS
BEGIN
	SELECT DISTINCT TenThucAn
	FROM dbo.ThucAn join dbo.LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn
	where TenLoaiThucAn=@TenLoaiThucAn
END
--GO
EXEC uspGetLayThucAn_ByTenLoaiThucAn 'Trái Cây Tô';