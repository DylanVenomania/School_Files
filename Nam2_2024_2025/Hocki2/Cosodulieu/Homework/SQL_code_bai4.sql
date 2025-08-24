--1 Danh sách các người thợ không tham gia vào hợp đồng sửa chữa nào
select tho.matho, tho.tentho
from tho
left join chitiet_hd on tho.matho = chitiet_hd.matho
where chitiet_hd.matho is null;



--2 Danh sách hợp đồng đã thanh lý nhưng chưa thanh toán đầy đủ
select hopdong.sohd, khachhang.tenkh, hopdong.trigiahd, 
       coalesce(sum(phieuthu.sotienthu), 0) as tongdathanhtoan
from hopdong
left join phieuthu on hopdong.sohd = phieuthu.sohd
join khachhang on hopdong.makh = khachhang.makh
where hopdong.ngayngthu is not null  -- đã thanh lý
group by hopdong.sohd, khachhang.tenkh, hopdong.trigiahd
having coalesce(sum(phieuthu.sotienthu), 0) < hopdong.trigiahd;



--3 Danh sách hợp đồng cần hoàn tất trước ngày 31/12/2002
select sohd, ngayhd, makh, soxe, trigiahd, ngaygiaodk
from hopdong
where ngaygiaodk < '2002-12-31' and ngayngthu is null;



--4 Người thợ thực hiện nhiều công việc nhất
select top 1 tho.matho, tho.tentho, count(chitiet_hd.macv) as soluongcongviec
from tho
left join chitiet_hd on tho.matho = chitiet_hd.matho
group by tho.matho, tho.tentho
order by soluongcongviec desc;




--5 Người thợ có tổng trị giá công việc cao nhất
select top 1 tho.matho, tho.tentho, coalesce(sum(chitiet_hd.trigiacv), 0) as tongtrigiacv
from tho
left join chitiet_hd on tho.matho = chitiet_hd.matho
group by tho.matho, tho.tentho
order by tongtrigiacv desc;
