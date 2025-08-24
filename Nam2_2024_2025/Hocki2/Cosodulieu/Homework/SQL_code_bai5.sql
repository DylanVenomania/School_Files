--a Danh sách giáo viên dạy môn học có số tiết từ 45 trở lên
select gv.magv, gv.tengv, mhoc.tenmh, mhoc.sotiet
from gv
join mhoc on gv.mamh = mhoc.mamh
where mhoc.sotiet >= 45;


--b Danh sách giáo viên được phân công gác thi trong học kỳ 1
select gv.magv, gv.tengv
from gv
join pc_coi_thi on gv.magv = pc_coi_thi.magv
where pc_coi_thi.hky = 1;


--c Danh sách giáo viên không được phân công gác thi trong học kỳ 1
select gv.magv, gv.tengv
from gv
left join pc_coi_thi on gv.magv = pc_coi_thi.magv and pc_coi_thi.hky = 1
where pc_coi_thi.magv is null;


--d Cho biết lịch thi môn Văn (TENMH = ‘VĂN HỌC’)
select buoithi.hky, buoithi.ngay, buoithi.gio, buoithi.phg, buoithi.tgthi
from buoithi
join mhoc on buoithi.mamh = mhoc.mamh
where mhoc.tenmh = 'van hoc';


--e Buổi gác thi của giáo viên chủ nhiệm môn Văn
select pc_coi_thi.magv, gv.tengv, pc_coi_thi.hky, pc_coi_thi.ngay, pc_coi_thi.gio, pc_coi_thi.phg
from pc_coi_thi
join gv on pc_coi_thi.magv = gv.magv
join mhoc on gv.mamh = mhoc.mamh
where mhoc.tenmh = 'van hoc';


