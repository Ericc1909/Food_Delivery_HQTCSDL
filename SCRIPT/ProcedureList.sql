

use Ql_DATHANG_BANHANG_HQTCSDL
go

create proc sp_getHopDongByMaHD @MaHD char(5) , @status int 
as
	begin 
		select * from HOPDONG as HD where HD.MA_HOP_DONG = @MaHD and TRANG_THAI = @status
	end
go

create proc UpdateThoiHanHopDong @maHD char(5), @TgKetThuc_new datetime
as
	update HOPDONG
	set TG_KET_THUC = @TgKetThuc_new
	where MA_HOP_DONG = @maHD and TRANG_THAI = 1
go

create proc SelectHopDong_ThoiGian_BD_ThoiGian_KT @ThoiGian_BD datetime , @ThoiGian_KT datetime
as
	select * from HOPDONG as HD
	where datediff(d,@ThoiGian_BD,HD.TG_BAT_DAU) > 0 
	and datediff(d,HD.TG_KET_THUC,@ThoiGian_KT) > 0 and TRANG_THAI = 0
go

create proc SlectHopDong_TenCuaHangGanDung @string nvarchar(255) , @TrangThai int
as
begin
	select HD.MA_HOP_DONG,HD.NGAY_TAO,HD.TG_BAT_DAU,HD.TG_KET_THUC,HD.MA_CUA_HANG,HD.STK,HD.MA_NHAN_VIEN,HD.TRANG_THAI
	from HOPDONG HD , CUAHANG CH where CH.MA_CUA_HANG = hd.MA_CUA_HANG AND
	CH.TEN_CUA_HANG Like '%'+@string+'%' AND HD.TRANG_THAI = @TrangThai
end

go
create proc sp_getHopDongByMaCH @MaCH char(5) , @status int 
as
	begin 
		select * from HOPDONG as HD where HD.MA_CUA_HANG = @MaCH and TRANG_THAI = @status
	end
go
----------------------------------------------------------
create proc sq_updateStatus_HopDong @maHD char(5) , @TrangThai INT
as
begin
	update HOPDONG 
	set TRANG_THAI = @TrangThai 
	WHERE MA_HOP_DONG = @maHD
end

------------------------------------------------------------------------
go
CREATE PROC SP_ThongTinChiNhanh_Ma @MaChiNhanh char(5)
as
	
    select HD.MA_HOP_DONG, CH.MA_CUA_HANG,CH.TEN_CUA_HANG,CN.MA_CHI_NHANH,CN.SDT,CN.DIA_CHI,CN.KHUVUC
	from HOPDONG HD, CUAHANG CH, CHINHANH CN
	WHERE HD.MA_HOP_DONG = CN.MA_HOP_DONG AND CN.MA_CUA_HANG = CH.MA_CUA_HANG 
	AND HD.TRANG_THAI = 1  AND CN.MA_CHI_NHANH = @MaChiNhanh
go


--=================================================================================================
create procedure gia_han_hop_dong
@maHD char(5),
@so_ngay_them int
as
begin transaction
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin try
-- kiểm tra mã hợp đồng có tồn tại hay không
		if @maHD not in (select hd.MA_HOP_DONG
		     from HOPDONG hd 
			 where hd.MA_HOP_DONG=@maHD)
            begin
	print N'Không tồn tại hợp đồng này'
	rollback tran
	end

-- lấy ra ngày cuối hợp đồng
	declare @ngay_hien_tai datetime
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

--------------------------------------------------------
create proc ThemTK @idtk int, @username nvarchar(255), @pass char(100), @loaitk int
as
insert into TAIKHOAN(ID_TAI_KHOAN,TEN_DANG_NHAP,MAT_KHAU,LOAI_TK,TRANG_THAI)
values (@idtk,@username,@pass,@loaitk,1)
go


