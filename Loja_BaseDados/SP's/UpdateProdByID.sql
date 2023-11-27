Create Procedure [dbo].[UpdateProdByID]
	@Id_Produto int,
	@Nome_Produto varchar(256),
	@Marca text,
	@Id_Categoria int,
	@Preco money,
	@Descricao text,
	@imagem varchar(256),
	@Tamanho text
	as
	begin
	declare @count int
	select @count = Count(*) from Produtos where Id_Produto = @Id_Produto
	if(@count = 1)
	begin
		select -1 as ReturnCode
	end
	else
	begin
		update Produtos set Nome_Produto=@Nome_Produto, Marca=@Marca,Id_Categoria=@Id_Categoria,Preco=@Preco,Descricao=@Descricao,imagem=@imagem,Tamanho=@Tamanho
		select 1 as ReturnCode
	end
	end