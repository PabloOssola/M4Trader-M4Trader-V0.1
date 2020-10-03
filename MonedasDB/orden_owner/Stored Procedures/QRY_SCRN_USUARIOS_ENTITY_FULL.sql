CREATE PROCEDURE orden_owner.QRY_SCRN_USUARIOS_ENTITY_FULL
@IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    
SELECT  u.IdUsuario as IdUsuario,                   
		u.Username as UserName,    
		u.Pass as Pass,    
		u.Nombre as Nombre,    
		u.Expiracion as Expiracion,    
		u.FechaBaja as FechaBaja,    
		u.CantidadIntentos as CantidadIntentos,    
		u.Bloqueado as Bloqueado,    
		u.Proceso as Proceso,    
		u.NoControlarInactividad AS NoControlarInactividad,    
		u.UltimaModificacionPassword as UltimaModificacionPassword,    
		u.UltimoLoginExitoso as UltimoLoginExitoso,    
		u.UltimaActualizacion as UltimaActualizacion,  
		u.IdPersona as IdPersona,  
		p.PartyType as TipoPersona,
		tp.Descripcion as NombreTipoPersona,
		p.MarketCustomerNumber as NumeroClienteParticipante,
		p.Name as NombrePersona
    FROM        
		  shared_owner.Usuarios u
		  INNER JOIN shared_owner.Parties p ON (p.IdParty = u.IdPersona)
		  INNER JOIN shared_owner.TiposPersona tp ON (tp.IdTipoPersona = p.PartyType)
    WHERE   
		  u.IdUsuario = @IdUsuario
END
