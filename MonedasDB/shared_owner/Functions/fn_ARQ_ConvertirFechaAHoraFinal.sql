CREATE FUNCTION shared_owner.fn_ARQ_ConvertirFechaAHoraFinal 
( @fechaentrada DATETIME ) 
RETURNS DATETIME
BEGIN
	DECLARE @FechaSalida DATETIME
	SET @FechaSalida = NULL

	IF @fechaentrada IS NOT NULL
		SET @fechasalida = CAST(dateadd(ms, -2, dateadd(dd, 1, convert(varchar, @fechaEntrada, 112))) as DATETIME)

	RETURN @FechaSalida
END
