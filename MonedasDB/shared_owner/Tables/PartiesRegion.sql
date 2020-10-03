CREATE TABLE [shared_owner].[PartiesRegion] (
    [IdPartiesRegion]		INT				CONSTRAINT [DF_PartiesRegion_IdPartiesRegion] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_PartiesRegion]) NOT NULL,
    [IdRegion]				TINYINT				NOT NULL,
    [IdPersona]				INT				NOT NULL,
    CONSTRAINT [PK__PartiesRegion] PRIMARY KEY CLUSTERED ([IdPartiesRegion] ASC),
    CONSTRAINT [FK_PartiesRegion_IdRegion] FOREIGN KEY ([IdRegion]) REFERENCES [shared_owner].[Regiones] ([IdRegion]) NOT FOR REPLICATION,
	CONSTRAINT [FK_PartiesRegion_IdPersona] FOREIGN KEY ([IdPersona]) REFERENCES [shared_owner].[Parties] ([IdParty]) NOT FOR REPLICATION
);