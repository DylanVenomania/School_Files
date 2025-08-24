CREATE DATABASE PETSHOP
GO
USE PETSHOP

CREATE TABLE [USER](
    ID int PRIMARY KEY,
    Name nvarchar(50),
    Address nvarchar(50),
    Phone varchar(10),
    Role varchar(20),
    Dateofbirth date,
    Password varchar(60),
    Balance int,
    Email varchar(50) UNIQUE,
	OTP int
)
GO


CREATE TABLE CUSTOMER(
    ID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Address NVARCHAR(50),
    Phone VARCHAR(10)
);
GO

CREATE TABLE [PRODUCT](
    Pcode int PRIMARY KEY,
    Name nvarchar(50),
    Category nvarchar(50),
    Qty int,
    Price int
)
GO

CREATE TABLE CASH(
    CashID int PRIMARY KEY,
	TransNo varchar(15),
    Pcode int,
    Qty int,
    Price int,
    Total int,
    CustomerID int,
    CashierID int,
    CONSTRAINT FK_Cash_Customer FOREIGN KEY (CustomerID) REFERENCES CUSTOMER(ID) ON DELETE SET NULL,
    CONSTRAINT FK_Cash_Product FOREIGN KEY (Pcode) REFERENCES [PRODUCT](Pcode) ON DELETE SET NULL,
	CONSTRAINT FK_Cash_User FOREIGN KEY (CashierID) REFERENCES [USER](ID) ON DELETE SET NULL
)
GO


CREATE TABLE BILL (
    BillID INT,
	TransNo varchar(15),
    CustomerID INT,
    Pcode int,
    BillDate DATETIME,
    CONSTRAINT PK_Bill PRIMARY KEY (BillID),
    CONSTRAINT FK_Bill_Product FOREIGN KEY (Pcode) REFERENCES [PRODUCT](Pcode) ON DELETE SET NULL
);
GO

INSERT INTO [USER] (ID, Name, Address, Phone, Role, Dateofbirth, Password, Balance,Email)
VALUES 
(1002, N'Trần Văn C', N'Đà Nẵng', '0912345678', 'User', '1992-03-15', '2', 0,'anhmapbmt123@gmail.com'),
(1003, N'Trần Văn D', N'Đà Nẵng', '0912345678', 'User', '1992-03-15', '3', 0,'anhmapbmt1@gmail.com'),
(1004, N'Lê Thị D', N'TP HCM', '0908765432', 'User', '1988-11-20', '4', 0,'anhmapbmt2@gmail.com'),
(1005, N'Phạm Văn E', N'Huế', '0935123456', 'Admin', '1990-05-10', '5', 0,'xinloihuy123@gmail.com');
GO

INSERT INTO CUSTOMER (ID, Name, Address, Phone)
VALUES 
(1001, N'Nguyễn Thị X', N'Hải Phòng', '0334478172'),
(1002, N'Trần Văn CAE', N'Đà Nẵng', '0912345678'),
(1003, N'Lê DO', N'TP HCM', '0908765432'),
(1004, N'Lê D12O', N'TP HCM', '0908765432');
GO

INSERT INTO [PRODUCT] (Pcode, Name, Category, Qty, Price)
VALUES 
(101, N'Chó Pedigree', N'Chó', 50, 150000),
(102, N'Mèo Tom', N'Mèo', 30, 80000),
(103, N'Chim bồ câu', N'Chim', 15, 250000),
(104, N'Cá cảnh', N'Cá', 100, 50000),
(105, N'Chó Husky', N'Chó', 25, 120000);
GO



