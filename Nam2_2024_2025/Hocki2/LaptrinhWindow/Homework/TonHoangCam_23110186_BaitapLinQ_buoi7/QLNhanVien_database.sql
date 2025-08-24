create database Winform_tuan7_QLNhanVien;
go

use Winform_tuan7_QLNhanVien;
go

create table NhanVien (
	MaNV int identity(1,1) primary key,
	Hoten nvarchar (100) not null,
	Ngaysinh date not null,
	Diachi nvarchar ( 255 ) not null,
	Dienthoai nvarchar ( 15 ) not null,
	Bangcap nvarchar ( 50 ) not null,
);


insert into NhanVien( Hoten, Ngaysinh, Diachi, Dienthoai, Bangcap ) 
values 
( N'Phạm Minh Vũ', '1980-01-24', N'163/30 Thành Thái', '0905646162', N'Tiến sĩ'),
( N'Nguyễn Minh Thành', '1983-04-05', N'41/4 Calmette, Quận 1', '0908373612', N'Thạc sĩ'),
( N'Nguyễn Hà My', '1985-03-13', N'178 Nam Kì Khởi Nghĩa', '0908783274', N'Đại học');
