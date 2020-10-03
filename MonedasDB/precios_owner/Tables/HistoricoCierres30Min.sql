CREATE TABLE [precios_owner].[HistoricoCierres30Min](
	IdHistoricoCierres30Min	INT CONSTRAINT [DF_HistoricoCierres30Min_IdHistoricoCierres30Min] DEFAULT (NEXT VALUE FOR [precios_owner].[SQ_HistoricoCierres30Min]) NOT NULL,
	Fecha					DATE			NOT NULL,
	HoraDesde				INT				NOT NULL,
	HoraHasta				INT				NOT NULL,
	IdProducto				INT				NOT NULL,
	IdMoneda				TINYINT			NOT NULL,
	MontoOperado			DECIMAL(18, 8)	NOT NULL,
	Cantidad				DECIMAL(18, 4)	NOT NULL,
	PrecioCierre			DECIMAL(18, 8)	NOT NULL,
	PrecioApertura			DECIMAL(18, 8)	NOT NULL,
	PrecioMinimo			DECIMAL(18, 8)	NOT NULL,
	PrecioMaximo			DECIMAL(18, 8)	NOT NULL,
    CONSTRAINT [PK_HistoricoCierres30Min] PRIMARY KEY ([IdHistoricoCierres30Min]),
    CONSTRAINT [FK_HistoricoCierres30Min_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [orden_owner].[Productos] ([IdProducto]),
    CONSTRAINT [FK_HistoricoCierres30Min_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
) ON [FG_Precios_001]
GO
