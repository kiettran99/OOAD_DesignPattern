--Cập Nhật xóa Hồ sơ nhân viên
-- Trước khi xóa hồ sơ, ta sẽ xóa tính lương, chấm công cho nhân viên đó. 
use QuanLyCaPhe
go

drop trigger if exists Tigger_XoaNhanVien_ChamCong_TinhLuong
go

create trigger Tigger_XoaNhanVien_ChamCong_TinhLuong on NhanVien
instead of delete
as
begin
	--Tìm ID Nhân viên chuẩn bị xóa
	declare @MaNV int = (select deleted.MaNV from deleted)

	--Xóa Tài Khoản nhân viên
	delete from DangNhap where DangNhap.MaNV = @MaNV

	--Xóa Tính Lương
	delete from TinhLuong where TinhLuong.MaNV = @MaNV

	--Xóa Chấm Công
	delete from ChamCong where ChamCong.MaNV = @MaNV

	--Xoá Nhân Viên
	delete NhanVien from deleted join NhanVien on deleted.MaNV = NhanVien.MaNV
end
go