create proc [dbo].[SP_Suaphongban]
(
	@ID nvarchar ( 10 ),
	@Name nvarchar (250),
	@Description nvarchar( 250 )
)
as 
begin
	if not exists( select 1 from Phongban where Maphongban = @ID )
	begin
		raiserror (N'Ma phong ban khong ton tai!', 16,1 );
		return;
	end;


update Phongban 
set Tenphongban = @Name,
	Mota = @Description
	where Maphongban = @ID;

	print N'Cap nhat phong ban thanh cong!';
end;
go