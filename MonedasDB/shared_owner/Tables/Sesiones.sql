﻿CREATE TABLE [shared_owner].[Sesiones] (
    [IdSesion]                      UNIQUEIDENTIFIER CONSTRAINT [DF__Sesiones__IdSesion] DEFAULT (newsequentialid()) NOT NULL,
    [IdUsuario]                     INT              NOT NULL,
    [Ip]                            VARCHAR (28)     NULL,
    [FechaInicio]                   DATETIME         NOT NULL,
    [FechaFinalizacion]             DATETIME         NULL,
    [BajaLogica]                    BIT              CONSTRAINT [DF__Sesiones__BajaLogica] DEFAULT ((0)) NOT NULL,
    [UltimaActualizacion]           ROWVERSION       NULL,
    [IdAplicacion]                  TINYINT          NULL,
    [IdPersona]						INT              NULL,
    [Dispositivo]                   VARCHAR(100)   NULL,
	[Global]                        VARCHAR(20)   NULL,
	[ClientSecret] VARCHAR(100) NULL, 
    [ClientPublic] VARCHAR(100) NULL, 
    [ServerSecret] VARCHAR(100) NULL, 
    [ServerPublic] VARCHAR(100) NULL, 
    [Nonce] VARCHAR(100) NULL, 
	[jsAllowedCommands] VARCHAR(5000) NULL, 
	[jsPermisosUsuario] VARCHAR(5000) NULL, 
    [ConfiguracionRegional] VARCHAR(8) NULL, 
    CONSTRAINT [PK_Sesiones] PRIMARY KEY CLUSTERED ([IdSesion] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Sesiones_IdParty] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]),
    CONSTRAINT [FK_Sesiones_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [shared_owner].[Usuarios] ([IdUsuario])
);

