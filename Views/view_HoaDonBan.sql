--View bản lương nhân viên 
USE QuanLyCaPhe
GO

drop view if exists view_HoaDonBan
go

create view view_HoaDonBan as
	select IDHoaDon, TenNV, TenKH, NgayBan, ThanhTien  from NhanVien_HoaDon_KhachHang
go

select * from view_HoaDonBan
