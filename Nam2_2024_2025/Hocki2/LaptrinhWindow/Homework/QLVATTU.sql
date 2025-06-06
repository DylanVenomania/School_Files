create database QLVATTU;
go

use QLVATTU;
go

create table VatTu (
	mavt nvarchar(10) primary key,
	tenvt nvarchar(100) not null,
	nhasx nvarchar(100) not null,
	ngaysx date not null   check ( ngaysx <= getdate() ),
	hansd int not null   check ( hansd >= 0 ),
	soluong int not null check (soluong >= 0 ),
	dongia decimal (18,2) not null check (dongia >= 0 )
);

insert into VatTu( mavt, tenvt, nhasx, ngaysx, hansd, soluong, dongia) 
values
('MVT01', N'Máy in', N'HP', '2018-06-14',10, 10, 1500.00),
('MVT02', N'Máy laptop', N'Dell', '2018-05-01', 12, 100, 1200.00),
('MVT03', N'Máy chiếu', N'SoMy', '2018-08-09', 12, 5, 5000.00);