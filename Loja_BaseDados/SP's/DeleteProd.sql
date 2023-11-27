CREATE PROCEDURE [dbo].[DeleteProd]
	@Id_Produto int
AS
	begin
	declare @count int
	select @count = Count(*) from Produtos where Id_Produto = @Id_Produto
	if(@count = 0)
	begin 
		select -1 as ReturnCode
	end
	else
	begin
		delete from Produtos where Id_Produto = @Id_Produto
	end
end