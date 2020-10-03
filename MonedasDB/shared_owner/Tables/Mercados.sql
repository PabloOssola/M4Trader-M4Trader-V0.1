CREATE TABLE [shared_owner].[Mercados] (
    [IdMercado]					TINYINT		  CONSTRAINT [DF__Mercados__IdMercado] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Mercados]) NOT NULL,
    [Codigo]					VARCHAR (5)   NULL,
    [Descripcion]				VARCHAR (50)  NULL,
    [EsInterno]					BIT           CONSTRAINT [DF_Mercados_EsInterno] DEFAULT ((0)) NOT NULL,
    [ProductoHabilitadoDefecto] BIT CONSTRAINT [DF_Mercados_ProductoHabilitadoDefecto] DEFAULT ((0)) NOT NULL, 
    CONSTRAINT [PK_Mercados] PRIMARY KEY CLUSTERED ([IdMercado] ASC)
);



