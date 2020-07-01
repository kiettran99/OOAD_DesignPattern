--View bản lương nhân viên 
USE QuanLyCaPhe
GO
IF OBJECT_ID ('view_BanLuongChoNhanVien') IS NOT NULL
DROP VIEW view_BanLuongChoNhanVien;
GO
CREATE VIEW view_BanLuongChoNhanVien AS
SELECT	
	nv.HoNV, nv.TenNV,nv.NgaySinh,nv.SDT,nv.Nu,cc.GioIn,cc.GioOut,tl.SoGioLam,tl.Luong
FROM NhanVien nv join ChamCong cc on nv.MaNV=cc.MaNV join TinhLuong tl on tl.MaNV=nv.MaNV
GO
--Test View
SELECT * FROM view_BanLuongChoNhanVien;
