﻿CREATE PROCEDURE orden_owner.CMD_SCRN_VAL_PERSONA_BAJA_EXISTENPADRES
@IdPersona tinyint
AS 
BEGIN 
      	SELECT COUNT(1) 
		FROM shared_owner.Parties p
		INNER JOIN shared_owner.PartiesHierarchy ph on p.IdParty = ph.IdPartySon
		WHERE p.IdParty = @IdPersona
END