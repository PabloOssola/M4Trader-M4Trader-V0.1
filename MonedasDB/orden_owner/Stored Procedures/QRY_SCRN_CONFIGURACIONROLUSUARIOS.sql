CREATE PROCEDURE orden_owner.QRY_SCRN_CONFIGURACIONROLUSUARIOS
@IdUsuario	int = NULL,
@PageNumber int=0, 
@PageSize	int=20
AS
BEGIN
	;WITH pg AS
		(
		SELECT	
		   r.IdRol as Id,
		   r.Descripcion as Descripcion,
		   (SELECT DISTINCT CAST(COUNT(1) AS bit) FROM shared_owner.RolUsuario WHERE IdUsuario = @IdUsuario AND IdRol = r.IdRol) AS Habilitado,    
		   r.ValorNumerico as ValorNumerico,
		    r.UltimaActualizacion AS UltimaActualizacion,
		    COUNT(1) OVER() AS TotalRows 
		FROM shared_owner.Roles r
		ORDER BY r.IdRol OFFSET 0  ROWS --FETCH NEXT @PageSize ROWS ONLY
	)
	select * from pg
END
