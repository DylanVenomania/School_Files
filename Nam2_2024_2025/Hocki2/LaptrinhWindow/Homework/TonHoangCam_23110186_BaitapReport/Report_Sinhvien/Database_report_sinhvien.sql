create database Winform_report_sinhvien;
go

use Winform_report_sinhvien;

create table sinhvien (
	Masv nvarchar(10) primary key,
	Hoten nvarchar(50) not null,
	Gioitinh nvarchar(5) not null,
	Ngaysinh date not null,
	Khoa nvarchar( 50 ) not null,
	Lop nvarchar(20 ) not null,
	Quequan nvarchar(50) not null
);

insert into sinhvien values
('SV01', N'Nguyễn Văn A', N'Nam', '2002-03-12', N'Công nghệ thông tin', 'CNTT01', N'Hà Nội'),
('SV02', N'Lê Thị B', N'Nữ', '2002-07-18', N'Công nghệ thông tin', 'CNTT02', N'Hải Phòng'),
('SV03', N'Trần Văn C', N'Nam', '2001-11-05', N'Kinh tế', 'KT01', N'Nam Định'),
('SV04', N'Phạm Thị D', N'Nữ', '2002-09-22', N'Cơ khí', 'CK01', N'Hưng Yên');

