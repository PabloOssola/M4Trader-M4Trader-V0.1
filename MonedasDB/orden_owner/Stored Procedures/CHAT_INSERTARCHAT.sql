CREATE PROCEDURE [orden_owner].[CHAT_INSERTARCHAT] 
 @Nombre VARCHAR(100),                
 @IdChat INT OUTPUT,
 @EsGrupo BIT
AS                 
BEGIN                 
 SET NOCOUNT ON                 

DECLARE @resultado TABLE (IdChat int)            
                 
 INSERT INTO orden_owner.Chats (                 
  Nombre                
  , EsGrupo
  , Fecha
 )             
 OUTPUT Inserted.IdChat INTO @resultado            
 VALUES (                 
  @Nombre                
  , @EsGrupo
  , GETDATE()
 )                 
             
 SELECT @IdChat = r.IdChat from @resultado r
                
END
GO