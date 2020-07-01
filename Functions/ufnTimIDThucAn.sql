--tìm ID của thức ăn thông qua tên
USE QuanLyCaPhe
GO
IF OBJECT_ID ('ufnTimIDThucAn') IS NOT NULL
DROP FUNCTION ufnTimIDThucAn 

GO
CREATE FUNCTION ufnTimIDThucAn( @TenThucAn nvarchar(100) )
	RETURNS Table
AS
RETURN (SELECT IDThucAn
		FROM dbo.ThucAn AS ThucAn
		where TenThucAn =@TenThucAn)
GO
--TEST
SELECT * FROM ufnTimIDThucAn('7UP');
select *from ThucAn

--tìm tên thức ăn thông qua tên
USE QuanLyCaPhe
GO
IF OBJECT_ID ('ufnTimFThucAn') IS NOT NULL
DROP FUNCTION ufnTimFThucAn 

GO
CREATE FUNCTION ufnTimFThucAn( @TenThucAn nvarchar(100))
	RETURNS Table
AS
RETURN (SELECT *
		FROM dbo.ThucAn AS ThucAn
		where TenThucAn like '%' + @TenThucAn + '%')
GO
SELECT * FROM ufnTimFThucAn('7UP');