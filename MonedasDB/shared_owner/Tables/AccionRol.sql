CREATE TABLE [shared_owner].[AccionRol] (
    [IdAccionRol]         SMALLINT   CONSTRAINT [DF_AccionRol_IdAccionRol] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_AccionRol])  NOT NULL,
    [IdRol]               SMALLINT   NOT NULL,
    [IdAccion]            SMALLINT   NOT NULL,
    [Permiso]             INT        CONSTRAINT [DF__AccionRol__Permiso] DEFAULT ((0)) NOT NULL,
    [UltimaActualizacion] ROWVERSION NULL,
    CONSTRAINT [PK_AccionRol] PRIMARY KEY CLUSTERED ([IdAccionRol] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_AccionRol_IdAccion] FOREIGN KEY ([IdAccion]) REFERENCES [shared_owner].[Acciones] ([IdAccion]),
    CONSTRAINT [FK_AccionRol_IdRol] FOREIGN KEY ([IdRol]) REFERENCES [shared_owner].[Roles] ([IdRol])
);

