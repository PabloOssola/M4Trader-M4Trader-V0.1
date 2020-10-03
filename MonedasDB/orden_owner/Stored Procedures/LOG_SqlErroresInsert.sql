CREATE PROCEDURE orden_owner.LOG_SqlErroresInsert
@Fecha datetime,
@TipoSentenciaSQL varchar(30),
@StackTrace varchar(max),
@ParametrosSP varchar(max),
@NombreSP varchar(255),
@MensajeError varchar(max),
@CallStack varchar(max),
@IdUsuario int,
@RequestId uniqueidentifier
AS
BEGIN

INSERT INTO orden_owner.LogSqlErrores
           (Fecha
           ,TipoSentenciaSQL
           ,StackTrace
           ,ParametrosSP
           ,NombreSP
           ,MensajeError
           ,CallStack
           ,IdUsuario
           ,RequestId)
     VALUES
           (@Fecha,
           @TipoSentenciaSQL,
           @StackTrace, 
           @ParametrosSP, 
           @NombreSP, 
           @MensajeError, 
           @CallStack, 
           @IdUsuario, 
           @RequestId)

END
GO

