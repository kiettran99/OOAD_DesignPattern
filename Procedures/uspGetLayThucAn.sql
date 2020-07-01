--Lấy Thức Ăn 
USE QuanLyCaPhe
GO
IF OBJECT_ID('uspGetLayThucAn') IS NOT NULL
DROP PROC uspGetLayThucAn
GO
CREATE PROC uspGetLayThucAn
AS
BEGIN
	select IDThucAn, TenThucAn, TenLoaiThucAn, Gia from ThucAn join LoaiThucAn on ThucAn.IDLoaiThucAn = LoaiThucAn.IDLoaiThucAn;
END
--GO
EXEC uspGetLayThucAn