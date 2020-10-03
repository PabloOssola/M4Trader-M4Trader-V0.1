CREATE PROCEDURE [orden_owner].[CHAT_INSERTARMENSAJECHAT] 
 @Mensaje VARCHAR(100),                
 @IdChat INT,        
 @IdChatMensaje INT OUTPUT,
 @IdUsuarioOrigen INT,
 @IdTipoMensaje TINYINT
AS                 
BEGIN                 
 SET NOCOUNT ON                 
       
DECLARE @resultado TABLE (IdChatMensaje int)       
                 
 INSERT INTO orden_owner.ChatMensajes (            
  IdChat                
  , IdUsuario
  , Fecha
  , Mensaje
  , IdChatTipoMensaje
 )     
 OUTPUT Inserted.IdChatMensaje INTO @resultado       
 VALUES (             
  @IdChat                
  , @IdUsuarioOrigen
  , GETDATE()
  , @Mensaje
  ,@IdTipoMensaje
 )                 
                
             
 SELECT @IdChatMensaje = r.IdChatMensaje from @resultado r
END
GO
