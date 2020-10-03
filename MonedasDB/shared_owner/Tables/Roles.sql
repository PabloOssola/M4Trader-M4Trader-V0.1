CREATE TABLE [shared_owner].[Roles] (
    [IdRol]                SMALLINT      CONSTRAINT [DF__Roles__IdRol] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Roles]) NOT NULL,
    [Descripcion]          VARCHAR (100) NOT NULL,
    [ValorNumerico]        SMALLINT      NOT NULL,
    [BajaLogica]           BIT           CONSTRAINT [DF__Roles__BajaLogica] DEFAULT ((0)) NOT NULL,
    [UltimaActualizacion]  ROWVERSION    NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([IdRol] ASC) WITH (FILLFACTOR = 90)
);

