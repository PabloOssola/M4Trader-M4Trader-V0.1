namespace M4Trader.ordenes.server.CQRSFramework.Exceptions
{
    public class CodigosMensajes
    {
        public const string FE_ALTA_UNICIDAD_CAMPO = "FE00001";
        public const string FE_ALTA_REQUERIDO_CAMPO = "FE00002";
        public const string FE_ACTUALIZA_UNICIDAD_CAMPO = "FE00003";
        public const string FE_ACTUALIZA_REQUERIDO_CAMPO = "FE00004";
        public const string FE_ACTUALIZA_NO_EXISTE = "FE00005";
        public const string FE_ALTA_UNICIDAD_8CAMPOS = "FE00006";
        public const string FE_ALTA_UNICIDAD_3CAMPOS = "FE00007";
        public const string FE_ACTUALIZA_UNICIDAD_3CAMPOS = "FE00008";
        public const string FE_ACTUALIZA_UNICIDAD_8CAMPOS = "FE00009";
        public const string FE_ALTA_FECHA1_MENOR_IGUAL_FECHA2 = "FE00010";
        public const string FE_APROBAR_NOVEDAD = "FE00011";
        public const string FE_RECHAZAR_NOVEDAD = "FE00012";
        public const string FE_NO_APROBAR_NOVEDAD_POR_EMISOR = "FE00013";
        public const string FE_NO_APROBAR_NOVEDAD_POR_PRODUCTO = "FE00014";
        public const string FE_NO_APROBAR_NOVEDAD_POR_TIPODOCUMNETO = "FE00015";
        public const string FE_NO_APROBAR_NOVEDAD_POR_TIPOPERSONA = "FE00016";
        public const string FE_NO_APROBAR_NOVEDAD_POR_PARTICIPANTE = "FE00017";
        public const string FE_NO_APROBAR_NOVEDAD_POR_TIPOPARTICIPANTE = "FE00018";
        public const string FE_NO_RECHAZAR_NOVEDAD = "FE00019";
        public const string FE_ALTA_UNICIDAD_4CAMPOS = "FE00020";
        public const string FE_ALTA_UNICIDAD_5CAMPOS = "FE00021";
        public const string FE_ACTUALIZA_UNICIDAD_5CAMPOS = "FE00022";
        public const string FE_ALTA_UNICIDAD_2CAMPOS = "FE00023";
        public const string FE_ACTUALIZA_UNICIDAD_2CAMPOS = "FE00024";
        public const string FE_ALTA_UNICIDAD_6CAMPOS = "FE00025";
        public const string FE_ACTUALIZA_UNICIDAD_6CAMPOS = "FE00026";
        public const string FE_ALTA_UNICIDAD_7CAMPOS = "FE00027";
        public const string FE_ACTUALIZA_UNICIDAD_7CAMPOS = "FE00028";
        public const string FE_ALTA_SIAENTONCESB = "FE00029";
        public const string FE_ACTUALIZA_SIAENTONCESB = "FE00030";
        public const string FE_ALTA_REQUERIDO_CAMPO_LARGO = "FE00031";
        public const string FE_CAMPO_INEXISTENTE = "FE00032";
        public const string ERR_CONTRATO_NO_EXISTE = "FE00033";
        public const string ERR_TIPO_NEGOCIACION = "FE00034";
        public const string ERR_CONTRATO_NO_SE_PUEDE_ASIGNAR = "FE00035";
        public const string ERR_ASIGNACION_SEGUNDA_PARTE_NO_REQUERIDA = "FE00036";
        public const string ERR_ENTIDAD_COMPRADORA_VENDEDORA_NO_COINCIDEN = "FE00037";
        public const string ERR_ENTIDAD_DIFIERE_USUARIO_REGISTRADO = "FE00038";
        public const string ERR_CUENTA_NO_VALIDA_O_INEXISTENTE = "FE00039";
        public const string ERR_VALOR_TRANSADO_TOTAL_INCORRECTO = "FE00040";
        public const string ERR_VALOR_FACIAL_INCORRECTO = "FE00041";
        public const string ERR_CONTRATO_SIN_SALDO_PARA_ASIGNAR = "FE00042";
        public const string ERR_CODIGO_ISIN_DIFIERE_ASIGNACION = "FE00043";
        public const string ERR_CUENTA_EFECTIVO_NO_CORRESPONDE_CUENTA_REGISTRADA = "FE00044";
        public const string ERR_CENTRAL_SECURITY_REPOSITORY_NO_EXISTE_O_NO_COINCIDE_CONTRATO = "FE00045";
        public const string ERR_CODIGO_MONEDA_LIQUIDACION_NO_EXISTE = "FE00046";
        public const string ERR_CODIGO_MONEDA_LIQUIDACION_NO_COINCIDE_CONTRATO = "FE00047";
        public const string ERR_VALOR_FACIAL_TOTAL_INCORRECTO = "FE00048";
        public const string ERR_ASIGNACIONNOEXISTE = "FE00049";
        public const string ERR_ELIMINA_ACCION_ROL_INEXISTENTE = "FE00050";
        public const string ERR_ELIMINA_ACCION_ROL_INEXISTENTE2 = "FE00051";
        public const string ERR_ORDEN_ENVIAR_AL_MERCADO = "FE00052";
        public const string ERR_ORDEN_CAMBIO_ESTADO_CLIENTE = "FE00054";
        public const string ERR_CONTRASENAS_DISTINTAS = "FE00056";
        public const string ERR_MAL_FORMATO_MAIL = "FE00057";
        public const string FE_ELIMINA_ENTIDAD_TIENE_HIJOS = "FE00058";
        public const string FE_ELIMINA_ENTIDAD_TIENE_PADRES = "FE00059";
        public const string FE_CAMPOA_MAYORQUE_CAMPOB = "FE00060";

        public const string FE_ELIMINA_ENTIDAD_ORDENES_ACTIVAS = "FE01001";
        public const string FE_CAMBIO_ULTIMA_ACTUALIZACION = "FE01002";
        public const string FE_ALTA_UNICIDAD_CARTERA_PROPIA = "FE01003";
        public const string FE_ACTUALIZA_UNICIDAD_CARTERA_PROPIA = "FE01004";
        public const string FE_ESTADO_ORDEN_NO_VALIDO = "FE01005";
        public const string FE_ALTA_MAX_AMOUNT_REACHED = "FE01006";
        public const string FE_HAY_OPERACIONES_SIN_LIQUIDAR = "FE01007";
        public const string FE_ELIMINA_ENTIDAD_ASIGNACIONES_NEGOCIACIONES_ACTIVAS = "FE01008";
        public const string FE_NROMERCADO_EXISTENTE = "FE01009";
        public const string FE_EXISTELOTE_COMPENSADO = "FE01010";
        public const string FE_ERROR_FALTA_PERMISOS = "FE01011";
        public const string FE_CENTRAL_VALORES_MONEDAS_REPETIDAS = "FE01012";
        public const string FE_ELIMINA_ENTIDAD_TIPOCUENTALIQUIDACION_CUENTAEXISTENTE = "FE01013";
        public const string FE_COMISION_ASIGNADA = "FE01014";
        public const string FE_ELIMINA_ENTIDAD_CUENTA_EMISOR_EXISTENTE = "FE01015";
        public const string FE_ELIMINA_ENTIDAD_ACCION_ASOCIADA_ROL = "FE01016";
        public const string FE_EXISTE_ESTADO_SISTEMA = "FE01017";
        public const string FE_SUPERA_LIMITES_OFERTA = "FE01018";

        public const string FE_EXISTE_ACCIONROL = "E100804";
        public const string FE_NO_EXISTE_MERCADO_INTERNO = "E100556";

        public const string ERR_CANTIDAEXCEDEORDEN = "LBL_CANTIDADSELECCIONADANODEBEEXCEDERORDEN";
    }
}
