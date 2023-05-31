Use Ql_DATHANG_BANHANG
go
--T1 khách hàng A đang đăng nhập
--T2 khách hàng A cập nhật lại mật khẩu ở thiết bị khác 
--T1: không đọc ra được dữ liệu của khách hàng A nữa
exec dang_nhap 'TEST001','1111'
--select * from TAIKHOAN
