IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200807125458_MigracaoInicial')
BEGIN
    CREATE TABLE [Livro] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] nvarchar(200) NOT NULL,
        [Sinopse] nvarchar(300) NOT NULL,
        [Preco] decimal(18,2) NOT NULL,
        [EmEstoque] bit NOT NULL,
        [Genero] nvarchar(100) NULL,
        [Escritor] nvarchar(200) NOT NULL,
        [ImagemUrl] nvarchar(400) NULL,
        CONSTRAINT [PK_Livro] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200807125458_MigracaoInicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200807125458_MigracaoInicial', N'3.1.6');
END;

GO

