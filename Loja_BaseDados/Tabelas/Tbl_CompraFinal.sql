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
    CONSTRAINT [UK_Produtos] FOREIGN KEY ([Id_Produto]) REFERENCES [dbo].[Produtos] ([Id_Produto]),
    CONSTRAINT [UK_Cliente] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id_Cliente])
);
