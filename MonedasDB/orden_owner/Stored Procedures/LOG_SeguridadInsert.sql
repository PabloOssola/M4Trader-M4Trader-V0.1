CREATE PROCEDURE orden_owner.LOG_SeguridadInsert
@idusuario int,
@IdLogCodigoAccion int,
@fecha datetime,
@descripcion text,
@RequestId	uniqueidentifier,
@IdAplicacion tinyint
AS
BEGIN

	INSERT INTO [orden_owner].[LogSeguridad]
           ([IdUsuario]
           ,[IdLogCodigoAccion]
           ,[Fecha]
           ,[Descripcion]
		   ,[IdAplicacion]
           ,[RequestId])
     VALUES
           (@idusuario,
			@IdLogCodigoAccion,
			@fecha,
			@descripcion,
			@IdAplicacion,
			@RequestId)
END