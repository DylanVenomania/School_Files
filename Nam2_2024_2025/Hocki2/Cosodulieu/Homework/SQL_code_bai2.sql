--a Địa chỉ và số điện thoại của Nhà xuất bản “Addison Wesley”
select DiaChi, Sdt
from NXB
where TenNXB = 'Addison Wesley';


--b Mã sách và tựa sách của những cuốn sách xuất bản bởi “Addison Wesley”
select Masach, Tua
from DauSach
join NXB on DauSach.MaNXB = NXB.MaNXB
where NXB.TenNXB = 'Addison Wesley';


--c Mã sách và tựa sách của những cuốn sách có tác giả là “Hemingway”
select DauSach.Masach, Tua
from DauSach
join TacGia on DauSach.Masach = TacGia.Masach
where TacGia.TenTacGia = 'Hemingway';


--d Với mỗi đầu sách, cho biết tựa và số lượng cuốn sách thư viện đang sở hữu
select DauSach.Tua, count(CuonSach.MaCuon) as SoLuongCuon
from DauSach
left join CuonSach on DauSach.Masach = CuonSach.Masach
group by DauSach.Tua;


--e Với mỗi độc giả, cho biết tên, địa chỉ và số lượng cuốn sách đã mượn
select DocGia.TenDG, DocGia.DiaChi, count(Muon.MaCuon) as SoLuongMuon
from DocGia
left join Muon on DocGia.MaDG = Muon.MaDG
group by DocGia.TenDG, DocGia.DiaChi;


--f Mã cuốn, tựa sách và vị trí của những cuốn sách do “Addison Wesley” xuất bản
select CuonSach.MaCuon, DauSach.Tua, CuonSach.ViTri
from CuonSach
join DauSach on CuonSach.Masach = DauSach.Masach
join NXB on DauSach.MaNXB = NXB.MaNXB
where NXB.TenNXB = 'Addison Wesley';


--g Với mỗi đầu sách, cho biết tên nhà xuất bản và số lượng tác giả
select NXB.TenNXB, DauSach.Tua, count(TacGia.TenTacGia) as SoLuongTacGia
from DauSach
join NXB on DauSach.MaNXB = NXB.MaNXB
left join TacGia on DauSach.Masach = TacGia.Masach
group by NXB.TenNXB, DauSach.Tua;


--h Thông tin độc giả đã mượn từ 5 cuốn sách trở lên
select DocGia.TenDG, DocGia.DiaChi, DocGia.Sdt
from DocGia
join Muon on DocGia.MaDG = Muon.MaDG
group by DocGia.TenDG, DocGia.DiaChi, DocGia.Sdt
having count(Muon.MaCuon) >= 5;


--i Mã NXB, tên NXB và số lượng đầu sách của NXB trong CSDL
select NXB.MaNXB, NXB.TenNXB, count(DauSach.Masach) as SoLuongDauSach
from NXB
left join DauSach on NXB.MaNXB = DauSach.MaNXB
group by NXB.MaNXB, NXB.TenNXB;


--j  Mã NXB, tên NXB và địa chỉ của những NXB có từ 100 đầu sách trở lên
select NXB.MaNXB, NXB.TenNXB, NXB.DiaChi
from NXB
join DauSach on NXB.MaNXB = DauSach.MaNXB
group by NXB.MaNXB, NXB.TenNXB, NXB.DiaChi
having count(DauSach.Masach) >= 100;


--k Mã NXB, tên NXB và số lượng tác giả đã hợp tác với NXB đó
select NXB.MaNXB, NXB.TenNXB, count(distinct TacGia.TenTacGia) as SoLuongTacGia
from NXB
join DauSach on NXB.MaNXB = DauSach.MaNXB
join TacGia on DauSach.Masach = TacGia.Masach
group by NXB.MaNXB, NXB.TenNXB;

--l l. Tựa sách và số lượng tác giả của những cuốn sách có tác giả là “Hemingway” mà độc giả “Nguyễn Văn A” đã từng mượn
select DauSach.Tua, count(distinct TacGia.TenTacGia) as SoLuongTacGia
from DauSach
join TacGia on DauSach.Masach = TacGia.Masach
join CuonSach on DauSach.Masach = CuonSach.Masach
join Muon on CuonSach.MaCuon = Muon.MaCuon
join DocGia on Muon.MaDG = DocGia.MaDG
where TacGia.TenTacGia = 'Hemingway' and DocGia.TenDG = 'Nguyễn Văn A'
group by DauSach.Tua;