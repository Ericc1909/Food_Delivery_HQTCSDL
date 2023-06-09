﻿
USE Ql_DATHANG_BANHANG
GO
--UNREPEATABLE READ 
-- KHÁCH HÀNG XEM TỔNG TIỀN CHO 1 MÓN ĂN VỚI SÔ LƯỢNG CỤ THỂ TRƯỚC KHI ĐẶT HÀNG (TRẠNG THÁI N'CÓ BÁN')
-- CỬA HÀNG CẬP GIÁ MÓN CỦA MÓN ĂN
GO

-- PROC KHÁCH HÀNG XEM TỔNG TIỀN CỦA MỘT MÓN ĂN VỚI SỐ LƯỢNG CỤ THỂ
CREATE PROC SP_KH_XEM_TONG_TIEN_MOT_MON_AN
	@MA_CUA_HANG CHAR(5),
	@MA_MON_AN CHAR(5),
	@SO_LUONG CHAR(5)
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRAN
		IF(@MA_CUA_HANG NOT IN ( SELECT MA_CUA_HANG FROM CUAHANG ))
			BEGIN	
				PRINT @MA_CUA_HANG + N' KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END
			--(1)
		IF(NOT EXISTS ( SELECT * FROM MON_AN MA WHERE MA.MA_MON_AN = @MA_MON_AN 
				AND MA.TINH_TRANG = N'có bán' AND MA.TRANG_THAI = 1 AND MA.MA_CUA_HANG = @MA_CUA_HANG))
			BEGIN	
				PRINT @MA_MON_AN + N' KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END

		WAITFOR DELAY '00:00:10' 


		SELECT @SO_LUONG* DON_GIA FROM MON_AN WHERE @MA_MON_AN = MA_MON_AN --(4)
	COMMIT TRAN
PRINT N'HIỂN THỊ THÀNH CÔNG'
RETURN 1




-- PROC CỬA HÀNG CẬP GIÁ MÓN ĂN 
GO
CREATE PROC SP_CH_CAP_NHAT_DON_GIA_MOT_MON_AN
	@MA_CUA_HANG CHAR(5),
	@MA_MON_AN CHAR(5),
	@NEW_DONGIA FLOAT
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	BEGIN TRAN
		IF(@MA_CUA_HANG NOT IN ( SELECT MA_CUA_HANG FROM CUAHANG))
			BEGIN	
				PRINT @MA_CUA_HANG + N' KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END
		IF(NOT EXISTS ( SELECT * FROM MON_AN MA WHERE MA.MA_MON_AN = @MA_MON_AN AND TRANG_THAI !=0 AND MA.MA_CUA_HANG = @MA_CUA_HANG))
			BEGIN	
				PRINT @MA_MON_AN + N' KHÔNG HỢP LỆ !'
				ROLLBACK TRAN
				RETURN 0
			END --(1)

		UPDATE MON_AN  --(3)
		SET DON_GIA = @NEW_DONGIA 
		WHERE MA_MON_AN = @MA_MON_AN
	COMMIT TRAN
PRINT N'CẬP NHẬT THÀNH CÔNG'
RETURN 1


