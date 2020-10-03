CREATE TABLE [orden_owner].[MovimientosSaldo]
(
	[IdMovimiento] INT NOT NULL CONSTRAINT [DF_MovimientosSaldos_IdMovimiento] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_MovimientosSaldo]),
	[IdTipoMovimiento] INT NOT NULL, 
    [IdMoneda] TINYINT NOT NULL, 
    [IdPersona] INT NOT NULL, 
    [Importe] DECIMAL(18, 4) NOT NULL,
    [IdPropietario] INT NULL, 
    [ImpactoEnSaldo] BIT NOT NULL, 
    [IdEstado] INT NULL, 
    CONSTRAINT [PK_MovimientosSaldo] PRIMARY KEY CLUSTERED ([IdMovimiento] ASC),
    CONSTRAINT [FK_MovimientosSaldo_TipoMovimiento] FOREIGN KEY ([IdTipoMovimiento]) REFERENCES [shared_owner].[TiposMovimiento] ([IdTipoMovimiento]),
    CONSTRAINT [FK_MovimientosSaldo_Persona] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_MovimientosSaldo_Monedas] FOREIGN KEY([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda]),
    CONSTRAINT [FK_MovimientosSaldo_Estado] FOREIGN KEY([IdEstado]) REFERENCES [shared_owner].[EstadosMovimientos] ([IdEstado])
)
