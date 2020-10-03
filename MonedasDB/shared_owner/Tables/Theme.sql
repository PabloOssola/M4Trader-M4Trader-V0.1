CREATE TABLE [shared_owner].[Theme]
(
	[IdTheme] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdUsuario] INT NOT NULL, 
    [ThemeJSON] NVARCHAR(MAX) NULL,
    CONSTRAINT [FK_IdTheme_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]),
)
