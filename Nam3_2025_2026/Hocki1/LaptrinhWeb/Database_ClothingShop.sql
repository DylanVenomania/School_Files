create database ClothingShop;
go

use ClothingShop;

create table Users 
(
    id int identity primary key,
    email nvarchar(255) unique not null,
    username nvarchar(100) unique not null,
    passwords nvarchar(255) not null,
    role nvarchar(50) default 'user' -- user / admin
);

create table Categories (
    id int identity primary key,
    name nvarchar(255) not null,
    description nvarchar(500),
    user_id int not null,
    foreign key (user_id) references Users(id)
);

create table Products (
    id int identity primary key,
    name nvarchar(255) not null,
    price decimal(10,2) not null,
    category_id int not null,
    foreign key (category_id) references Categories(id)
);