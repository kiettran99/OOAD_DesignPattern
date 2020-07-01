--tìm ID của Loại Thức Ăn Theo Tên
USE QuanLyCaPhe
GO

drop function if exists	ufnTimIDTheoTenLoaiThucAn
go

create function ufnTimIDTheoTenLoaiThucAn (@TenLoaiThucAn nvarchar(100))
returns table
as
	return (select distinct IDLoaiThucAn from LoaiThucAn where TenLoaiThucAn = @TenLoaiThucAn)

