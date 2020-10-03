CREATE PROCEDURE orden_owner.QRY_SCRN_USUARIOSWEB_GRID_MAIN_ALL
@IdUsuario int,
@Username varchar(20)=null,
@Name varchar(50)=null,
@PageNumber int=NULL, 
@PageSize int=0
AS
BEGIN 
    SET NOCOUNT ON;

	;WITH pg AS
		(
		SELECT  
			u.IdUsuario,
			u.Username,
			u.Nombre,
			p.MarketCustomerNumber AS CustomerNumber,
			p.Name,
			u.UltimoLoginExitoso,
			u.Bloqueado,
			u.Email,
			COUNT(1) OVER() AS TotalRows
		FROM shared_owner.Usuarios u
			INNER JOIN shared_owner.Parties p ON (p.IdParty = u.IdPersona)
			INNER JOIN shared_owner.PartiesHierarchy pH ON (ph.IdPartySon = p.IdParty)
			INNER JOIN shared_owner.Parties father ON (father.IdParty = ph.IdPartyFather)
			INNER JOIN shared_owner.Usuarios u2 on u2.IdPersona = father.IdParty
		WHERE u.IdUsuario not in (1, 2)
			AND u2.IdUsuario = @IdUsuario
			AND u.BajaLogica = 0 
			AND u.IdUsuario != @IdUsuario
			AND (@Name is null OR u.Nombre like '%' + UPPER(@Name) + '%')  
			AND (@Username is null OR u.Username like '%' + UPPER(@Username) + '%') 
		ORDER BY IdUsuario
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	  )
   
    SELECT * from pg
	
END
