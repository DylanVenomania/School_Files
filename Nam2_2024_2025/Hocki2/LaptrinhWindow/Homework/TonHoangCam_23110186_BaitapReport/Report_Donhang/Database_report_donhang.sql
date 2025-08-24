create database Winform_report_donhang;
go

use Winform_report_donhang;

create table Product(
	Masanpham varchar(20) primary key,
	Tensanpham nvarchar(100) not null,
	Donvitinh nvarchar(20) not null,
	Giamua int not null,
	Giaban int not null
	
);

create table Invoice(
	Sohoadon varchar(20) primary key,
	Ngaydathang date not null,
	Ngaygiaohang date not null,
	Ghichu nvarchar(255)
);

create table [Order](
	Sohoadon varchar(20) not null,
	Stt int not null,
	Masanpham varchar(20) not null,
	Tensanpham nvarchar(100) not null,
	Donvitinh nvarchar(20) not null,
	Dongia int not null,
	Soluong int not null,

	primary key( Sohoadon, Masanpham ),
	foreign key( Sohoadon) references Invoice( Sohoadon),
	foreign key( Masanpham) references Product(Masanpham)
);


insert into Product (Masanpham, Tensanpham, Donvitinh, Giamua, Giaban) values
('SP001', N'Nước suối', N'Chai', 5000, 7000),
('SP002', N'Cà phê', N'Hộp', 25000, 30000),
('SP003', N'Mì', N'Gói', 3000, 4000);

insert into Invoice( Sohoadon, Ngaydathang, Ngaygiaohang, Ghichu) values
('HD001', '2024-04-12', '2024-04-15', N'Khách đặt giao gấp'),
('HD002', '2024-04-10', '2024-04-14', N'Giao tại văn phòng');

insert into [Order] ( Sohoadon, Stt, Masanpham, Tensanpham, Donvitinh, Dongia, Soluong ) values
('HD001', 1, 'SP001', N'Nước suối', N'Chai', 7000, 10),
('HD001', 2, 'SP002', N'Cà phê', N'Hộp', 30000, 5);

insert into [Order] ( Sohoadon, Stt, Masanpham, Tensanpham, Donvitinh, Dongia, Soluong ) values 
('HD002', 1, 'SP003', N'Mì', N'Gói', 4000, 20),
('HD002', 2, 'SP002', N'Cà phê', N'Hộp', 30000, 3);

