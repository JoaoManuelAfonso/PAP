CREATE DATABASE Loja_Angela;
CREATE TABLE [dbo].[Produtos] (
    [Id_Produto]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome_Produto] TEXT         NOT NULL,
    [Marca]        TEXT         NOT NULL,
    [Id_Categoria] INT          NOT NULL,
    Constraint [UK_Categoria] foreign key ([Id_Categoria]) references [Categoria]([Id_Categoria]),
    [Preco]        DECIMAL (18) NOT NULL,
    [Descricao]    TEXT         NOT NULL,
    [imagem]       TEXT         NOT NULL,
    [Quantidade_Disponivel] int not null ,
    [Tamanho]      TEXT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Produto] ASC)
);

CREATE TABLE [dbo].[Clientes]
(
	[Id_Cliente] INT NOT NULL identity PRIMARY KEY, 
    [Primeiro_Nome] VARCHAR(250) NOT NULL, 
    [Ultimo_Nome] VARCHAR(250) NOT NULL, 
    [Telemovel] INT NOT NULL, 
    [Email] VARCHAR(250) NOT NULL, 
    [Morada] VARCHAR(250) NOT NULL, 
    [Codigo_Postal] INT NOT NULL, 
    [Password] CHAR(64) NOT NULL
);

CREATE TABLE [dbo].[Categoria] (
    [Id_Categoria]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome_Categoria] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Categoria] ASC)
);

CREATE TABLE [dbo].[Detalhes_Envio] (
    [Id_Detalhes]              INT           IDENTITY (1, 1) NOT NULL,
    [Id_Cliente]               INT           NOT NULL,
    [Id_Produto]               INT           NOT NULL,
    [Estado_Pedido]            TEXT          NOT NULL,
    [Data_Encomenta]           DATE          NOT NULL,
    [Data_Estimada]            DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Detalhes] ASC),
    CONSTRAINT [UK_Clientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id_Cliente]),
    CONSTRAINT [UK_Produto] FOREIGN KEY ([Id_Produto]) REFERENCES [dbo].[Produtos] ([Id_Produto])
);

CREATE TABLE [dbo].[Compra_Final] (
    [Id_CompraFinal]           INT           IDENTITY (1, 1) NOT NULL,
    [Id_Cliente]               INT           NOT NULL,
    [Id_Produto]               INT           NOT NULL,
    [Quantidade_Desejada]      INT           NOT NULL,
    [Valor]                    FLOAT (53)    NOT NULL,
    [Desconto]                 FLOAT (53)    NULL,
    [Morada_Alternativa]       VARCHAR (250) NULL,
    [CodigoPostal_Alternativo] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id_CompraFinal] ASC),
    CONSTRAINT [UK_Cliente] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id_Cliente]),
    CONSTRAINT [UK_Produtos] FOREIGN KEY ([Id_Produto]) REFERENCES [dbo].[Produtos] ([Id_Produto])
);
