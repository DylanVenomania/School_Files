create proc [dbo].[SP_Xoaphongban]
(
	@ID nvarchar (10)
)
as 
begin 
	if not exists( select 1 from Phongban where Maphongban = @ID ) 
		begin
			Raiserror( N'Ma phong ban khong ton tai !', 16, 1 );
			return;
		end;

	delete Phongban where Maphongban = @ID;
	print N'Xoa thanh cong!';
end;
go