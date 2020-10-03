CREATE TABLE [shared_owner].[PartiesHierarchy] (
    [IdPartiesHierarchy]		INT				CONSTRAINT [DF_PartiesHierarchy_IdPartiesHierarchy] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_PartiesHierarchy]) NOT NULL,
    [IdPartyFather]				INT				NOT NULL,
    [IdPartySon]				INT				NOT NULL,
    CONSTRAINT [PK__PersonasHierarchy] PRIMARY KEY CLUSTERED ([IdPartiesHierarchy] ASC),
    CONSTRAINT [FK_PersonasHierarchy_IdPersonaSon] FOREIGN KEY ([IdPartySon]) REFERENCES [shared_owner].[Parties] ([IdParty]) NOT FOR REPLICATION,
	CONSTRAINT [FK_PersonasHierarchy_IdPersonaFather] FOREIGN KEY ([IdPartyFather]) REFERENCES [shared_owner].[Parties] ([IdParty]) NOT FOR REPLICATION
);