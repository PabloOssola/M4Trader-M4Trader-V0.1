CREATE TABLE [shared_owner].[Acciones] (
    [IdAccion]          SMALLINT      CONSTRAINT [DF_Acciones_IdAccion] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Acciones]) NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [HabilitarPermisos] INT           CONSTRAINT [DF__Acciones__HabilitarPermisos] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Acciones] PRIMARY KEY CLUSTERED ([IdAccion] ASC) WITH (FILLFACTOR = 90)
);

