CREATE TABLE [orden_owner].[Noticias](
	[IdNoticia]			    bigint CONSTRAINT [DF__Noticias__IdNoticia] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Noticias]) NOT NULL,
	[NewsId]				varchar(20) NOT NULL,
	[Titulo]				VARCHAR(100) NOT NULL,
	[Mensaje]				VARCHAR(MAX) NOT NULL,
	[IdMercado]             TINYINT NOT NULL,
	[Fecha]					DATETIME NOT NULL,
    [Remitente]				VARCHAR(50) NULL, 
    [Destinatarios]			VARCHAR(50) NULL, 
    CONSTRAINT [PK_Noticias] PRIMARY KEY CLUSTERED([IdNoticia] ASC),
    CONSTRAINT [FK_Noticias_IdMercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado])
)
GO
