CREATE TABLE [orden_owner].[Transacciones]
(
	[IdTransaccion] INT NOT NULL CONSTRAINT [DF_Transacciones_IdTransaccion] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Transacciones]),
	[IdTipoMovimiento] INT NOT NULL, 
    [IdMoneda] TINYINT NOT NULL, 
    [IdPersona] INT NOT NULL, 
    [Importe] DECIMAL(18, 4) NOT NULL,
    [IdOperacion] INT NOT NULL,  
    CONSTRAINT [PK_Transacciones] PRIMARY KEY CLUSTERED ([IdTransaccion] ASC),
    CONSTRAINT [FK_Transacciones_TipoMovimiento] FOREIGN KEY ([IdTipoMovimiento]) REFERENCES [shared_owner].[TiposMovimiento] ([IdTipoMovimiento]),
    CONSTRAINT [FK_Transacciones_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_Transacciones_Monedas] FOREIGN KEY([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])
)