create proc ThemKH @makh char(5), @hoten nvarchar(255), @diachi nvarchar(255), @sdt char(10), @email nvarchar(100)
as
insert into KHACHHANG(MA_KHACH_HANG,HOTEN,DIACHI,SDT,EMAIL,ID_TAI_KHOAN)
values(@makh,@hoten,@diachi,@sdt,@email,null)
go

create proc ThemNV @manv char(5), @hoten nvarchar(255), @diachi nvarchar(255), @sdt char(10), @email char(100)
as
insert into NHANVIEN(MA_NHAN_VIEN,TEN_NHAN_VIEN,DIA_CHI,SDT,ID_TAI_KHOAN,GMAIL)
values(@manv,@hoten,@diachi,@sdt,null,@email)
go

create proc ThemTX @matx char(5), @hoten varchar(255), @sdt char(10), @bienso char(10), @cmnd char(10), @mathue char(5), @email char(100), @khuvuc nvarchar(255)
as
insert into TAIXE(MA_TAI_XE,HOTEN,SDT,BIEN_SO,CMND,MA_THUE,EMAIL,KHU_VUC,TRANG_THAI,STK,ID_TAI_KHOAN)
values(@matx,@hoten,@sdt,@bienso,@cmnd,@mathue,@email,@khuvuc,null,null,null)
go

create proc ThemCH @mach char(5), @tench nvarchar(255), @email char(100), @tp nvarchar(255), @quan nvarchar(255), @sdt char(10), @sochinhanh int, @nguoidaidien nvarchar(50), @masothue char(5)
as
insert into CUAHANG(MA_CUA_HANG,TEN_CUA_HANG,EMAIL,THANH_PHO,QUAN,SDT,SO_CHI_NHANH,NGUOI_DAI_DIEN,MA_SO_THUE,ID_TAI_KHOAN)
values(@mach,@tench,@email,@tp,@quan,@sdt,@sochinhanh,@nguoidaidien,@masothue,null)
go


CREATE PROCEDURE USP_QT1_CAPNHAT_TT_FIX @TEN_DANG_NHAP NVARCHAR(255), @MAT_KHAU_MOI CHAR(100), @MATX CHAR(5), @EMAIL_MOI CHAR(100)
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT TK.* FROM TAIKHOAN TK WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP)
	BEGIN
		PRINT N'Tài khoản không tồn tại'
		RETURN
	END


	UPDATE TAIKHOAN SET MAT_KHAU = @MAT_KHAU_MOI WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP
	WAITFOR DELAY '00:00:05'

	UPDATE TAIXE
	SET EMAIL = @EMAIL_MOI
	WHERE MA_TAI_XE = @MATX
COMMIT TRAN
GO

CREATE PROCEDURE USP_QT2_CAPNHAT_TT_FIX @TEN_DANG_NHAP NVARCHAR(255), @MAT_KHAU_MOI CHAR(100), @MATX CHAR(5), @EMAIL_MOI CHAR(100)
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT TK.* FROM TAIKHOAN TK WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP)
	BEGIN
		PRINT N'Tài khoản không tồn tại'
		RETURN
	END

	UPDATE TAIKHOAN 
	SET MAT_KHAU = @MAT_KHAU_MOI 
	WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP
	WAITFOR DELAY '00:00:05'

	UPDATE TAIXE
	SET EMAIL = @EMAIL_MOI
	WHERE MA_TAI_XE = @MATX

	
COMMIT TRAN
GO

CREATE PROCEDURE USP_QT1_CAPNHAT_TT @TEN_DANG_NHAP NVARCHAR(255), @MAT_KHAU_MOI CHAR(100), @MATX CHAR(5), @EMAIL_MOI CHAR(100)
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT TK.* FROM TAIKHOAN TK WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP)
	BEGIN
		PRINT N'Tài khoản không tồn tại'
		RETURN
	END


	UPDATE TAIKHOAN SET MAT_KHAU = @MAT_KHAU_MOI WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP
	WAITFOR DELAY '00:00:05'

	UPDATE TAIXE
	SET EMAIL = @EMAIL_MOI
	WHERE MA_TAI_XE = @MATX
COMMIT TRAN
GO


