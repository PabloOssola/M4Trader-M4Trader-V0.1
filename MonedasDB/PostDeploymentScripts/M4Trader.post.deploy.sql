IF ( 1 > (SELECT count(*) FROM shared_owner.ConfiguracionSistema ))
begin
INSERT INTO [shared_owner].[ConfiguracionSistema]
           ( [OcultarErroresBaseDeDatos]
           ,[PathSalida]
           ,[TiempoLogSQL]
           ,[PermiteProcesamientoParalelo]
           ,[EnviaNotificaciones]
           ,[PreciosHabilitados]
           ,[EnvioOrdenesHabilitados]
           ,[MainPortWcfServices]
           ,[AbsoluteServicesURL]
           ,[EnviarAgentCode]
           ,[ApiServicePort]
           ,[JwtSecretKey]
           ,[JwtAudienceToken]
           ,[JwtIssuerToken]
           ,[MaxOperationRows]
           ,[MinOperationRows])
     VALUES
           ( 1
           ,'c:\'
           ,3000
           ,0
           ,0
           ,0
           ,0
           ,8080
           ,'http:\\'
           ,0
           , 81
           , '1243567'
           ,'1234567'
           ,'123467'
           ,100
           ,1)
end
GO


exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00001' ,@Mensaje ='Al querer dar de alta un {0} se ingreso un {1} ya existente, valor del campo: {2}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00002' ,@Mensaje ='Al querer dar de alta un {0} no se ingreso el campo {1}, el cual es obligatorio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00003' ,@Mensaje ='Al querer actualizar un {0} se ingreso un {1} ya existente, valor del campo: {2}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00004' ,@Mensaje ='Al querer actualizar un {0} no se ingreso el campo {1}, el cual es obligatorio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00005' ,@Mensaje ='No se encontro la entidad {0} que desea modificar. El identificador tiene el valor {1}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00006' ,@Mensaje ='Al querer dar de alta una {0} se ingreso una combinacion de valores de campos existente:|| {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00007' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00008' ,@Mensaje ='Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00009' ,@Mensaje ='Al querer modificar una {0} se ingreso una combinacion de valores de campos existente:|| {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00010' ,@Mensaje ='Error al querer dar de alta un {0}. El valor de la fecha "{1}" debe ser menor o igual que el valor de la fecha "{2}". Los valores ingresados son {3} <= {4}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00020' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00021' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00022' ,@Mensaje ='Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00023' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00024' ,@Mensaje ='Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00025' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00026' ,@Mensaje ='Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00027' ,@Mensaje ='Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00028' ,@Mensaje ='Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00031' ,@Mensaje ='Al querer dar de alta un {0} se ingreso un {1} de largo diferente a {2}. Valor ingresado: {3}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00032' ,@Mensaje ='En la ejecución de {0} se no se encontró el campo {1} '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00051' ,@Mensaje ='No se puede eliminar el/la {0} ya que NO existe uno/a con el id {1}.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100006' ,@Mensaje ='El nombre de usuario y/o contraseña ingresados son incorrectos. El acceso al sistema ha sido denegado.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100008' ,@Mensaje ='El usuario {0} se encuentra bloqueado. La aplicación se cerrará.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100011' ,@Mensaje ='La cuenta del usuario {0} ha expirado.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100012' ,@Mensaje ='Superó la cantidad máxima de intentos. Se bloqueará la cuenta del usuario.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100802' ,@Mensaje ='Acceso sin permiso.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100014' ,@Mensaje ='No tiene permiso para {0} en la acción {1}.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100015' ,@Mensaje ='La sesión ha expirado.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100020' ,@Mensaje ='La contraseña propuesta y su verificación no coinciden.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100021' ,@Mensaje ='La contraseña propuesta no tiene la cantidad mínima de caracteres numéricos y alfabéticos requeridos {0}.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100022' ,@Mensaje ='La contraseña propuesta debe ser diferente a las últimas {0} utilizadas.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100060' ,@Mensaje ='No se pudo actualizar información del último login exitoso.||||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100061' ,@Mensaje ='Se ha excedido el límite de tiempo de inactividad.  Se bloqueará la cuenta del usuario.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100062' ,@Mensaje ='La contraseña actual ingresada es incorrecta.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100132' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede ser igual al nombre de usuario: {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100133' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener caracteres que no sean alfabéticos o númericos: {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100134' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres alfabéticos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100135' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres númericos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100136' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener más de {0} caracteres consecutivos repetidos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100139' ,@Mensaje ='Error al cambiar clave.|| ||La nueva clave y la actual no puden ser iguales.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100553' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres en minúculas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100554' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres en mayúsculas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100555' ,@Mensaje ='Error al cambiar clave.|| || La clave no puede contener menos de {0} símbolos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100558' ,@Mensaje ='Usuario {0} no valido para la agencia {1}.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'W100002' ,@Mensaje ='Debe cambiar la contraseña.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'I100000' ,@Mensaje ='INFO: OK'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'I100002' ,@Mensaje ='Inicio de sesión correcto.  Usuario: {0}.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'I100004' ,@Mensaje ='Modificación exitosa de contraseña.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'I100010' ,@Mensaje ='Cierre de sesión exitoso.  Usuario: {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01002' ,@Mensaje ='Ya se ha modificado este registro de la entidad {0}, refresque la ventana.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01003' ,@Mensaje ='Ya existe una persona de tipo Cartera Propia, para dar de alta una nueva, previamente debe dar de baja la existente.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01004' ,@Mensaje ='Ya existe una persona de tipo Cartera Propia, para modificar a tipo de persona Cartera Propia, previamente debe dar de baja la existente.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACCESOCONSULTA' ,@Mensaje ='Acceso/Consulta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ATRIBUTOS_DE_REGLA' ,@Mensaje ='Atributos de Regla'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACCION' ,@Mensaje ='Acción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACCION_DEMORANDO_DE_MAS' ,@Mensaje ='La acción esta demorando más de lo previsto. Espere a que termine...'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACEPTAR' ,@Mensaje ='Aceptar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACTUALIZACION_DE' ,@Mensaje ='Actualizacion de {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ACTUALIZAR_DE' ,@Mensaje ='Actualizar {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ALTA' ,@Mensaje ='Alta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ALTA_DE' ,@Mensaje ='Alta de {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APLICACION' ,@Mensaje ='Aplicación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APLICACION_NO_PUEDE_CONECTARSE_SERVIDOR' ,@Mensaje ='La aplicacion no puede conectarse al servidor o el servidor no puede responder a la peticion. Intente mas tarde.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APLICADA' ,@Mensaje ='Aplicada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APROBAR' ,@Mensaje ='Aprobar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ATENCION' ,@Mensaje ='Atención'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ATRIBUTOS_DE_BUSQUEDA' ,@Mensaje ='Atributos de Búsqueda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BAJA' ,@Mensaje ='Baja'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BAJA_DE' ,@Mensaje ='Baja de {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BAJACOMPETENCIA' ,@Mensaje ='Baja de Competencia Accion'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_ACTUALIZA' ,@Mensaje ='Modificar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_ALTA' ,@Mensaje ='Alta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_ANCLAR' ,@Mensaje ='Anclar a pantalla de inicio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_AUDITORIA' ,@Mensaje ='Auditoría'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_BUSCAR' ,@Mensaje ='Buscar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_CERRAR' ,@Mensaje ='Cerrar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_COPIAR_CELDA' ,@Mensaje ='Copiar celda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_COPIAR_FILA' ,@Mensaje ='Copiar fila'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_ELIMINAR' ,@Mensaje ='Eliminar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_EXPORTA_EXCEL' ,@Mensaje ='Exportar a excel'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_LIMPIAR_FILTROS' ,@Mensaje ='Limpiar filtros'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BOTON_VISTA' ,@Mensaje ='Ver'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BUSCAR' ,@Mensaje ='Buscar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BUSCAR_POR' ,@Mensaje ='Buscar por '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BUSCAR_TITULO' ,@Mensaje ='Buscar {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BUSQEUDA_AVANZADA' ,@Mensaje ='Busqueda avanzada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CAMPO_CARGADO_INCORRECTAMENTE' ,@Mensaje ='Este campo no está cargado correctamente.  '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CAMPOS_SIN_FORMATO_ADECUADO' ,@Mensaje ='Algunos campos no tienen el formato o el valor adecuado para la carga. Corrija y vuelva a <kbd>ACEPTAR</kbd>'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANCELADA' ,@Mensaje ='CANCELADA'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANCELAR' ,@Mensaje ='Cancelar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDAD' ,@Mensaje ='Cantidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADESTADOSMAX' ,@Mensaje ='Máximo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADESTADOSMIN' ,@Mensaje ='Mínimo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTMONT' ,@Mensaje ='Cantidad / Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTMONTO' ,@Mensaje ='Cantidad / Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CAPITALESPECIE' ,@Mensaje ='Capital Especie'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CAPITALOPERACION' ,@Mensaje ='Capital Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CARGA_FINALIZADA_EXITOSA' ,@Mensaje ='Carga finalizada con exito'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CARGANDO' ,@Mensaje ='Cargando...'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CARTERA_PROPIA' ,@Mensaje ='Cartera propia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CATEGORIA' ,@Mensaje ='Categoría'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CLASEOPERACIONDESCRIPCION' ,@Mensaje ='Compra Venta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGO' ,@Mensaje ='Codigo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGO_ERROR_ESP' ,@Mensaje ='Codigo de Error: {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGO_ERROR_NRO_ID' ,@Mensaje ='Codigo de Error: {0}, Numero de identificacion de incidente: {1}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGO_GRUPO' ,@Mensaje ='Código Grupo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGOESPECIE' ,@Mensaje ='Código'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGOESPECIEVISIBLE' ,@Mensaje ='Código'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_COMPRAOVENTA' ,@Mensaje ='Compra Venta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_COMPRAVENTA' ,@Mensaje ='CompraVenta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_COMPRAVENTADESCRIPCION' ,@Mensaje ='Clase operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIGURACION_COLUMNA' ,@Mensaje ='Configuración Columna'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIRMA_ELIMINAR_REGISTROS' ,@Mensaje ='¿Esta seguro que quiere eliminar los registros seleccionados?'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIRMA_VINCULACION' ,@Mensaje ='Confirmar Vinculación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIRMAOPERACIONAMERCADO' ,@Mensaje ='Va a enviar al mercado a la orden nùmero {0}. ¿Está seguro?'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIRMAR' ,@Mensaje ='Confirmar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONTRASENIA' ,@Mensaje ='Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_COTIZADA' ,@Mensaje ='Cotizada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CREAR_OPERACION' ,@Mensaje ='Crear Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CUENTA_MONETARIA' ,@Mensaje ='Cuenta Monetaria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CUENTA_TENENCIA' ,@Mensaje ='Cuenta Tenencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DATOS_CONTACTO' ,@Mensaje ='Tambien puede comunicarse por telefono al +54 11 4590 6600 en el horario de 10hs a 18hs de Lunes a Viernes'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DEBE_SELECIONAR_UN_REGISTRO' ,@Mensaje ='Debe seleccionar un registro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DEBESELECCIONAROPERACION' ,@Mensaje ='Debe seleccionar una operación.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DEBESELECCIONARUNAFILA' ,@Mensaje ='Debes seleccionar al menos una fila'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESANCLAR_PANTALLA' ,@Mensaje ='Desanclar pantalla'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESBLOQUEARORDEN' ,@Mensaje ='Desbloquear Orden '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESCRIPCION' ,@Mensaje ='Descripción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DIASHORAS' ,@Mensaje ='Tipo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EJECUTAR' ,@Mensaje ='Ejecutar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERORR_RECUPERAR DATOS' ,@Mensaje ='Error al recuparar datos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERROR_404' ,@Mensaje ='"404 Pagina no encontrada"'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERROR_RECUPERAR_DATOS' ,@Mensaje ='Error al recuperar datos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERROR_SERVIDOR' ,@Mensaje ='Error en Servidor'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERROR_TECNICO' ,@Mensaje ='Error técnico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERROR_VALIDACION' ,@Mensaje ='Error de Validación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERRORRECUPERARCANTIDADMONTO' ,@Mensaje ='Error al recuperar la cantidad o monto estimado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERRORRECUPERARFECHAVENCIMIENTO' ,@Mensaje ='Error al recuperar la fecha de vencimiento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ERRRORRECUPERARCANTIADADFUTURO' ,@Mensaje ='Error al recuperar la cantidad o monto estimado futuro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ESTA_SEGURO' ,@Mensaje ='¿Está seguro?'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ESTADO' ,@Mensaje ='Estado del sistema'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ESTADOGLOBALDESCRIPCION' ,@Mensaje ='Estado Global Descripcion'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EXITOSO' ,@Mensaje ='EXITOSA'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EXPIRADA' ,@Mensaje ='Expirada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EXPORTAR_DATOS_EXCEL' ,@Mensaje ='Exportar datos a Excel'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EXPORTAR_DATOS_PDF' ,@Mensaje ='Exportar datos a PDF'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EXPORTAR_DETALLES_EXCEL' ,@Mensaje ='Exportar detalles a Excel'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHA_HORA' ,@Mensaje ='Fecha/Hora'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHA_ULTIMA_MODIFICACION' ,@Mensaje ='Fecha Última Modificación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAALTA_DESDE' ,@Mensaje ='Fecha Carga Desde'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAALTA_HASTA' ,@Mensaje ='Fecha Carga Hasta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAALTAFECHA' ,@Mensaje ='Fecha Alta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAALTAHORA' ,@Mensaje ='Hora Alta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACARGA' ,@Mensaje ='Fecha Carga'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACION' ,@Mensaje ='Fecha Concertación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACION_DESDE' ,@Mensaje ='Fecha Alta Desde'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACION_HASTA' ,@Mensaje ='Fecha Alta Hasta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACIONFECHA' ,@Mensaje ='Fecha Concertación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACIONHORA' ,@Mensaje ='Hora Concertación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAHORA' ,@Mensaje ='Fecha/Hora'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAULTIMAMODIFICACION' ,@Mensaje ='Fecha Última Modificación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCESPECIE' ,@Mensaje ='Fecha Venc. Especie'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCESPECIEFUTURO' ,@Mensaje ='Fecha Venc. Especie Futuro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCLIQUIDADOR_MONEDA' ,@Mensaje ='Fecha Venc. Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCLIQUIDADOR_PRODUCTO' ,@Mensaje ='Fecha Venc. Prod.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCMONEDA' ,@Mensaje ='Fecha Venc. Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCMONEDAFUTURO' ,@Mensaje ='Fecha Venc. Moneda Futuro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVIGENCIA' ,@Mensaje ='Fecha Vigencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVIGENCIAFECHA' ,@Mensaje ='Fecha Vigencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVIGENCIAHORA' ,@Mensaje ='Hora Vigencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_HORAALTA' ,@Mensaje ='Hora Alta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_HORAVIGENCIA' ,@Mensaje ='Hora Vigencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ID' ,@Mensaje ='ID'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ID_ENTIDAD' ,@Mensaje ='IdEntidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDACCION' ,@Mensaje ='Acción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDAREANEGOCIO' ,@Mensaje ='Area de negocio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDCLASEOPERACIONDESCRIPCION' ,@Mensaje ='Clase de Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDCUENTAESPECIE' ,@Mensaje ='ID'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDCUENTAMONEDA' ,@Mensaje ='ID'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDMONEDA' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDMONEDADESTINO' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDPLATAFORMA' ,@Mensaje ='Plataforma'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDPRODUCTO' ,@Mensaje ='Id'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDROL' ,@Mensaje ='Rol'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDRUEDA' ,@Mensaje ='Rueda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDSUCURSAL' ,@Mensaje ='Sucursal'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDTIPODECONFIRMACION' ,@Mensaje ='Ingreso por'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDTIPOOPERACION' ,@Mensaje ='Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDTIPOOPERATORIA' ,@Mensaje ='Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDUSUARIO' ,@Mensaje ='Usuario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDZONA' ,@Mensaje ='Zona'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IMPORTACION' ,@Mensaje ='Importación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IMPRIMIR_DETALLES' ,@Mensaje ='Impimir detalles'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INC_PRECIO_PARCIAL' ,@Mensaje ='Incompl. Por Precio Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INC_PRECIO_TRANSFERENCIA' ,@Mensaje ='Incompl. Por Precio Transferencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INGRESADA' ,@Mensaje ='Ingresada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INGRESANDO' ,@Mensaje ='Ingresando'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INGRESAR' ,@Mensaje ='Ingresar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INGRESO_AL_SISTEMA' ,@Mensaje ='Ingreso al Sistema'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_INGRESO_PRECIO' ,@Mensaje ='Ingreso Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_Inicio' ,@Mensaje ='Inicio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IP' ,@Mensaje ='IP'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ISDETALLE' ,@Mensaje ='IsDetalle'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_ADMINISTRACION' ,@Mensaje ='Administración'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_AGREGANDO_NUMERADORES' ,@Mensaje ='Agregando Numeradores'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_AUDITORIA' ,@Mensaje ='Auditoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_CONFIGURACION_ATRIBUTOS' ,@Mensaje ='Configuración de atributos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_DESCONECTAR' ,@Mensaje ='Desconectar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_PARAMETROS' ,@Mensaje ='Parametros'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MODAL_TITLE' ,@Mensaje ='Modal title'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MODIFICACION' ,@Mensaje ='Modificación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONEDACODIGO' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONEDADESCRIP' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONEDADESCRIPCION' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONEDAS' ,@Mensaje ='Monedas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTO_CLIENTE' ,@Mensaje ='Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTO_TRANSFERENCIA' ,@Mensaje ='Monto Transferencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTOESTIMADO' ,@Mensaje ='Monto Estimado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTOESTIMADOFUTURO' ,@Mensaje ='Monto Estimado Futuro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTOESTIMADOTRANSFERENCIA' ,@Mensaje ='Monto Estimado Transf.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MOSTRAR_OCULTAR' ,@Mensaje ='Mostrar/Ocultar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MOTIVO' ,@Mensaje ='Motivo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MOTIVOBAJADESCRIP' ,@Mensaje ='Motivo Baja'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MOTIVORECHAZODESCRIPCION' ,@Mensaje ='Motivo Rechazo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NO_HAY_DATOS_PARA_RESTAURAR' ,@Mensaje ='No hay datos para restaurar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NO_HAY_REGISTROS_PARA_EL_FILTRO' ,@Mensaje ='NO HAY REGISTROS CON EL FILTRO SELECCIONADO'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NO_VIGENTE' ,@Mensaje =' No Vigente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOHAYMOVIMIENTOS' ,@Mensaje ='NO HAY MOVIMIENTOS'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOMBREPERSONA' ,@Mensaje ='Nombre'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOSERECONOCETIPOINGRESO' ,@Mensaje ='No se reconoce el tipo de ingreso: '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NRO_OPERACION' ,@Mensaje ='Nro. Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NRO_OPERACION_BOLETO' ,@Mensaje ='Nro. Operacion Boleto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROCLIENTE' ,@Mensaje ='Nro Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROCLIENTEPARTICIPANTE' ,@Mensaje ='Nro. Cliente Participante'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROCLIENTEVISIBLE' ,@Mensaje ='Nro. Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROCUENTADEPOSITANTE' ,@Mensaje ='Cta. Depositante'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NRODOCUMENTO' ,@Mensaje ='Nro Documento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROOPERACION' ,@Mensaje ='Nro. Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROOPERACIONDESCRIPCION' ,@Mensaje ='Nro. Operacion'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROOPERACIONSE' ,@Mensaje ='Número Operación SE'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUEVA' ,@Mensaje ='Nueva'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMERADOR' ,@Mensaje ='Numerador'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMERO_CLIENTE' ,@Mensaje ='Nro. Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMERO_DOCUMENTO' ,@Mensaje ='Número Documento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMERO_ORDEN' ,@Mensaje ='Nro. Orden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROCUENTAMONEDA' ,@Mensaje ='Nro Cuenta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROCUENTAMONEDAVISIBLE' ,@Mensaje ='Nro Cuenta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROCUENTATENENCIA' ,@Mensaje ='Nro Cuenta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROCUENTATENENCIAVISIBLE' ,@Mensaje ='Nro Cuenta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMERODOCUMENTO' ,@Mensaje ='Documento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OBSERVACIONES' ,@Mensaje ='Observaciones'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OBTENERSALDOMONEDA' ,@Mensaje ='Permite obtener saldo moneda?'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OK' ,@Mensaje ='OK'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OPERADOR' ,@Mensaje ='Operador'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OPERATORIADESCRIPCION' ,@Mensaje ='Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PAGINA_ACTUAL' ,@Mensaje ='Página actual'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PANTALLA_SIN_NOMBRE' ,@Mensaje ='PANTALLA SIN NOMBRE'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERFIL' ,@Mensaje ='Perfil'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERFILDESCRIPCION' ,@Mensaje ='Perfil'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERIODO_DESDE' ,@Mensaje ='Periodo Desde'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERIODO_HASTA' ,@Mensaje ='Periodo Hasta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERMISO' ,@Mensaje ='Permiso'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERMISO_EJECUTADO' ,@Mensaje ='Permiso Ejecutado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PH_BUSCAR' ,@Mensaje ='Buscar...'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PH_CONTRASENIA' ,@Mensaje ='Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PH_NOMBRE_USUARIO' ,@Mensaje ='Nombre de Usuario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PLATAFORMA' ,@Mensaje ='Plataforma'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PLATAFORMADESCRIPCION' ,@Mensaje ='Plataforma'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIO_LIMITE' ,@Mensaje ='Precio Límite'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIO_TASA_CLIENTE' ,@Mensaje ='Precio/Tasa Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIO_TASA_TRANSFERENCIA' ,@Mensaje ='Precio/Tasa Transferencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOCLIENTETIPOUSO' ,@Mensaje ='Tipo Uso'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOLIMITE' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOPROMEDIO' ,@Mensaje ='Precio Promedio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOREFERENCIA' ,@Mensaje ='Precio Referencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOTASA' ,@Mensaje ='Precio/Tasa'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOTASAFUTURO' ,@Mensaje ='Precio/Tasa Futuro'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOTASATRANSFERENCIA' ,@Mensaje ='Precio/Tasa Transferencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOTRANSFERENCIATIPOUSO' ,@Mensaje ='Tipo Uso '
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRINCIPAL' ,@Mensaje ='Principal'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_RECHAZAR' ,@Mensaje ='Rechazar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_RECURSO_NO_ENCONTRADO' ,@Mensaje ='El servidor Web no pudo encontrar el recurso solicitado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_REPORTAR_ERROR_M4Trader' ,@Mensaje ='Reportar este problema a M4Trader'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_REQUIEREPRECIOCLIENTE' ,@Mensaje ='(*)Precio Tasa Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_REQUIEREPRECIOCLIENTEDESCRIPCION' ,@Mensaje ='Precio Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_REQUIEREPRECIOTRANSFERENCIA' ,@Mensaje ='(*)Precio Tasa Transferencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_RESTAURANDO_ESPERE' ,@Mensaje ='Restaurando. Espere a que termine...'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALIDAS' ,@Mensaje ='Salidas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SE_COPIO_CELDA' ,@Mensaje ='Se copió la celda al portapapeles..'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SE_COPIO_FILA' ,@Mensaje ='Se copió una fila al portapapeles.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SESION_EXPIRADA' ,@Mensaje ='Sesión Expirada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SESION_VENCIDA' ,@Mensaje ='SesiÓn vencida'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SISITEMA_BACKOFFICE_M4Trader' ,@Mensaje ='Sistema Backoffice del Mercado Abierto Electrónico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SOLO_SE_PERMITE_MODIFICAR_1' ,@Mensaje ='Solo se permite modificar un (1) registro.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SR-ONLY' ,@Mensaje =''
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SUCURSAL' ,@Mensaje ='Sucursal'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SUCURSALDESCRIP' ,@Mensaje ='Sucursal'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SUCURSALDESCRIPCION' ,@Mensaje ='Sucursal'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SUPERVISION' ,@Mensaje ='Supervisión'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TASA' ,@Mensaje ='Tasa'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TEXTONOVEDAD' ,@Mensaje ='Observaciones'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPO' ,@Mensaje ='(*)Tipo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPO_DOCUMENTO' ,@Mensaje ='Tipo Documento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPO_LOG' ,@Mensaje ='Tipo de Log'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOCONFIRMACIONDESCRIPCION' ,@Mensaje ='Tipo Conf.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPODECONFIRMACION' ,@Mensaje ='(*)Tipos de Confirmación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPODENEGOCIACION' ,@Mensaje ='Tipo de Negociación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPODEORDEN' ,@Mensaje ='Tipo de Orden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPODEPARTICIPANTE' ,@Mensaje ='Tipo de Participante'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPODESCRIPCION' ,@Mensaje ='Tipo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOEJECUCIONDESCRIPCION' ,@Mensaje ='Tipo Ejecución'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPONEGOCIACION' ,@Mensaje ='(*) Tipo de Negociacion'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPONEGOCIACIONDESCRIP' ,@Mensaje ='Tipo Negociación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPONEGOCIACIONDESCRIPCION' ,@Mensaje ='Tipo de negociación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOOPERACIONDESCRIP' ,@Mensaje ='Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOOPERACIONDESCRIPCION' ,@Mensaje ='Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOOPERATORIA' ,@Mensaje ='Tipo de Operatoria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TODAS_LAS_PAGINAS' ,@Mensaje ='Todas las páginas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIO' ,@Mensaje ='Usuario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIOALTANOMBRE' ,@Mensaje ='Usuario Carga'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIOCARGA' ,@Mensaje ='Usuario Carga'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIODESCRIPCION' ,@Mensaje ='Usuario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIOMODIFNOMBRE' ,@Mensaje ='Usuario Ultima Modificación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USUARIOULTIMAMODIFICACION' ,@Mensaje ='Usuario Última Modificación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_VALIDACION_DATOS' ,@Mensaje ='Validación datos en {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OBSERVACIONES_500' ,@Mensaje ='Observaciones (max.500)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MENU_CUENTAS' ,@Mensaje ='Cuentas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DOCUMENTO' ,@Mensaje ='Numero Documento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_LOGIN_USUARIOREQUERIDO' ,@Mensaje ='Usuario es un dato requerido'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_LOGIN_PWDREQUERIDO' ,@Mensaje ='Password es un dato requerido'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_LOGIN_DOCUMENTOREQUERIDO' ,@Mensaje ='Documento es un dato requerido'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_LOGIN_NUMBERVALIDATION' ,@Mensaje ='solo se permiten numeros'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CHANGEPASS_LOGIN' ,@Mensaje ='Volver Login'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROORDENINTERNO' ,@Mensaje ='N°'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERSONADESCRIPCION' ,@Mensaje ='Persona'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDESTADO' ,@Mensaje ='Estado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIO' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NUMEROORDENMERCADO' ,@Mensaje ='Número de Mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NROOPERACIONMERCADO' ,@Mensaje ='Nro Operacion Mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MONTO' ,@Mensaje ='Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDPERSONA' ,@Mensaje ='Id'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_QUANTITY' ,@Mensaje ='Cantidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_VIGENCIACANTIDAD' ,@Mensaje ='TTL'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAVENCIMIENTO' ,@Mensaje ='Fecha de Expiración'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TCQ' ,@Mensaje ='TCQ'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACIONDESDE' ,@Mensaje ='Fecha Desde'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACONCERTACIONHASTA' ,@Mensaje ='Fecha Hasta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESCRIPCIONACCION' ,@Mensaje ='Descripción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONSULTA' ,@Mensaje ='Consulta'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APROBACION_AUTOMATICA' ,@Mensaje ='Aprobación Automática'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EJECUCION' ,@Mensaje ='Ejecución'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FILTROACCIONUPDATE' ,@Mensaje ='Nombre Acción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIMEOUTINICIALSESION' ,@Mensaje ='Timeout Inicial (en segs)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIMEOUTEXTENSIONSESION' ,@Mensaje ='Timeout Extensión Sesión (en segs)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADINTENTOSMAXIMO' ,@Mensaje ='Cantidad Intentos Login'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MAXIMODIASINACTIVIDAD' ,@Mensaje ='Max días Inactividad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DIASCAMBIOPASSWORD' ,@Mensaje ='Días Cambio Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADPASSWORDSHISTORICAS' ,@Mensaje ='Cantidad Contraseñas históricas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONSIDERAMINIMOLARGOPASSWORD' ,@Mensaje ='Considerar Mínimo Largo Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADMINIMOLARGOPASSWORD' ,@Mensaje ='Cantidad Mínimo Largo Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONSIDERAMAXIMACANTCARACTERESCONSECUTIVOS' ,@Mensaje ='Considerar Max cant caract consecutivos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADMAXIMACARACTERESCONSECUTIVOS' ,@Mensaje ='Cant Max Caracteres Consecutivos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADSIMBOLOSPASSWORD' ,@Mensaje ='Cantidad Símbolos Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADMAYUSCULASPASSWORD' ,@Mensaje ='Cantidad Mayúsculas Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADMINUSCULASPASSWORD' ,@Mensaje ='Cantidad Minúsculas Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADALFABETICOSPASSWORD' ,@Mensaje ='Cant Caract. Alfabéticos Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CANTIDADNUMERICOSPASSWORD' ,@Mensaje ='Cant Caract. Numéricos Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONSIDERACANTIDADCARACTERES' ,@Mensaje ='Considerar Cantidad Caracteres'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PREVIOUSPASS' ,@Mensaje ='Contraseña vieja'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NEWPASSWORD' ,@Mensaje ='Contraseña Nueva'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONFIRMPASSWORD' ,@Mensaje ='Contraseña Confirmar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BTNACEPTAR' ,@Mensaje ='Aceptar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_VALORNUMERICO' ,@Mensaje ='Valor Numérico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USERNAME' ,@Mensaje ='Usuario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_USERGRID' ,@Mensaje ='Usuarios'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOMBRE' ,@Mensaje ='Nombre completo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BLOQUEADO' ,@Mensaje ='Bloqueado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PROCESO' ,@Mensaje ='Proceso'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOCONTROLARINACTIVIDAD' ,@Mensaje ='No Controlar Inactividad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PASSWORD' ,@Mensaje ='Contraseña'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CODIGOMERCADO' ,@Mensaje ='Código'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESCRIPCIONMERCADO' ,@Mensaje ='Descripción'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_LIMIT' ,@Mensaje ='LÍMITE'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PRECIOLIMITEMERCADO' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOMONEDA' ,@Mensaje ='Tipo Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDTIPOPERSONA' ,@Mensaje ='Tipo Persona'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDPERSONERIAJURIDICA' ,@Mensaje ='Personeria Juridica'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAEVENTO' ,@Mensaje ='Fecha/Hora'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOEVENTO' ,@Mensaje ='Evento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_NOMBREENTIDAD' ,@Mensaje ='Entidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHADESDE' ,@Mensaje ='Fecha (desde)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAHASTA' ,@Mensaje ='Fecha (hasta)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDTIPOEVENTO' ,@Mensaje ='Tipo Evento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDLOGAUDITORIACLASE' ,@Mensaje ='Entidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_REQUESTID' ,@Mensaje ='RequestId'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DESCRIPCIONSEGURIDAD' ,@Mensaje ='Texto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ORIGEN' ,@Mensaje ='Origen'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHAAPERTURA' ,@Mensaje ='Fecha de apertura'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_FECHACIERRE' ,@Mensaje ='Fecha de cierre'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_EJECUCIONVALIDACION' ,@Mensaje ='Ejecución validación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_APERTURASISTEMA' ,@Mensaje ='Apertura del Sistema.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BTNDESHACER' ,@Mensaje ='Deshacer'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CIERRESISTEMA' ,@Mensaje ='Cierre del Sistema'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_BTNVERERROR' ,@Mensaje ='Ver Error'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOURL' ,@Mensaje ='Tipo Url'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_URL' ,@Mensaje ='Url'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PARAMETROS' ,@Mensaje ='Parametros'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_OCULTARERRORESBASEDEDATOS' ,@Mensaje ='Ocultar Errores Base De Datos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ENVIANOTIFICACIONES' ,@Mensaje ='Envía Notificaciones'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PERMITEPROCESAMIENTOPARALELO' ,@Mensaje ='Permite Procesamiento Paralelo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PATHSALIDA' ,@Mensaje ='Path Salida'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIEMPOLOGSQL' ,@Mensaje ='Tiempo Log SQL'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_COD_PRODUCTO' ,@Mensaje ='Ticker'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_DESC_PRODUCTO' ,@Mensaje ='Especie'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_FECHA_VENCIMIENTO' ,@Mensaje ='Fecha Vencimiento'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_CODIGO_CUENTA' ,@Mensaje ='Concepto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_PRECIO_NACIONAL' ,@Mensaje ='Precio ($)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_MONTO_NACIONAL' ,@Mensaje ='Valorizacion ($)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_MONTO_DOLARES' ,@Mensaje ='Valorizacion (U$S)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDOS_PRECIO_DOLARES' ,@Mensaje ='Precio (u$s)'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_IDENTIFICACION_TRIBUTARIA' ,@Mensaje ='Identificacion Tributaria'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CLIENTES' ,@Mensaje ='Clientes'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CLIENTE' ,@Mensaje ='Cliente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00053' ,@Mensaje ='Error de comunicacion.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ESDESISTEMA' ,@Mensaje ='Es De Sistema'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PORTFOLIOS' ,@Mensaje ='Portfolios'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ASOCIAR' ,@Mensaje ='Asociar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_HABILITADO' ,@Mensaje ='Habilitado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_CONSULTE_ADMIN' ,@Mensaje ='Surgio un error en la transaccion. Por favor, consulte con su administrador'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PORDEFECTO' ,@Mensaje ='Por Defecto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100556' ,@Mensaje ='Error al Cerrar la Orden en un Mercado Interno. No existe un Mercado Interno.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOSALDO_1' ,@Mensaje ='Monedas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SALDO_TOTALES' ,@Mensaje ='Totales'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TELEFONO' ,@Mensaje ='Teléfono'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00055' ,@Mensaje ='Error de Concurrencia: El registro que esta tratando de modificar esta siendo modificado por otro usuario. Por favor intente de nuevo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_DOBLEFACTOR' ,@Mensaje ='Doble Factor'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOPRODUCTO' ,@Mensaje ='Tipo de Producto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_RESULTADO' ,@Mensaje ='Resultado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PORTFOLIO_COMPOSICION_ACTUALIZADA' ,@Mensaje ='Composición del portfolio ha sido actualizada exitosamente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00056' ,@Mensaje ='Las contraseñas no coinciden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00057' ,@Mensaje ='La dirección de mail no es válida'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00056' ,@Mensaje ='Las contraseñas no coinciden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00057' ,@Mensaje ='La dirección de mail no es válida'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ESINTERNO' ,@Mensaje ='Es Interno'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_HABILITADODEFECTO' ,@Mensaje ='Habilitado Defecto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_SOURCEAPPLICATION' ,@Mensaje ='Aplicación Origen'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_TIPOPERSONA' ,@Mensaje ='Tipo de persona'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01006' ,@Mensaje ='Se alcanzo la maxima cantidad posible para agregar al portfolio.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00058' ,@Mensaje ='No se pudo eliminar un(a) {0} debido a que tiene {1} asociados'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00059' ,@Mensaje ='No se pudo eliminar un(a) {0} debido a que esta asociado a algun(a) otro(a) {0}'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE00060' ,@Mensaje ='La cantidad mínima debe ser menor o igual a la cantidad.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100557' ,@Mensaje ='No existe la acción con ID {0}.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ALIQAN' ,@Mensaje ='ALIQ/AN'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'E100016' ,@Mensaje ='El comando no está permitido para el usuario logueado.|| ||'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ENVIARAGENTCODE' ,@Mensaje ='Enviar Codigo de Agente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_JWT_SECRET_KEY' ,@Mensaje ='Jwt Secret Key'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_JWT_AUDIENCE_TOKEN' ,@Mensaje ='Jwt Audience Token'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_JWT_ISSUER_TOKEN' ,@Mensaje ='Jwt Issuer Token'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MAX_OPERATIONS_ROWS' ,@Mensaje ='Max Filas de Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_MIN_OPERATIONS_ROWS' ,@Mensaje ='Min Filas de Operación'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_ABSOLUTE_SERVICES_URL' ,@Mensaje ='Absolute Services URL'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LBL_PUERTO' ,@Mensaje ='Puerto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01011' ,@Mensaje ='El usuario logueado no tiene permisos suficientes para realizar esta operación. Permiso requerido {0}. Por favor contacte al administrador.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.charts' ,@Mensaje ='Gráficos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.charts' ,@Mensaje ='Graficos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.openTrades' ,@Mensaje ='Operaciones propias de hoy'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.openTrades' ,@Mensaje ='Operaciones propias de hoy'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.history' ,@Mensaje ='Detalle de operaciones'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.history' ,@Mensaje ='Historial'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.closedPositions' ,@Mensaje ='Posturas Cerradas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.closedPositions' ,@Mensaje ='Posturas Cerradas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.rejected' ,@Mensaje ='Rechazo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.rejected' ,@Mensaje ='Rechazadas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.symbolInfo' ,@Mensaje ='Info Símbolo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES_DESCRIPTIONS.symbolInfo' ,@Mensaje ='Info Símbolo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Garanty' ,@Mensaje ='Garantías'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.DETACH' ,@Mensaje ='Separar  Vista'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.MAXIMIZE' ,@Mensaje ='Maximizar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.MINIMALIZE' ,@Mensaje ='Minimixar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.CLOSE' ,@Mensaje ='Cerrar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.EMPTY_CONTAINER' ,@Mensaje ='Contenedor vacio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'LAYOUT.ADD_MODULE_OR_CHANGE_LAYOUT' ,@Mensaje ='Añada un Modulo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH.SYMBOL' ,@Mensaje ='SIMBOLO'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH_GROUP.M4Trader' ,@Mensaje ='M4Trader'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.receptor' ,@Mensaje ='Receptor'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.dador' ,@Mensaje ='Dador'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.moneda' ,@Mensaje ='moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.montoAsignado' ,@Mensaje ='Monto asignado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.montoConsumido' ,@Mensaje ='Monto consumido'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.fichas' ,@Mensaje ='Fichas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.disponible' ,@Mensaje ='Disponible'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'GARANTY.clearingHouse' ,@Mensaje ='Clearing house'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'CHAR_TRADE_SYMBOL.INFORMATION' ,@Mensaje ='Abrir Gráfico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'POPUP_TRADE_SYMBOL_INFO.INSTRUMENT_INFORMATION' ,@Mensaje ='Abrir info'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH_TICKET.OPEN_CHART' ,@Mensaje ='Abrir Gráfico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'CHART.MAX_CHARTS' ,@Mensaje ='max gráfico'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH_TICKET.OPEN_TICKET' ,@Mensaje ='Abrir tkt'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH_TICKET.REMOVE_FROM_FAVORITES' ,@Mensaje ='Remover de favoritos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'MARKET_WATCH_TICKET.ADD_TO_FAVORITES' ,@Mensaje ='Añadir a favoritos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'SYMBOLS_SEARCH.NO_RESULTS' ,@Mensaje ='sin resultados'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'SYMBOLS_SEARCH_EXTENDED.LOOKING_FOR_NEW' ,@Mensaje ='Buscar nuevos'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.CLOSE' ,@Mensaje ='Cerrar'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.OPEN_ORIGIN' ,@Mensaje ='Abierto originalmente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.COMMENT' ,@Mensaje ='Comentario'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PROFIT' ,@Mensaje ='Ganacia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.TOTAL_PROFIT' ,@Mensaje ='Total ganancias'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.SWAP' ,@Mensaje ='Intercambio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.CLOSE_COMMISSION' ,@Mensaje ='comisiones cerradas'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.COMMISSION' ,@Mensaje ='Comision'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.NET_PL' ,@Mensaje ='net pl'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.MARKET_VALUE' ,@Mensaje ='valor de mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PURCHASE_VALUE' ,@Mensaje ='Precio de compra'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.MARGIN' ,@Mensaje ='Margen'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.MARKET_PRICE' ,@Mensaje ='Precio de mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.EXPIRY_DATE' ,@Mensaje ='Fecha de expiracion'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.TP' ,@Mensaje ='tp'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.SL' ,@Mensaje ='sl'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.OPEN_PRICE' ,@Mensaje ='Precio de apertura'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.OPEN_TIME' ,@Mensaje ='Tiempo de apertura'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.VOLUME' ,@Mensaje ='Volumen'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.TYPE' ,@Mensaje ='tipo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.SYMBOL' ,@Mensaje ='Simbolo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.ORDER' ,@Mensaje ='Orden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.POSITION' ,@Mensaje ='Posición'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PRICE' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.FECHA' ,@Mensaje ='Fecha'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.TOTAL' ,@Mensaje ='Total'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Monto' ,@Mensaje ='Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Cantidad' ,@Mensaje ='Cantidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PrecioDetalle' ,@Mensaje ='PrecioDetalle'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.NroOperacionMercado' ,@Mensaje ='N° Op M'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.NumeroOrdenMercado' ,@Mensaje ='N° Orden M'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PersonaDescripcion' ,@Mensaje ='Persona'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Remanente' ,@Mensaje ='Remanente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Ejecutada' ,@Mensaje ='Ejecutada'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Precio' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.CodigoMercado' ,@Mensaje ='Mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.MonedaDescripcion' ,@Mensaje ='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.PlazoDescripcion' ,@Mensaje ='Plazo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.ProductoDescripcion' ,@Mensaje ='Producto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.CompraVenta' ,@Mensaje ='C o V'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.FechaConcertacion' ,@Mensaje ='Fecha'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.Estado' ,@Mensaje ='Estado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.NumeroOrdenInterno' ,@Mensaje ='N°'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.BITACORA' ,@Mensaje ='Bitácora Orden'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.NroOperacionMercado' ,@Mensaje ='Número Operación Mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.Precio' ,@Mensaje ='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.Cantidad' ,@Mensaje ='Cantidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.Monto' ,@Mensaje ='Monto'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.Tasa' ,@Mensaje ='Tasa'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DETALLE.Fecha' ,@Mensaje ='Fecha'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'DATE.SELECT_DATE_RANGE' ,@Mensaje ='Seleccionar rango de fechas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.FROM' ,@Mensaje ='Desde'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORY.TO' ,@Mensaje ='A'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'POPUPS.APPLY' ,@Mensaje ='Aplicar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.TITLETEXT' ,@Mensaje ='Bitacora de Orden'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.Fecha' ,@Mensaje ='Fecha'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.UsuarioDescripcion' ,@Mensaje ='Usuario'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.EstadoDescripcion' ,@Mensaje ='Estado'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.AccionDescripcion' ,@Mensaje ='Accion'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.MotivoCancelacionDescripcion' ,@Mensaje ='Motivo Baja'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.Observaciones' ,@Mensaje ='Observaciones'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'BITACORA.Source' ,@Mensaje ='Fuente'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Depth' ,@Mensaje ='Profundidad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.marketWatchDepth' ,@Mensaje ='Ofertas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Admin' ,@Mensaje ='Administrar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Action' ,@Mensaje ='Acciones'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.ActionRol' ,@Mensaje ='Acciones por Roles'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.ChangePass' ,@Mensaje ='Cambio de Clave'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.ConfigurationSave' ,@Mensaje ='Configuración de Seguridad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Roles' ,@Mensaje ='Roles'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Users' ,@Mensaje ='Usuarios'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.AdminUsers' ,@Mensaje ='Administración de Usuarios'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'SYMBOLS_SEARCH_EXTENDED.PLACEHOLDER' ,@Mensaje ='Ingrese su búsqueda'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Products' ,@Mensaje ='Asignacion de Productos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'REJECTED.PORTFOLIO' ,@Mensaje ='Portfolio'

EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USER.Ver' ,@Mensaje ='Ver'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USER.Modificar' ,@Mensaje ='Modificar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USER.Reset' ,@Mensaje ='Reset Contraseña'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USER.Eliminar' ,@Mensaje ='Eliminar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.Limite' ,@Mensaje ='Límite'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.Bloqueado' ,@Mensaje ='Bloqueado'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.USERNAME' ,@Mensaje ='Usuario'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.NOMBRE' ,@Mensaje ='Nombre Completo'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.LimiteOferta' ,@Mensaje ='Limite Oferta'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.LimiteOperacion' ,@Mensaje ='Limite Operación'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.ConsumidoOfera' ,@Mensaje ='Consumido Oferta'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'USERS.ConsumidoOperacion' ,@Mensaje ='Consumido Operación'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.HistoricoMercado' ,@Mensaje ='Histórico de Mercado'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo = 'MODULES.Noticias' ,@Mensaje ='Noticias'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.SECUENCIA' ,@Mensaje='Secuencia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.PORTFOLIO' ,@Mensaje='Portfolio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.POSICION' ,@Mensaje='Posición'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.TIPO' ,@Mensaje='Tipo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.MONEDA' ,@Mensaje='Moneda'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.PRECIO' ,@Mensaje='Precio'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.TASA' ,@Mensaje='Tasa'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.CANTIDAD' ,@Mensaje='Cantidad'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.TOTAL' ,@Mensaje='Total'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.FECHA' ,@Mensaje='Fecha'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.PLAZO' ,@Mensaje='Plazo'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.OPEROPRECIOTAZA' ,@Mensaje='Oper/ precio /taza'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.PRECIOMERCADO' ,@Mensaje='Precio mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.CONTRAPARTEVENDEDORA' ,@Mensaje='Contraparte vendedora'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'HISTORICOMERCADO.CONTRAPARTECOMPRADORA' ,@Mensaje='Contraparte Compradora'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.IDNOTICIA' ,@Mensaje='Id Noticia'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.NEWSID' ,@Mensaje='Id News'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.TITULO' ,@Mensaje='Título'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.MENSAJE' ,@Mensaje='Mensaje'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.FECHA' ,@Mensaje='Fecha'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.REMITENTE' ,@Mensaje='Remitente'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.DESTINATARIOS' ,@Mensaje='Destinatarios'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'NOTICIAS.MERCADO' ,@Mensaje='Mercado'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'FE01018' ,@Mensaje='El usuario superó los limites asignados para alta de ofertas.'
exec [dbo].[AMB_CodigosMensajes] @Codigo = 'USERLISTCHATMODULE.NAME' ,@Mensaje='USUARIOS'


go

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'ADMAGENCIA')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(1,'ADMAGENCIA')
	PRINT 'Insert ID 8'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'ADMUSUARIOSAGENCIA')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(2,'ADMUSUARIOSAGENCIA')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'USUARIODEAGENCIA')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(3,'USUARIODEAGENCIA')
	PRINT 'Insert ID 9'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.TiposPersona WHERE Descripcion = 'AGENCIAJUPITER')
