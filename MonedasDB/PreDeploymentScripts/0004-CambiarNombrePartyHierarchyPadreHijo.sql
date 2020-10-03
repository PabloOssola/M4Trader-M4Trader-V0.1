IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'shared_owner' AND TABLE_NAME='PartiesHierarchy' AND COLUMN_NAME = 'IdPartySon'))
BEGIN
  EXEC sp_RENAME '[shared_owner].[PartiesHierarchy].[IdPartyHijo]', 'IdPartySon', 'COLUMN'
END

IF (1 > (SELECT COUNT(1) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = 'shared_owner' AND TABLE_NAME='PartiesHierarchy' AND COLUMN_NAME = 'IdPartyFather'))
BEGIN
  EXEC sp_RENAME '[shared_owner].[PartiesHierarchy].[IdPartyPadre]', 'IdPartyFather', 'COLUMN'
END