--Quản trị 2 cập nhật thông tin của tài xế(Email) và cập nhật thông tin tài khoản của khách hàng (đổi mật khẩu).
CREATE PROCEDURE USP_QT2_CAPNHAT_TT @TEN_DANG_NHAP NVARCHAR(255), @MAT_KHAU_MOI CHAR(100), @MATX CHAR(5), @EMAIL_MOI CHAR(100)
AS
BEGIN TRAN
	IF NOT EXISTS(SELECT TK.* FROM TAIKHOAN TK WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP)
	BEGIN
		PRINT N'Tài khoản không tồn tại'
		RETURN
	END

	UPDATE TAIXE
	SET EMAIL = @EMAIL_MOI
	WHERE MA_TAI_XE = @MATX
	WAITFOR DELAY '00:00:05'

	UPDATE TAIKHOAN SET MAT_KHAU = @MAT_KHAU_MOI WHERE TEN_DANG_NHAP=@TEN_DANG_NHAP
COMMIT TRAN

GO
--LOST UPDATED
-- ĐỐI TÁC CẬP NHẬT SỐ LƯỢNG MÓN ĂN TẠI MÔT CHI NHÀNH
-- KHÁCH HÀNG MUA HÀNG TẠI MỘT CHI NHÁNH VỚI SỐ LƯỢNG NHẤT ĐỊNH
GO

-- ĐỐI TÁC CẬP NHẬT SỐ LƯỢNG MÓN ĂN TẠI MÔT CHI NHÀNH
CREATE PROC SP_CH_CAP_NHAT_SL_MON_AN
	@MA_CHI_NHANH CHAR(5),
	@MA_MON_AN CHAR(5),
	@SO_LUONG_THEM INT
AS
     SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRAN
	    
		IF NOT EXISTS (SELECT * FROM MON_AN_CHI_NHANH MA_CN WHERE MA_CHI_NHANH = @MA_CHI_NHANH AND MA_MON_AN = @MA_MON_AN) --(1)
			BEGIN	
				PRINT @MA_CHI_NHANH +', '+@MA_MON_AN + N' KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END

		IF @SO_LUONG_THEM <1
			BEGIN	
				PRINT N'SỐ LƯỢNG THÊM KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END
		DECLARE @SO_LUONG_HIEN_CO INT
		SET @SO_LUONG_HIEN_CO = ( SELECT SO_LUONG FROM MON_AN_CHI_NHANH WHERE MA_CHI_NHANH = @MA_CHI_NHANH AND MA_MON_AN = @MA_MON_AN )
		IF @SO_LUONG_HIEN_CO <1
			BEGIN	
				PRINT ' SỐ LƯỢNG HIỆN CÓ KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END

		WAITFOR DELAY '00:00:03' 

		UPDATE MON_AN_CHI_NHANH --(4)
		SET SO_LUONG = @SO_LUONG_HIEN_CO + @SO_LUONG_THEM
		WHERE MA_CHI_NHANH = @MA_CHI_NHANH AND MA_MON_AN = @MA_MON_AN
	COMMIT TRAN
PRINT N'CẬP NHẬT THÀNH CÔNG'
RETURN 1

GO


-- KHÁCH HÀNG MUA HÀNG TẠI MỘT CHI NHÁNH VỚI SỐ LƯỢNG NHẤT ĐỊNH
--CREATE PROC SP_KHACH_HANG_DAT_HANG_MON_AN
--	@MA_DON CHAR(5),
--	@MA_MON_AN CHAR(5),
--	@SO_LUONG INT,
--	@DIA_CHI NVARCHAR(255),
--	@PHI_VAN_CHUYEN FLOAT,
--	@MA_KHACH_HANG CHAR(5),
--	@MA_TAI_XE CHAR(5),
--	@MA_CHI_NHANH CHAR(5)

