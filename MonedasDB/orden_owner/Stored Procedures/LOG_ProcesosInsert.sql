CREATE PROCEDURE orden_owner.LOG_ProcesosInsert
@IdUsuario		INT,
@Descripcion	VARCHAR(MAX),
@Fecha			DATETIME,
@Resultado		VARCHAR(MAX),
@IdLogCodigoAccion  TINYINT,
@RequestId		UNIQUEIDENTIFIER = null
AS
BEGIN

	INSERT INTO orden_owner.LogProcesos
           (IdUsuario
		   ,Fecha
		   ,Descripcion
           ,Resultado
           ,RequestId
		   ,IdLogCodigoAccion)
     VALUES
           (@IdUsuario,
		    @Fecha,
			@Descripcion,
			@Resultado,
			@RequestId,
			@IdLogCodigoAccion)

END