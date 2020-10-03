CREATE PROCEDURE shared_owner.SESSION_INSERT
@IdSesion			UNIQUEIDENTIFIER,
@IdUsuario			INT,
@Ip					VARCHAR(28),
@FechaInicio		DATETIME,
@FechaFinalizacion	DATETIME,
@BajaLogica			BIT,
@IdAplicacion		TINYINT,
@IdPersona          INT,
@Dispositivo			VARCHAR(100) = NULL,
@Global			VARCHAR(20) = NULL,
@ClientPublic		VARCHAR(100) = NULL,
@ClientSecret		VARCHAR(100) = NULL,
@ServerPublic		VARCHAR(100) = NULL,
@ServerSecret		VARCHAR(100) = NULL,
@Nonce				VARCHAR(100) = NULL,
@JsAllowedCommands  VARCHAR(5000) = NULL,
@PermisosUsuario  VARCHAR(5000) = NULL,
@ConfiguracionRegional VARCHAR(8) = NULL
AS
  BEGIN
      IF ( NOT EXISTS(SELECT 1
                      FROM   shared_owner.Sesiones
                      WHERE  IdSesion = @IdSesion) )
        INSERT INTO shared_owner.Sesiones
                    (IdSesion,
                     IdUsuario,
                     Ip,
                     FechaInicio,
                     FechaFinalizacion,
                     BajaLogica,
                     IdAplicacion,
                     IdPersona,
					 Dispositivo,
					 Global,
					 ClientPublic,
					 ClientSecret,
					 ServerPublic,
					 ServerSecret,
					 Nonce,
					 jsAllowedCommands,
					 jsPermisosUsuario,
					 ConfiguracionRegional)
        VALUES      (@IdSesion,
                     @IdUsuario,
                     @Ip,
                     @FechaInicio,
                     @FechaFinalizacion,
                     @BajaLogica,
                     @IdAplicacion,
                     @IdPersona,
					 @Dispositivo,
					 @Global,
					 @ClientPublic,
					 @ClientSecret,
					 @ServerPublic,
					 @ServerSecret,
					 @Nonce,
					 @JsAllowedCommands,
					 @PermisosUsuario,
					 @ConfiguracionRegional)
      ELSE
	  /*
	  
@Dispositivo			VARCHAR(100) = NULL,
@Global			VARCHAR(20) = NULL,
@ClientPublic		VARCHAR(100) = NULL,
@ClientSecret		VARCHAR(100) = NULL,
@ServerPublic		VARCHAR(100) = NULL,
@ServerSecret		VARCHAR(100) = NULL,
@Nonce				VARCHAR(100) = NULL,
@JsAllowedCommands  VARCHAR(5000) = NULL
	  */
        UPDATE shared_owner.Sesiones
        SET    IdUsuario = @IdUsuario,
               Ip = @Ip,
               FechaInicio = @FechaInicio,
               FechaFinalizacion = @FechaFinalizacion,
               BajaLogica = @BajaLogica,
               IdAplicacion = @IdAplicacion,
               IdPersona = @IdPersona,
			   Dispositivo = ISNULL(@Dispositivo, Dispositivo),
			   Global = ISNULL(@Global,Global),
			   ClientPublic = ISNULL(@ClientPublic,ClientPublic),
			   ClientSecret = ISNULL(@ClientSecret,ClientSecret),
			   ServerPublic = ISNULL(@ServerPublic,ServerPublic),
			   ServerSecret = ISNULL(@ServerSecret,ServerSecret),
			   jsAllowedCommands = ISNULL(@JsAllowedCommands,jsAllowedCommands),
			   ConfiguracionRegional = ISNULL(@ConfiguracionRegional,ConfiguracionRegional)
        WHERE  IdSesion = @IdSesion
  END  
GO
