﻿CREATE PROCEDURE orden_owner.CMD_SCRN_VAL_ROL_BAJA_EXISTEACCIONCONROL
@IdRol smallint
AS
BEGIN
	SELECT COUNT(1) 
	FROM shared_owner.AccionRol 
	WHERE IdRol = @IdRol

END