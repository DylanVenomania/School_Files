-- 1. Tạo cơ sở dữ liệu nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CinemaDB')
BEGIN
    CREATE DATABASE CinemaDB;
END
GO

USE CinemaDB;
GO

-- 2. Tạo bảng VaiTro
IF OBJECT_ID('VaiTro', 'U') IS NOT NULL DROP TABLE VaiTro;
GO

CREATE TABLE VaiTro (
    VaiTroID VARCHAR(10) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE,
    MoTa NVARCHAR(255)
);
GO

-- Thêm dữ liệu mẫu cho VaiTro
INSERT INTO VaiTro (VaiTroID, TenVaiTro, MoTa)
VALUES 
    ('VT001', N'Admin', N'Quản trị toàn hệ thống'),
    ('VT002', N'Nhân viên kho', N'Quản lý kho thiết bị'),
    ('VT003', N'Nhân viên kỹ thuật', N'Báo cáo và kiểm tra thiết bị'),
    ('VT004', N'Nhân viên bảo trì', N'Sửa chữa thiết bị và ghế');
GO

-- 3. Tạo bảng NhanVien
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
GO

CREATE TABLE NhanVien (
    EmployeeID VARCHAR(10) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARBINARY(256) NOT NULL,
    VaiTroID VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES VaiTro(VaiTroID),
    HoTen NVARCHAR(100) NOT NULL
);
GO

-- 4. Tạo bảng LichSuHoatDong
IF OBJECT_ID('LichSuHoatDong', 'U') IS NOT NULL DROP TABLE LichSuHoatDong;
GO

CREATE TABLE LichSuHoatDong (
    LogID VARCHAR(10) PRIMARY KEY,
    EmployeeID VARCHAR(10) FOREIGN KEY REFERENCES NhanVien(EmployeeID),
    HanhDong NVARCHAR(100),
    DoiTuongID VARCHAR(50),
    ThoiGian DATETIME DEFAULT GETDATE(),
    MoTa NVARCHAR(255)
);
GO

-- 5. Tạo bảng DanhMuc
IF OBJECT_ID('DanhMuc', 'U') IS NOT NULL DROP TABLE DanhMuc;
GO

CREATE TABLE DanhMuc (
    CategoryID VARCHAR(10) PRIMARY KEY,
    TenDanhMuc NVARCHAR(50) NOT NULL UNIQUE,
    MoTa NVARCHAR(255)
);
GO

-- Thêm dữ liệu mẫu cho DanhMuc
INSERT INTO DanhMuc (CategoryID, TenDanhMuc, MoTa)
VALUES 
    ('CAT001', N'Ghế ngồi', N'Ghế trong phòng chiếu phim'),
    ('CAT002', N'Máy chiếu', N'Máy chiếu phim'),
    ('CAT003', N'Loa', N'Hệ thống loa âm thanh'),
    ('CAT004', N'Đèn', N'Đèn chiếu sáng phòng chiếu');
GO

-- 6. Tạo bảng PhongChieu
IF OBJECT_ID('PhongChieu', 'U') IS NOT NULL DROP TABLE PhongChieu;
GO

CREATE TABLE PhongChieu (
    PhongChieuID VARCHAR(10) PRIMARY KEY,
    TenPhong NVARCHAR(50) NOT NULL UNIQUE,
    SucChua INT NOT NULL CHECK (SucChua > 0)
);
GO

-- 7. Tạo bảng ThietBi
IF OBJECT_ID('ThietBi', 'U') IS NOT NULL DROP TABLE ThietBi;
GO

CREATE TABLE ThietBi (
    EquipmentID VARCHAR(10) PRIMARY KEY,
    CategoryID VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES DanhMuc(CategoryID),
    TenThietBi NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Good', 'Broken', 'Repairing', 'In Use')),
    NgayMua DATE NOT NULL,
    NhaCungCap NVARCHAR(100) NULL,
    Location NVARCHAR(50) NOT NULL CHECK (Location IN ('Warehouse', 'Screening Room')),
    PhongChieuID VARCHAR(10) NULL FOREIGN KEY REFERENCES PhongChieu(PhongChieuID) ON DELETE SET NULL
);
GO

-- 8. Tạo bảng GheNgoi
IF OBJECT_ID('GheNgoi', 'U') IS NOT NULL DROP TABLE GheNgoi;
GO

CREATE TABLE GheNgoi (
    GheID VARCHAR(10) PRIMARY KEY,
    PhongChieuID VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES PhongChieu(PhongChieuID) ON DELETE CASCADE,
    Hang CHAR(1) NOT NULL CHECK (Hang BETWEEN 'A' AND 'Z'),
    Cot INT NOT NULL CHECK (Cot > 0),
    Status NVARCHAR(50) NOT NULL CHECK (Status IN ('Good', 'Broken', 'Repairing')),
    NgayLapDat DATE NOT NULL DEFAULT GETDATE()
);
GO

-- 9. Tạo bảng SuaChua
IF OBJECT_ID('SuaChua', 'U') IS NOT NULL DROP TABLE SuaChua;
GO

CREATE TABLE SuaChua (
    SuaChuaID VARCHAR(10) PRIMARY KEY,
    EquipmentID VARCHAR(10) NULL FOREIGN KEY REFERENCES ThietBi(EquipmentID),
    GheID VARCHAR(10) NULL FOREIGN KEY REFERENCES GheNgoi(GheID),
    NgaySuaChua DATE NOT NULL CHECK (NgaySuaChua <= GETDATE()),
    MoTa NVARCHAR(255) NOT NULL,
    ChiPhi DECIMAL(15, 2) NOT NULL CHECK (ChiPhi >= 0),
    EmployeeID VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES NhanVien(EmployeeID),
    TrangThai NVARCHAR(50) NOT NULL CHECK ( TrangThai IN ('In Progress', 'Completed')),
    NgayHoanThanh DATE NULL 
);
GO

-- 10. Tạo trigger cho NhanVien: trg_TaoEmployeeID
IF OBJECT_ID('trg_TaoEmployeeID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoEmployeeID;
GO

CREATE TRIGGER trg_TaoEmployeeID
ON NhanVien
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10);
    DECLARE @MaxID INT;
    
    SELECT @MaxID = ISNULL(MAX(CAST(RIGHT(EmployeeID, 3) AS INT)), 0)
    FROM NhanVien
    WHERE EmployeeID LIKE 'NV[0-9][0-9][0-9]';
    
    SET @NewID = 'NV' + RIGHT('000' + CAST((@MaxID + 1) AS VARCHAR(3)), 3);
    
    INSERT INTO NhanVien (EmployeeID, TenDangNhap, MatKhau, VaiTroID, HoTen)
    SELECT @NewID, TenDangNhap, MatKhau, VaiTroID, HoTen
    FROM inserted;
END;
GO

