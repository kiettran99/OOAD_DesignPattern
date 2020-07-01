--SP:  Xóa Một Loại Thức ăn Khỏi Bảng Thức Ăn

USE QuanLyCaPhe
GO
IF OBJECT_ID('uspDeleteThucAn') IS NOT NULL
	DROP PROC uspDeleteThucAn
GO
CREATE PROCEDURE uspDeleteThucAn
	@IDThucAn nvarchar(50)
AS
	--Kiểm Soát Lỗi

	DELETE FROM ThucAn WHERE IDThucAn = @IDThucAn
--Test
select *from ThucAn;
EXEC uspDeleteThucAn '4'