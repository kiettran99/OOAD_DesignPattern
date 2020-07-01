use QuanLyCaPhe
go

drop procedure if exists Create_ThucAn
go

create procedure Create_ThucAn @IDThucAn int,  @TenMonAn nvarchar(100), @IDLoaiThucAn int, @Gia float
as
begin
	insert into ThucAn values(@IDThucAn, @TenMonAn, @IDLoaiThucAn, @Gia)
end
go
