CREATE TABLE [shared_owner].[RolUsuario] (
    [IdRolUsuario]         INT        CONSTRAINT [DF__RolUsuario__IdRolUsuario] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_RolUsuario]) NOT NULL,
    [IdUsuario]            INT        NOT NULL,
    [IdRol]                SMALLINT   NOT NULL,
    [UltimaActualizacion] ROWVERSION NULL,
    CONSTRAINT [PK_RolUsuario] PRIMARY KEY CLUSTERED ([IdRolUsuario] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_RolUsuario_IdRol] FOREIGN KEY ([IdRol]) REFERENCES [shared_owner].[Roles] ([IdRol]) NOT FOR REPLICATION,
    CONSTRAINT [FK_RolUsuario_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]) NOT FOR REPLICATION
);

