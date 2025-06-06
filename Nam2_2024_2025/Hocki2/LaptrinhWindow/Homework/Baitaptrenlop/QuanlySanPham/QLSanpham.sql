create database Laptrinhwinform_tuan7_QLSanpham;
go

use Laptrinhwinform_tuan7_QLSanpham;
go

create table Danhmuc(
	Madanhmuc nvarchar( 20 ) primary key,
	Tendanhmuc nvarchar( 100 ) not null
);

insert into Danhmuc( Madanhmuc, Tendanhmuc)
values 
('DM001', N'Điện thoại'),
('DM002', N'Máy tính'),
('DM003', N'Phụ kiện');


create table Sanpham(
	MaSP nvarchar( 10 ) primary key,
	Madanhmuc nvarchar( 20 ) not null,
	TenSP nvarchar( 100 ) not null,
	Gia decimal( 18, 2 ) not null default 0 check ( Gia >= 0 ),

	foreign key ( Madanhmuc ) references Danhmuc ( Madanhmuc )
);

insert into Sanpham ( MaSP, Madanhmuc, TenSP, Gia)
values 
('SP001', 'DM001', N'iPhone 14 Pro Max', 29990000),
('SP002', 'DM001', N'Samsung Galaxy S23', 23990000),
('SP003', 'DM002', N'MacBook Air M2', 27990000),
('SP004', 'DM003', N'Chuột Logitech G502', 1499000);


