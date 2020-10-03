CREATE PROCEDURE [orden_owner].[QRY_SCRN_USUARIOS_FILTERS_BUNDLE]
@IdParty INT,
@PageNumber        INT=0, 
@PageSize          INT=999, 
@Busqueda varchar(200) = null
AS
BEGIN
        SET NOCOUNT ON;
        SELECT * from(SELECT u.IdUsuario,
		u.Username AS UserName,
            u.Nombre, 
            u.Bloqueado,
			ul.LimiteOferta AS LimiteOferta,
			ul.LimiteOperacion AS LimiteOperacion,
			0 AS ConsumidoOfera,
			0 AS ConsumidoOperacion,
			u.IdPersona,
			COUNT(1) OVER() AS totalRows       
        FROM shared_owner.Usuarios u
		INNER JOIN shared_owner.UsuariosAdministradorParties uap ON uap.IdParty = u.IdPersona
		INNER JOIN shared_owner.UsuariosLimites ul ON ul.IdUsuario = u.IdUsuario
		INNER JOIN STRING_SPLIT(ISNULL(@Busqueda,''), '#') bus ON u.Username Like '%' + isnull(bus.value,u.Username)+'%'
        WHERE uap.IdAdministrador = @IdParty AND u.BajaLogica = 0) t
		ORDER BY Nombre
		OFFSET isnull(@PageSize,999) * isnull(@PageNumber,0) ROWS
		FETCH NEXT isnull(@PageSize,999) ROWS ONLY

END