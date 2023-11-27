CREATE PROCEDURE [dbo].[DeleteUser]
	@Id_Cliente int
AS
	begin
	declare @count int
	select @count = Count(*) from Clientes where Id_Cliente = @Id_Cliente
	if(@count = 0)
	begin 
		select -1 as ReturnCode
	end
	else
	begin
		delete from Produtos where @Id_Cliente = @Id_Cliente
	end
end