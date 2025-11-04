CREATE DATABASE ALOUTE_SocialNetwork_DB
USE ALOUTE_SocialNetwork_DB

-- Bảng Users (Thông tin người dùng)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Email VARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    IsActivated BIT DEFAULT 0,
    ActivationCode VARCHAR(50),
    Role VARCHAR(20) DEFAULT 'User' CHECK (Role IN ('Guest', 'User', 'Manager', 'Admin')),
    LastLogin DATETIME,
    SessionToken VARCHAR(500)
);

-- Bảng OtpRequests (Quản lý mã OTP)
CREATE TABLE OtpRequests (
    OtpID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    OtpCode VARCHAR(6) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    ExpiresAt DATETIME,
    IsUsed BIT DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Friends (Mối quan hệ bạn bè)
CREATE TABLE Friends (
    FriendID INT PRIMARY KEY IDENTITY(1,1),
    UserID1 INT NOT NULL,
    UserID2 INT NOT NULL,
    Status VARCHAR(20) CHECK (Status IN ('Invite', 'Waiting', 'Accepted', 'Blocked')),
    RequestDate DATETIME DEFAULT GETDATE(),
    AcceptDate DATETIME,
    FOREIGN KEY (UserID1) REFERENCES Users(UserID),
    FOREIGN KEY (UserID2) REFERENCES Users(UserID),
    CONSTRAINT UC_Friend_Unique UNIQUE (UserID1, UserID2)
);

-- Bảng Posts (Bài đăng)
CREATE TABLE Posts (
    PostID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Content NVARCHAR(1000),
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    LikesCount INT DEFAULT 0,
    CommentsCount INT DEFAULT 0,
    IsDeleted BIT DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Comments (Bình luận)
CREATE TABLE Comments (
    CommentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    Content NVARCHAR(500) NOT NULL CHECK (LEN(Content) >= 50),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsDeleted BIT DEFAULT 0,
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Likes (Lượt thích)
CREATE TABLE Likes (
    LikeID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT NOT NULL,
    UserID INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT UC_Like_Unique UNIQUE (PostID, UserID)
);

-- Bảng Messages (Tin nhắn)
CREATE TABLE Messages (
    MessageID INT PRIMARY KEY IDENTITY(1,1),
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    Content NVARCHAR(1000) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    FOREIGN KEY (SenderID) REFERENCES Users(UserID),
    FOREIGN KEY (ReceiverID) REFERENCES Users(UserID)
);

-- Bảng Attachments (Tệp đính kèm)
CREATE TABLE Attachments (
    AttachmentID INT PRIMARY KEY IDENTITY(1,1),
    PostID INT,
    MessageID INT,
    FileURL VARCHAR(255) NOT NULL,
    FileType VARCHAR(50),
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PostID) REFERENCES Posts(PostID),
    FOREIGN KEY (MessageID) REFERENCES Messages(MessageID)
);

-- Bảng Notifications (Thông báo)
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Type VARCHAR(50) CHECK (Type IN ('FriendRequest', 'Like', 'Comment', 'Message')),
    RelatedID INT, -- ID của Post, Comment, hoặc Friend request
    Content NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Bảng Groups (Nhóm)
CREATE TABLE Groups (
    GroupID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CreatedBy INT NOT NULL,
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
);

-- Bảng UserGroups (Mối quan hệ người dùng và nhóm)
CREATE TABLE UserGroups (
    UserGroupID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    GroupID INT NOT NULL,
    JoinedAt DATETIME DEFAULT GETDATE(),
    RoleInGroup VARCHAR(20) DEFAULT 'Member' CHECK (RoleInGroup IN ('Member', 'Admin')),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (GroupID) REFERENCES Groups(GroupID),
    CONSTRAINT UC_UserGroup_Unique UNIQUE (UserID, GroupID)
);

-- Bảng BlockedUsers (Danh sách chặn người dùng)
CREATE TABLE BlockedUsers (
    BlockedID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    BlockedUserID INT NOT NULL,
    BlockedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (BlockedUserID) REFERENCES Users(UserID),
    CONSTRAINT UC_Blocked_Unique UNIQUE (UserID, BlockedUserID)
);

-- Bảng AuditLogs (Theo dõi hành động)
CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    Action VARCHAR(100) NOT NULL,
    Details NVARCHAR(500),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);