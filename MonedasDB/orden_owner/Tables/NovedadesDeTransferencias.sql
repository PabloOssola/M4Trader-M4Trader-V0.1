CREATE TABLE [orden_owner].[NovedadesDeTransferencias]
(
	[IdNovedadTransferenciaFondo] INT CONSTRAINT [DF_NovedadesDeTransferencias_IdNovedadTransferenciaFondo] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_NovedadTransferenciaFondo]) NOT NULL,
	[CodigoUsuario] nvarchar(20) NOT NULL,
	[Fecha] DATETIME NOT NULL,
	[CBUOrigen] NVARCHAR(22) NOT NULL,
	[IdMoneda] TINYINT NOT NULL,
	[BancoReceptor] NVARCHAR(50) NOT NULL,
	[CBUDestino] NVARCHAR(22) NOT NULL,
	[Importe] Decimal(18,2) NOT NULL,
	[Comprobante] Image NULL,
	[Comentarios] NVARCHAR(100) NULL,
	[IdEstado] INT NOT NULL, 
    CONSTRAINT [PK_NovedadTransferenciaFondo] PRIMARY KEY CLUSTERED ([IdNovedadTransferenciaFondo] ASC),
	CONSTRAINT [FK_NovedadesDeTransferencias_Moneda] FOREIGN KEY([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda]),
    CONSTRAINT [FK_NovedadesDeTransferencias_Estado] FOREIGN KEY([IdEstado]) REFERENCES [shared_owner].[EstadosMovimientos] ([IdEstado])
)
