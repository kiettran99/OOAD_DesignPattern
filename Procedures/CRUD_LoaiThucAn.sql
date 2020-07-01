use QuanLyCaPhe
go
--1. Tạo Loại thức ăn
drop procedure if exists Create_LoaiThucAn
go

create procedure Create_LoaiThucAn @IDLoaiThucAn int, @TenLoaiThucAn nvarchar(100)
as
begin
	insert into LoaiThucAn values(@IDLoaiThucAn, @TenLoaiThucAn)
end
go

--2. Đọc Loại thức ăn
drop procedure if exists Read_LoaiThucAn
go

create procedure Read_LoaiThucAn
as
begin
	select * from LoaiThucAn
end
go

drop procedure if exists Read_LoaiThucAnTheoTen
go

create procedure Read_LoaiThucAnTheoTen @TenLoaiThucAn nvarchar(100)
as
begin
	select IDLoaiThucAn from LoaiThucAn where TenLoaiThucAn = @TenLoaiThucAn
end
go

--3. Sửa Loại thức ăn
drop procedure if exists Update_LoaiThucAn
go

create procedure Update_LoaiThucAn @IDLoaiThucAn int, @TenLoaiThucAn nvarchar(100)
as
begin
	Update LoaiThucAn
	Set TenLoaiThucAn = @TenLoaiThucAn
	where IDLoaiThucAn = @IDLoaiThucAn
end
go

--4. Xóa Loại Thức ăn
drop procedure if exists Delete_LoaiThucAn
go

create procedure Delete_LoaiThucAn @IDLoaiThucAn int
as
begin
	delete from LoaiThucAn where IDLoaiThucAn = @IDLoaiThucAn
end