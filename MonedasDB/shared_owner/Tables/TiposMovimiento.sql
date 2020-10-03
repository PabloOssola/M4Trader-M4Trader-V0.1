CREATE TABLE [shared_owner].[TiposMovimiento]
(
	[IdTipoMovimiento] INT NOT NULL CONSTRAINT [DF_TipoMovimiento_IdTipoMovimiento] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_TipoMovimiento]),
	[Descripcion] NVARCHAR(50) NOT NULL,
	[Codigo] INT NOT NULL,
	    CONSTRAINT [PK_TiposMovimiento] PRIMARY KEY CLUSTERED ([IdTipoMovimiento] ASC),
)
