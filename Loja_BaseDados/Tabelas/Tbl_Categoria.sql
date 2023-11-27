CREATE TABLE [dbo].[Categoria] (
    [Id_Categoria]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome_Categoria] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Categoria] ASC)
);