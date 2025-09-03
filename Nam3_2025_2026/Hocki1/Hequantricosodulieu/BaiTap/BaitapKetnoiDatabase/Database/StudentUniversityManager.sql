create database StudentUniversityManager;
go

use StudentUniversityManager;
go

create table StudentList 
(
	StudentID varchar(10) primary key,
	Fullname nvarchar(255) not null,
	Age int check ( Age >= 18) not null,
	GPA decimal (3,2) check ( GPA >= 0 and GPA <= 4 ) not null,
);


create table AddStudentLog
(
	LogID int identity primary key,
	Eventname nvarchar(255) not null,
	LogDate Datetime
);


create table UpdateStudentLog
(
	LogID int identity primary key,
	Eventname nvarchar(255) not null,
	LogDate Datetime
);


create trigger trg_AfterAddStudent
on AddStudentLog
after insert
as
begin
	insert into AddStudentLog(Eventname, LogDate ) values (N'Đã thêm sinh viên thành công', GETDATE() ); 
end;


create trigger trg_AfterUpdateStudent
on UpdateStudentLog 
after update 
as
begin
	insert into UpdateStudentLog(Eventname, LogDate ) values (N'Cập nhật sinh viên thành công', GETDATE()) ;
end;



create procedure sp_AddStudent
	@id varchar(10),
	@name nvarchar (255),
	@age int,
	@gpa decimal (3,2) 
as
begin
	insert into StudentList(StudentID, Fullname, Age, GPA) values ('@id', '@name', @age, @gpa );
end; 


create function fn_GetGPA ( @id varchar(10) )
returns decimal(3,2)
as
begin
	declare @result decimal (3,2 );
	select @result = GPA from StudentList where StudentID = @id;
	return @result;
end;