BEGIN
	INSERT INTO shared_owner.TiposPersona (IdTipoPersona, Descripcion) VALUES(4,'AGENCIAJUPITER')
	PRINT 'Insert ID 9'
END


IF NOT EXISTS (SELECT 1 FROM shared_owner.PersoneriaJuridica WHERE Descripcion = 'Persona Fisica')
BEGIN
	INSERT INTO shared_owner.PersoneriaJuridica (IdPersoneriaJuridica, Descripcion) VALUES (1, 'Persona Fisica')
	PRINT 'Insert ID PJ 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.PersoneriaJuridica WHERE Descripcion = 'Persona Juridica')
BEGIN
	INSERT INTO shared_owner.PersoneriaJuridica (IdPersoneriaJuridica, Descripcion) VALUES (2, 'Persona Juridica')
	PRINT 'Insert ID PJ 2'
END


GO


DECLARE @IdTipoPersona TINYINT

IF NOT EXISTS (SELECT 1 FROM shared_owner.Parties WHERE [Name] = 'M4Trader')
BEGIN
	SELECT @IdTipoPersona = IdTipoPersona FROM shared_owner.TiposPersona WHERE Descripcion = 'ADMAGENCIA'
	INSERT INTO shared_owner.Parties (IdParty, MarketCustomerNumber, [Name], PartyType, AgentCode) VALUES (1, '001', 'M4Trader', @IdTipoPersona, '111')
	PRINT 'Insert M4Trader S.A.'
