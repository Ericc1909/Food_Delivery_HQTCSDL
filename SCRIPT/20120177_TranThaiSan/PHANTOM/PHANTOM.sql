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