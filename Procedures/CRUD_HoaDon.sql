use QuanLyCaPhe
go
--1. Tạo Hóa Đơn
drop procedure if exists Create_HoaDon
go

create procedure Create_HoaDon @IDHoaDon int,
	@NgayTaoHoaDon datetime,
	@NgayKetThucHoaDon datetime,
	@IDBanAn int,
	@TongTien float,
	@GiamGia int,
	@TinhTrang bit
as
begin
	insert into HoaDon values(@IDHoaDon, @NgayTaoHoaDon, @NgayKetThucHoaDon, @IDBanAn, @TongTien, @GiamGia, @TinhTrang)
end
go

drop procedure if exists Create_HoaDonTheoBan
go

create procedure Create_HoaDonTheoBan @IDHoaDon int, @IDBanAn int
as
begin
	insert into HoaDon values(@IDHoaDon, GETDATE(), null, @IDBanAn, 0, 0, 0)
end
go

--2. Đọc Hóa Đơn
drop procedure if exists Read_HoaDon
go

create procedure Read_HoaDon
as
begin
	select * from HoaDon
end
go

drop procedure if exists Read_HoaDon_IDBanAn
go

create procedure Read_HoaDon_IDBanAn @idBanAn int
as
begin
	select * 
	from HoaDon
	where IDBanAn = @idBanAn and HoaDon.TinhTrang = 0
end
go

--3. Sửa Hóa Đơn
drop procedure if exists Update_HoaDon
go

create procedure Update_HoaDon @idHoaDon int, @NgayTaoHoaDon datetime,
	@NgayKetThucHoaDon datetime,
	@IDBanAn int,
	@TongTien float,
	@GiamGia int,
	@TinhTrang bit
as
begin
	update HoaDon
	set NgayTaoHoaDon = @NgayTaoHoaDon, NgayKetThucHoaDon = @NgayKetThucHoaDon,
	IDBanAn = @IDBanAn, TongTien = @TongTien, GiamGia = @GiamGia, TinhTrang = @TinhTrang
	where IDHoaDon = @idHoaDon
end
go

--4. Xóa Hóa Đơn
drop procedure if exists Delete_HoaDon
go

create procedure Delete_HoaDon @idHoaDon int
as
begin
	delete from HoaDon 
	where IDHoaDon = @idHoaDon and HoaDon.TinhTrang = 0
end