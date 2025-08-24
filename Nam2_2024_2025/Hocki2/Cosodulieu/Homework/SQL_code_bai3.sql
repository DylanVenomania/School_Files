
--a Tìm tên những nhân viên ở cơ quan có mã số là 50
select ten 
from nv 
where mscoquan = 50;

--b  Tìm mã số tất cả các cơ quan từ quan hệ NV
select distinct mscoquan 
from nv;


--c Tìm tên các nhân viên ở cơ quan có mã số là 15, 20, 25
select ten 
from nv 
where mscoquan IN (15, 20, 25);

--d Tìm tên những người làm việc ở Đồ Sơn
select nv.ten 
from nv 
join coquan on nv.mscoquan = coquan.mscoquan 
where coquan.diachi = 'Do Son';

