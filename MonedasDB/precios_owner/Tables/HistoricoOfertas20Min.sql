CREATE TABLE [precios_owner].[HistoricoOfertas20Min](
	[IdHistoricoOfertas20Min]	INT CONSTRAINT [DF_HistoricoOfertas20Min_IdHistoricoOfertas20Min] DEFAULT (NEXT VALUE FOR [precios_owner].[SQ_HistoricoOfertas20Min]) NOT NULL,
	[Fecha]					DATE			NOT NULL,
	[HoraDesde]				INT				NOT NULL,
	[HoraHasta]				INT				NOT NULL,
	[PrecioCompra]			DECIMAL(20, 10) NULL,
	[PrecioVenta]			DECIMAL(20, 10) NULL,
	[IdProducto]			INT				NOT NULL,
	[IdMoneda]				TINYINT			NOT NULL,
	[IdPlazo]				TINYINT			NOT NULL,
	[Rueda]					Varchar(5)		NOT NULL,
	[IdMercado]				TINYINT			NOT NULL,
	[Timestamp]				TIMESTAMP		  NOT NULL, 
	CONSTRAINT [PK_HistoricoOfertas20Min] PRIMARY KEY ([IdHistoricoOfertas20Min]),
    CONSTRAINT [FK_HistoricoOfertas20Min_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto]),
	CONSTRAINT [FK_HistoricoOfertas20Min_IdPlazo] FOREIGN KEY ([IdPlazo]) REFERENCES [orden_owner].[Plazos] ([IdPlazo]),
	CONSTRAINT [FK_HistoricoOfertas20Min_IdMercado] FOREIGN KEY ([IdMercado]) REFERENCES [shared_owner].[Mercados] ([IdMercado]),
    CONSTRAINT [FK_HistoricoOfertas20Min_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
) ON [FG_Precios_001]
GO
