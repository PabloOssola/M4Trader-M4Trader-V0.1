CREATE TABLE [shared_owner].[Parties] (
    [IdParty]                     INT           CONSTRAINT [DF_Parties_IdParty] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_Parties]) NOT NULL,
    [DocumentNumber]              VARCHAR (50)  NULL,
    [Name]                        VARCHAR (100) NOT NULL,
    [MarketCustomerNumber]        VARCHAR (18)  NULL,
    [PartyType]                   TINYINT       NOT NULL,
    [IdLegalPersonality]		  TINYINT       CONSTRAINT [DF__Parties__IdLegalPersonality] DEFAULT ((1)) NOT NULL,
    [TaxIdentificationNumber]     VARCHAR (50)  NULL,
    [Phone]						  VARCHAR(50)	NULL,
	[AgentCode]					  VARCHAR(8)	NULL,
    [BajaLogica]				  BIT			CONSTRAINT [DF__Parties__BajaLogica] DEFAULT ((0)) NOT NULL,
    [CBU] VARCHAR(22) NULL, 
    CONSTRAINT [PK__Parties] PRIMARY KEY CLUSTERED ([IdParty] ASC),
    CONSTRAINT [FK_Parties_PartyType] FOREIGN KEY ([PartyType]) REFERENCES [shared_owner].[TiposPersona] ([IdTipoPersona]),
    CONSTRAINT [FK_Parties_IdLegalPersonality] FOREIGN KEY ([IdLegalPersonality]) REFERENCES [shared_owner].[PersoneriaJuridica] ([IdPersoneriaJuridica]) NOT FOR REPLICATION
);