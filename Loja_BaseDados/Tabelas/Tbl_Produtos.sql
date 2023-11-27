
CREATE TABLE [dbo].[Produtos] (
    [Id_Produto]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome_Produto] VARCHAR (256) NOT NULL,
    [Marca]        TEXT          NOT NULL,
    [Id_Categoria] INT           NOT NULL,
    [Preco]        MONEY         NOT NULL,
    [Descricao]    TEXT          NOT NULL,
    [imagem]       VARCHAR (256) NOT NULL,
    [Tamanho]      TEXT          NOT NULL,
    CONSTRAINT [PK__Produtos__94E704D8D0B9D3CD] PRIMARY KEY CLUSTERED ([Id_Produto] ASC),
    CONSTRAINT [UK_Categoria] FOREIGN KEY ([Id_Categoria]) REFERENCES [dbo].[Categoria] ([Id_Categoria])
);