END

GO

IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'Adm Agencias' or Name = 'Adm Agencias Jupiter')
BEGIN
	INSERT INTO shared_owner.Parties (IdParty, DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber)
	VALUES(2,'20304501','Adm Agencias','001',2,2,'20203045010')
	PRINT 'Party Adm Agencias insertado'
End
ELSE
BEGIN
	UPDATE shared_owner.Parties set Name = 'Adm Agencias Jupiter' where Name = 'Adm Agencias'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'Adm Agencia Exchange')
BEGIN
	INSERT INTO shared_owner.Parties (IdParty, DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber, CBU)
	VALUES(3,'111222333','Adm Agencia Exchange ','001',2,2,'111222333', '00205005200525005')
	PRINT 'Party Adm Agencias Exchange insertado'
End
ELSE
BEGIN
	PRINT 'Ya existe party Adm Agencia Exchange'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'usr Agencia Exchange' or Name = 'JPerez')
BEGIN
	INSERT INTO shared_owner.Parties (IdParty, DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber)
	VALUES(4,'443123132','JPerez ','001',3,2,'4124214122')
	PRINT 'Party usr Agencias Exchange insertado'
End
ELSE
BEGIN
	UPDATE shared_owner.Parties set Name = 'JPerez' where  Name = 'usr Agencia Exchange'
