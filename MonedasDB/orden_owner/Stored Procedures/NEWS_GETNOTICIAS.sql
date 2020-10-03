CREATE PROCEDURE [orden_owner].[NEWS_GETNOTICIAS]

@PageNumber        INT=0, 
@PageSize          INT=999
AS
BEGIN
        SET NOCOUNT ON;
        SELECT * from(SELECT IdNoticia,NewsId,Titulo,Mensaje,m.Codigo as Mercado,Fecha,Remitente,Destinatarios,
			COUNT(1) OVER() AS totalRows
			FROM orden_owner.Noticias n
		inner join shared_owner.Mercados m ON m.IdMercado = n.IdMercado
		WHERE Fecha > GETDATE() - 30) t
		ORDER BY Fecha DESC
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
END

