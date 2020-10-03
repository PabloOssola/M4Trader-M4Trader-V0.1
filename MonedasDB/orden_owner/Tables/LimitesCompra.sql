CREATE TABLE [orden_owner].[LimitesPorPersona](
	[IdLimite]			INT CONSTRAINT [DF_LimitesCompra_IdLimite] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_LimitesCompra]) NOT NULL,
	[IdPersona]	        INT,
    [Tope]				int,
	[TipoOperacion]		char,
	[IdTiempoLimite]	INT,
	CONSTRAINT [PK_LimitesCompra] PRIMARY KEY CLUSTERED([IdLimite] ASC),
    CONSTRAINT [FK_Persona_IdPersona] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[parties] ([IdParty]),
	)
GO
