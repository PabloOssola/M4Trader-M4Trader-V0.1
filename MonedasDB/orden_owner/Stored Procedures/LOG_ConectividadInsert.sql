CREATE PROCEDURE orden_owner.LOG_ConectividadInsert
@IdPersona int,
@Fecha datetime,
@Mensaje VARCHAR(MAX)
AS
BEGIN

	INSERT INTO [orden_owner].[LogConectividad]
           ([IdPersona]
           ,[Fecha]
           ,[Mensaje])
     VALUES
           (@IdPersona,
		   @Fecha,
		   @Mensaje)
END