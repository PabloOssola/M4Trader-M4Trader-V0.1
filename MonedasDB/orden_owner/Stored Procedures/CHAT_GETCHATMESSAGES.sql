CREATE PROCEDURE [orden_owner].[CHAT_GETCHATMESSAGES]
@PageNumber     INT=0, 
@PageSize       INT=999,
@IdChat			INT,
@IdUsuario		INT
AS
BEGIN
        SET NOCOUNT ON;
        SELECT * FROM (SELECT * from(SELECT IdChatMensaje as id,u.IdUsuario as origen, u.Username as name,
		ISNULL(c.Nombre,orden_owner.fn_CHAT_ObtenerContraparte(u.IdUsuario, c.IdChat)) as target,
		c.IdChat as idChat, EsGrupo as isGroup, cm.Fecha as fecha, 1 as type,Mensaje,
			COUNT(1) OVER() AS totalRows
			FROM orden_owner.ChatMensajes cm
			inner join shared_owner.Usuarios u on u.IdUsuario = cm.IdUsuario
			inner join orden_owner.Chats c on cm.IdChat = c.IdChat
		WHERE c.IdChat = @IdChat) t
		ORDER BY Fecha DESC
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY) mensajes
		order by Fecha asc
END