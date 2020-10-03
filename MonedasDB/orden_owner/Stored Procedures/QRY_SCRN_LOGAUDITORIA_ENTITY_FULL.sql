CREATE PROCEDURE orden_owner.QRY_SCRN_LOGAUDITORIA_ENTITY_FULL
 @IdLogAuditoria INT
AS
BEGIN 
    SET NOCOUNT ON;
    
SELECT u.Username as UserName, FechaEvento, clase.IdLogAuditoriaClase,
CASE la.TipoEvento when 0 then 'Alta'else 'Modificación' end as TipoEvento, 
NombreEntidad as NombreEntidad
from shared_owner.LogAuditoria la
inner join shared_owner.LogAuditoriaClases clase on la.IdClase = clase.IdLogAuditoriaClase
inner join shared_owner.Usuarios u on u.IdUsuario = la.IdUsuario
    WHERE   
		  la.IdLogAuditoria = @IdLogAuditoria
END
GO