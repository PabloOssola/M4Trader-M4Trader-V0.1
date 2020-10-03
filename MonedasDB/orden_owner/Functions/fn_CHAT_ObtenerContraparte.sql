
CREATE FUNCTION [orden_owner].[fn_CHAT_ObtenerContraparte] 
(
	@IdUsuario INT,
	@IdChat INT

)
RETURNS  VARCHAR (50) 
AS
BEGIN

DECLARE @result VARCHAR (50) 

		SELECT @result = Username FROM orden_owner.ChatUsuarios cu 
		inner join orden_owner.Chats c on c.IdChat = cu.IdChat
		inner join shared_owner.Usuarios u on u.IdUsuario = cu.IdUsuario
		WHERE c.IdChat = @IdChat AND u.IdUsuario != @IdUsuario
		AND c.EsGrupo = 0


	RETURN @result
END