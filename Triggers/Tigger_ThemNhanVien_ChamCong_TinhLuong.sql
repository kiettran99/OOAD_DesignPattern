--Cập Nhật thêm Hồ sơ nhân viên
-- Sau khi thêm hồ sơ, ta sẽ thêm tính lương, chấm công, Tài khoản cho nhân viên đó. 
use QuanLyCaPhe
go

drop trigger if exists Tigger_ThemNhanVien_ChamCong_TinhLuong
go

create trigger Tigger_ThemNhanVien_ChamCong_TinhLuong on NhanVien
after insert
as
begin
	declare @MaNV int = (select MaNV from inserted)

	declare @TenNV nvarchar(20) = (select TenNV from inserted)
	--Thêm Tài Khoản cho Nhân Viên
	insert into DangNhap values('nv' + cast(@MaNV as nvarchar(5)), 'nv' + cast(@MaNV as nvarchar(5)), @MaNV)

	--Thêm Chấm Công cho Nhân Viên
	Insert into ChamCong values(@MaNV, @TenNV, '00:00:00.0000000', '00:00:00.0000000')

	--Thêm Tính Lương cho Nhân Viên
	Insert into TinhLuong values(@MaNV, @TenNV, 0, 0)
end
go