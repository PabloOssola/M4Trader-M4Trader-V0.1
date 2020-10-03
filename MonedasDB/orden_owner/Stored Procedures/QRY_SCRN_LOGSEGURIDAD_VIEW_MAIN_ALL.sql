CREATE PROCEDURE orden_owner.QRY_SCRN_LOGSEGURIDAD_VIEW_MAIN_ALL      
@IdLogSeguridad BIGINT = null   
AS  
BEGIN    
   
 SELECT  
		l.IdLogSeguridad  as idlogseguridad,
		l.IdUsuario AS IdUsuario, 
		C.Descripcion AS Codigo, 
		l.Fecha AS Fecha, 
		l.Descripcion As Descripcion,
		U.Nombre AS Usuario
	FROM orden_owner.LogSeguridad l
	JOIN shared_owner.Usuarios U ON U.IdUsuario = L.IdUsuario
	JOIN shared_owner.LogCodigoAccion C ON C.IdLogCodigoAccion = L.IdLogCodigoAccion
    WHERE (NOT @IdLogSeguridad IS NULL AND l.IdLogSeguridad = @IdLogSeguridad)   
END