END


IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'usr Agencia Jupiter' or Name = 'ESosa')
BEGIN
	INSERT INTO shared_owner.Parties (IdParty, DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber)
	VALUES(5,'443123123123132','ESosa','001',3,2,'213213')
	PRINT 'Party usr Agencias Exchange insertado'
End
ELSE
BEGIN
	UPDATE shared_owner.Parties set Name = 'Esosa' where  Name = 'usr Agencia Jupiter'
END

IF NOT EXISTS(SELECT 1 FROM shared_owner.Parties WHERE Name = 'Juan Pablo Guerrero')
BEGIN
	INSERT INTO shared_owner.Parties (IdParty, DocumentNumber, Name, MarketCustomerNumber, PartyType,IdLegalPersonality,TaxIdentificationNumber, CBU)
	VALUES(6,'28765432','Juan Pablo Guerrero','009',3,2,'20287654329', '005005005005005005005')
	PRINT 'Party usr Agencias Exchange insertado'
End



GO
 

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'Usuario Proceso' OR Nombre = 'Usuario Proceso')
BEGIN
	INSERT INTO shared_owner.Usuarios(IdUsuario, Username, Pass, Nombre, Proceso, NoControlarInactividad, IdPersona)
	VALUES (1,'UsuarioProceso', '989FA7EC5802BB6283C6B3741923C158','Usuario Proceso',1,1,1)
	print 'Insert proceso'
