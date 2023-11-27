CREATE PROCEDURE [dbo].[InsertProd]
	
	@Nome_Produto varchar(256),
	@Descricao text,
	@Preco money,
	@Tamanho text,
	@Marca text,
	@imagem varchar(256),
	@Id_Categoria int
as
begin
	declare @count int
	select @count = Count(*) from Produtos where Nome_Produto = @Nome_Produto

	if(@count<>0)
	begin
		select -1 as ReturnCode
	end
	else
	begin
	insert into Produtos values(@Nome_Produto,@Marca,@Id_Categoria,@Preco,@Descricao,@imagem,@Tamanho);
	select 1 as ReturnCode
end
end