--AS
-- SET TRANSACTION ISOLATION LEVEL READ COMMITTED
--	BEGIN TRAN
--		-- KIỂM TRA THÔNG TIN ĐẦU VÀO 
--		IF( @PHI_VAN_CHUYEN IS NULL OR @DIA_CHI IS NULL OR @SO_LUONG IS NULL )
--			BEGIN	
--				PRINT N' THÔNG TIN (PHÍ VẬN CHUYỂN | ĐỊA CHỈ | SỐ LƯỢNG ) NULL'
--				ROLLBACK TRAN
--				RETURN 0
--			END
--		IF( @MA_KHACH_HANG NOT IN( SELECT MA_KHACH_HANG FROM KHACHHANG) OR
--			@MA_TAI_XE NOT IN( SELECT MA_TAI_XE FROM TAIXE) OR
--			@MA_CHI_NHANH NOT IN( SELECT MA_CHI_NHANH FROM CHINHANH))
--			BEGIN	
--				PRINT N'KHÔNG TỒN TẠI ' + @MA_KHACH_HANG +N' HOẶC '+ @MA_TAI_XE +N' HOẶC '+ @MA_CHI_NHANH
--				ROLLBACK TRAN
--				RETURN 0
--			END
		
--		IF( EXISTS ( SELECT * FROM DONDATHANG DH WHERE DH.MA_DON = @MA_DON))
--			BEGIN	
--				PRINT @MA_DON + N' ĐÃ TỒN TẠI'
--				ROLLBACK TRAN
--				RETURN 0
--			END
--		IF( @MA_MON_AN NOT IN ( SELECT MA_MON_AN FROM MON_AN WHERE TINH_TRANG = N'có bán'))
--			BEGIN	
--				PRINT @MA_MON_AN + N' KHÔNG TỒN TẠI'
--				ROLLBACK TRAN
--				RETURN 0
--			END
--		IF (@SO_LUONG > ( SELECT A.SO_LUONG FROM MON_AN_CHI_NHANH A WHERE A.MA_CHI_NHANH = @MA_CHI_NHANH AND A.MA_MON_AN =@MA_MON_AN)) --(2)
--			BEGIN	
--				PRINT N'SỐ LƯỢNG HIỆN TẠI CỦA CHI NHÁNH '+ @MA_CHI_NHANH+' KHÔNG ĐỦ ĐÁP ỨNG'
--				ROLLBACK TRAN
--				RETURN 0
--			END
--		DECLARE @DON_GIA_MON FLOAT
--		SET @DON_GIA_MON  = (SELECT DON_GIA FROM MON_AN WHERE MA_MON_AN = @MA_MON_AN )

--		DECLARE @TONG_TIEN FLOAT 
--		SET @TONG_TIEN = @DON_GIA_MON * @SO_LUONG
		
--		-- INSERT DON DAT HÀNG
--		INSERT INTO DONDATHANG VALUES(@MA_DON,@TONG_TIEN,@DIA_CHI,N'chờ xác nhận',@PHI_VAN_CHUYEN,@MA_KHACH_HANG,@MA_TAI_XE,@MA_CHI_NHANH,1)
--		-- INSERT CHI TIẾT ĐƠN HÀNG 
--		INSERT INTO CHITIET_DONHANG VALUES(@MA_DON , @MA_MON_AN,@SO_LUONG,@TONG_TIEN)
--		-- CẬP NHẬT SỐ LƯỢNG MÓN TẠI CHI NHÁNH
--		UPDATE MON_AN_CHI_NHANH 
--		SET SO_LUONG = SO_LUONG - @SO_LUONG --(3)
--		WHERE @MA_CHI_NHANH = MA_CHI_NHANH AND @MA_MON_AN = MA_MON_AN
--	COMMIT TRAN
--	PRINT N'CẬP NHẬT THÀNH CÔNG'
--RETURN 1
--GO


--DIRTY READ