END


GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Ingreso al Sistema')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (1, 'Ingreso al Sistema', 1)
	PRINT 'Insert ID 1'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 1 WHERE Descripcion = 'Ingreso al Sistema'
	PRINT 'UPDATE ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Consultas Generales')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (2, 'Consultas Generales', 2)
	PRINT 'Insert ID 2'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 2 WHERE Descripcion = 'Consultas Generales'
	PRINT 'UPDATE ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Administrador')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (3, 'Administrador', 3)
	PRINT 'Insert ID 3'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 3 WHERE Descripcion = 'Administrador'
	PRINT 'UPDATE ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Administrador Agencias')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (4, 'Administrador Agencias', 4)
	PRINT 'Insert ID 3'
END
ELSE
BEGIN
	UPDATE shared_owner.Roles SET ValorNumerico = 4 WHERE Descripcion = 'Administrador Agencias'
	PRINT 'UPDATE ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Roles WHERE Descripcion = 'Usuario de Agencia')
BEGIN
	INSERT INTO shared_owner.Roles (IdRol, Descripcion, ValorNumerico) values (5, 'Usuario de Agencia', 5)
	PRINT 'Insert ID 5'
END


GO

DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'UsuarioProceso'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert Acceso al sistema para UsuarioProceso'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 6
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'UsuarioProceso'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert Acceso al sistema para UsuarioProceso'
END
 
GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.ConfiguracionSeguridad WHERE IdConfiguracionSeguridad = 1)
BEGIN
	INSERT INTO [shared_owner].[ConfiguracionSeguridad]
           ([IdConfiguracionSeguridad]
           ,[TimeOutInicialSesion]
           ,[TimeOutExtensionSesion]
           ,[CantidadIntentosMaximo]
           ,[DiasCambioPassword]
           ,[MaximoDiasInactividad]
           ,[CantidadPasswordsHistoricas]
           ,[ConsideraMinimoLargoPassword]
           ,[CantidadMinimoLargoPassword]
           ,[ConsideraCantidadCaracteres]
           ,[CantidadAlfabeticosPassword]
           ,[CantidadNumericosPassword]
           ,[ConsideraMaximaCantCaracteresConsecutivos]
           ,[CantidadMaximaCaracteresConsecutivos]
           ,[CantidadMayusculasPassword]
           ,[CantidadMinusculasPassword]
           ,[CantidadSimbolosPassword])
     VALUES
           (1
           ,3600
           ,3600
           ,3
           ,30
           ,30
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)
	PRINT 'Insert ID 1'
END

GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.EstadoSistema)
BEGIN
	INSERT INTO shared_owner.EstadoSistema (FechaSistema, IdUsuarioApertura, BajaLogica, EstadoAbierto, EjecucionValidacion)
		VALUES ( CONVERT(DATETIME,CONVERT(varchar(10), GETDATE(), 103),103), (SELECT TOP 1 IdUsuario FROM shared_owner.Usuarios ORDER BY IdUsuario ASC), 0, 1, 0)
	PRINT 'Insert ID 1'
END

GO



IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'admin')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES (2, 'admin', '1A1DC91C907325C69271DDF0C944BC72', 'Administrador', 0, 0, 0, 0, GETDATE(), NULL, 0, 1, 0)
	PRINT 'Insert admin'
END

 

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'AgenciaJupiter')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado, Email)
	VALUES (3, 'AgenciaJupiter', '1A1DC91C907325C69271DDF0C944BC72', 'AGENCIA DE CAMBIO JUPITER S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 4, 0, 'agenciaJupite@agenciaJupiter.com')
	PRINT 'Insert admin'
END
ELSE
BEGIN 
   update shared_owner.Usuarios set idpersona = 2 WHERE Username = 'AgenciaJupiter'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'admAgenciaJupiter')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado, Email)
	VALUES (7, 'admAgenciaJupiter', '1A1DC91C907325C69271DDF0C944BC72', 'ADM AGENCIA DE CAMBIO JUPITER S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 2, 0, 'agenciaJupite@agenciaJupiter.com')
	PRINT 'Insert admin'
END



IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'AgenciaExchange')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado)
	VALUES (4, 'AgenciaExchange', '1A1DC91C907325C69271DDF0C944BC72', 'AGENCIA Exchange S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 3, 0)
	PRINT 'Insert admin'
END
BEGIN 
   update shared_owner.Usuarios set idpersona = 3 WHERE Username = 'AgenciaExchange'
END


IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'admAgenciaExchange')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado, Email)
	VALUES (8, 'admAgenciaExchange', '1A1DC91C907325C69271DDF0C944BC72', 'ADM AGENCIA Exchange S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 3, 0, 'AgenciaExchange@AgenciaExchange.com')
	PRINT 'Insert admin'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'JPerez')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado,Email)
	VALUES (5, 'JPerez', '1A1DC91C907325C69271DDF0C944BC72', 'Juan Perez usr AGENCIA Exchange S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 4, 0, 'JPerez@AgenciaExchange.com')
	PRINT 'Insert JPerez'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'ESosa')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado, email)
	VALUES (6, 'ESosa', '1A1DC91C907325C69271DDF0C944BC72', 'ESosa usr AGENCIA Jupiter S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 5, 0, 'esosa170978@gmail.com')
	PRINT 'Insert JPerez'
END


IF NOT EXISTS (SELECT 1 FROM shared_owner.Usuarios WHERE Username = 'JGuerrero')
BEGIN
	INSERT INTO shared_owner.Usuarios (IdUsuario, Username, Pass, Nombre, CantidadIntentos, Bloqueado, Proceso, BajaLogica, UltimaModificacionPassword, 
		UltimoLoginExitoso, NoControlarInactividad, IdPersona, LoginRealizado, email)
	VALUES (9, 'JGuerrero', '1A1DC91C907325C69271DDF0C944BC72', 'JGuerrero usr AGENCIA Jupiter S.A', 0, 0, 0, 0, GETDATE(), NULL, 0, 6, 0, 'adrian.ossola@gmail.com')
	PRINT 'Insert JPerez'
END


GO


GO
DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 1'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 3
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admin'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 3'
END

GO

DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 1'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 4
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

GO

DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admAgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 1'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admAgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 4
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'admAgenciaJupiter'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

GO

DECLARE @IdRol SMALLINT
DECLARE @IdUsuario INT

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaExchange'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 1'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaExchange'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 4
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'AgenciaExchange'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END



SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'JPerez'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END


SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'JPerez'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END



SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'ESosa'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END


SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 5
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'ESosa'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END


SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 1
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'JGuerrero'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END
SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 5
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'JGuerrero'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END

SELECT @IdRol = IdRol FROM shared_owner.Roles WHERE ValorNumerico = 2
SELECT @IdUsuario = IdUsuario FROM shared_owner.Usuarios WHERE Username = 'JGuerrero'
IF NOT EXISTS (SELECT 1 FROM shared_owner.RolUsuario WHERE IdRol = @IdRol AND IdUsuario = @IdUsuario)
BEGIN
	INSERT INTO shared_owner.RolUsuario (IdUsuario, IdRol) VALUES (@IdUsuario, @IdRol)
	PRINT 'Insert ID 2'
END 

 GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Accion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (1,'Accion', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Accion/Rol')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (2,'Accion/Rol', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Configuracion Seguridad')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (3,'Configuracion Seguridad', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Configuracion Sistema')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (4,'Configuracion Sistema', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Customizacion Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (5,'Customizacion Usuario', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Estado Sistema')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (6,'Estado Sistema', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 6'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Historico Password')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (7,'Historico Password', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Mensajes Literales')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (8,'Mensajes Literales', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Mercado')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (9,'Mercado', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Moneda')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (10,'Moneda', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Orden')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (11,'Orden', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 11'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Persona')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (12,'Persona', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 12'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Producto')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (13,'Producto', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 13'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Roles')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (14,'Roles', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 14'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Rol/Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (15,'Rol/Usuario', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 15'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Sesiones')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (16,'Sesiones', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 16'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Usuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (17,'Usuario', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 17'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'Portfolios')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (18,'Portfolios', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 18'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'PortfoliosComposicion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (19,'PortfoliosComposicion', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 19'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'PortfolioUsuario')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (20,'PortfolioUsuario', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 20'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'ProductosPorMercado')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (23,'ProductosPorMercado', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 23'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'OrdenOperacion')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (24,'OrdenOperacion', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 24'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'OrdenHistorico')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (25,'OrdenHistorico', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 25'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.LogAuditoriaClases WHERE NombreEntidad = 'ConfirmacionManual')
BEGIN
       INSERT INTO shared_owner.LogAuditoriaClases (IdLogAuditoriaClase, NombreEntidad, NombreClase) VALUES (26,'ConfirmacionManual', 'M4Trader.ordenes.server.MCContext.Entidades')
       PRINT 'Insert ID 25'
END



GO

-- PORTFOLIO
IF NOT EXISTS (SELECT 1 FROM orden_owner.Portfolios WHERE codigo = 'USD')
BEGIN
	INSERT INTO [orden_owner].[Portfolios] ([Nombre],[Codigo],[EsDeSistema]) VALUES ('Dólar','USD',1)
END


IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 2)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (1
           ,2
           ,1
           ,1)
end
GO


IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 3)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (2
           ,3
           ,1
           ,1)
