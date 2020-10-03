CREATE TABLE [orden_owner].[ConfirmacionManual]
(
	[IdConfirmacionManual] INT  CONSTRAINT [DF_ConfirmacionManual_IdConfirmacionManual] DEFAULT (NEXT VALUE FOR [orden_owner].[SQ_ConfirmacionManual]) NOT NULL, 
    [IdSourceApplication] TINYINT NOT NULL, 
    [IdParty] INT NOT NULL, 
    [IdMoneda] TINYINT NOT NULL, 
    CONSTRAINT [PK_ConfirmacionManual] PRIMARY KEY CLUSTERED ([IdConfirmacionManual] ASC) WITH (FILLFACTOR = 90),
	--CONSTRAINT [FK_ConfirmacionManual_IdSourceApplication] FOREIGN KEY ([IdSourceApplication]) REFERENCES [orden_owner].[SourcesApplication] ([IdSourceApplication]),
	CONSTRAINT [FK_ConfirmacionManual_IdParty] FOREIGN KEY (IdParty) REFERENCES [shared_owner].[Parties] (IdParty),
	CONSTRAINT [FK_ConfirmacionManual_IdMoneda] FOREIGN KEY ([IdMoneda]) REFERENCES [shared_owner].[Monedas] ([IdMoneda])	
)