-- 11. Tạo trigger cho LichSuHoatDong: trg_TaoLogID
IF OBJECT_ID('trg_TaoLogID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoLogID;
GO

CREATE TRIGGER trg_TaoLogID
ON LichSuHoatDong
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10);
    DECLARE @MaxID INT;
    
    SELECT @MaxID = ISNULL(MAX(CAST(RIGHT(LogID, 3) AS INT)), 0)
    FROM LichSuHoatDong
    WHERE LogID LIKE 'LOG[0-9][0-9][0-9]';
    
    SET @NewID = 'LOG' + RIGHT('000' + CAST((@MaxID + 1) AS VARCHAR(3)), 3);
    
    INSERT INTO LichSuHoatDong (LogID, EmployeeID, HanhDong, DoiTuongID, ThoiGian, MoTa)
    SELECT @NewID, EmployeeID, HanhDong, DoiTuongID, ThoiGian, MoTa
    FROM inserted;
END;
GO

-- 12. Tạo trigger cho DanhMuc: trg_TaoCategoryID
IF OBJECT_ID('trg_TaoCategoryID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoCategoryID;
GO

CREATE TRIGGER trg_TaoCategoryID
ON DanhMuc
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @NewID VARCHAR(10);
    DECLARE @Count INT;
    
    SELECT @Count = COUNT(*) + 1 FROM DanhMuc;
    SET @NewID = 'CAT' + RIGHT('000' + CAST(@Count AS VARCHAR(3)), 3);
    
    INSERT INTO DanhMuc (CategoryID, TenDanhMuc, MoTa)
    SELECT @NewID, TenDanhMuc, MoTa
    FROM inserted;
END;
GO

-- 13. Tạo trigger cho ThietBi: trg_TaoEquipmentID
IF OBJECT_ID('trg_TaoEquipmentID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoEquipmentID;
GO

CREATE TRIGGER trg_TaoEquipmentID
ON ThietBi
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10);
    DECLARE @MaxID INT;
    
    SELECT @MaxID = ISNULL(MAX(CAST(RIGHT(EquipmentID, 3) AS INT)), 0)
    FROM ThietBi
    WHERE EquipmentID LIKE 'TB[0-9][0-9][0-9]';
    
    SET @NewID = 'TB' + RIGHT('000' + CAST((@MaxID + 1) AS VARCHAR(3)), 3);
    
    INSERT INTO ThietBi (EquipmentID, CategoryID, TenThietBi, Status, NgayMua, NhaCungCap, Location, PhongChieuID)
    SELECT @NewID, CategoryID, TenThietBi, Status, NgayMua, NhaCungCap, Location, PhongChieuID
    FROM inserted;
END;
GO

-- 14. Tạo trigger ghi log cho ThietBi: trg_LogThietBi
IF OBJECT_ID('trg_LogThietBi', 'TR') IS NOT NULL DROP TRIGGER trg_LogThietBi;
GO

CREATE TRIGGER trg_LogThietBi
ON ThietBi
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @HanhDong NVARCHAR(50), @DoiTuongID VARCHAR(10), @MoTa NVARCHAR(255), @EmployeeID VARCHAR(10);
    
    SET @EmployeeID = (SELECT EmployeeID FROM NhanVien WHERE TenDangNhap = SUSER_NAME());

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = EquipmentID, @MoTa = N'Thêm thiết bị ' + TenThietBi FROM inserted;
        SET @HanhDong = N'Thêm thiết bị';
    END
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = EquipmentID, @MoTa = N'Sửa thiết bị ' + TenThietBi FROM inserted;
        SET @HanhDong = N'Sửa thiết bị';
    END
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = EquipmentID, @MoTa = N'Xóa thiết bị ' + TenThietBi FROM deleted;
        SET @HanhDong = N'Xóa thiết bị';
    END

    INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
    VALUES (@EmployeeID, @HanhDong, @DoiTuongID, @MoTa);
END;
GO

-- 15. Tạo trigger sinh GheID
IF OBJECT_ID('trg_TaoGheID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoGheID;
GO

CREATE TRIGGER trg_TaoGheID
ON GheNgoi
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10), @PhongID VARCHAR(10), @Hang CHAR(1), @Cot INT;
    
    SELECT @PhongID = PhongChieuID, @Hang = Hang, @Cot = Cot
    FROM inserted;
    
    SET @NewID = @PhongID + '-' + @Hang + RIGHT('00' + CAST(@Cot AS VARCHAR(2)), 2);
    
    INSERT INTO GheNgoi (GheID, PhongChieuID, Hang, Cot, Status, NgayLapDat)
    SELECT @NewID, PhongChieuID, Hang, Cot, Status, NgayLapDat
    FROM inserted;
END;
GO

-- 16. Tạo trigger ghi log cho GheNgoi
IF OBJECT_ID('trg_LogGheNgoi', 'TR') IS NOT NULL DROP TRIGGER trg_LogGheNgoi;
GO

CREATE TRIGGER trg_LogGheNgoi
ON GheNgoi
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @HanhDong NVARCHAR(50), @DoiTuongID VARCHAR(10), @MoTa NVARCHAR(255), @EmployeeID VARCHAR(10);
    
    SET @EmployeeID = (SELECT EmployeeID FROM NhanVien WHERE TenDangNhap = SUSER_NAME());

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = GheID, @MoTa = N'Thêm ghế ' + GheID FROM inserted;
        SET @HanhDong = N'Thêm ghế';
    END
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = GheID, @MoTa = N'Sửa ghế ' + GheID FROM inserted;
        SET @HanhDong = N'Sửa ghế';
    END
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = GheID, @MoTa = N'Xóa ghế ' + GheID FROM deleted;
        SET @HanhDong = N'Xóa ghế';
    END

    INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
    VALUES (@EmployeeID, @HanhDong, @DoiTuongID, @MoTa);
END;
GO

-- 17. Tạo trigger sinh SuaChuaID
IF OBJECT_ID('trg_TaoSuaChuaID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoSuaChuaID;
GO

CREATE TRIGGER trg_TaoSuaChuaID
ON SuaChua
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10), @Count INT;
    
    SELECT @Count = COUNT(*) + 1 FROM SuaChua;
    SET @NewID = 'SC' + RIGHT('000' + CAST(@Count AS VARCHAR(3)), 3);
    
    INSERT INTO SuaChua (SuaChuaID, EquipmentID, GheID, NgaySuaChua, MoTa, ChiPhi, EmployeeID, TrangThai, NgayHoanThanh)
    SELECT @NewID, EquipmentID, GheID, NgaySuaChua, MoTa, ChiPhi, EmployeeID, TrangThai, NgayHoanThanh
    FROM inserted;
END;
GO

-- 18. Tạo trigger ghi log cho SuaChua
IF OBJECT_ID('trg_LogSuaChua', 'TR') IS NOT NULL DROP TRIGGER trg_LogSuaChua;
GO

CREATE TRIGGER trg_LogSuaChua
ON SuaChua
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @HanhDong NVARCHAR(50), @DoiTuongID VARCHAR(10), @MoTa NVARCHAR(255), @EmployeeID VARCHAR(10);
    
    SET @EmployeeID = (SELECT EmployeeID FROM NhanVien WHERE TenDangNhap = SUSER_NAME());

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = SuaChuaID, @MoTa = N'Thêm sửa chữa ' + SuaChuaID FROM inserted;
        SET @HanhDong = N'Thêm sửa chữa';
    END
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = SuaChuaID, @MoTa = N'Cập nhật sửa chữa ' + SuaChuaID FROM inserted;
        SET @HanhDong = N'Cập nhật sửa chữa';
    END
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = SuaChuaID, @MoTa = N'Xóa sửa chữa ' + SuaChuaID FROM deleted;
        SET @HanhDong = N'Xóa sửa chữa';
    END

    INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
    VALUES (@EmployeeID, @HanhDong, @DoiTuongID, @MoTa);
END;
GO

-- 19. Tạo trigger sinh PhongChieuID
IF OBJECT_ID('trg_TaoPhongChieuID', 'TR') IS NOT NULL DROP TRIGGER trg_TaoPhongChieuID;
GO

CREATE TRIGGER trg_TaoPhongChieuID
ON PhongChieu
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewID VARCHAR(10);
    DECLARE @MaxID INT;
    
    SELECT @MaxID = ISNULL(MAX(CAST(RIGHT(PhongChieuID, 3) AS INT)), 0)
    FROM PhongChieu
    WHERE PhongChieuID LIKE 'PC[0-9][0-9][0-9]';
    
    SET @NewID = 'PC' + RIGHT('000' + CAST((@MaxID + 1) AS VARCHAR(3)), 3);
    
    INSERT INTO PhongChieu (PhongChieuID, TenPhong, SucChua)
    SELECT @NewID, TenPhong, SucChua
    FROM inserted;
END;
GO

-- 20. Tạo trigger ghi log cho PhongChieu
IF OBJECT_ID('trg_LogPhongChieu', 'TR') IS NOT NULL DROP TRIGGER trg_LogPhongChieu;
GO

CREATE TRIGGER trg_LogPhongChieu
ON PhongChieu
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @HanhDong NVARCHAR(50), @DoiTuongID VARCHAR(10), @MoTa NVARCHAR(255), @EmployeeID VARCHAR(10);
    
    SET @EmployeeID = (SELECT EmployeeID FROM NhanVien WHERE TenDangNhap = SUSER_NAME());

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = PhongChieuID, @MoTa = N'Thêm phòng chiếu ' + TenPhong FROM inserted;
        SET @HanhDong = N'Thêm phòng chiếu';
    END
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = PhongChieuID, @MoTa = N'Sửa phòng chiếu ' + TenPhong FROM inserted;
        SET @HanhDong = N'Sửa phòng chiếu';
    END
    ELSE IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SELECT @DoiTuongID = PhongChieuID, @MoTa = N'Xóa phòng chiếu ' + TenPhong FROM deleted;
        SET @HanhDong = N'Xóa phòng chiếu';
    END

    INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
    VALUES (@EmployeeID, @HanhDong, @DoiTuongID, @MoTa);
END;
GO

-- 21. Tạo stored procedure sp_DangNhap
IF OBJECT_ID('sp_DangNhap', 'P') IS NOT NULL DROP PROCEDURE sp_DangNhap;
GO

CREATE PROCEDURE sp_DangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50)
AS
BEGIN
    DECLARE @StoredPassword VARBINARY(256);
    DECLARE @EmployeeID VARCHAR(10);
    DECLARE @VaiTroID VARCHAR(10);
    DECLARE @HoTen NVARCHAR(100);
    
    SELECT @StoredPassword = MatKhau, @EmployeeID = EmployeeID, @VaiTroID = VaiTroID, @HoTen = HoTen
    FROM NhanVien
    WHERE TenDangNhap = @TenDangNhap;
    
    IF @StoredPassword IS NOT NULL AND @StoredPassword = HASHBYTES('SHA2_256', @MatKhau)
    BEGIN
        INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
        VALUES (@EmployeeID, N'Đăng nhập', @EmployeeID, N'Nhân viên ' + @HoTen + N' đăng nhập thành công');
        
        SELECT EmployeeID, TenDangNhap, VaiTroID, HoTen
        FROM NhanVien
        WHERE EmployeeID = @EmployeeID;
    END
    ELSE
    BEGIN
        RAISERROR (N'Tên đăng nhập hoặc mật khẩu không đúng', 16, 1);
    END