CREATE PROCEDURE USP_DT_CAPNHAT_GIA_MONAN @MA_MON_AN CHAR(5), @GIA_UPDATE MONEY
AS
BEGIN TRAN
	IF NOT EXISTS (SELECT * FROM MON_AN WHERE MA_MON_AN=@MA_MON_AN)
	BEGIN
		PRINT N'MÓN ĂN KHÔNG TỒN TẠI'
		RETURN 
	END

	DECLARE @GIASP MONEY
	SET @GIASP = (SELECT DON_GIA FROM MON_AN WHERE MA_MON_AN=@MA_MON_AN)
	UPDATE MON_AN
    SET DON_GIA = @GIA_UPDATE  
	WHERE MA_MON_AN=@MA_MON_AN
	WAITFOR DELAY '00:00:05'

	IF (@GIA_UPDATE = 0)
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRAN
GO


-- Khách hàng xem giá món ăn

CREATE PROCEDURE USP_KH_XEMGIA_MONAN @MA_MON_AN CHAR(5)
AS
BEGIN TRAN
	IF NOT EXISTS (SELECT * FROM MON_AN WHERE MA_MON_AN=@MA_MON_AN)
	BEGIN
		PRINT N'MÓN ĂN KHÔNG TỒN TẠI'
		RETURN 
	END

    SELECT *
    FROM MON_AN WITH(NOLOCK)
	WHERE MA_MON_AN=@MA_MON_AN
COMMIT TRAN
GO


--PHANTOM:

-- them chi nhanh
CREATE PROCEDURE sp_DT_ThemChiNhanh @machinhanh char(5), @diachi nvarchar(255), @sdt nvarchar(10), @macuahang char(5), @mahopdong char(5), @khuvuc nvarchar(255)
AS

BEGIN TRAN
	BEGIN TRY
	--Kiểm tra địa chỉ có trùng hay không
	IF(EXISTS(SELECT * FROM CHINHANH WHERE MA_CUA_HANG = @macuahang AND DIA_CHI = @diachi))
			begin
			rollback tran
			RETURN  -1
			end

	-- Kiểm tra mã chi nhánh có trùng hay không
	IF(EXISTS(SELECT * FROM CHINHANH WHERE MA_CHI_NHANH = @machinhanh))
			begin
			rollback tran
			RETURN  -1
			end
	
	INSERT INTO CHINHANH(MA_CHI_NHANH, SL_DON_MOINGAY, DIA_CHI, SDT, TINH_TRANG, MA_CUA_HANG, MA_HOP_DONG, KHUVUC)
	VALUES
		(@machinhanh,NULL,@diachi, @sdt, null, @macuahang, @mahopdong, @khuvuc)

	UPDATE CUAHANG
	SET SO_CHI_NHANH = SO_CHI_NHANH + 1
	WHERE MA_CUA_HANG = @macuahang
	END TRY
	BEGIN CATCH
		PRINT N'LỖI HỆ THỐNG'
		ROLLBACK TRAN
		RETURN 1
	END CATCH
COMMIT TRAN
	return 1
GO



--PROCEDURE khách hàng xem danh sách đối tác
CREATE PROCEDURE sp_KH_XemDSDoiTac
AS
SET TRAN ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN
	BEGIN TRY
		SELECT MA_CUA_HANG, TEN_CUA_HANG, EMAIL, THANH_PHO, QUAN, SDT, SO_CHI_NHANH  FROM CUAHANG
		--ĐỂ TEST
		--WAITFOR DELAY '0:0:10'
	END TRY
	BEGIN CATCH
			PRINT N'LỖI HỆ THỐNG'
			ROLLBACK TRAN
			RETURN 0
	END CATCH
COMMIT TRAN
return 1
GO


create
--alter 
proc sp_KH_xem_MonAN
@MaCH char(5)
as
  select  Mon.MA_MON_AN as N'Mã Món', Mon.TEN_MON as N'Tên Món', Mon.DON_GIA as N'Ðon giá', Mon.TINH_TRANG as N'Tình Tr?ng'
  from MON_AN Mon
  where Mon.MA_CUA_HANG=@MaCH and TRANG_THAI=1
go


