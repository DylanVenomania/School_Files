CREATE DATABASE ute_web_login_register;
GO
USE ute_web_login_register;
GO

CREATE TABLE UserList (
    id INT PRIMARY KEY IDENTITY(1,1),
    email NVARCHAR(100) NOT NULL,
    username NVARCHAR(50) NOT NULL UNIQUE,
    fullname NVARCHAR(100),
    [password] NVARCHAR(255) NOT NULL,
    avatar NVARCHAR(255),
    roleid INT DEFAULT 3,
    phone NVARCHAR(20),
    createdDate DATE DEFAULT GETDATE()
);
