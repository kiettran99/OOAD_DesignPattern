--tìm ID của Loại Thức Ăn Theo Tên
USE QuanLyCaPhe
GO

drop function if exists	ufnTimMaxIDThucAn
go

create function ufnTimMaxIDThucAn ()
returns table
as
	return (select distinct Max(IDThucAn) as IDthucAn from ThucAn)