end
GO

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 4)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (3
           ,4
           ,1
           ,1)
end
GO 

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 5)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (4
           ,5
           ,1
           ,1)
end

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 6)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (5
           ,6
           ,1
           ,1)
end


IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 7)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (6
           ,7
           ,1
           ,1)
end 

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 8)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (7
           ,8
           ,1
           ,1)
end 

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 5)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (8
           ,5
           ,1
           ,1)
end 

IF NOT EXISTS (SELECT 1 FROM orden_owner.PortfolioUsuario WHERE IdUsuario = 9)
begin
INSERT INTO [orden_owner].[PortfolioUsuario]
           ([IdPortfolioUsuario]
           ,[IdUsuario]
           ,[IdPortfolio]
           ,[PorDefecto])
     VALUES
           (9
           ,9
           ,1
           ,1)
end 
GO 

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 110)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (110, 'Inicio Sesión')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 111)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (111, 'Usuario Bloqueado')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 112)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (112, 'Máximos Intentos')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 113)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (113, 'Usuario Inexistente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 114)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (114, 'Usuario Baja Lógica')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 115)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (115, 'Usuario Bloqueado Por Cuenta Expirada')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 116)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (116, 'Usuario Bloqueado Por Tiempo Inactividad')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 117)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (117, 'Iniciando Servicio')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 118)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (118, 'Servicio Iniciado Correctamente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 119)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (119, 'Servicio Iniciado Con Error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 120)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (120, 'Procesado XML Correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 121)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (121, 'Procesado XML Con Error')
END 
 
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 125)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (125, 'La sesión ha expirado.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 126)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (126, 'Error al cerrar sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 127)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (127, 'Error inicio de sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 128)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (128, 'Cierre de sesión exitoso.')
END
 

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 133)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (133, 'Error al cerrar sesión.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 134)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (134, 'El usuario alcanzó la cantidad máxima de intentos.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 135)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (135, 'Código genérico')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 136)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (136, 'Alta usuario')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 137)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (137, 'Eliminación usuario')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 138)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (138, 'Reset password')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 139)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (139, 'Actualiza User')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 140)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (140, 'Reactivación usuario')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario inexistente')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (141, 'Usuario inexistente')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario dado de baja')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (142, 'Usuario dado de baja')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario desbloqueado por el administrador del sistema')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (143, 'Usuario desbloqueado por el administrador del sistema')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por el administrador del sistema')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (144, 'Usuario bloqueado por el administrador del sistema')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por cuenta expirada')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (145, 'Usuario bloqueado por cuenta expirada')
END
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE  Descripcion = 'Usuario bloqueado por exceder el límite de tiempo de inactividad')
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (146, 'Usuario bloqueado por exceder el límite de tiempo de inactividad')
END 
  
IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 149)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (149, 'Iniciando Servicios de Aplicación')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 150)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (150, 'Inicio de servicio correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 151)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (151, 'Inicio de servicio con error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 152)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (152, 'Iniciando Interface')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 153)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (153, 'Interface No inicializada. Error en configuracion.')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 154)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (154, 'Interface Iniciada Correctamente')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 155)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (155, 'Interface Iniciada ConError')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 156)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (156, 'Dispatching Interface Starts')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 157)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (157, 'Dispatching Interface Succeeded')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 158)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (158, 'Dispatching Interface Error')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 159)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (159, 'Error Proccessing MarketData Fix Message');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 160)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (160, 'AccionIncorrecta');
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 162)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (162, 'Crear Movimiento Saldo')
END
ELSE
BEGIN
    UPDATE [shared_owner].[LogCodigoAccion] Set Descripcion = 'Crear Movimiento Saldo' WHERE IdLogCodigoAccion = 162
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 163)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (163, 'Crear Operación')
END
ELSE
BEGIN
    UPDATE [shared_owner].[LogCodigoAccion] Set Descripcion = 'Crear Operación' WHERE IdLogCodigoAccion = 163
END


IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 253)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (253, 'Item Queue Cancelled')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 254)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (254, 'Items on Queued')
END

IF NOT EXISTS (SELECT 1 FROM [shared_owner].[LogCodigoAccion] WHERE IdLogCodigoAccion = 255)
BEGIN
	INSERT INTO [shared_owner].[LogCodigoAccion] (IdLogCodigoAccion, Descripcion) VALUES (255, 'Ejecucion')
END


GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Usuarios')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (1, 'Usuarios', 31)
	PRINT 'Insert ID 1'

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Estado del sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (2, 'Estado del sistema', 257)
	PRINT 'Insert ID 2'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Cambio Clave')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (3, 'Cambio Clave', 257)
	PRINT 'Insert ID 3'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'GetPermisosAcciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (4, 'GetPermisosAcciones', 1)
	PRINT 'Insert ID 4'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ordenar Pantallas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (5, 'Ordenar Pantallas', 256)
	PRINT 'Insert ID 5'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ordenes')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (6, 'Ordenes', 1)
	PRINT 'Insert ID 6'
END

END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Abrir Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (7, 'Abrir Sistema', 256)
	PRINT 'Insert ID 7'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Anular Cierre Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (8, 'Anular Cierre Sistema', 256)
	PRINT 'Insert ID 8'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Rol')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (9, 'Rol', 31)
	PRINT 'Insert ID 9'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Monedas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (10, 'Monedas', 31)
	PRINT 'Insert ID 10'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mercados')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (11, 'Mercados', 31)
	PRINT 'Insert ID 11'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Login')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (12, 'Login', 1)
	PRINT 'Insert ID 12'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Productos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (13, 'Productos', 255)
	PRINT 'Insert ID 13'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Ejecutar Procesos Encadenados')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (14, 'Ejecutar Procesos Encadenados', 256)
	PRINT 'Insert ID 14'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Configuracion Sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (15, 'Configuracion Sistema', 255)
	PRINT 'Insert ID 15'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Configuracion Seguridad')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (16, 'Configuracion Seguridad', 31)
	PRINT 'Insert ID 16'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Accion Rol')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (17, 'Accion Rol', 31)
	PRINT 'Insert ID 17'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Consultas Generales')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (18, 'Consultas Generales', 1)
	PRINT 'Insert ID 18'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Consultas Auditoria')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (19, 'Consultas Auditoria', 1)
	PRINT 'Insert ID 19'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administrador Usuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (20, 'Administrador Usuario', 31)
	PRINT 'Insert ID 20'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administracion de Sesiones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (21, 'Administracion de Sesiones', 15)
	PRINT 'Insert ID 21'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Personas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (22, 'Personas', 255)
	PRINT 'Insert ID 22'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Accion')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (23, 'Accion', 31)
	PRINT 'Insert ID 23'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'MarketWatch')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (24, 'MarketWatch', 1)
	PRINT 'Insert ID 24'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Portfolio')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (25, 'Portfolio', 29)
	PRINT 'Insert ID 25'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfoliosComposicion')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (26, 'PortfoliosComposicion', 29)
	PRINT 'Insert ID 26'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfolioUsuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (27, 'PortfolioUsuario', 285)
	PRINT 'Insert ID 27'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AppContext')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (29, 'AppContext', 1)
	PRINT 'Insert ID 29'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Menu')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (30, 'Menu', 1)
	PRINT 'Insert ID 30'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ProductosPorMercado')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (31, 'ProductosPorMercado', 1)
	PRINT 'Insert ID 31'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Autenticar Api')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (32, 'Autenticar Api', 1)
	PRINT 'Insert ID 32'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Autenticar Mobile')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (33, 'Autenticar Mobile', 1)
	PRINT 'Insert ID 33'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'CierreMercadoInterno')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (34, 'CierreMercadoInterno', 1)
	PRINT 'Insert ID 34'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Saldos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (35, 'Saldos', 1)
	PRINT 'Insert ID 35'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ConfirmacionManual')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (36, 'ConfirmacionManual', 31)
	PRINT 'Insert ID 36'
END
IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mensajes Ordenes')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (37, 'Mensajes Ordenes', 1)
	PRINT 'Insert ID 37'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Traducciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (38, 'Traducciones', 255)
	PRINT 'Insert ID 38'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ConfiguracionInterfaces')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (39, 'ConfiguracionInterfaces', 255)
	PRINT 'Insert ID 39'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'CachingManager')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (40, 'CachingManager', 1)
	PRINT 'Insert ID 40'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'RegistroUsuario')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (41, 'RegistroUsuario', 31)
	PRINT 'Insert ID 41'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AdministracionUsuariosWeb')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (42, 'AdministracionUsuariosWeb', 31)
	PRINT 'Insert ID 42'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Menu Estado del sistema')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (43, 'Menu Estado del sistema', 1)
	PRINT 'Insert ID 43'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Graficos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (44, 'Graficos', 1)
	PRINT 'Insert ID 44'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfolioMercadoProductos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) values (45, 'PortfolioMercadoProductos', 1)
	PRINT 'Insert ID 45'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PuntasPortfolio')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (46, 'PuntasPortfolio', 1)
	PRINT 'Insert ID 46'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'DMA_GetPosicionAgenteLogueado')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (47, 'DMA_GetPosicionAgenteLogueado', 1)
	PRINT 'Insert ID 47'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'OPERACIONSTATUSCUSTOMQUERYBYID')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (48, 'OPERACIONSTATUSCUSTOMQUERYBYID', 1)
	PRINT 'Insert ID 48'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'MARKETDATACUSTOMQUERYBYID')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (49, 'MARKETDATACUSTOMQUERYBYID', 1)
	PRINT 'Insert ID 49'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'HISTORICODEORDENES')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (50, 'HISTORICODEORDENES', 1)
	PRINT 'Insert ID 50'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'ReRegistrarseSecurityList')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (51, 'ReRegistrarseSecurityList', 1)
	PRINT 'Insert ID 51'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'AltaOrdenExcel')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (52, 'AltaOrdenExcel', 31)
	PRINT 'Insert ID 52'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'GetUserSession')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (53, 'GetUserSession', 1)
	PRINT 'Insert ID 53'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'PortfoliosEmpresas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (54, 'PortfoliosEmpresas', 29)
	PRINT 'Insert ID 54'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'RefrescarCacheCommand')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (55, 'RefrescarCacheCommand', 1)
	PRINT 'Insert ID 55'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Noticias')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (56, 'Noticias', 1)
	PRINT 'Insert ID 56'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Chat')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (57, 'Chat', 1)
	PRINT 'Insert ID 57'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administración de saldos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (58, 'Administración de saldos', 285)
	PRINT 'Insert ID 58'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Operaciones historicas de cliente')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (59, 'Operaciones historicas de cliente', 257)
	PRINT 'Insert ID 59'
