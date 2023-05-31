use Ql_DATHANG_BANHANG
go
--case 1: T1:nhân viên A đang đọc kiểm tra ngày cuối hợp đồng -  xin khóa S(thành công)
----------T2:nhân viên B cũng vào đọc kiểm tra ngày cuối hợp đồng - xin khóa S(thành công) vì khóa S với khóa S tương thích nhau
----------T1: nhân viên A tiến hành update ngày gia hạn hợp động - xin khóa X (không thành công vì T2 đang giữ khóa S)
----------T2: nhân viên B tiến hành update ngày gia hạn hợp động - xin khóa X (không thành công vì T1 đang giữ khóa S)

--=> Lỗi conversion Deadlock => Treo hệ thống

exec gia_han_hop_dong 'HD001', '100'
select* from HOPDONG
