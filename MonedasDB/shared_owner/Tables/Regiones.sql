CREATE TABLE [shared_owner].[Regiones] (
    [IdRegion]					TINYINT		  CONSTRAINT [DF__Regiones__IdRegion] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Regiones]) NOT NULL,
    [Descripcion]				VARCHAR (50)  NULL,
    CONSTRAINT [PK_Regiones] PRIMARY KEY CLUSTERED ([IdRegion] ASC)
);



