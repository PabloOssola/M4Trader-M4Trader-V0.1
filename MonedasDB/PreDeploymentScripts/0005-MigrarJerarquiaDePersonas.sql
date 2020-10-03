IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[shared_owner].[SQ_PartiesHierarchy]') AND type = 'SO')
begin
	CREATE SEQUENCE [shared_owner].SQ_PartiesHierarchy
		AS INT
		START WITH 1
		INCREMENT BY 1;
		end
if not exists (select * from sys.tables t join sys.schemas s on (t.schema_id = s.schema_id) where s.name = 'shared_owner' and t.name = 'PartiesHierarchy')
	begin
		

		CREATE TABLE [shared_owner].[PartiesHierarchy] (
			[IdPartiesHierarchy]		INT				CONSTRAINT [DF_PartiesHierarchy_IdPartiesHierarchy] DEFAULT (NEXT VALUE FOR [shared_owner].[SQ_PartiesHierarchy]) NOT NULL,
			[IdPartyFather]				INT				CONSTRAINT [DF_PartiesHierarchy_IdPartyFather] NOT NULL,
			[IdPartySon]				INT				CONSTRAINT [DF_PartiesHierarchy_IdPartySon] NOT NULL,
			CONSTRAINT [PK__PersonasHierarchy] PRIMARY KEY CLUSTERED ([IdPartiesHierarchy] ASC)
		);

		insert into [shared_owner].[PartiesHierarchy](IdPartySon, IdPartyFather)
		select IdParty, IdEmpresa from shared_owner.Parties
		where IdEmpresa is not null

		print 'Inserts correctos.';
	end
else 
	begin
		print 'Ya existe la tabla [PartiesHierarchy]';
	end