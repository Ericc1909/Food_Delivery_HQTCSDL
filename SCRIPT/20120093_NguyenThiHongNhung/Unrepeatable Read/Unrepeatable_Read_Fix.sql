USE Ql_DATHANG_BANHANG
-- T1: khách hàng Đăng nhập tài khoản chưa kịp commit thì 
-- T2:  Khách hàng đó lại cập nhật tài khoản
--=> Gây ra lỗi unrepeatable read
go


--drop proc đăng nhập
create 
--alter
proc dang_nhap 
@ten_tk NVARCHAR(255),
@mat_khau CHAR(100)
as
begin tran
begin try
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
if not exists ( select tk.TEN_DANG_NHAP from TAIKHOAN tk where tk.TEN_DANG_NHAP=@ten_tk)
	begin
			print N'Không tồn tại tên đăng nhập'
			rollback tran
			return -1
	end
if not exists ( select tk.TEN_DANG_NHAP from TAIKHOAN tk where tk.TEN_DANG_NHAP=@ten_tk and tk.MAT_KHAU= @mat_khau)
	begin
			print N'Sai mật khẩu'
			rollback tran
			return -1
	end


declare @loai_tk int
set     @loai_tk = NULL
SET @loai_tk = (SELECT TOP 1 tk.LOAI_TK
					FROM TAIKHOAN tk
					WHERE tk.TEN_DANG_NHAP = @ten_tk AND tk.MAT_KHAU = @mat_khau AND tk.TRANG_THAI = 1)
WAITFOR DELAY '00:00:10'	
	IF @loai_tk IS NOT NULL
	begin
	if @loai_tk=0
	begin 
		SELECT distinct @loai_tk AS 'loai_tk', CH.MA_CUA_HANG  AS 'ma' 
		FROM CUAHANG CH WHERE  CH.MA_CUA_HANG = @ten_tk;
		COMMIT TRAN;
		RETURN;	
	end
	else if @loai_tk=1
	BEGIN
		SELECT distinct @loai_tk AS 'loai_tk', KH.MA_KHACH_HANG AS  'ma'FROM KHACHHANG KH, TAIKHOAN tk WHERE KH.TEN_DANG_NHAP = @ten_tk and tk.MAT_KHAU=@mat_khau
		COMMIT TRAN;
		RETURN;
	END
	else if @loai_tk=2
	BEGIN
		SELECT distinct @loai_tk AS 'loai_tk', TX.MA_TAI_XE AS 'ma' FROM TAIXE TX, TAIKHOAN tk WHERE TX.TEN_DANG_NHAP = @ten_tk and tk.MAT_KHAU=@mat_khau
		COMMIT TRAN;
		RETURN
	END
	else if @loai_tk=3
	begin 
		select distinct @loai_tk as 'loai_tk', NV.MA_NHAN_VIEN from NHANVIEN NV, TAIKHOAN tk where NV.TEN_DANG_NHAP=@ten_tk and tk.MAT_KHAU=@mat_khau
	end
	else if @loai_tk=3
	begin 
	declare @ad char(10)
	set @ad= 'admin'
	select distinct @loai_tk as 'loai_tk', tk.TEN_DANG_NHAP from TAIKHOAN tk where tk.TEN_DANG_NHAP=@ten_tk and tk.MAT_KHAU=@mat_khau
	end

	end
	
end try
begin catch 	
	print N'Đăng nhập thất bại'
	rollback tran	
end catch
commit tran
go

-- update thong tin tk
create 
--alter
proc cap_nhat_mat_khau
@ten_tk NVARCHAR(255),
@mat_khau CHAR(100),
@mat_khau_moi char(100)
as 
begin tran
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
begin try
if not exists ( select tk.TEN_DANG_NHAP from TAIKHOAN tk where tk.TEN_DANG_NHAP=@ten_tk)
	begin
			print N'Sai tên đăng nhập'
			rollback tran
			return -1
	end
if not exists ( select tk.TEN_DANG_NHAP from TAIKHOAN tk where tk.TEN_DANG_NHAP=@ten_tk and tk.MAT_KHAU= @mat_khau)
	begin
			print N'Sai mật khẩu. Vui lòng nhập đúng mật khẩu để sửa đổi thông tin'
			rollback tran
			return -1
	end

update TAIKHOAN
set MAT_KHAU=@mat_khau_moi
where TEN_DANG_NHAP= @ten_tk
print N'Đổi mật khẩu thành công'

end try
begin catch
	print N'Thay đổi mật khẩu thất bại'
	rollback tran
end catch
commit tran
go