END


IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Cotizaciones historicas')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (60, 'Cotizaciones historicas', 257)
	PRINT 'Insert ID 60'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Datos del cliente')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (61, 'Datos del cliente', 285)
	PRINT 'Insert ID 61'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Estadística')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (62, 'Estadística', 257)
	PRINT 'Insert ID 62'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Estadística')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (62, 'Estadística', 257)
	PRINT 'Insert ID 62'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Administración de usuarios')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (63, 'Administración de usuarios', 285)
	PRINT 'Insert ID 63'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Crear Mensaje')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (64, 'Crear Mensaje', 285)
	PRINT 'Insert ID 64'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mensajes Enviados')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (65, 'Mensajes Enviados', 285)
	PRINT 'Insert ID 65'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Mensajes Recibidos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (66, 'Mensajes Recibidos', 285)
	PRINT 'Insert ID 66'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Precios')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (67, 'Precios', 257)
	PRINT 'Insert ID 67'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Pizarra')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (68, 'Pizarra', 257)
	PRINT 'Insert ID 68'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Operaciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (69, 'Operaciones', 257)
	PRINT 'Insert ID 68'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Notificaciones')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (70, 'Notificaciones', 257)
	PRINT 'Insert ID 70'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.Acciones WHERE Descripcion = 'Novedades De Transferencia Fondos')
BEGIN
	INSERT INTO shared_owner.Acciones (IdAccion, Descripcion, HabilitarPermisos) VALUES (71, 'Novedades De Transferencia Fondos', 285)
	PRINT 'Insert ID 71'
END

GO

DECLARE @IdRol SMALLINT 
DECLARE @IdAccion SMALLINT 



SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Cambio Clave' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 3' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'GetPermisosAcciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 4' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Ordenar Pantallas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   256) 

      PRINT 'Insert ID 5' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 6' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 7' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Consultas Generales' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 8' 
  END
  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Notificaciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 8' 
  END

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 10' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 11' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Estado del sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 14' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Configuracion Sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   255) 

      PRINT 'Insert ID 15' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Consultas Auditoria' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 16' 
  END 

  SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Monedas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1023) 

      PRINT 'Insert ID 19' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Usuarios' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 21' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Rol' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 22' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Personas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   255) 

      PRINT 'Insert ID 23' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Accion Rol' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 24' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Configuracion Seguridad' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 25' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Accion' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 26' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Portfolio' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 28' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfoliosComposicion' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   29) 

      PRINT 'Insert ID 29' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'AppContext' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 31' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Menu' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 32' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'ProductosPorMercado' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   31) 

      PRINT 'Insert ID 33' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Autenticar Api' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   17) 

      PRINT 'Insert ID 35' 
  END 

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'PortfolioUsuario' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 37' 
  END 

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Saldos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 38' 
  END 



SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 3 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Abrir Sistema' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 14' 
  END 
  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Autenticar Api' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   17) 

      PRINT 'Insert ID 35' 
  END 

  
 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 1 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'GetUserSession' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 53' 
  END 

 
 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Administración de saldos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 58' 
  END 

 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Operaciones historicas de cliente' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 59' 
  END 

   SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Cotizaciones historicas' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 60' 
  END 

  SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Datos del cliente' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 61' 
  END 

 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Estadística' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 62' 
  END

   SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Administración de usuarios' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 63' 
  END

  SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Crear Mensaje' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 64' 
  END

  SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Mensajes Enviados' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 65' 
  END


   SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Mensajes Recibidos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 66' 
  END

     SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Precios' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 67' 
  END

       SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Pizarra' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 68' 
  END



SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'CachingManager' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 40' 
  END

  
SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Operaciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 40' 
  END

 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 4 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Operaciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 40' 
  END


SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 5 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Operaciones' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 40' 
  END

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 5 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Saldos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 40' 
  END

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 5 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Operaciones historicas de cliente' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   257) 

      PRINT 'Insert ID 40' 
  END

SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 5 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Novedades De Transferencia Fondos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 70' 
  END

 SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Crear Mensaje' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 64' 
  END

   SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Mensajes Enviados' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 65' 
  END

   SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 2 

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Mensajes Recibidos' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   285) 

      PRINT 'Insert ID 65' 
  END


      SELECT @IdRol = idrol 
FROM   shared_owner.roles 
WHERE  valornumerico = 5

SELECT @IdAccion = idaccion 
FROM   shared_owner.acciones 
WHERE  descripcion = 'Pizarra' 

IF @IdRol IS NOT NULL 
   AND @IdAccion IS NOT NULL 
   AND NOT EXISTS (SELECT 1 
                   FROM   shared_owner.accionrol 
                   WHERE  idrol = @IdRol 
                          AND idaccion = @IdAccion) 
  BEGIN 
      INSERT INTO shared_owner.accionrol 
                  (idrol, 
                   idaccion, 
                   permiso) 
      VALUES      (@IdRol, 
                   @IdAccion, 
                   1) 

      PRINT 'Insert ID 68' 
  END

  

GO

 update shared_owner.usuarios set configuracionRegional = 'en-US' where idusuario = 3

 update shared_owner.usuarios set configuracionRegional = 'pt-BR' where idusuario = 4

DECLARE @Idioma varchar(5)
SET @Idioma = 'en-US'
declare @Codigo varchar(max)
declare @Mensaje varchar(max)

select @Codigo = 'LBL_USUARIO' ,@Mensaje ='UserName'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_CLAVE' ,@Mensaje ='Password'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_RECORDARME' ,@Mensaje ='RememberMe'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_RECUPERARCONTRASENIA' ,@Mensaje ='Forgot your password'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END


select @Codigo = 'LBL_INGRESAR' ,@Mensaje ='Login'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

GO

DECLARE @Idioma varchar(5)
SET @Idioma = 'pt-BR'
declare @Codigo varchar(max)
declare @Mensaje varchar(max)

select @Codigo = 'LBL_USUARIO' ,@Mensaje ='Nome de usuário'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_CLAVE' ,@Mensaje ='CHAVE'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_RECORDARME' ,@Mensaje ='LEMBRE DE MIM'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

select @Codigo = 'LBL_RECUPERARCONTRASENIA' ,@Mensaje ='Esqueceu sua senha'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END


select @Codigo = 'LBL_INGRESAR' ,@Mensaje ='Esqueceu sua senha'

IF (1 > (SELECT COUNT(1) FROM shared_owner.MensajesLiterales WHERE Idioma = @Idioma AND Referencia = @Codigo))
BEGIN
	INSERT INTO shared_owner.MensajesLiterales (Idioma, Referencia, Valor) VALUES (@Idioma, @Codigo, @Mensaje)
END
ELSE
BEGIN
	UPDATE shared_owner.MensajesLiterales 
	SET Valor = @Mensaje
	WHERE Idioma = @Idioma
	AND Referencia = @Codigo
END

GO


DECLARE @IdUsuario INT 
DECLARE @ThemeJSON NVARCHAR(MAX)
select @IdUsuario = IdUsuario from shared_owner.Usuarios where Username = 'AgenciaJupiter' 
SET @ThemeJSON = ''

IF (1 > (SELECT COUNT(1) FROM shared_owner.Theme WHERE IdUsuario = @IdUsuario))
BEGIN
	INSERT INTO shared_owner.Theme (IdUsuario, ThemeJSON) VALUES (@IdUsuario, @ThemeJSON)
END
ELSE
BEGIN
	UPDATE shared_owner.Theme 
	SET ThemeJSON =@ThemeJSON
	WHERE IdUsuario = @IdUsuario
END


select @IdUsuario = IdUsuario from shared_owner.Usuarios where Username = 'admin' 
SET @ThemeJSON = ''

IF (1 > (SELECT COUNT(1) FROM shared_owner.Theme WHERE IdUsuario = @IdUsuario))
BEGIN
	INSERT INTO shared_owner.Theme (IdUsuario, ThemeJSON) VALUES (@IdUsuario, @ThemeJSON)
END
ELSE
BEGIN
	UPDATE shared_owner.Theme 
	SET ThemeJSON =@ThemeJSON
	WHERE IdUsuario = @IdUsuario
END

select @IdUsuario = IdUsuario from shared_owner.Usuarios where Username = 'AgenciaExchange' 
SET @ThemeJSON = ''

IF (1 > (SELECT COUNT(1) FROM shared_owner.Theme WHERE IdUsuario = @IdUsuario))
BEGIN
	INSERT INTO shared_owner.Theme (IdUsuario, ThemeJSON) VALUES (@IdUsuario, @ThemeJSON)
END
ELSE
BEGIN
	UPDATE shared_owner.Theme 
	SET ThemeJSON =@ThemeJSON
	WHERE IdUsuario = @IdUsuario
END



GO

IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 2 AND IdPartySon = 5))
BEGIN

INSERT INTO [shared_owner].[PartiesHierarchy]
           ( [IdPartyFather]
           ,[IdPartySon])
     VALUES
           ( 2
           ,5)

END

IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 3 AND IdPartySon = 4))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           ( 3
           ,4)
end


IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 2 AND IdPartySon = 2))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           ( 2
           ,2)
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 2 AND IdPartySon = 7))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           ( 4
           ,2)
end


IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 3 AND IdPartySon = 3))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           ( 3
           ,3)
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 4 AND IdPartySon = 3))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           ( 4
           ,3)
end


IF (1 > (SELECT COUNT(1) FROM shared_owner.PartiesHierarchy WHERE IdPartyFather = 2 AND IdPartySon = 6))
BEGIN
INSERT INTO [shared_owner].[PartiesHierarchy]
( [IdPartyFather]
,[IdPartySon])
     VALUES
           (2
           ,6)
end


go

IF (1 > (SELECT COUNT(1) FROM shared_owner.TiposMovimiento WHERE Descripcion =  'Moneda Débito' AND Codigo = 1))
BEGIN
INSERT INTO [shared_owner].[TiposMovimiento]
( [Descripcion]
,[Codigo])
     VALUES
           ( 'Moneda Débito'
           ,1)
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.TiposMovimiento WHERE Descripcion = 'Moneda Crédito' AND Codigo = 2))
BEGIN
INSERT INTO [shared_owner].[TiposMovimiento]
( [Descripcion]
,[Codigo])
     VALUES
           ( 'Moneda Crédito'
           ,2)
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.TiposMovimiento WHERE Descripcion = 'Depósito De Transferencia' AND Codigo = 3))
BEGIN
INSERT INTO [shared_owner].[TiposMovimiento]
( [Descripcion]
,[Codigo])
     VALUES
           ( 'Depósito De Transferencia'
           ,3)
end

GO

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposMoneda WHERE Descripcion = 'Moneda')
BEGIN
	INSERT INTO shared_owner.TiposMoneda (IdTipoMoneda, Descripcion) VALUES (1,'Moneda')
	PRINT 'Insert ID 1'
END

IF NOT EXISTS (SELECT 1 FROM shared_owner.TiposMoneda WHERE Descripcion = 'Nominal')
BEGIN
	INSERT INTO shared_owner.TiposMoneda (IdTipoMoneda, Descripcion) VALUES (2,'Nominal')
	PRINT 'Insert ID 2'
END

IF (1 > (SELECT COUNT(1) FROM shared_owner.Monedas WHERE Descripcion = 'Pesos' AND Codigo = '$'))
BEGIN
INSERT INTO [shared_owner].[Monedas]
( [Descripcion]
,[Codigo]
,[TipoMoneda] 
,[CodigoISO])
     VALUES
           ( 'Pesos'
           ,'$'
           ,1
           ,'ARS')
end


