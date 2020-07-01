USE QuanLyCaPhe
GO
drop procedure if exists Update_ThucAn
go

create procedure Update_ThucAn @IDThucAn int,  @TenMonAn nvarchar(100), @IDLoaiThucAn int, @Gia float
as
begin
	Update ThucAn
	Set IDLoaiThucAn = @IDLoaiThucAn,
		Gia=@Gia,
		TenThucAn=@TenMonAn
	where IDThucAn = @IDThucAn
end
go