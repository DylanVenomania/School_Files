
--1 Hãy cho biết tên các dự án mà nhân viên có mã ‘NV01’ tham gia
select distinct Duan.TenDa 
from PhanCong PC 
join Duan on PC.MaDa = Duan.MaDa where PC.MaDa = 'NV01';

--2 Tính tổng thời gian tham gia các dự án của mỗi nhân viên
select NV.MaNV, NV.HonV, NV.Tenlot, NV.TenNV, sum( PC.ThoiGian) as TongThoiGian 
from NhanVien NV
left join PhanCong PC on NV.MaNV = PC.MaNV 
group by NV.MaNV, NV.HonV, NV.Tenlot, NV.TenNV;

--3 Cho biết họ tên các nhân viên chưa tham gia dự án nào
select NV.HonV, NV.Tenlot, NV.TenNV 
from NhanVien NV 
left join PhanCong PC on NV.MaNV = PC.MaNV 
where PC.MaNV is null;

--a Tìm ngày sinh và địa chỉ của nhân viên “Nguyễn Bảo Hùng”
select NgSinh, Dchi from NhanVien 
where HonV = 'Nguyen' and Tenlot = 'Bao' and TenNV = 'Hung';

--b Tìm tên và địa chỉ của các nhân viên làm việc cho phòng “Nghiên cứu”
select NV.HonV, NV.Tenlot, NV.TenNV, NV.Dchi
from NhanVien NV 
join PhongBan PB on NV.Phong = PB.MaPB 
where PB.TenPB = 'Nghien cuu';


--c Với mỗi dự án triển khai ở Gò Vấp, cho biết mã dự án, mã phòng quản lý và họ tên, ngày sinh trưởng phòng
select Da.MaDa, Da.Phong, NV.HonV, NV.Tenlot, NV.TenNV, NV.NgSinh 
from Duan Da
join PhongBan PB on Da.Phong = PB.MaPB
join NhanVien NV on PB.TrPhong = NV.MaNV
where Da.DiaDiem = 'Go Vap'


--d Với mỗi nhân viên, cho biết họ tên nhân viên và họ tên của người quản lý nhân viên đó
select NV.HonV, NV.Tenlot, NV.TenNV, 
NQL.HonV as HonQL, NQL.Tenlot as TenlotNQL, NQL.TenNV as TenNQL
from NhanVien NV
left join NhanVien NQL on NV.MaNQL = NQL.MaNV;

--e Cho biết mã nhân viên, họ và tên của các nhân viên của phòng “Nghiên cứu” có mức lương từ 30000 đến 50000
select NV.MaNV, NV.HonV, NV.Tenlot, NV.TenNV
from NhanVien NV
join PhongBan PB on NV.Phong = PB.MaPB
where PB.TenPB = 'Nghien cuu' and NV.Luong between 30000 and 50000;

--f Cho biết mã nhân viên, họ tên nhân viên và mã dự án, tên dự án của các dự án mà họ tham gia
select NV.MaNV, NV.HonV, NV.Tenlot, NV.TenNV, Da.MaDa, Da.TenDa
from NhanVien NV
join PhanCong PC on NV.MaNV = PC.MaNV
join Duan Da on PC.MaDa = Da.MaDa;


--g  Cho biết mã nhân viên, họ tên của những người không có người quản lý
select NV.MaNV, NV.HonV, NV.Tenlot, NV.TenNV
from NhanVien NV
where NV.MaNQL is null;

--h Cho biết họ tên của các trưởng phòng có thân nhân
select DISTINCT NV.HonV, NV.Tenlot, NV.TenNV
from NhanVien NV
join PhongBan PB on NV.MaNV = PB.TrPhong
join ThanNhan TN on NV.MaNV = TN.MaNV;

--i Tính tổng lương nhân viên, lương cao nhất, lương thấp nhất và mức lương trung bình
select sum(Luong) as TongLuong, max(Luong) as LuongCaonhat, 
min(Luong) as LuongThapNhat, avg(Luong) as LuongTrungBinh
from NhanVien;


--j Cho biết tổng số nhân viên và mức lương trung bình của phòng “Nghiên cứu”
select count(NV.MaNV) as TongSonhanVien, avg(NV.Luong) as LuongTrungBinh
from NhanVien NV
join PhongBan PB on NV.Phong = PB.MaPB
where PB.TenPB = 'Nghien cuu';

--k Với mỗi phòng, cho biết mã phòng, số lượng nhân viên và mức lương trung bình
select PB.MaPB, count(NV.MaNV) as SoLuongNhanVien, avg(NV.Luong) as LuongTrungBinh
from PhongBan PB
LEFT join NhanVien NV on PB.MaPB = NV.Phong
group by PB.MaPB;

--l Với mỗi dự án, cho biết mã dự án, tên dự án và tổng số nhân viên tham gia
select Da.MaDa, Da.TenDa, count(PC.MaNV) as SoLuongNhanVien
from Duan Da
LEFT join PhanCong PC on Da.MaDa = PC.MaDa
group by Da.MaDa, Da.TenDa;

--m Với mỗi dự án có nhiều hơn 2 nhân viên tham gia, cho biết mã dự án, tên dự án và số lượng nhân viên tham gia
select Da.MaDa, Da.TenDa, count(PC.MaNV) as SoLuongNhanVien
from Duan Da
join PhanCong PC on Da.MaDa = PC.MaDa
group by Da.MaDa, Da.TenDa
having count(PC.MaNV) > 2;

--n Với mỗi dự án, cho biết mã số dự án, tên dự án và số lượng nhân viên phòng số 5 tham gia
select Da.MaDa, Da.TenDa, count(PC.MaNV) as SoLuongNhanVien
from Duan Da
join PhanCong PC on Da.MaDa = PC.MaDa
join NhanVien NV on PC.MaNV = NV.MaNV
where NV.Phong = 5
group by Da.MaDa, Da.TenDa;


--o  Với mỗi phòng có nhiều hơn 2 nhân viên, cho biết mã phòng và số lượng nhân viên có lương lớn hơn 25000
select NV.Phong, count(NV.MaNV) as SoLuongNhanVien
from NhanVien NV
where NV.Luong > 25000
group by NV.Phong
having count(NV.MaNV) > 2;


--p Với mỗi phòng có mức lương trung bình lớn hơn 30000, cho biết mã phòng, tên phòng, số lượng nhân viên của phòng đó
select PB.MaPB, PB.TenPB, count(NV.MaNV) as SoLuongNhanVien
from PhongBan PB
join NhanVien NV on PB.MaPB = NV.Phong
group by PB.MaPB, PB.TenPB
having avg(NV.Luong) > 30000;


--q Với mỗi phòng có mức lương trung bình lớn hơn 30000, cho biết mã phòng, tên phòng, số lượng nhân viên nam của phòng đó
select PB.MaPB, PB.TenPB, count(NV.MaNV) as SoLuongNhanVienNam
from PhongBan PB
join NhanVien NV on PB.MaPB = NV.Phong
where NV.Gioitinh = 'Nam'
group by PB.MaPB, PB.TenPB
having avg(NV.Luong) > 30000;