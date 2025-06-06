CREATE DATABASE SanPham;
GO
USE SanPham;
GO

CREATE TABLE SanPham	
(
    MaSanPham INT PRIMARY KEY,            
    TenSanPham NVARCHAR(100) NOT NULL,    
    DonViTinh NVARCHAR(50),               
    GiaMua MONEY,                       
    GiaBan MONEY                    
);
go

CREATE TABLE HoaDon
(
    SoHoaDon INT PRIMARY KEY,              
    NgayDatHang DATE,                      
    NgayGiaoHang DATE,                     
    GhiChu NVARCHAR(255)                 
);
go
-- Tạo bảng [Order]: Lưu trữ chi tiết thông tin đơn hàng
CREATE TABLE ChiTietDonHang
(
    SoHoaDon INT NOT NULL,
    SoThuTu INT NOT NULL,                 
    MaSanPham INT NOT NULL,            
    TenSanPham NVARCHAR(100),             
    DonViTinh NVARCHAR(50),              
    DonGia MONEY,                      
    SoLuong INT,                       
    CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (SoHoaDon, SoThuTu),
    CONSTRAINT FK_ChiTietDonHang_HoaDon FOREIGN KEY (SoHoaDon)
         REFERENCES HoaDon(SoHoaDon),
    CONSTRAINT FK_ChiTietDonHang_SanPham FOREIGN KEY (MaSanPham)
         REFERENCES SanPham(MaSanPham)
);
GO

INSERT INTO SanPham (MaSanPham, TenSanPham, DonViTinh, GiaMua, GiaBan)
VALUES
(1, N'Bút bi Thiên Long', N'Cây', 3000, 5000),
(2, N'Vở Campus A4', N'Cuốn', 12000, 15000),
(3, N'Thước kẻ 20cm', N'Cây', 4000, 6000);
go

INSERT INTO HoaDon (SoHoaDon, NgayDatHang, NgayGiaoHang, GhiChu)
VALUES
(1001, '2025-04-10', '2025-04-15', N'Khách yêu cầu giao trước 15/4'),
(1002, '2025-04-11', '2025-04-18', N'Giao theo đợt, chia làm 2 lần');
go

INSERT INTO ChiTietDonHang (SoHoaDon, SoThuTu, MaSanPham, TenSanPham, DonViTinh, DonGia, SoLuong)
VALUES
(1001, 1, 1, N'Bút bi Thiên Long', N'Cây', 5000, 20),
(1001, 2, 2, N'Vở Campus A4', N'Cuốn', 15000, 10),
(1002, 1, 1, N'Bút bi Thiên Long', N'Cây', 5000, 50),
(1002, 2, 3, N'Thước kẻ 20cm', N'Cây', 6000, 15);
go