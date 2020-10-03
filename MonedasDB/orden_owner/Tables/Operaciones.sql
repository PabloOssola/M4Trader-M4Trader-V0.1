CREATE TABLE [orden_owner].[Operaciones]
(
	[IdOperacion] INT CONSTRAINT [DF_Operaciones_IdOperacion] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_Operaciones]),
    [IdPersonaComprador] INT NOT NULL, 
    [IdPersonaVendedor] INT NOT NULL, 
    [Cantidad] DECIMAL(18, 2) NOT NULL, 
    [Monto] DECIMAL(18, 2) NOT NULL, 
    [Precio] DECIMAL(18, 4) NOT NULL DEFAULT 0, 
    [NroOperacion] NVARCHAR(25) NOT NULL,
    [FechaOperacion] DATETIME NOT NULL, 
    [UltimaModificacion] TIMESTAMP NOT NULL, 
    [IdMonedaCompra] TINYINT NOT NULL, 
    [IdMonedaVenta] TINYINT NOT NULL, 
    CONSTRAINT [PK_Operaciones] PRIMARY KEY CLUSTERED ([IdOperacion] ASC),
    CONSTRAINT [FK_Operaciones_PersonaComprador] FOREIGN KEY ([IdPersonaComprador]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_Operaciones_PersonaVendedor] FOREIGN KEY ([IdPersonaVendedor]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_Operaciones_MonedasCompra] FOREIGN KEY([IdMonedaCompra]) REFERENCES [shared_owner].[Monedas] ([IdMoneda]),
    CONSTRAINT [FK_Operaciones_MonedasVenta] FOREIGN KEY([IdMonedaVenta]) REFERENCES [shared_owner].[Monedas] ([IdMoneda]),
)
