CREATE PROCEDURE orden_owner.CMD_SCRN_VAL_PERSONA_BAJA_EXISTENHIJOS
@IdPersona tinyint
AS 
BEGIN 
      	SELECT COUNT(1) 
		FROM shared_owner.Parties p
		INNER JOIN shared_owner.PartiesHierarchy ph on p.IdParty = ph.IdPartyFather
		WHERE p.IdParty = @IdPersona
END