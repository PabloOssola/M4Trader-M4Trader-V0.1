CREATE FUNCTION shared_owner.fn_ARQ_ConvertirFechaAHoraInicial
	( @fechaentrada DATETIME ) 
RETURNS DATETIME
BEGIN
	DECLARE @FechaSalida DATETIME
	SET @FechaSalida = NULL
	IF @fechaentrada IS NOT NULL
	   SET @FechaSalida = CAST(CONVERT(varchar,@fechaentrada,112) as DATETIME)

	RETURN @FechaSalida
END