IF (1 > (SELECT COUNT(1) FROM shared_owner.Monedas WHERE Descripcion = 'Dolar' AND Codigo = 'D'))
BEGIN
INSERT INTO [shared_owner].[Monedas]
( [Descripcion]
,[Codigo]
,[TipoMoneda] 
,[CodigoISO])
     VALUES
           ( 'Dolar'
           ,'D'
           ,1
           ,'USD')
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.Monedas WHERE Descripcion = 'Euro' AND Codigo = 'E'))
BEGIN
INSERT INTO [shared_owner].[Monedas]
( [Descripcion]
,[Codigo]
,[TipoMoneda] 
,[CodigoISO])
     VALUES
           ( 'Euro'
           ,'E'
           ,1
           ,'EUR')
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.Monedas WHERE Descripcion = 'Peso Uruguayo' AND Codigo = 'PU'))
BEGIN
INSERT INTO [shared_owner].[Monedas]
( [Descripcion]
,[Codigo]
,[TipoMoneda] 
,[CodigoISO])
     VALUES
           ( 'Peso Uruguayo'
           ,'PU'
           ,1
           ,'UYU')
end

IF (1 > (SELECT COUNT(1) FROM shared_owner.Monedas WHERE Descripcion = 'Real' AND Codigo = 'R'))
BEGIN
INSERT INTO [shared_owner].[Monedas]
( [Descripcion]
,[Codigo]
,[TipoMoneda] 
,[CodigoISO])
     VALUES
           ( 'Real'
           ,'R'
           ,1
           ,'BRL')
end


GO

IF (1 > (SELECT COUNT(1) FROM orden_owner.TiposProducto WHERE Descripcion = 'Moneda' ))
BEGIN
INSERT INTO [orden_owner].[TiposProducto]
           ([IdTipoProducto]
           ,[Descripcion])
     VALUES
           (2
           ,'Moneda')
 END

 GO

 IF (1 > (SELECT COUNT(1) FROM orden_owner.TiposCuenta WHERE Descripcion = 'Cuenta Corriente' ))
BEGIN
 INSERT INTO [orden_owner].[TiposCuenta]
           ([IdTipoCuenta]
           ,[Descripcion])
     VALUES
           (1
           ,'Cuenta Corriente')
END

GO



 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 5 and idmoneda = 1 and numeroCuenta= '1212' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           ( 5
           ,2
           ,10000000
           ,1
           ,'1212'
           ,1)
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 5 and idmoneda = 2 and numeroCuenta= '334455' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (5
           ,2
           ,100000
           ,2
           ,'334455'
           ,1)
END




 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 4 and idmoneda = 1 and numeroCuenta= '9989' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (4
           ,2
           ,88000000
           ,1
           ,'9989'
           ,1)
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 4 and idmoneda = 2 and numeroCuenta= '55464' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (4
           ,2
           ,6000000
           ,2
           ,'55464'
           ,1)
END
GO

 IF (1 > (SELECT COUNT(1) FROM orden_owner.SaldosHistoricos WHERE IdPersona = 4 and idmoneda = 1 and numeroCuenta= '9989' ))
BEGIN
INSERT INTO [orden_owner].[SaldosHistoricos]
           (
            [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta]
           ,[Fecha])
     VALUES
           (4
           ,2
           ,88000000
           ,1
           ,'9989'
           ,1
           ,getdate())
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.SaldosHistoricos WHERE IdPersona = 4 and idmoneda = 2 and numeroCuenta= '55464' ))
BEGIN
INSERT INTO [orden_owner].[SaldosHistoricos]
           (
            [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta]
           ,[Fecha])
     VALUES
           ( 4
           ,2
           ,6000000
           ,2
           ,'55464'
           ,1
           ,getdate())
            
END
GO



 IF (1 > (SELECT COUNT(1) FROM orden_owner.SaldosHistoricos WHERE IdPersona = 5 and idmoneda = 1 and numeroCuenta= '1212' ))
BEGIN
INSERT INTO [orden_owner].[SaldosHistoricos]
           (
            [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta]
           ,[Fecha])
     VALUES
           ( 5
           ,2
           ,10000000
           ,1
           ,'1212'
           ,1
           ,getdate())
            
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.SaldosHistoricos WHERE IdPersona = 5 and idmoneda = 2 and numeroCuenta= '334455' ))
BEGIN
INSERT INTO [orden_owner].[SaldosHistoricos]
           (
            [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta]
           ,[Fecha])
     VALUES
           ( 5
           ,2
           ,100000
           ,2
           ,'334455'
           ,1
           ,getdate())
            
END




 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 2 and idmoneda = 1 and numeroCuenta= '0000001' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (2
           ,2
           ,999999999
           ,1
           ,'0000001'
           ,1)
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 2 and idmoneda = 2 and numeroCuenta= '0000002' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (2
           ,2
           ,9999999
           ,2
           ,'0000002'
           ,1)
END



 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 3 and idmoneda = 1 and numeroCuenta= '0000003' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (3
           ,2
           ,999999999
           ,1
           ,'0000003'
           ,1)
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 3 and idmoneda = 2 and numeroCuenta= '0000004' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (3
           ,2
           ,9999999
           ,2
           ,'0000004'
           ,1)
END






IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 6 and idmoneda = 1 and numeroCuenta= '0000005' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (6
           ,2
           ,1000000
           ,1
           ,'0000005'
           ,1)
END

 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 6 and idmoneda = 2 and numeroCuenta= '0000006' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (6
           ,2
           ,1000000
           ,2
           ,'0000006'
           ,1)
END



declare @IdMoneda tinyint
select @IdMoneda = idmoneda from shared_owner.monedas where Descripcion = 'Peso Uruguayo'

IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 6 and idmoneda = @IdMoneda and numeroCuenta= '0000007' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (6
           ,2
           ,130000
           ,@IdMoneda
           ,'0000007'
           ,1)
END

select @IdMoneda = idmoneda from shared_owner.monedas where Descripcion = 'Real'
 IF (1 > (SELECT COUNT(1) FROM orden_owner.Saldos WHERE IdPersona = 6 and idmoneda = @IdMoneda and numeroCuenta= '0000008' ))
BEGIN
INSERT INTO [orden_owner].[Saldos]
           ( [IdPersona]
           ,[IdTipoProducto]
           ,[Importe]
           ,[IdMoneda]
           ,[NumeroCuenta]
           ,[IdTipoCuenta])
     VALUES
           (6
           ,2
           ,5000
           ,@IdMoneda
           ,'0000008'
           ,1)
END

GO


update shared_owner.parties set MarketCustomerNumber = '002' where idparty = 2
update shared_owner.parties set MarketCustomerNumber = '003' where idparty = 3
update shared_owner.parties set MarketCustomerNumber = '004' where idparty = 4
update shared_owner.parties set MarketCustomerNumber = '005' where idparty = 5


GO

UPDATE shared_owner.monedas set EsMonedaNacional = 1 where codigoISO = 'ARS' 

GO

 IF (1 > (SELECT COUNT(1) FROM shared_owner.EstadosMovimientos WHERE IdEstado = 1 and Descripcion = 'Pendiente' ))
BEGIN
INSERT INTO [shared_owner].[EstadosMovimientos]
           ( [IdEstado]
           ,[Descripcion] )
     VALUES
           (1
           ,'Pendiente') 
END

 IF (1 > (SELECT COUNT(1) FROM shared_owner.EstadosMovimientos WHERE IdEstado = 2 and Descripcion = 'Aceptada' ))
BEGIN
INSERT INTO [shared_owner].[EstadosMovimientos]
           ( [IdEstado]
           ,[Descripcion] )
     VALUES
           (2
           ,'Aceptada') 
END
GO

IF NOT EXISTS (SELECT 1 FROM orden_owner.ConfiguracionSistemaUrls WHERE IdConfiguracionSistemaUrls = 11)
BEGIN
	INSERT INTO [orden_owner].[ConfiguracionSistemaUrls]
           ([IdConfiguracionSistemaUrls]
            ,[IdConfiguracionSistema]
			,[Url]
			,[TipoUrl]
			,[Usuario]
			,[Password]
			,[Parametros])
     VALUES
           (11
           ,1
           ,'https://localhost:44324/api/Message'
           ,'Notificaciones'
           ,''
           ,''
		   ,'')
	PRINT 'Insert ID 2'
END



GO


IF(1 >(select count(*) from [orden_owner].[Pizarra] where Idmoneda = 1))
BEGIN
INSERT INTO [orden_owner].[Pizarra]
           ( [IdMoneda]
           ,[PrecioCompra]
           ,[PrecioVenta])
     VALUES
           (1
           ,1
           ,1)
END

IF(1 >(select count(*) from [orden_owner].[Pizarra] where Idmoneda = 2))
BEGIN 
INSERT INTO [orden_owner].[Pizarra]
           ( [IdMoneda]
           ,[PrecioCompra]
           ,[PrecioVenta])
     VALUES
           (2
           ,136
           ,140)
END
GO

IF(1 >(select count(*) from [orden_owner].[Pizarra] where Idmoneda = 3))
BEGIN 
INSERT INTO [orden_owner].[Pizarra]
           ( [IdMoneda]
           ,[PrecioCompra]
           ,[PrecioVenta])
     VALUES
           (3
           ,160
           ,166)
END
GO

IF(1 >(select count(*) from [orden_owner].[Pizarra] where Idmoneda = 4))
BEGIN
INSERT INTO [orden_owner].[Pizarra]
           ( [IdMoneda]
           ,[PrecioCompra]
           ,[PrecioVenta])
     VALUES
           (4
           ,3.5
           ,6)
END
GO

IF(1 >(select count(*) from [orden_owner].[Pizarra] where Idmoneda = 5))
BEGIN
INSERT INTO [orden_owner].[Pizarra]
           ( [IdMoneda]
           ,[PrecioCompra]
           ,[PrecioVenta])
     VALUES
           (5
           ,25
           ,30)
END
GO


IF(1 >(select count(*) from [shared_owner].[TiposNotificacion] where IdTipoNotificacion = 1))
BEGIN
INSERT INTO [shared_owner].[TiposNotificacion]
           ( [IdTipoNotificacion]
           ,[Descripcion])
     VALUES
           (1
           ,'Successfully')
END
GO

IF(1 >(select count(*) from [shared_owner].[TiposNotificacion] where IdTipoNotificacion = 2))
BEGIN
INSERT INTO [shared_owner].[TiposNotificacion]
           ( [IdTipoNotificacion]
           ,[Descripcion])
     VALUES
           (2
           ,'Warning')
END
GO

IF(1 >(select count(*) from [shared_owner].[TiposNotificacion] where IdTipoNotificacion = 3))
BEGIN
INSERT INTO [shared_owner].[TiposNotificacion]
           ( [IdTipoNotificacion]
           ,[Descripcion])
     VALUES
           (3
           ,'Error')
END
GO
 
IF(1 >(select count(*) from [shared_owner].[TiposNotificacion] where IdTipoNotificacion = 4))
BEGIN
INSERT INTO [shared_owner].[TiposNotificacion]
           ( [IdTipoNotificacion]
           ,[Descripcion])
     VALUES
           (4
           ,'Info')
END
GO
 

IF(1 >(select count(*) from [shared_owner].[SubTiposNotificacion] where IdSubTipoNotificacion = 1))
BEGIN
INSERT INTO [shared_owner].[SubTiposNotificacion]
           ( [IdSubTipoNotificacion]
           ,[Descripcion])
     VALUES
           (1
           ,'Depósito Recibido')
END
GO

IF(1 >(select count(*) from [shared_owner].[SubTiposNotificacion] where IdSubTipoNotificacion = 2))
BEGIN
INSERT INTO [shared_owner].[SubTiposNotificacion]
           ( [IdSubTipoNotificacion]
           ,[Descripcion])
     VALUES
           (2
           ,'Depósito Realizado')
END
GO

IF(1 >(select count(*) from [shared_owner].[SubTiposNotificacion] where IdSubTipoNotificacion = 3))
BEGIN
INSERT INTO [shared_owner].[SubTiposNotificacion]
           ( [IdSubTipoNotificacion]
           ,[Descripcion])
     VALUES
           (3
           ,'Operación Realizada')
END
GO
   

