
CREATE PROCEDURE [orden_owner].[LV_ConsultaMotivoBaja] 
(
	@TipoEvento nvarchar(20) = NULL
)
AS 
BEGIN	
	SET NOCOUNT ON 
	SELECT 
		Valor = IdMotivoBaja, 
		Descripcion,
		Nombre = 'MotivoBaja'
	FROM 
		shared_owner.MotivosBaja
	WHERE (@TipoEvento IS NULL OR EventoTipo = @TipoEvento)
	ORDER BY 
		Descripcion
END