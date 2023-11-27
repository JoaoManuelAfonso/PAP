

CREATE TABLE [dbo].[Detalhes_Envio] (
    [Id_Detalhes]    INT  IDENTITY (1, 1) NOT NULL,
    [Id_Cliente]     INT  NOT NULL,
    [Id_Produto]     INT  NOT NULL,
    [Estado_Pedido]  TEXT NOT NULL,
    [Data_Encomenta] DATE NOT NULL,
    [Data_Estimada]  DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Detalhes] ASC),
    CONSTRAINT [UK_Produto] FOREIGN KEY ([Id_Produto]) REFERENCES [dbo].[Produtos] ([Id_Produto]),
    CONSTRAINT [UK_Clientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id_Cliente])
);