CREATE TABLE [shared_owner].[EstadoSistema] (
    [IdEstadoSistema]     INT        CONSTRAINT [DF__EstadoSistema__IdEstadoSistema] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_EstadoSistema]) NOT NULL,
    [FechaApertura]       DATETIME   CONSTRAINT [DF__EstadoSistema__FechaApertura] DEFAULT (getdate()) NOT NULL,
    [FechaCierre]         DATETIME   NULL,
    [FechaSistema]        DATETIME   NOT NULL,
    [IdUsuarioApertura]   INT        NOT NULL,
    [IdUsuarioCierre]     INT        NULL,
    [BajaLogica]          BIT        CONSTRAINT [DF__EstadoSistema__baja_logica] DEFAULT ((0)) NOT NULL,
    [UltimaActualizacion] ROWVERSION NULL,
    [EstadoAbierto]       BIT        CONSTRAINT [DF__EstadoSistema__EstadoAbierto] DEFAULT ((1)) NULL,
    [EjecucionValidacion] BIT        CONSTRAINT [DF__EstadoSistema__EjecucionValidacion] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_EstadoSistema] PRIMARY KEY CLUSTERED ([IdEstadoSistema] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_EstadoSistema_IdUsuarioApertura] FOREIGN KEY ([IdUsuarioApertura]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]),
    CONSTRAINT [FK_EstadoSistema_IdUsuarioCierre] FOREIGN KEY ([IdUsuarioCierre]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario]),
    CONSTRAINT [FK_EstadoSistema_Usuarios] FOREIGN KEY ([IdUsuarioApertura]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);