END;
GO

-- 22. Tạo stored procedure sp_ThemNhanVien
IF OBJECT_ID('sp_ThemNhanVien', 'P') IS NOT NULL DROP PROCEDURE sp_ThemNhanVien;
GO

CREATE PROCEDURE sp_ThemNhanVien
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50),
    @VaiTroID VARCHAR(10),
    @HoTen NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT 1 FROM NhanVien WHERE TenDangNhap = @TenDangNhap)
            RAISERROR (N'Tên đăng nhập đã tồn tại', 16, 1);
        
        IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE VaiTroID = @VaiTroID)
            RAISERROR (N'Vai trò không tồn tại', 16, 1);
        
        -- Thêm nhân viên vào bảng NhanVien
        INSERT INTO NhanVien (TenDangNhap, MatKhau, VaiTroID, HoTen)
        VALUES (@TenDangNhap, HASHBYTES('SHA2_256', @MatKhau), @VaiTroID, @HoTen);
        
        DECLARE @NewEmployeeID VARCHAR(10);
        SELECT @NewEmployeeID = EmployeeID 
        FROM NhanVien 
        WHERE TenDangNhap = @TenDangNhap;
        
        -- ← Thêm: Tạo login SQL (tài khoản server-level)
        DECLARE @LoginSQL NVARCHAR(MAX) = 'IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = ''' + @TenDangNhap + ''') CREATE LOGIN [' + @TenDangNhap + '] WITH PASSWORD = ''' + @MatKhau + ''', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF;';
        EXEC sp_executesql @LoginSQL;
        
        -- ← Thêm: Tạo user database (database-level)
        DECLARE @UserSQL NVARCHAR(MAX) = 'IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = ''' + @TenDangNhap + ''') CREATE USER [' + @TenDangNhap + '] FOR LOGIN [' + @TenDangNhap + '];';
        EXEC sp_executesql @UserSQL;
        
        -- ← Thêm: Gán role dựa trên VaiTroID
        DECLARE @RoleSQL NVARCHAR(MAX);
        IF @VaiTroID = 'VT001' SET @RoleSQL = 'ALTER ROLE db_admin ADD MEMBER [' + @TenDangNhap + '];';
        ELSE IF @VaiTroID = 'VT002' SET @RoleSQL = 'ALTER ROLE db_warehouse ADD MEMBER [' + @TenDangNhap + '];';
        ELSE IF @VaiTroID = 'VT003' SET @RoleSQL = 'ALTER ROLE db_technician ADD MEMBER [' + @TenDangNhap + '];';
        ELSE IF @VaiTroID = 'VT004' SET @RoleSQL = 'ALTER ROLE db_maintenance ADD MEMBER [' + @TenDangNhap + '];';
        IF @RoleSQL IS NOT NULL EXEC sp_executesql @RoleSQL;
        
        -- Ghi log thêm nhân viên
        INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
        VALUES (
            @NewEmployeeID,
            N'Thêm nhân viên',
            @NewEmployeeID,
            N'Thêm nhân viên ' + @HoTen + N' với vai trò ' + @VaiTroID + N' và tạo tài khoản SQL'
        );
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- Thêm admin 
IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE TenDangNhap = N'admin')
    EXEC sp_ThemNhanVien @TenDangNhap = N'admin', @MatKhau = N'123456789', @VaiTroID = 'VT001', @HoTen = N'Tôn Hoàng Cầm';
GO

-- 23. Tạo stored procedure cho DanhMuc
IF OBJECT_ID('sp_LayDanhSachDanhMuc', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachDanhMuc;
GO

CREATE PROCEDURE sp_LayDanhSachDanhMuc
AS
BEGIN
    SELECT CategoryID, TenDanhMuc, MoTa
    FROM DanhMuc
    ORDER BY CategoryID;
END;
GO

IF OBJECT_ID('sp_ThemDanhMuc', 'P') IS NOT NULL DROP PROCEDURE sp_ThemDanhMuc;
GO

CREATE PROCEDURE sp_ThemDanhMuc
    @TenDanhMuc NVARCHAR(50),
    @MoTa NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO DanhMuc (TenDanhMuc, MoTa)
        VALUES (@TenDanhMuc, @MoTa);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

IF OBJECT_ID('sp_SuaDanhMuc', 'P') IS NOT NULL DROP PROCEDURE sp_SuaDanhMuc;
GO

CREATE PROCEDURE sp_SuaDanhMuc
    @CategoryID VARCHAR(10),
    @TenDanhMuc NVARCHAR(50),
    @MoTa NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE DanhMuc
        SET TenDanhMuc = @TenDanhMuc, MoTa = @MoTa
        WHERE CategoryID = @CategoryID;
        
        IF @@ROWCOUNT = 0
            RAISERROR (N'Không tìm thấy danh mục', 16, 1);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaDanhMuc', 'P') IS NOT NULL DROP PROCEDURE sp_XoaDanhMuc;
GO

CREATE PROCEDURE sp_XoaDanhMuc
    @CategoryID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT 1 FROM ThietBi WHERE CategoryID = @CategoryID)
            RAISERROR (N'Không thể xóa vì có thiết bị liên quan', 16, 1);
        
        DELETE FROM DanhMuc
        WHERE CategoryID = @CategoryID;
        
        IF @@ROWCOUNT = 0
            RAISERROR (N'Không tìm thấy danh mục', 16, 1);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- 24. Tạo stored procedure cho ThietBi
IF OBJECT_ID('sp_ThemThietBi', 'P') IS NOT NULL DROP PROCEDURE sp_ThemThietBi;
GO

CREATE PROCEDURE sp_ThemThietBi
    @CategoryID VARCHAR(10),
    @TenThietBi NVARCHAR(100),
    @Status NVARCHAR(50),
    @NgayMua DATE,
    @NhaCungCap NVARCHAR(100),
    @Location NVARCHAR(50),
    @PhongChieuID VARCHAR(10) = NULL,
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM DanhMuc WHERE CategoryID = @CategoryID)
            THROW 50001, N'Danh mục không tồn tại', 1;
        
        IF @PhongChieuID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM PhongChieu WHERE PhongChieuID = @PhongChieuID)
            THROW 50002, N'Phòng chiếu không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50003, N'Nhân viên không tồn tại', 1;
        
        IF @Location = 'Screening Room' AND @PhongChieuID IS NULL
            THROW 50004, N'Phải chỉ định phòng chiếu khi xuất kho', 1;

        INSERT INTO ThietBi (CategoryID, TenThietBi, Status, NgayMua, NhaCungCap, Location, PhongChieuID)
        VALUES (@CategoryID, @TenThietBi, @Status, @NgayMua, @NhaCungCap, @Location, @PhongChieuID);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_SuaThietBi', 'P') IS NOT NULL DROP PROCEDURE sp_SuaThietBi;
GO

CREATE PROCEDURE sp_SuaThietBi
    @EquipmentID VARCHAR(10),
    @CategoryID VARCHAR(10),
    @TenThietBi NVARCHAR(100),
    @Status NVARCHAR(50),
    @NgayMua DATE,
    @NhaCungCap NVARCHAR(100),
    @Location NVARCHAR(50),
    @PhongChieuID VARCHAR(10) = NULL,
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM ThietBi WHERE EquipmentID = @EquipmentID)
            THROW 50001, N'Thiết bị không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM DanhMuc WHERE CategoryID = @CategoryID)
            THROW 50002, N'Danh mục không tồn tại', 1;
        
        IF @PhongChieuID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM PhongChieu WHERE PhongChieuID = @PhongChieuID)
            THROW 50003, N'Phòng chiếu không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50004, N'Nhân viên không tồn tại', 1;
        
        IF @Location = 'Screening Room' AND @PhongChieuID IS NULL
            THROW 50005, N'Phải chỉ định phòng chiếu khi xuất kho', 1;

        UPDATE ThietBi
        SET CategoryID = @CategoryID,
            TenThietBi = @TenThietBi,
            Status = @Status,
            NgayMua = @NgayMua,
            NhaCungCap = @NhaCungCap,
            Location = @Location,
            PhongChieuID = @PhongChieuID
        WHERE EquipmentID = @EquipmentID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaThietBi', 'P') IS NOT NULL DROP PROCEDURE sp_XoaThietBi;
GO

CREATE PROCEDURE sp_XoaThietBi
    @EquipmentID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM ThietBi WHERE EquipmentID = @EquipmentID)
            THROW 50001, N'Thiết bị không tồn tại', 1;
        
        IF (SELECT Location FROM ThietBi WHERE EquipmentID = @EquipmentID) = 'Screening Room'
            THROW 50002, N'Không thể xóa thiết bị đang sử dụng', 1;
        
        DELETE FROM ThietBi WHERE EquipmentID = @EquipmentID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_NhapKho', 'P') IS NOT NULL DROP PROCEDURE sp_NhapKho;
GO

CREATE PROCEDURE sp_NhapKho
	@EquipmentID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM ThietBi WHERE EquipmentID = @EquipmentID)
            THROW 50001, N'Thiết bị không tồn tại', 1;
        
        UPDATE ThietBi
        SET Location = 'Warehouse',
            PhongChieuID = NULL
        WHERE EquipmentID = @EquipmentID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XuatKho', 'P') IS NOT NULL DROP PROCEDURE sp_XuatKho;
GO

CREATE PROCEDURE sp_XuatKho
	@EquipmentID VARCHAR(10),
    @PhongChieuID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM ThietBi WHERE EquipmentID = @EquipmentID)
            THROW 50001, N'Thiết bị không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM PhongChieu WHERE PhongChieuID = @PhongChieuID)
            THROW 50002, N'Phòng chiếu không tồn tại', 1;
        
        UPDATE ThietBi
        SET Location = 'Screening Room',
            PhongChieuID = @PhongChieuID,
            Status = 'In Use'
        WHERE EquipmentID = @EquipmentID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;

-- 25. Tạo stored procedure cho PhongChieu
IF OBJECT_ID('sp_LayDanhSachPhongChieu', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachPhongChieu;
GO

CREATE PROCEDURE sp_LayDanhSachPhongChieu
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PhongChieuID, TenPhong, SucChua
    FROM PhongChieu
    ORDER BY PhongChieuID;
END;
GO

IF OBJECT_ID('sp_ThemPhongChieu', 'P') IS NOT NULL DROP PROCEDURE sp_ThemPhongChieu;
GO

CREATE PROCEDURE sp_ThemPhongChieu
    @TenPhong NVARCHAR(50),
    @SucChua INT,
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF EXISTS (SELECT 1 FROM PhongChieu WHERE TenPhong = @TenPhong)
            THROW 50001, N'Tên phòng chiếu đã tồn tại', 1;
        
        IF @SucChua <= 0
            THROW 50002, N'Sức chứa phải lớn hơn 0', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50003, N'Nhân viên không tồn tại', 1;
        
        INSERT INTO PhongChieu (TenPhong, SucChua)
        VALUES (@TenPhong, @SucChua);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_SuaPhongChieu', 'P') IS NOT NULL DROP PROCEDURE sp_SuaPhongChieu;
GO

CREATE PROCEDURE sp_SuaPhongChieu
    @PhongChieuID VARCHAR(10),
    @TenPhong NVARCHAR(50),
    @SucChua INT,
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM PhongChieu WHERE PhongChieuID = @PhongChieuID)
            THROW 50001, N'Phòng chiếu không tồn tại', 1;
        
        IF EXISTS (SELECT 1 FROM PhongChieu WHERE TenPhong = @TenPhong AND PhongChieuID != @PhongChieuID)
            THROW 50002, N'Tên phòng chiếu đã tồn tại', 1;
        
        IF @SucChua <= 0
            THROW 50003, N'Sức chứa phải lớn hơn 0', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50004, N'Nhân viên không tồn tại', 1;
        
        UPDATE PhongChieu
        SET TenPhong = @TenPhong,
            SucChua = @SucChua
        WHERE PhongChieuID = @PhongChieuID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaPhongChieu', 'P') IS NOT NULL DROP PROCEDURE sp_XoaPhongChieu;
GO

CREATE PROCEDURE sp_XoaPhongChieu
    @PhongChieuID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM PhongChieu WHERE PhongChieuID = @PhongChieuID)
            THROW 50001, N'Phòng chiếu không tồn tại', 1;
        
        IF EXISTS (SELECT 1 FROM ThietBi WHERE PhongChieuID = @PhongChieuID)
            THROW 50002, N'Không thể xóa vì phòng chiếu đang được sử dụng bởi thiết bị', 1;
        
        IF EXISTS (SELECT 1 FROM GheNgoi WHERE PhongChieuID = @PhongChieuID)
            THROW 50003, N'Không thể xóa vì phòng chiếu đang có ghế ngồi', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50004, N'Nhân viên không tồn tại', 1;
        
        DELETE FROM PhongChieu WHERE PhongChieuID = @PhongChieuID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

-- 26. Tạo stored procedure cho NhanVien
IF OBJECT_ID('sp_LayDanhSachNhanVien', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachNhanVien;
GO

CREATE PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EmployeeID, TenDangNhap, HoTen, TenVaiTro, MoTa
    FROM vw_NhanVienVaiTro
    ORDER BY EmployeeID;
END;
GO

IF OBJECT_ID('sp_SuaNhanVien', 'P') IS NOT NULL DROP PROCEDURE sp_SuaNhanVien;
GO

CREATE PROCEDURE sp_SuaNhanVien
    @EmployeeID VARCHAR(10),
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(50),
    @VaiTroID VARCHAR(10),
    @HoTen NVARCHAR(100),
    @EmployeeIDCurrent VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50001, N'Nhân viên không tồn tại', 1;
        
        IF EXISTS (SELECT 1 FROM NhanVien WHERE TenDangNhap = @TenDangNhap AND EmployeeID != @EmployeeID)
            THROW 50002, N'Tên đăng nhập đã tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM VaiTro WHERE VaiTroID = @VaiTroID)
            THROW 50003, N'Vai trò không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeIDCurrent)
            THROW 50004, N'Nhân viên thực hiện không tồn tại', 1;

        UPDATE NhanVien
        SET TenDangNhap = @TenDangNhap,
            MatKhau = HASHBYTES('SHA2_256', @MatKhau),
            VaiTroID = @VaiTroID,
            HoTen = @HoTen
        WHERE EmployeeID = @EmployeeID;
        
        INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
        VALUES (@EmployeeIDCurrent, N'Sửa nhân viên', @EmployeeID, N'Sửa thông tin nhân viên ' + @HoTen);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaNhanVien', 'P') IS NOT NULL DROP PROCEDURE sp_XoaNhanVien;
GO

CREATE PROCEDURE sp_XoaNhanVien
    @EmployeeID VARCHAR(10),
    @EmployeeIDCurrent VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50001, N'Nhân viên không tồn tại', 1;
   
      
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeIDCurrent)
            THROW 50003, N'Nhân viên thực hiện không tồn tại', 1;

		UPDATE LichSuHoatDong SET EmployeeID = NULL WHERE EmployeeID = @EmployeeID;

		INSERT INTO LichSuHoatDong (EmployeeID, HanhDong, DoiTuongID, MoTa)
        VALUES (@EmployeeIDCurrent, N'Xóa nhân viên', @EmployeeID, N'Xóa nhân viên');

        DELETE FROM NhanVien WHERE EmployeeID = @EmployeeID;
        
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

-- 27. Tạo stored procedure cho GheNgoi
IF OBJECT_ID('sp_LayMaTranGheTheoPhong', 'P') IS NOT NULL DROP PROCEDURE sp_LayMaTranGheTheoPhong;
GO

CREATE PROCEDURE sp_LayMaTranGheTheoPhong
    @PhongChieuID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT GheID, Hang, Cot, Status
    FROM GheNgoi
    WHERE PhongChieuID = @PhongChieuID
    ORDER BY Hang, Cot;
END;
GO

IF OBJECT_ID('sp_ThemGhe', 'P') IS NOT NULL DROP PROCEDURE sp_ThemGhe;
GO

CREATE PROCEDURE sp_ThemGhe
    @PhongChieuID VARCHAR(10),
    @Hang CHAR(1),
    @Cot INT,
    @Status VARCHAR(20),
    @NgayLapDat DATE,
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF EXISTS (SELECT 1 FROM GheNgoi WHERE PhongChieuID = @PhongChieuID AND Hang = @Hang AND Cot = @Cot)
        BEGIN
            RAISERROR('Ghế đã tồn tại tại vị trí này!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        IF @Hang NOT LIKE '[A-Z]'
        BEGIN
            RAISERROR('Hàng ghế phải từ A-Z!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
        INSERT INTO GheNgoi (PhongChieuID, Hang, Cot, Status, NgayLapDat)
        VALUES (@PhongChieuID, @Hang, @Cot, @Status, @NgayLapDat);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;      


IF OBJECT_ID('sp_SuaGhe', 'P') IS NOT NULL DROP PROCEDURE sp_SuaGhe;
GO

CREATE PROCEDURE sp_SuaGhe
    @GheID VARCHAR(10),
    @Status NVARCHAR(50),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM GheNgoi WHERE GheID = @GheID)
            THROW 50001, N'Ghế không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50002, N'Nhân viên không tồn tại', 1;
        
        UPDATE GheNgoi
        SET Status = @Status
        WHERE GheID = @GheID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaGhe', 'P') IS NOT NULL DROP PROCEDURE sp_XoaGhe;
GO

CREATE PROCEDURE sp_XoaGhe
    @GheID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM GheNgoi WHERE GheID = @GheID)
            THROW 50001, N'Ghế không tồn tại', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50002, N'Nhân viên không tồn tại', 1;
        
        DELETE FROM GheNgoi WHERE GheID = @GheID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

-- 28. Tạo stored procedure cho SuaChua
IF OBJECT_ID('sp_LayDanhSachSuaChua', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachSuaChua;
GO

CREATE PROCEDURE sp_LayDanhSachSuaChua
    @EquipmentID VARCHAR(10) = NULL,
    @GheID VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    -- Sử dụng function trả về bảng để lấy dữ liệu, làm gọn code procedure
    SELECT *
    FROM dbo.fn_LayLichSuSuaChua(@EquipmentID, @GheID)
    ORDER BY NgaySuaChua DESC;
END;
GO

IF OBJECT_ID('sp_ThemSuaChua', 'P') IS NOT NULL DROP PROCEDURE sp_ThemSuaChua;
GO

CREATE PROCEDURE sp_ThemSuaChua
    @EquipmentID VARCHAR(10) = NULL,
    @GheID VARCHAR(10) = NULL,
    @NgaySuaChua DATE,
    @MoTa NVARCHAR(255),
    @ChiPhi DECIMAL(15, 2),
    @EmployeeID VARCHAR(10),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF @EquipmentID IS NULL AND @GheID IS NULL
            THROW 50001, N'Chọn thiết bị, hoặc ghế để sửa!', 1;
        
        IF @EquipmentID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM ThietBi WHERE EquipmentID = @EquipmentID)
            THROW 50002, N'Thiết bị không tồn tại!', 1;
        
        IF @GheID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM GheNgoi WHERE GheID = @GheID)
            THROW 50003, N'Ghế ngồi không tồn tại!', 1;
        
        IF @NgaySuaChua > GETDATE()
            THROW 50004, N'Ngày sửa chữa không thể là ở tương lai', 1;
        
        IF @ChiPhi < 0
            THROW 50005, N'Chi phí phải lớn hơn hoặc bằng 0!', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50006, N'Nhân viên không tồn tại!', 1;
        
        IF @TrangThai NOT IN (N'In Progress', N'Completed')
            THROW 50007, N'Lỗi trạng thái! Vui lòng chọn "In Progress" hoặc "Completed".', 1;
        
        INSERT INTO SuaChua (EquipmentID, GheID, NgaySuaChua, MoTa, ChiPhi, EmployeeID, TrangThai, NgayHoanThanh)
        VALUES (@EquipmentID, @GheID, @NgaySuaChua, @MoTa, @ChiPhi, @EmployeeID, @TrangThai, NULL);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_CapNhatTrangThaiSuaChua', 'P') IS NOT NULL DROP PROCEDURE sp_CapNhatTrangThaiSuaChua;
GO

CREATE PROCEDURE sp_CapNhatTrangThaiSuaChua
    @SuaChuaID VARCHAR(10),
    @TrangThai NVARCHAR(50),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM SuaChua WHERE SuaChuaID = @SuaChuaID)
            THROW 50001, N'Bản ghi sửa chữa không tồn tại!', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50002, N'Nhân viên không tồn tại!', 1;
        
        IF @TrangThai NOT IN (N'In Progress', N'Completed')
            THROW 50003, N'Lỗi trạng thái! Vui lòng chọn "In Progress" hoặc "Completed".', 1;
        
        UPDATE SuaChua
        SET TrangThai = @TrangThai,
            NgayHoanThanh = CASE WHEN @TrangThai = 'Completed' THEN GETDATE() ELSE NULL END
        WHERE SuaChuaID = @SuaChuaID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

IF OBJECT_ID('sp_XoaSuaChua', 'P') IS NOT NULL DROP PROCEDURE sp_XoaSuaChua;
GO

CREATE PROCEDURE sp_XoaSuaChua
    @SuaChuaID VARCHAR(10),
    @EmployeeID VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM SuaChua WHERE SuaChuaID = @SuaChuaID)
            THROW 50001, N'Bản ghi sửa chữa không tồn tại!', 1;
        
        IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE EmployeeID = @EmployeeID)
            THROW 50002, N'Nhân viên không tồn tại!', 1;

        DELETE FROM SuaChua WHERE SuaChuaID = @SuaChuaID;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50000, @ErrorMessage, 1;
    END CATCH
END;
GO

-- 29. Tạo stored procedure tìm kiếm 
IF OBJECT_ID('sp_TimKiemThietBi', 'P') IS NOT NULL DROP PROCEDURE sp_TimKiemThietBi;
GO

CREATE PROCEDURE sp_TimKiemThietBi
    @TuKhoa NVARCHAR(100) = NULL,
    @TrangThai VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EquipmentID, CategoryID, TenThietBi, Status, NgayMua, NhaCungCap, Location, PhongChieuID
    FROM ThietBi
    WHERE (@TuKhoa IS NULL OR TenThietBi LIKE '%' + @TuKhoa + '%' OR NhaCungCap LIKE '%' + @TuKhoa + '%')
    AND (@TrangThai IS NULL OR Status = @TrangThai);
END; 


IF OBJECT_ID('sp_TimKiemPhongChieu', 'P') IS NOT NULL DROP PROCEDURE sp_TimKiemPhongChieu;
GO

CREATE PROCEDURE sp_TimKiemPhongChieu
    @TenPhong NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PhongChieuID, TenPhong, SucChua
    FROM PhongChieu
    WHERE (@TenPhong IS NULL OR TenPhong LIKE '%' + @TenPhong + '%')
    ORDER BY PhongChieuID;
END;
GO

IF OBJECT_ID('sp_LayDanhSachLichSuHoatDong', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachLichSuHoatDong;
GO

CREATE PROCEDURE sp_LayDanhSachLichSuHoatDong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        l.LogID,
        l.EmployeeID,
        n.HoTen,
        l.HanhDong,
        l.DoiTuongID,
        l.ThoiGian,
        l.MoTa
    FROM LichSuHoatDong l
    LEFT JOIN NhanVien n ON l.EmployeeID = n.EmployeeID
    ORDER BY l.ThoiGian DESC;
END;
GO

IF OBJECT_ID('sp_TimKiemLichSuHoatDong', 'P') IS NOT NULL DROP PROCEDURE sp_TimKiemLichSuHoatDong;
GO

CREATE PROCEDURE sp_TimKiemLichSuHoatDong
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    IF @TuNgay > @DenNgay
    BEGIN
        RAISERROR('Ngày bắt đầu phải trước ngày kết thúc!', 16, 1);
        RETURN;
    END
    SELECT LogID, EmployeeID, HanhDong, DoiTuongID, ThoiGian, MoTa
    FROM LichSuHoatDong
    WHERE ThoiGian BETWEEN @TuNgay AND @DenNgay;
END;

GO

IF OBJECT_ID('sp_BaoCaoThietBiTheoTrangThai', 'P') IS NOT NULL DROP PROCEDURE sp_BaoCaoThietBiTheoTrangThai;
GO

CREATE PROCEDURE sp_BaoCaoThietBiTheoTrangThai
AS
BEGIN
    SET NOCOUNT ON;
    -- Sử dụng function trả về bảng để lấy thiết bị theo trạng thái và tính số lượng
    DECLARE @TrangThai NVARCHAR(50) = 'Good'; 
    SELECT 
        Status AS TrangThai,
        COUNT(*) AS SoLuong
    FROM dbo.fn_LayThietBiTheoTrangThai(@TrangThai)  -- Gọi function để lấy dữ liệu theo trạng thái
    GROUP BY Status
    ORDER BY Status;
END;
GO

IF OBJECT_ID('sp_BaoCaoPhongChieuTheoSucChua', 'P') IS NOT NULL DROP PROCEDURE sp_BaoCaoPhongChieuTheoSucChua;
GO

CREATE PROCEDURE sp_BaoCaoPhongChieuTheoSucChua
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        CASE 
            WHEN SucChua < 50 THEN '< 50'
            WHEN SucChua BETWEEN 50 AND 100 THEN '50 - 100'
            WHEN SucChua > 100 THEN '> 100'
        END AS KhoangSucChua,
        COUNT(*) AS SoLuong,
        AVG(dbo.fn_DemGheHongTrongPhong(PhongChieuID)) AS TrungBinhGheHong  -- Sử dụng function trả về giá trị để tính ghế hỏng trung bình
    FROM PhongChieu
    GROUP BY 
        CASE 
            WHEN SucChua < 50 THEN '< 50'
            WHEN SucChua BETWEEN 50 AND 100 THEN '50 - 100'
            WHEN SucChua > 100 THEN '> 100'
        END
    ORDER BY KhoangSucChua;
END;
GO

IF OBJECT_ID('sp_BaoCaoNhanVienTheoVaiTro', 'P') IS NOT NULL DROP PROCEDURE sp_BaoCaoNhanVienTheoVaiTro;
GO

CREATE PROCEDURE sp_BaoCaoNhanVienTheoVaiTro
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        v.TenVaiTro,
        COUNT(*) AS SoLuong
    FROM NhanVien n
    JOIN VaiTro v ON n.VaiTroID = v.VaiTroID
    GROUP BY v.TenVaiTro
    ORDER BY v.TenVaiTro;
END;
GO

-- 30. Tạo stored procedure cho ComboBox
IF OBJECT_ID('sp_LayDanhSachThietBiCombo', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachThietBiCombo;
GO

CREATE PROCEDURE sp_LayDanhSachThietBiCombo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EquipmentID, TenThietBi 
    FROM ThietBi
    ORDER BY TenThietBi;
END;
GO

IF OBJECT_ID('sp_LayDanhSachGheCombo', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachGheCombo;
GO

CREATE PROCEDURE sp_LayDanhSachGheCombo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT GheID, PhongChieuID + '-' + Hang + CAST(Cot AS NVARCHAR(2)) AS TenGhe 
    FROM GheNgoi
    ORDER BY PhongChieuID, Hang, Cot;
END;
GO

IF OBJECT_ID('sp_LayDanhSachTrangThai', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachTrangThai;
GO

CREATE PROCEDURE sp_LayDanhSachTrangThai
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        TenTrangThai AS DisplayValue,
        TenTrangThai AS Value
    FROM (VALUES 
        ('Good'),
        ('Broken'),
        ('Repairing'),
        ('In Use')
    ) AS TrangThai(TenTrangThai);
END;
GO

IF OBJECT_ID('sp_LayDanhSachVaiTro', 'P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachVaiTro;
GO

CREATE PROCEDURE sp_LayDanhSachVaiTro
AS
BEGIN
    SET NOCOUNT ON;
    SELECT VaiTroID, TenVaiTro
    FROM VaiTro
    ORDER BY VaiTroID;
END;
GO

-- 31. Tạo view
IF OBJECT_ID('vw_NhanVienVaiTro', 'V') IS NOT NULL DROP VIEW vw_NhanVienVaiTro;
GO

CREATE VIEW vw_NhanVienVaiTro AS
SELECT n.EmployeeID, n.TenDangNhap, n.HoTen, v.TenVaiTro, v.MoTa
FROM NhanVien n
JOIN VaiTro v ON n.VaiTroID = v.VaiTroID;
GO

IF OBJECT_ID('vw_DanhMuc', 'V') IS NOT NULL DROP VIEW vw_DanhMuc;
GO

CREATE VIEW vw_DanhMuc AS
SELECT CategoryID, TenDanhMuc, MoTa
FROM DanhMuc;
GO

IF OBJECT_ID('vw_ThietBi', 'V') IS NOT NULL DROP VIEW vw_ThietBi;
GO

CREATE VIEW vw_ThietBi AS
SELECT 
    t.EquipmentID,
    t.CategoryID,
    d.TenDanhMuc,
    t.TenThietBi,
    t.Status,
    t.NgayMua,
    t.NhaCungCap,
    t.Location,
    t.PhongChieuID,
    p.TenPhong
FROM ThietBi t
LEFT JOIN DanhMuc d ON t.CategoryID = d.CategoryID
LEFT JOIN PhongChieu p ON t.PhongChieuID = p.PhongChieuID;
GO

-- 32. Tạo function
-- Function trả về giá trị (scalar-valued)
IF OBJECT_ID('fn_TinhTongChiPhiSuaChua', 'FN') IS NOT NULL DROP FUNCTION fn_TinhTongChiPhiSuaChua;
GO

CREATE FUNCTION fn_TinhTongChiPhiSuaChua (@TuNgay DATE = NULL, @DenNgay DATE = NULL)
RETURNS DECIMAL(15, 2)
AS
BEGIN
    DECLARE @TongChiPhi DECIMAL(15, 2);
    
    SELECT @TongChiPhi = ISNULL(SUM(ChiPhi), 0)
    FROM SuaChua
    WHERE (@TuNgay IS NULL OR NgaySuaChua >= @TuNgay)
      AND (@DenNgay IS NULL OR NgaySuaChua <= @DenNgay);
    
    RETURN @TongChiPhi;
END;
GO


CREATE PROCEDURE sp_TinhTongChiPhi
    @TuNgay DATE,
    @DenNgay DATE,
    @TongChiPhi DECIMAL(18,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Gọi function fn_TinhTongChiPhiSuaChua để tính tổng chi phí
    SELECT @TongChiPhi = dbo.fn_TinhTongChiPhiSuaChua(@TuNgay, @DenNgay);
END



IF OBJECT_ID('fn_DemGheHongTrongPhong', 'FN') IS NOT NULL DROP FUNCTION fn_DemGheHongTrongPhong;
GO

CREATE FUNCTION fn_DemGheHongTrongPhong (@PhongChieuID VARCHAR(10))
RETURNS INT
AS
BEGIN
    DECLARE @SoGheHong INT;
    
    SELECT @SoGheHong = COUNT(*)
    FROM GheNgoi
    WHERE PhongChieuID = @PhongChieuID AND Status = 'Broken';
    
    RETURN @SoGheHong;
END;
GO

-- Function trả về bảng 
IF OBJECT_ID('fn_LayThietBiTheoTrangThai', 'IF') IS NOT NULL DROP FUNCTION fn_LayThietBiTheoTrangThai;
GO

CREATE FUNCTION fn_LayThietBiTheoTrangThai (@Status NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT 
        t.EquipmentID,
        t.CategoryID,
        t.TenThietBi,
        t.Status,
        t.NgayMua,
        t.NhaCungCap,
        t.Location,
        t.PhongChieuID,
        d.TenDanhMuc,
        p.TenPhong
    FROM ThietBi t
    LEFT JOIN DanhMuc d ON t.CategoryID = d.CategoryID
    LEFT JOIN PhongChieu p ON t.PhongChieuID = p.PhongChieuID
    WHERE t.Status = @Status
);
GO

IF OBJECT_ID('fn_LayLichSuSuaChua', 'IF') IS NOT NULL DROP FUNCTION fn_LayLichSuSuaChua;
GO

CREATE FUNCTION fn_LayLichSuSuaChua (@EquipmentID VARCHAR(10) = NULL, @GheID VARCHAR(10) = NULL)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        s.SuaChuaID,
        s.NgaySuaChua,
        s.MoTa,
        s.ChiPhi,
        s.TrangThai,
        n.HoTen AS NhanVienThucHien
    FROM SuaChua s
    JOIN NhanVien n ON s.EmployeeID = n.EmployeeID
    WHERE (s.EquipmentID = @EquipmentID OR @EquipmentID IS NULL)
      AND (s.GheID = @GheID OR @GheID IS NULL)
);
GO

-- 33. Tạo role
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'db_admin' AND type = 'R') CREATE ROLE db_admin;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'db_warehouse' AND type = 'R') CREATE ROLE db_warehouse;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'db_technician' AND type = 'R') CREATE ROLE db_technician;
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'db_maintenance' AND type = 'R') CREATE ROLE db_maintenance;
GO

-- 34. Phân quyền
GRANT EXECUTE ON sp_DangNhap TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT SELECT ON vw_NhanVienVaiTro TO db_admin;
GRANT EXECUTE ON sp_LayDanhSachDanhMuc TO db_admin;
GRANT EXECUTE ON sp_ThemDanhMuc TO db_admin;
GRANT EXECUTE ON sp_SuaDanhMuc TO db_admin;
GRANT EXECUTE ON sp_XoaDanhMuc TO db_admin;
GRANT SELECT ON vw_DanhMuc TO db_admin;
GRANT EXECUTE ON sp_ThemNhanVien TO db_admin;
GRANT EXECUTE ON sp_LayDanhSachNhanVien TO db_admin;
GRANT EXECUTE ON sp_SuaNhanVien TO db_admin;
GRANT EXECUTE ON sp_XoaNhanVien TO db_admin;
GRANT EXECUTE ON sp_LayDanhSachVaiTro TO db_admin;
GRANT EXECUTE ON sp_ThemThietBi TO db_admin, db_warehouse;
GRANT EXECUTE ON sp_SuaThietBi TO db_admin, db_warehouse;
GRANT EXECUTE ON sp_XoaThietBi TO db_admin;
GRANT SELECT ON vw_ThietBi TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_NhapKho TO db_admin, db_warehouse;
GRANT EXECUTE ON sp_XuatKho TO db_admin, db_warehouse;
GRANT EXECUTE ON sp_LayDanhSachPhongChieu TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_ThemPhongChieu TO db_admin;
GRANT EXECUTE ON sp_SuaPhongChieu TO db_admin;
GRANT EXECUTE ON sp_XoaPhongChieu TO db_admin;
GRANT EXECUTE ON sp_TimKiemPhongChieu TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_LayDanhSachLichSuHoatDong TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_TimKiemLichSuHoatDong TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_BaoCaoThietBiTheoTrangThai TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_BaoCaoPhongChieuTheoSucChua TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_BaoCaoNhanVienTheoVaiTro TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_LayDanhSachThietBiCombo TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_LayDanhSachGheCombo TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_LayDanhSachTrangThai TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_LayMaTranGheTheoPhong TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON sp_ThemGhe TO db_admin;
GRANT EXECUTE ON sp_SuaGhe TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_XoaGhe TO db_admin;
GRANT EXECUTE ON sp_LayDanhSachSuaChua TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_ThemSuaChua TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_CapNhatTrangThaiSuaChua TO db_admin, db_maintenance;
GRANT EXECUTE ON sp_XoaSuaChua TO db_admin;
GRANT EXECUTE ON sp_TimKiemThietBi TO db_admin, db_warehouse, db_technician, db_maintenance;

-- Phân quyền cho function mới
GRANT EXECUTE ON fn_TinhTongChiPhiSuaChua TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT EXECUTE ON fn_DemGheHongTrongPhong TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT SELECT ON fn_LayThietBiTheoTrangThai TO db_admin, db_warehouse, db_technician, db_maintenance;
GRANT SELECT ON fn_LayLichSuSuaChua TO db_admin, db_warehouse, db_technician, db_maintenance;
GO