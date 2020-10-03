CREATE TABLE [shared_owner].[UsuariosAdministradorParties] (
    [IdAdministradorParty]	INT		CONSTRAINT [DF_UsuariosAdministradorParties_IdAdministradorParty] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_UsuariosAdministradorParties]) NOT NULL,
	[IdAdministrador]		INT		NOT NULL,
	[IdParty]				INT		NOT NULL,
    CONSTRAINT [PK_UsuariosAdministradorParties] PRIMARY KEY CLUSTERED ([IdAdministradorParty] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_UsuariosAdministradorParties_PartiesAdm] FOREIGN KEY ([IdAdministrador]) REFERENCES [shared_owner].[Parties] ([IdParty]),
	CONSTRAINT [FK_UsuariosAdministradorParties_Parties] FOREIGN KEY ([IdParty]) REFERENCES [shared_owner].[Parties] ([IdParty])
);