CREATE TABLE [orden_owner].[Pizarra](
	[IdPizarra]        bigint CONSTRAINT [DF_Pizarra_IdPizarra] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Pizarra]) NOT NULL,
	[IdMoneda]	        TINYINT NOT NULL,
    [PrecioCompra]	        DECIMAL (18,4),
	[PrecioVenta] DECIMAL(18, 4) NULL, 
    CONSTRAINT [PK_Pizarra] PRIMARY KEY CLUSTERED([IdPizarra] ASC),
    CONSTRAINT [FK_Monedas_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[monedas] ([IdMoneda]),
   )
GO