CREATE 
--alter
PROC SP_KHACH_HANG_DAT_HANG_MON_AN
	@MA_DON CHAR(5),
	@MA_MON_AN CHAR(5),
	@SO_LUONG INT,
	@DIA_CHI NVARCHAR(255),
	@PHI_VAN_CHUYEN FLOAT,
	@MA_KHACH_HANG CHAR(5),
	@MA_CHI_NHANH CHAR(5)

AS
 SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN
		-- KIỂM TRA THÔNG TIN ĐẦU VÀO 
		IF( @PHI_VAN_CHUYEN IS NULL OR @DIA_CHI IS NULL OR @SO_LUONG IS NULL )
			BEGIN	
				PRINT N' THÔNG TIN (PHÍ VẬN CHUYỂN | ĐỊA CHỈ | SỐ LƯỢNG ) NULL'
				ROLLBACK TRAN
				RETURN 0
			END
		IF( @MA_KHACH_HANG NOT IN( SELECT MA_KHACH_HANG FROM KHACHHANG) OR
			@MA_CHI_NHANH NOT IN( SELECT MA_CHI_NHANH FROM CHINHANH))
			BEGIN	
				PRINT N'KHÔNG TỒN TẠI ' + @MA_KHACH_HANG  +N' HOẶC '+ @MA_CHI_NHANH
				ROLLBACK TRAN
				RETURN 0
			END
		

		IF( @MA_MON_AN NOT IN ( SELECT MA_MON_AN FROM MON_AN WHERE TINH_TRANG = N'có bán'))
			BEGIN	
				PRINT @MA_MON_AN + N' KHÔNG TỒN TẠI'
				ROLLBACK TRAN
				RETURN 0
			END
		IF (@SO_LUONG > ( SELECT A.SO_LUONG FROM MON_AN_CHI_NHANH A WHERE A.MA_CHI_NHANH = @MA_CHI_NHANH AND A.MA_MON_AN =@MA_MON_AN)) --(2)
			BEGIN	
				PRINT N'SỐ LƯỢNG HIỆN TẠI CỦA CHI NHÁNH '+ @MA_CHI_NHANH+' KHÔNG ĐỦ ĐÁP ỨNG'
				ROLLBACK TRAN
				RETURN 0
			END
		DECLARE @DON_GIA_MON FLOAT
		SET @DON_GIA_MON  = (SELECT DON_GIA FROM MON_AN WHERE MA_MON_AN = @MA_MON_AN )

		DECLARE @TONG_TIEN FLOAT 
		SET @TONG_TIEN = @DON_GIA_MON * @SO_LUONG
		
		-- INSERT DON DAT HÀNG
				IF( EXISTS ( SELECT * FROM DONDATHANG DH WHERE DH.MA_DON = @MA_DON))
			BEGIN	
					INSERT INTO CHITIET_DONHANG VALUES(@MA_DON , @MA_MON_AN,@SO_LUONG,@TONG_TIEN)
			END
			else
			BEGIN
				INSERT INTO DONDATHANG VALUES(@MA_DON,@TONG_TIEN,@DIA_CHI,N'chờ xác nhận',@PHI_VAN_CHUYEN,@MA_KHACH_HANG,null,@MA_CHI_NHANH,1)
			-- INSERT CHI TIẾT ĐƠN HÀNG 
				INSERT INTO CHITIET_DONHANG VALUES(@MA_DON , @MA_MON_AN,@SO_LUONG,@TONG_TIEN)
			-- CẬP NHẬT SỐ LƯỢNG MÓN TẠI CHI NHÁNH
			END
		UPDATE MON_AN_CHI_NHANH 
		SET SO_LUONG = SO_LUONG - @SO_LUONG --(3)
		WHERE @MA_CHI_NHANH = MA_CHI_NHANH AND @MA_MON_AN = MA_MON_AN
	COMMIT TRAN
	PRINT N'CẬP NHẬT THÀNH CÔNG'
RETURN 1
GO


select * from TAIKHOAN
select* from MON_AN
select* from DONDATHANG
select * from DONDATHANG