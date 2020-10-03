CREATE PROCEDURE [orden_owner].[CHAT_SEARCHCHATLIST]
@IdUsuario INT
AS
BEGIN 
    SET NOCOUNT ON;
    
SELECT cu.IdChat as id, c.Nombre as name, c.EsGrupo, NULL
    FROM        
		  orden_owner.ChatUsuarios cu  
		  LEFT JOIN orden_owner.Chats c on c.IdChat = cu.IdChat
    WHERE   
			cu.IdUsuario = @IdUsuario
			AND c.EsGrupo = 1

UNION

SELECT cu.IdChat as id, tabAux.Nombre as name, c.EsGrupo, tabAux.IdUsuario
    FROM        
		  orden_owner.ChatUsuarios cu  
		  LEFT JOIN orden_owner.Chats c on c.IdChat = cu.IdChat
		  LEFT JOIN (SELECT u1.IdUsuario, cu2.IdChat, u1.Nombre FROM shared_owner.Usuarios u1 
				INNER JOIN orden_owner.ChatUsuarios cu2 on cu2.IdUsuario = u1.IdUsuario) tabAux on tabAux.IdChat = c.IdChat AND tabAux.IdUsuario != cu.IdUsuario
    WHERE   
			cu.IdUsuario = @IdUsuario
			AND c.EsGrupo = 0

UNION
SELECT 0 as id, u.Nombre as name, 0, u.IdUsuario
    FROM        
			shared_owner.Usuarios u

    WHERE   
			NOT EXISTS(select cu2.* from orden_owner.ChatUsuarios cu
					INNER JOIN orden_owner.ChatUsuarios cu2 ON cu2.IdChat = cu.IdChat AND cu2.IdUsuario != cu.IdUsuario
					INNER JOIN orden_owner.Chats c on c.IdChat = cu.IdChat
					WHERE cu.IdUsuario = @IdUsuario AND c.EsGrupo = 0 AND cu2.IdUsuario = u.IdUsuario)
			AND u.Proceso = 0 And u.IdUsuario != @IdUsuario
END