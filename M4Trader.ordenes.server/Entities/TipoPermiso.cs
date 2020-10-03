namespace M4Trader.ordenes.server.Entities
{	
	public enum TipoPermiso
	{
		CONSULTA				= 1,
		SALIDAS					= 2,
		MODIFICACION			= 4,
		BAJA					= 8,
		ALTA					= 16,
		SUPERVISION				= 32,
		IMPORTACION				= 64,
		APROBACION_AUTOMATICA	= 128,
		EJECUCION				= 256
	}
}
