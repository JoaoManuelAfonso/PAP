CREATE TABLE [dbo].[Clientes] (
    [Id_Cliente]    INT           IDENTITY (1, 1) NOT NULL,
    [Primeiro_Nome] VARCHAR (250) NOT NULL,
    [Ultimo_Nome]   VARCHAR (250) NOT NULL,
    [Telemovel]     INT           NOT NULL,
    [Email]         VARCHAR (250) NOT NULL,
    [Morada]        VARCHAR (250) NOT NULL,
    [Codigo_Postal] INT           NOT NULL,
    [Password]      CHAR (64)     NOT NULL,
    [Role]          CHAR (1)      NOT NULL,
    CONSTRAINT [PK_Id_Cliente] PRIMARY KEY CLUSTERED ([Id_Cliente] ASC)
);