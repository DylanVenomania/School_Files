create proc [dbo].[ SP_Themphongban]
(
	@Maphongban nvarchar( 10),
	@Name nvarchar ( 250 ),
	@Description nvarchar( 250 )
)
as 
begin
	if exists( select 1 from Phongban where Maphongban = @Maphongban )
	begin
		RAISERROR (N'M� ph�ng ban ?� t?n t?i!', 16, 1);
		return;
	end;


	insert into Phongban (Maphongban, Tenphongban, Mota ) values ( @Maphongban, @Name, @Description) ;
	print N'Th�m th�nh c�ng !';
end;
go