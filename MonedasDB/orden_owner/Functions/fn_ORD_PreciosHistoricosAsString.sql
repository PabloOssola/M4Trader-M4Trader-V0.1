
CREATE FUNCTION [orden_owner].[fn_ORD_PreciosHistoricosAsString] 
(
	@IdMoneda INT,
	@IdMercado TINYINT

)
RETURNS VARCHAR(MAX)
AS
BEGIN

	DECLARE @result VARCHAR(MAX) = ''

	SELECT TOP(10) @result = @result + CAST(CAST(Precio AS DECIMAL(18,2)) AS VARCHAR(1000)) + ',' FROM orden_owner.PreciosHistoricos 
	WHERE 
	CAST(Fecha AS DATE) BETWEEN DATEADD(DAY, -1, GETDATE()) AND CAST(GETDATE() AS DATE) AND 
	IdMoneda = @IdMoneda AND 
	IdMercado = @IdMercado

	IF LEN(@result) > 0
	SELECT @result = substring(@result, 0, len(@result) - 1)

	RETURN @result

END