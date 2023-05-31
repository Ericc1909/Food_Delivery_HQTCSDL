--CONVERSION DEADLOCK
USE Ql_DATHANG_BANHANG
-- T1: NHÂN VIÊN GIA HẠN HỢP ĐỒNG
-- T2: NHÂN VIÊN GIA HẠN HỢP ĐỒNG
go
create
--alter
procedure gia_han_hop_dong
@maHD char(5),
@so_ngay_them int
as
begin transaction
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin try
-- kiểm tra mã hợp đồng có tồn tại hay không
	if @maHD not in (select hd.MA_HOP_DONG
		     from HOPDONG hd with (UPDLOCK)
	 where hd.MA_HOP_DONG=@maHD)
            begin
	print N'Không tồn tại hợp đồng này'
	rollback tran
	end

-- lấy ra ngày cuối hợp đồng
	declare @ngay_hien_tai date
	set @ngay_hien_tai=( select top 1 hd.TG_KET_THUC
						from HOPDONG hd 
						where hd.MA_HOP_DONG=@maHD)
	if @ngay_hien_tai is not null
		begin
		-- bắt đầu chờ
	WAITFOR DELAY '00:00:15'
-- gia hạn ngày hợp đồng
		set @ngay_hien_tai = (select DATEADD(DAY, @so_ngay_them, @ngay_hien_tai))

-- cập nhật vào hợp đồng
		update HOPDONG
			SET TG_KET_THUC = @ngay_hien_tai
			WHERE MA_HOP_DONG = @maHD;
		end
end try
begin catch
	print N'Gia hạn hợp đồng thất bại'
	rollback tran
end catch

commit tran
go
