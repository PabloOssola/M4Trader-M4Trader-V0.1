CREATE PROCEDURE orden_owner.QRY_SCRN_EXPORTAR_USUARIOS_A_EXCEL
@Ids varchar(8000)=null,
@UserName varchar(20)=null,
@Nombre varchar(50)=null
 
AS
BEGIN 
    SET NOCOUNT ON;

	/* Variable Declaration */
    Declare @SQLQuery AS NVarchar(4000)
    Declare @ParamDefinition AS NVarchar(2000) 
    /* Build the Transact-SQL String with the input parameters */ 
    Set @SQLQuery = 'Select 
		u.Username as UserName,
		u.Nombre as Nombre,
		u.Bloqueado as Bloqueado,
		u.Expiracion Expiracion,
		u.Proceso as Proceso,
		u.NoControlarInactividad as NoControlarInactividad,
		u.UltimaModificacionPassword as UltimaModificacionPassword,
		u.UltimoLoginExitoso AS UltimoLoginExitoso,
		p.Name as NombrePersona,
		u.FechaReactivacion AS FechaReactivacion,
		u.FechaBaja AS FechaBaja,
		( SELECT r.Descripcion + '','' 
           FROM shared_owner.Roles r
		   INNER JOIN shared_owner.RolUsuario ru ON (ru.IdRol = r.IdRol)  
           WHERE ru.IdUsuario = u.IdUsuario
           FOR XML PATH('''') ) AS Roles
			FROM shared_owner.Usuarios u
			INNER JOIN shared_owner.Parties p ON (p.IdParty = u.IdPersona) WHERE (1 = 1) ' 
				
    If @Nombre Is Not Null 
		begin
		SET @Nombre = '%' + @Nombre + '%';
         Set @SQLQuery = @SQLQuery + ' AND (u.Nombre like @Nombre)';
		 end;

		     If @UserName Is Not Null 
		begin
		SET @UserName = '%' + @UserName + '%';
         Set @SQLQuery = @SQLQuery + ' AND ( u.Username like @UserName)';
		 end;
		     
    If @Ids Is Not Null
         Set @SQLQuery = @SQLQuery + ' AND (u.IdUsuario in (' +@Ids + ')) '

	Set @SQLQuery = @SQLQuery + ' ORDER BY IdUsuario'

	print @SQLQuery
	Set @ParamDefinition =      ' @Ids varchar(500)=null,
	@UserName varchar(20)=null,
    @Nombre varchar(50)=null'

    Execute sp_executesql     @SQLQuery, @ParamDefinition, @Ids, @UserName, @Nombre
	
END
