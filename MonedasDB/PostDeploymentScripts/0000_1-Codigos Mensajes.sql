--CODIGOS MENSAJES
DECLARE @Codigo varchar(100)
DECLARE @Mensaje varchar(500)

--FUNCIONAL EXCEPTION GENERALES
SET @Codigo = 'FE00001'
SET @Mensaje = 'Al querer dar de alta un {0} se ingreso un {1} ya existente, valor del campo: {2}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00002'
SET @Mensaje = 'Al querer dar de alta un {0} no se ingreso el campo ''{1}'', el cual es obligatorio'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00003'
SET @Mensaje = 'Al querer actualizar un {0} se ingreso un {1} ya existente, valor del campo: {2}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00004'
SET @Mensaje = 'Al querer actualizar un {0} no se ingreso el campo ''{1}'', el cual es obligatorio'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00005'
SET @Mensaje = 'No se encontro la entidad {0} que desea modificar. El identificador tiene el valor ''{1}'''
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00006'
SET @Mensaje = 'Al querer dar de alta una {0} se ingreso una combinacion de valores de campos existente:|| {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00007'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00008'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00009'
SET @Mensaje = 'Al querer modificar una {0} se ingreso una combinacion de valores de campos existente:|| {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00010'
SET @Mensaje = 'Error al querer dar de alta un {0}. El valor de la fecha "{1}" debe ser menor o igual que el valor de la fecha "{2}". Los valores ingresados son {3} <= {4}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00011'
SET @Mensaje = 'Se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}"'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00012'
SET @Mensaje = 'Se ha rechazado la novedad de la entidad "{0}" de código "{1}", acción "{2}"'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00013'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Emisor {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00014'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Producto {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00015'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Tipo de Documento {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00016'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Tipo de Persona {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00017'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Participante Mercado {3} - Tipo {4} - Participante {5}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00018'
SET @Mensaje = 'No se ha aprobado la novedad de la entidad "{0}" de código "{1}", acción "{2}". No existe el Tipo de Participante {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00019'
SET @Mensaje = 'No se ha rechazado la novedad de la entidad "{0}" de código "{1}", acción "{2}. Error técnico"'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00020'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00021'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00022'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00023'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00024'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00025'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00026'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00027'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00028'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó una combinacion de valores de campos existente: || {1} = {2} || {3} = {4} || {5} = {6} || {7} = {8} || {9} = {10} || {11} = {12} || {13} = {14}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00029'
SET @Mensaje = 'Al querer dar de alta un(a) {0} se ingresó ''{1}'' como valore de {2} pero no se ingreso valor para {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00030'
SET @Mensaje = 'Al querer modificar un(a) {0} se ingresó ''{1}'' como valore de {2} pero no se ingreso valor para {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00031'
SET @Mensaje = 'Al querer dar de alta un {0} se ingreso un {1} de largo diferente a {2}. Valor ingresado: {3}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00032'
SET @Mensaje = 'En la ejecución de {0} se no se encontró el campo {1} '
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00051'
SET @Mensaje = 'No se puede eliminar el/la {0} ya que NO existe uno/a con el id {1}.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00052'     
SET @Mensaje = 'Enviar al mercado Orden Nro: {0}. Msj: {1}'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00053'
SET @Mensaje = 'Error de comunicacion.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00054'     
SET @Mensaje = 'Ocurrio un error al cambiar de estado Orden Nro: {0}. Por favor, consulte'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00058'
SET @Mensaje = 'No se pudo eliminar un(a) {0} debido a que tiene {1} asociados'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00059'
SET @Mensaje = 'No se pudo eliminar un(a) {0} debido a que esta asociado a algun(a) otro(a) {0}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--FUNCIONAL EXCEPTION PARTICULARES
SET @Codigo = 'FE01001'
SET @Mensaje = 'Al querer dar de baja un {0} se encontraron ordenes activas que la utilizan'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE01002'
SET @Mensaje = 'Ya se ha modificado este registro de la entidad {0}, refresque la ventana.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE01003'
SET @Mensaje = 'Ya existe una persona de tipo Cartera Propia, para dar de alta una nueva, previamente debe dar de baja la existente.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE01004'
SET @Mensaje = 'Ya existe una persona de tipo Cartera Propia, para modificar a tipo de persona Cartera Propia, previamente debe dar de baja la existente.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE01005'
SET @Mensaje = 'La orden Nro:{0}.|| || Debe encontrarse en estado: {1}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE01006'
SET @Mensaje = 'Se alcanzo la maxima cantidad posible para agregar al portfolio.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

-- MENSAJES DE ERROR
SET @Codigo = 'E100006'
SET @Mensaje = 'El nombre de usuario y/o contraseña ingresados son incorrectos. El acceso al sistema ha sido denegado.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100008'
SET @Mensaje = 'El usuario {0} se encuentra bloqueado. La aplicación se cerrará.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100011'
SET @Mensaje = 'La cuenta del usuario {0} ha expirado.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100012'
SET @Mensaje = 'Superó la cantidad máxima de intentos. Se bloqueará la cuenta del usuario.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100802'
SET @Mensaje = 'Acceso sin permiso.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100014'
SET @Mensaje = 'No tiene permiso para {0} en la acción {1}.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100015'
SET @Mensaje = 'La sesión ha expirado.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100020'
SET @Mensaje = 'La contraseña propuesta y su verificación no coinciden.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100021'
SET @Mensaje = 'La contraseña propuesta no tiene la cantidad mínima de caracteres numéricos y alfabéticos requeridos {0}.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100022'
SET @Mensaje = 'La contraseña propuesta debe ser diferente a las últimas {0} utilizadas.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100060'
SET @Mensaje = 'No se pudo actualizar información del último login exitoso.||||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100061'
SET @Mensaje = 'Se ha excedido el límite de tiempo de inactividad.  Se bloqueará la cuenta del usuario.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100062'
SET @Mensaje = 'La contraseña actual ingresada es incorrecta.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100132'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede ser igual al nombre de usuario: {0}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100133'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener caracteres que no sean alfabéticos o númericos: {0}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100134'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres alfabéticos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100135'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres númericos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100136'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener más de {0} caracteres consecutivos repetidos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100139'
SET @Mensaje = 'Error al cambiar clave.|| ||La nueva clave y la actual no puden ser iguales.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100553'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres en minúculas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100554'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener menos de {0} caracteres en mayúsculas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100555'
SET @Mensaje = 'Error al cambiar clave.|| || La clave no puede contener menos de {0} símbolos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'E100557'
SET @Mensaje = 'No existe la acción con ID {0}.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
-- MESNAJES DE WARNING

SET @Codigo = 'W100002'
SET @Mensaje = 'Debe cambiar la contraseña.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

-- MESNAJES DE INFORMACION

SET @Codigo = 'I100000'
SET @Mensaje = 'INFO: OK'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'I100002'
SET @Mensaje = 'Inicio de sesión correcto.  Usuario: {0}.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'I100004'
SET @Mensaje = 'Modificación exitosa de contraseña.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'I100010'
SET @Mensaje = 'Cierre de sesión exitoso.  Usuario: {0}'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--LITERALES

SET @Codigo = 'LBL_ACCESOCONSULTA'     
SET @Mensaje = 'Acceso/Consulta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ATRIBUTOS_DE_REGLA'     
SET @Mensaje = 'Atributos de Regla'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACCION'     
SET @Mensaje = 'Acción'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACCION_DEMORANDO_DE_MAS'     
SET @Mensaje = 'La acción esta demorando más de lo previsto. Espere a que termine...'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACEPTAR'     
SET @Mensaje = 'Aceptar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACTUALIZACION_DE'     
SET @Mensaje = 'Actualizacion de {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACTUALIZAR_DE'     
SET @Mensaje = 'Actualizar {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ADMINISTRACION_ORDEN'     
SET @Mensaje = 'Administración Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ADMINISTRACION_ORDENES'     
SET @Mensaje = 'Administración Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ALTA'     
SET @Mensaje = 'Alta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ALTA_DE'     
SET @Mensaje = 'Alta de {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ANULAR_CONFIRMACION'     
SET @Mensaje = 'Anular Confirmación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ANULAR_CONFIRMACION_ORDEN'     
SET @Mensaje = 'Anular Confirmación de Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ANULARCONFIRMACIONORDEN'     
SET @Mensaje = 'Anular Confirmación de Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APLICACION'     
SET @Mensaje = 'Aplicación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APLICACION_NO_PUEDE_CONECTARSE_SERVIDOR'     
SET @Mensaje = 'La aplicacion no puede conectarse al servidor o el servidor no puede responder a la peticion. Intente mas tarde.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APLICADA'     
SET @Mensaje = 'Aplicada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APLICADA_PARCIAL'     
SET @Mensaje = 'Aplicada Parcial'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBAR'     
SET @Mensaje = 'Aprobar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBAR_NOVEDAD'     
SET @Mensaje = 'Aprobar Novedad'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBAR_NOVEDAD_ORDEN'     
SET @Mensaje = 'Va a aprobar la novedad de la orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBAR_NOVEDAD_SELECCIOANDA'     
SET @Mensaje = 'Va a aprobar las novedades seleccionadas. '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBARNOVEDADES'     
SET @Mensaje = 'Aprobar Novedades - Resúmen de ejecución'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBAUTOMATICA'     
SET @Mensaje = 'Aprob. automática'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_AREADENEGOCIODESCRIPCION'     
SET @Mensaje = 'Area de negocio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_AREANEGDESCRIP'     
SET @Mensaje = 'Area de Negocio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_AREANEGOCIO'     
SET @Mensaje = 'Área de Negocio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_AREANEGOCIODESCRIPCION'     
SET @Mensaje = 'Área de negocio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_AREANEGOCIOS'     
SET @Mensaje = 'Area de Negocios'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASGINAR_OPERACION_ORDEN'     
SET @Mensaje = 'Asignar Operacion a la Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASIGNACIONOFERTAOPERACION'     
SET @Mensaje = '(*)Asignación Oferta - Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASIGNACIONOFERTAOPERACIONDESCRIPCION'     
SET @Mensaje = 'Asignación Oferta - Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASIGNACIONORDENOFERTA'     
SET @Mensaje = '(*)Asignación Orden - Oferta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASIGNACIONORDENOFERTADESCRIPCION'     
SET @Mensaje = 'Asignación Orden - Oferta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASIGNAR_ORDEN_OPERACION'     
SET @Mensaje = 'Asignar Orden a Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ATENCION'     
SET @Mensaje = 'Atención'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ATRIBUTOS_DE_BUSQUEDA'     
SET @Mensaje = 'Atributos de Búsqueda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BAJA'     
SET @Mensaje = 'Baja'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BAJA_DE'     
SET @Mensaje = 'Baja de {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BAJACOMPETENCIA'     
SET @Mensaje = 'Baja de Competencia Accion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BIENVENIDO_WEB'     
SET @Mensaje = 'Bienvenido a Order Router'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BLOQUEADA'     
SET @Mensaje = 'Bloqueada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BLOQUEAR_ORDEN'     
SET @Mensaje = 'Bloquear Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BLOQUEARORDEN'     
SET @Mensaje = 'Bloquear Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOOK'     
SET @Mensaje = 'Book'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_ACTUALIZA'     
SET @Mensaje = 'Modificar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_ALTA'     
SET @Mensaje = 'Alta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_ANCLAR'     
SET @Mensaje = 'Anclar a pantalla de inicio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_AUDITORIA'     
SET @Mensaje = 'Auditoría'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_BUSCAR'     
SET @Mensaje = 'Buscar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_CERRAR'     
SET @Mensaje = 'Cerrar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_COPIAR_CELDA'     
SET @Mensaje = 'Copiar celda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_COPIAR_FILA'     
SET @Mensaje = 'Copiar fila'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_ELIMINAR'     
SET @Mensaje = 'Eliminar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_EXPORTA_EXCEL'     
SET @Mensaje = 'Exportar a excel'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_LIMPIAR_FILTROS'     
SET @Mensaje = 'Limpiar filtros'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BOTON_VISTA'     
SET @Mensaje = 'Ver'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BUSCAR'     
SET @Mensaje = 'Buscar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BUSCAR_POR'     
SET @Mensaje = 'Buscar por '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BUSCAR_TITULO'     
SET @Mensaje = 'Buscar {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BUSQEUDA_AVANZADA'     
SET @Mensaje = 'Busqueda avanzada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CAMPO_CARGADO_INCORRECTAMENTE'     
SET @Mensaje = 'Este campo no está cargado correctamente.  '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CAMPOS_SIN_FORMATO_ADECUADO'     
SET @Mensaje = 'Algunos campos no tienen el formato o el valor adecuado para la carga. Corrija y vuelva a <kbd>ACEPTAR</kbd>'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANAL'     
SET @Mensaje = 'Canal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANALDESCRIP'     
SET @Mensaje = 'Canal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANALDESCRIPCION'     
SET @Mensaje = 'Canal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANCELADA'     
SET @Mensaje = 'CANCELADA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANCELAR'     
SET @Mensaje = 'Cancelar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANCELARORDEN'     
SET @Mensaje = 'Cancelar la Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDAD'     
SET @Mensaje = 'Cantidad'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDAD_ESTADOS'     
SET @Mensaje = 'Por Omisión'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADEJECUTADA'     
SET @Mensaje = 'Ejecutada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADESTADOS'     
SET @Mensaje = 'Cantidad Estados'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADESTADOSMAX'     
SET @Mensaje = 'Máximo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADESTADOSMIN'     
SET @Mensaje = 'Mínimo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADREMANENTE'     
SET @Mensaje = 'Remanente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADREMANTE'     
SET @Mensaje = 'Cantidad Remanente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADSELECCIONADANODEBEEXCEDERORDEN'     
SET @Mensaje = 'La Cantidad seleccionada no debe superar la cantidad de la orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTMONT'     
SET @Mensaje = 'Cantidad / Monto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTMONTO'     
SET @Mensaje = 'Cantidad / Monto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CAPITALESPECIE'     
SET @Mensaje = 'Capital Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CAPITALOPERACION'     
SET @Mensaje = 'Capital Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CARGA_FINALIZADA_EXITOSA'     
SET @Mensaje = 'Carga finalizada con exito'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CARGANDO'     
SET @Mensaje = 'Cargando...'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CARTERA_PROPIA'     
SET @Mensaje = 'Cartera propia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CATEGORIA'     
SET @Mensaje = 'Categoría'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CIERREAUTOMATICO'     
SET @Mensaje = 'Cierre automatico?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CLASEOPERACIONDESCRIPCION'     
SET @Mensaje = 'Compra Venta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGO'     
SET @Mensaje = 'Código'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGO_ERROR_ESP'     
SET @Mensaje = 'Codigo de Error: {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGO_ERROR_NRO_ID'     
SET @Mensaje = 'Codigo de Error: {0}, Numero de identificacion de incidente: {1}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGO_GRUPO'     
SET @Mensaje = 'Código Grupo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGOESPECIE'     
SET @Mensaje = 'Código'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CODIGOESPECIEVISIBLE'     
SET @Mensaje = 'Código'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_COMPRAOVENTA'     
SET @Mensaje = 'Compra Venta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_COMPRAVENTA'     
SET @Mensaje = 'CV'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_COMPRAVENTADESCRIPCION'     
SET @Mensaje = 'Clase operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIGURACION_BOLETOS_ORDEN'     
SET @Mensaje = 'Configuración de Boleto de Ordene'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIGURACION_BOLETOS_ORDENES'     
SET @Mensaje = 'Configuración de Boleto de Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIGURACION_COLUMNA'     
SET @Mensaje = 'Configuración Columna'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIGURACIONSEGUN'     
SET @Mensaje = 'Configuración Según'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIGURACIONSEGUNDESCRIPCION'     
SET @Mensaje = 'Configuración Segun'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMA_ELIMINAR_REGISTROS'     
SET @Mensaje = '¿Esta seguro que quiere eliminar los registros seleccionados?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMA_VINCULACION'     
SET @Mensaje = 'Confirmar Vinculación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMAOPERACIONAMERCADO'     
SET @Mensaje = 'Va a enviar al mercado a la orden nùmero {0}. ¿Está seguro?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMAR'     
SET @Mensaje = 'Confirmar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMARACCION'     
SET @Mensaje = 'Confirmar Acción '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMARRORDEN'     
SET @Mensaje = 'Confirmar Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONTRASENIA'     
SET @Mensaje = 'Contraseña'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_COTIZADA'     
SET @Mensaje = 'Cotizada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CREAR_OPERACION'     
SET @Mensaje = 'Crear Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CREAR_OPERACION_ORDEN'     
SET @Mensaje = 'Crear Operacion a partir de la Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CREAROPERACIONDESDEORDEN'     
SET @Mensaje = 'Crear Operación desde Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CUENTA_MONETARIA'     
SET @Mensaje = 'Cuenta Monetaria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CUENTA_TENENCIA'     
SET @Mensaje = 'Cuenta Tenencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DATOS_CONTACTO'     
SET @Mensaje = 'Tambien puede comunicarse por telefono al +54 11 4590 6600 en el horario de 10hs a 18hs de Lunes a Viernes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEBE_SELECIONAR_UN_REGISTRO'     
SET @Mensaje = 'Debe seleccionar un registro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEBESELECCIONAROPERACION'     
SET @Mensaje = 'Debe seleccionar una operación.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEBESELECCIONARUNAFILA'     
SET @Mensaje = 'Debes seleccionar al menos una fila'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEBESELECCIONARUNAORDEN'     
SET @Mensaje = '"Debe seleccionar una orden."'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEMORA'     
SET @Mensaje = 'DEMORA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEPURAR'     
SET @Mensaje = 'Depurar '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DEPURARORDEN'     
SET @Mensaje = 'Depurar Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DESANCLAR_PANTALLA'     
SET @Mensaje = 'Desanclar pantalla'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DESBLOQUEARORDEN'     
SET @Mensaje = 'Desbloquear Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DESCRIPCION'     
SET @Mensaje = 'Descripción'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DIASHORAS'     
SET @Mensaje = 'Tipo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EJECUTAR'     
SET @Mensaje = 'Ejecutar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EMPRESA'     
SET @Mensaje = 'Empresa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EMAIL'
SET @Mensaje = 'Email'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EMPRESADESCRIP'     
SET @Mensaje = 'EmpresaDescrip'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EMPRESADESCRIPCION'     
SET @Mensaje = 'Empresa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ENVIAR_AL_MERCADO'     
SET @Mensaje = 'Enviar al Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ENVIAR_AL_MERCADO_AUT'     
SET @Mensaje = 'Enviar al Mercado (automáticamente) '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ENVIOMERCADO'     
SET @Mensaje = 'Envío al Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERORR_RECUPERAR DATOS'     
SET @Mensaje = 'Error al recuparar datos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_404'     
SET @Mensaje = '"404 Pagina no encontrada"'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_APROBANDO_ORDEN'     
SET @Mensaje = 'Error aprobando novedad de orden - '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_DATOS'     
SET @Mensaje = 'Nro. Error de Datos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_RECHAZANDO_ORDEN'     
SET @Mensaje = 'Error rechazando novedad de orden - '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_RECUPERAR_DATOS'     
SET @Mensaje = 'Error al recuperar datos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_SERVIDOR'     
SET @Mensaje = 'Error en Servidor'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_TECNICO'     
SET @Mensaje = 'Error tecnico'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERROR_VALIDACION'     
SET @Mensaje = 'Error de Validacion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERRORRECUPERARCANTIDADMONTO'     
SET @Mensaje = 'Error al recuperar la cantidad o monto estimado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERRORRECUPERARFECHAVENCIMIENTO'     
SET @Mensaje = 'Error al recuperar la fecha de vencimiento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ERRRORRECUPERARCANTIADADFUTURO'     
SET @Mensaje = 'Error al recuperar la cantidad o monto estimado futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESINTERNO'     
SET @Mensaje = 'Es Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESPECIE'     
SET @Mensaje = 'Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESPECIEDESCRIPCION'     
SET @Mensaje = 'Desc. Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTA_SEGURO'     
SET @Mensaje = '¿Está seguro?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADO'     
SET @Mensaje = 'Estado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOGLOBALDESCRIPCION'     
SET @Mensaje = 'Estado Global Descripcion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOINTERNODESC'     
SET @Mensaje = 'Estado Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOINTERNODESCRIPCION'     
SET @Mensaje = 'Estado de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOMERCADODESC'     
SET @Mensaje = 'Estado Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOMERCADODESCRIPCION'     
SET @Mensaje = 'Estado Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTADOSSELECCIONADOS'     
SET @Mensaje = 'Estado Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESTRUCTURA_INTERNA'     
SET @Mensaje = 'Estructura Interna'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXITO_APROBANDO_NOVEDAD_ORDEN'     
SET @Mensaje = '"Exito aprobando novedad de orden - '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXITOSO'     
SET @Mensaje = 'EXITOSA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXPIRADA'     
SET @Mensaje = 'Expirada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXPORTAR_DATOS'     
SET @Mensaje = 'Exportar Datos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXPORTAR_DATOS_EXCEL'     
SET @Mensaje = 'Exportar datos a Excel'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXPORTAR_DATOS_PDF'     
SET @Mensaje = 'Exportar datos a PDF'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EXPORTAR_DETALLES_EXCEL'     
SET @Mensaje = 'Exportar detalles a Excel'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHA_HORA'     
SET @Mensaje = 'Fecha/Hora'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHA_ULTIMA_MODIFICACION'     
SET @Mensaje = 'Fecha Última Modificación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAALTA_DESDE'     
SET @Mensaje = 'Fecha Carga Desde'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAALTA_HASTA'     
SET @Mensaje = 'Fecha Carga Hasta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAALTAFECHA'     
SET @Mensaje = 'Fecha Alta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAALTAHORA'     
SET @Mensaje = 'Hora Alta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACARGA'     
SET @Mensaje = 'Fecha Carga'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACION'     
SET @Mensaje = 'Fecha de concertación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACION_DESDE'     
SET @Mensaje = 'Fecha Alta Desde'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACION_HASTA'     
SET @Mensaje = 'Fecha Alta Hasta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACIONFECHA'     
SET @Mensaje = 'Fecha Concertación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACIONHORA'     
SET @Mensaje = 'Hora Concertación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAHORA'     
SET @Mensaje = 'Fecha/Hora'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAULTIMAMODIFICACION'     
SET @Mensaje = 'Fecha Última Modificación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCESPECIE'     
SET @Mensaje = 'Fecha Venc. Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCESPECIEFUTURO'     
SET @Mensaje = 'Fecha Venc. Especie Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCLIQUIDADOR_MONEDA'     
SET @Mensaje = 'Fecha Venc. Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCLIQUIDADOR_PRODUCTO'     
SET @Mensaje = 'Fecha Venc. Prod.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCMONEDA'     
SET @Mensaje = 'Fecha Venc. Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCMONEDAFUTURO'     
SET @Mensaje = 'Fecha Venc. Moneda Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVIGENCIA'     
SET @Mensaje = 'Fecha Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVIGENCIAFECHA'     
SET @Mensaje = 'Fecha Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVIGENCIAHORA'     
SET @Mensaje = 'Hora Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FUENTEPRECIOCLIENTE'     
SET @Mensaje = 'Fuente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FUENTEPRECIOCLIENTEDESCRIPCION'     
SET @Mensaje = 'Fuente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FUENTEPRECIOTRANSFERENCIA'     
SET @Mensaje = 'Fuente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GENERAROPERACIONESCLIENTES'     
SET @Mensaje = 'Generar Operaciones Cliente (Automáticamente)'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GRUPOECONOMICODESC'     
SET @Mensaje = 'Grupo Económico'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GRUPOESPECIE'     
SET @Mensaje = 'Grupo Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GRUPOESPECIEDESCRIPCION'     
SET @Mensaje = 'Grupo de especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GRUPOESPECIESDESCRIPCION'     
SET @Mensaje = 'Grupo especies'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GUARDO_EXITOSAMENTE_ESCRITORIO'     
SET @Mensaje = 'Se guardo exitosamente el escritorio.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_HABILITADODEFECTO'     
SET @Mensaje = 'Habilitado Defecto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_HORAALTA'     
SET @Mensaje = 'Hora Alta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_HORAVIGENCIA'     
SET @Mensaje = 'Hora Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ID'     
SET @Mensaje = 'ID'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ID_ENTIDAD'     
SET @Mensaje = 'IdEntidad'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDACCION'     
SET @Mensaje = 'Acción'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDAREANEGOCIO'     
SET @Mensaje = 'Area de negocio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCANAL'     
SET @Mensaje = 'Canal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCLASEOPERACION'     
SET @Mensaje = '(*)Compra Venta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCLASEOPERACIONDESCRIPCION'     
SET @Mensaje = 'Clase de Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCUENTAESPECIE'     
SET @Mensaje = 'ID'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCUENTAMONEDA'     
SET @Mensaje = 'ID'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDCV'     
SET @Mensaje = 'Compra Venta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDEMPRESA'     
SET @Mensaje = 'Empresa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTELIQUIDADORESPECIE'     
SET @Mensaje = 'Ente Liquidador Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTELIQUIDADORESPECIEFUTURO'     
SET @Mensaje = 'Ente Liq. Especie Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTELIQUIDADORFUTUROMONEDA'     
SET @Mensaje = 'Ente Liq. Moneda Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTELIQUIDADORMONEDA'     
SET @Mensaje = 'Ente Liq. Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTELIQUIDADORPRODUCTO'     
SET @Mensaje = 'Ente Liq. Producto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTIDAD'     
SET @Mensaje = 'Id Entidad'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDESPECIE'     
SET @Mensaje = 'ID'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDGRUPOESPECIE'     
SET @Mensaje = 'Grupo Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDGRUPOESPECIES'     
SET @Mensaje = 'IdGrupoEspecies'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDMERCADO'     
SET @Mensaje = 'Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDMESA'     
SET @Mensaje = 'Mesa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDMONEDA'     
SET @Mensaje = 'Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDMONEDADESTINO'     
SET @Mensaje = 'Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDMOTIVO'     
SET @Mensaje = 'Motivo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDNUMERADOR'     
SET @Mensaje = '(*)Numerador'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDOPASIGNAR'     
SET @Mensaje = 'idopasignar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDPLANTILLA'     
SET @Mensaje = '(*)Plantilla'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDPLATAFORMA'     
SET @Mensaje = 'Plataforma'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDPRODUCTO'     
SET @Mensaje = 'Descripción especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDREGIONGEOGRAFICA'     
SET @Mensaje = 'Región Geográfica'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDROL'     
SET @Mensaje = 'Perfil'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDRUEDA'     
SET @Mensaje = 'Rueda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSECTORINTERNO'     
SET @Mensaje = 'Sector Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSEGMENTO'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSEGMENTOPRECIOCLIENTE'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSEGMENTOPRECIOCLIENTEDESCRIPCION'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSEGMENTOPRECIOTRANSFERENCIA'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDSUCURSAL'     
SET @Mensaje = 'Sucursal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPODECONFIRMACION'     
SET @Mensaje = 'Ingreso por'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPODEORDEN'     
SET @Mensaje = '(*)Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPODEORDENDESCRIPCION'     
SET @Mensaje = 'Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPODEVIGENCIA'     
SET @Mensaje = 'Tipo de Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOLIQUIDACION'     
SET @Mensaje = 'Tipo de liquidación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPONEGOCIACION'     
SET @Mensaje = 'Tipo de Negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPONEGOCIACION_BOL'     
SET @Mensaje = 'Tipo de Negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPONEGOCIACION_BOLDESCRIPCION'     
SET @Mensaje = 'Tipo de Negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOOPERACION'     
SET @Mensaje = 'Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOOPERATORIA'     
SET @Mensaje = 'Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOORDEN'     
SET @Mensaje = 'Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOPARTICIPANTE'     
SET @Mensaje = 'Tipo de Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOPARTICIPANTE_BOL'     
SET @Mensaje = 'Tipo de Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOPARTICIPANTE_BOLDESCRIPCION'     
SET @Mensaje = 'Tipo de Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTRAMO'     
SET @Mensaje = 'Tramo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDUSUARIO'     
SET @Mensaje = 'Usuario'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDZONA'     
SET @Mensaje = 'Zona'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IMPORTACION'     
SET @Mensaje = 'Importación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IMPRIMIR_CONFIRMACION_ORDEN'     
SET @Mensaje = 'Imprimir Confirmacion Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IMPRIMIR_DETALLES'     
SET @Mensaje = 'Impimir detalles'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IMPRIMIRORDEN'     
SET @Mensaje = 'Imprimir Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INC_PRECIO_PARCIAL'     
SET @Mensaje = 'Incompl. Por Precio Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INC_PRECIO_TRANSFERENCIA'     
SET @Mensaje = 'Incompl. Por Precio Transferencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INGRESADA'     
SET @Mensaje = 'Ingresada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INGRESANDO'     
SET @Mensaje = 'Ingresando'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INGRESAR'     
SET @Mensaje = 'Ingresar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INGRESO_AL_SISTEMA'     
SET @Mensaje = 'Ingreso al Sistema'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INGRESO_PRECIO'     
SET @Mensaje = 'Ingreso Precio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_Inicio'     
SET @Mensaje = 'Inicio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INTERESCUPON'     
SET @Mensaje = 'Interés Cupón'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_INTERESOPERACION'     
SET @Mensaje = 'Interés Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IP'     
SET @Mensaje = 'IP'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ISDETALLE'     
SET @Mensaje = 'IsDetalle'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_ADMINISTRACION'     
SET @Mensaje = 'Administración'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_AGREGANDO_NUMERADORES'     
SET @Mensaje = 'Agregando Numeradores'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_AUDITORIA'     
SET @Mensaje = 'Auditoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_BANDEJA_NOVEDAD'     
SET @Mensaje = 'Bandeja De Novedades'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_COMPTENCIAS'     
SET @Mensaje = 'Competencias'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ASIGNACION_ORDENES'     
SET @Mensaje = 'Configuración de Asignacion de Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ATRIBUTOS'     
SET @Mensaje = 'Configuración de atributos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ATRIBUTOS_ORDENES'     
SET @Mensaje = 'Configuración de Atributos de órdenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_BOLETO_ORDENES'     
SET @Mensaje = 'Configuración de boletos Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_COMPETENCIAS'     
SET @Mensaje = 'Configuraciones Competencias'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ESTADOS'     
SET @Mensaje = 'Configuración de Estados'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ESTADOS_ORDENES'     
SET @Mensaje = 'Configuración de Estados Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CONFIGURACION_ORDENES'     
SET @Mensaje = 'Configuración de Asignación Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_DESCONECTAR'     
SET @Mensaje = 'Desconectar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_EDICION'     
SET @Mensaje = 'Edición'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_ESTADOS'     
SET @Mensaje = 'Estados'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_NUMERADORES'     
SET @Mensaje = 'Numeradores'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_ORDENES'     
SET @Mensaje = 'Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_PARAMETROS'     
SET @Mensaje = 'Parametros'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_PLIEGOS'     
SET @Mensaje = 'Pliegos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_VINCULACION'     
SET @Mensaje = 'Vinculación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_VINCULACION_ORDENES'     
SET @Mensaje = 'Vinculación Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MERCADO'     
SET @Mensaje = 'Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MERCADODESCRIP'     
SET @Mensaje = 'Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MERCADODESCRIPCION'     
SET @Mensaje = 'Mercado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MESA'     
SET @Mensaje = 'Mesa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MESADESCRIP'     
SET @Mensaje = 'Mesa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MESADESCRIPCION'     
SET @Mensaje = 'Mesa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MODAL_TITLE'     
SET @Mensaje = 'Modal title'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MODIFICACION'     
SET @Mensaje = 'Modificación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONEDACODIGO'     
SET @Mensaje = 'Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONEDADESCRIP'     
SET @Mensaje = 'Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONEDADESCRIPCION'     
SET @Mensaje = 'Moneda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONEDAS'     
SET @Mensaje = 'Monedas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONTO_CLIENTE'     
SET @Mensaje = 'Monto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONTO_TRANSFERENCIA'     
SET @Mensaje = 'Monto Transferencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONTOESTIMADO'     
SET @Mensaje = 'Monto Estimado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONTOESTIMADOFUTURO'     
SET @Mensaje = 'Monto Estimado Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MONTOESTIMADOTRANSFERENCIA'     
SET @Mensaje = 'Monto Estimado Transf.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOSTRAR_OCULTAR'     
SET @Mensaje = 'Mostrar/Ocultar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOTIVO'     
SET @Mensaje = 'Motivo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOTIVOBAJADESCRIP'     
SET @Mensaje = 'Motivo Baja'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOTIVORECHAZODESCRIPCION'     
SET @Mensaje = 'Motivo Rechazo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NEGOCIACIONDESCRIPCION'     
SET @Mensaje = 'Tipo de Negociacion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NO_HAY_DATOS_PARA_RESTAURAR'     
SET @Mensaje = 'No hay datos para restaurar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NO_HAY_REGISTROS_PARA_EL_FILTRO'     
SET @Mensaje = 'NO HAY REGISTROS CON EL FILTRO SELECCIONADO'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NO_VIGENTE'     
SET @Mensaje = ' No Vigente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOHAYMOVIMIENTOS'     
SET @Mensaje = 'NO HAY MOVIMIENTOS'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBRE_PARTICIPANTE'     
SET @Mensaje = 'Nombre Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBREESPECIE'     
SET @Mensaje = 'Descripción Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBREPARTICIPANTE'     
SET @Mensaje = 'Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBREPERSONA'     
SET @Mensaje = 'Persona'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBRECOMPLETO'
SET @Mensaje = 'Nombre Completo'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOSERECONOCETIPOINGRESO'     
SET @Mensaje = 'No se reconoce el tipo de ingreso: '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NRO_OPERACION'     
SET @Mensaje = 'Nro. Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NRO_OPERACION_BOLETO'     
SET @Mensaje = 'Nro. Operacion Boleto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROCLIENTE'     
SET @Mensaje = 'Nro. Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROCLIENTEPARTICIPANTE'     
SET @Mensaje = 'Nro. Cliente Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROCLIENTEVISIBLE'     
SET @Mensaje = 'Nro. Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROCUENTADEPOSITANTE'     
SET @Mensaje = 'Cta. Depositante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NRODOCUMENTO'     
SET @Mensaje = 'Nro. Documento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROOPERACION'     
SET @Mensaje = 'Nro. Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROOPERACIONDESCRIPCION'     
SET @Mensaje = 'Nro. Operacion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROOPERACIONORDEN'     
SET @Mensaje = 'Nro Operación Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROOPERACIONSE'     
SET @Mensaje = 'Número Operación SE'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NROORDENVINCULADA'     
SET @Mensaje = 'Nro. orden Vinc.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUEVA'     
SET @Mensaje = 'Nueva'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERADOR'     
SET @Mensaje = 'Numerador'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO'     
SET @Mensaje = 'Nro. orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_BOLETA'     
SET @Mensaje = 'Nro. Boleto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_BOLETO'     
SET @Mensaje = 'Nro. Boleto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_CLIENTE'     
SET @Mensaje = 'Nro. Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_CUPON'     
SET @Mensaje = 'Número Cupón'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_CUPON_OPERACION'     
SET @Mensaje = 'Número Cupón Operación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_DOCUMENTO'     
SET @Mensaje = 'Número Documento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERO_ORDEN'     
SET @Mensaje = 'Nro. Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROBOLETO'     
SET @Mensaje = 'Número Boleto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROCUENTAMONEDA'     
SET @Mensaje = 'Nro Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROCUENTAMONEDAVISIBLE'     
SET @Mensaje = 'Nro Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROCUENTATENENCIA'     
SET @Mensaje = 'Nro Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROCUENTATENENCIAVISIBLE'     
SET @Mensaje = 'Nro Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROCUPON'     
SET @Mensaje = 'Número Cupón'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMERODOCUMENTO'     
SET @Mensaje = 'Nro. Documento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NUMEROORDEN'     
SET @Mensaje = 'Número Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OBSERVACIONES'     
SET @Mensaje = 'Observaciones'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OBTENERSALDOESPECIE'     
SET @Mensaje = 'Permite obtener saldo especie?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OBTENERSALDOMONEDA'     
SET @Mensaje = 'Permite obtener saldo moneda?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OK'     
SET @Mensaje = 'OK'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OPERADOR'     
SET @Mensaje = 'Operador'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OPERATORIADESCRIPCION'     
SET @Mensaje = 'Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ORDEN_NUMEROS'     
SET @Mensaje = 'Orden Numeros: '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PAGINA_ACTUAL'     
SET @Mensaje = 'Página actual'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PANTALLA_SIN_NOMBRE'     
SET @Mensaje = 'PANTALLA SIN NOMBRE'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PARTICIPANTECOMPRADORDESCRIPCION'     
SET @Mensaje = 'Participante Comprador'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PARTICIPANTEDESC'     
SET @Mensaje = 'Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PARTICIPANTEVENDEDORDESCRIPCION'     
SET @Mensaje = 'Participante Vendedor'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERFIL'     
SET @Mensaje = 'Perfil'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERFILDESCRIPCION'     
SET @Mensaje = 'Perfil'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERIODO_DESDE'     
SET @Mensaje = 'Periodo Desde'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERIODO_HASTA'     
SET @Mensaje = 'Periodo Hasta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMISO'     
SET @Mensaje = 'Permiso'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMISO_EJECUTADO'     
SET @Mensaje = 'Permiso Ejecutado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEBENEFICIARIOEXTERIOR'     
SET @Mensaje = '(*)Permite Beneficiario Exterior'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEBENEFICIARIOEXTERIORDESCRIPCION'     
SET @Mensaje = 'Beneficiario Exterior'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEINVERTIRMONTOS'     
SET @Mensaje = 'Permite monto a invertir?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEREFERENCIAEXTERIOR'     
SET @Mensaje = '(*)Permite Referencia Exterior'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEREFERENCIAEXTERIORDESCRIPCION'     
SET @Mensaje = 'Referencia Exterior'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PH_BUSCAR'     
SET @Mensaje = 'Buscar...'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PH_CONTRASENIA'     
SET @Mensaje = 'Contraseña'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PH_NOMBRE_USUARIO'     
SET @Mensaje = 'Nombre de Usuario'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PLANTILLA'     
SET @Mensaje = 'Plantilla'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PLATAFORMA'     
SET @Mensaje = 'Plataforma'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PLATAFORMADESCRIPCION'     
SET @Mensaje = 'Plataforma'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIO_LIMITE'     
SET @Mensaje = 'Precio Límite'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIO_REFERENCIA'     
SET @Mensaje = 'Precio Referencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIO_TASA_CLIENTE'     
SET @Mensaje = 'Precio/Tasa Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIO_TASA_TRANSFERENCIA'     
SET @Mensaje = 'Precio/Tasa Transferencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOCLIENTETIPOUSO'     
SET @Mensaje = 'Tipo Uso'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOLIMITE'     
SET @Mensaje = 'Precio/Tasa Limite'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOPROMEDIO'     
SET @Mensaje = 'Precio Promedio'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOREFERENCIA'     
SET @Mensaje = 'Precio Referencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOTASA'     
SET @Mensaje = 'Precio/Tasa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOTASAFUTURO'     
SET @Mensaje = 'Precio/Tasa Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOTASATRANSFERENCIA'     
SET @Mensaje = 'Precio/Tasa Transferencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOTRANSFERENCIATIPOUSO'     
SET @Mensaje = 'Tipo Uso '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRINCIPAL'     
SET @Mensaje = 'Principal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PROCESANDO_RESTAURACION'     
SET @Mensaje = 'Procesando la restauración'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTOCODIGO'     
SET @Mensaje = 'Producto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTODESCRIPCION'     
SET @Mensaje = 'Descripción especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTOSCODIGO'     
SET @Mensaje = 'Especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTOSDESCRIP'     
SET @Mensaje = 'Descripción especie'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_QUIERESELECCIONARORDENPARAOPERACION'     
SET @Mensaje = 'Va a asignar la orden nùmero {0} (cantidad {1}) a la operación número {2} (cantidad {3}). ¿Está seguro?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RECHAZAR'     
SET @Mensaje = 'Rechazar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RECHAZAR_NOVEDADES_ORDENDES'     
SET @Mensaje = 'Rechazar Novedades de Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RECHAZARNOVEDADES'     
SET @Mensaje = 'Rechazar Novedades - Resúmen de ejecución'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RECURSO_NO_ENCONTRADO'     
SET @Mensaje = 'El servidor Web no pudo encontrar el recurso solicitado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REFERENCIA_1'     
SET @Mensaje = 'Referencia 1'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REFERENCIA_2'     
SET @Mensaje = 'Referencia 2'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REFERENCIAS'     
SET @Mensaje = 'Referencias'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REGIONGEOGRAFICA'     
SET @Mensaje = 'Región Geográfica'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REGIONGEOGRAFICADESCRIPCION'     
SET @Mensaje = 'Region Geografica'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RELANZAR'     
SET @Mensaje = 'Relanzar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RELANZARORDEN'     
SET @Mensaje = 'Relanzar Orden '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RENOVARORDEN'     
SET @Mensaje = 'Renovar la Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REPORTAR_ERROR_MAE'     
SET @Mensaje = 'Reportar este problema a MAE'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERECODIGOOPERACIONBCRA'     
SET @Mensaje = '(*)Requiere Código de Operación Banco Central'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERECODIGOOPERACIONBCRADESCRIPCION'     
SET @Mensaje = 'Código BCRA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERECONCEPTOBANCOCENTRAL'     
SET @Mensaje = '(*)Requiere Concepto Banco Central'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERECONCEPTOBANCOCENTRALDESCRIPCION'     
SET @Mensaje = 'Concepto BCRA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERECONTROLCONFORMACIONFIRMAS'     
SET @Mensaje = 'Solicitar conformación de firmas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREINSTRUMENTOBANCOCENTRAL'     
SET @Mensaje = '(*)Requiere Instrumento Banco Central'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREINSTRUMENTOBANCOCENTRALDESCRIPCION'     
SET @Mensaje = 'Instrumento BCRA'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREPRECIOCLIENTE'     
SET @Mensaje = '(*)Precio Tasa Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREPRECIOCLIENTEDESCRIPCION'     
SET @Mensaje = 'Precio Cliente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREPRECIOTRANSFERENCIA'     
SET @Mensaje = '(*)Precio Tasa Transferencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERERESPONSABLE'     
SET @Mensaje = '(*)Requiere Responsable'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIERERESPONSABLEDESCRIPCION'     
SET @Mensaje = 'Responsable'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_REQUIEREVIGENCIA'     
SET @Mensaje = '(*)Requiere'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RESPONSABLECUENTA'     
SET @Mensaje = 'Responsable de Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RESTAURANDO_ESPERE'     
SET @Mensaje = 'Restaurando. Espere a que termine...'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RESTAURAR'     
SET @Mensaje = 'Restaurar'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RUEDADESCRIP'     
SET @Mensaje = 'Rueda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RUEDADESCRIPCION'     
SET @Mensaje = 'Rueda'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALIDAS'     
SET @Mensaje = 'Salidas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SE_COPIO_CELDA'     
SET @Mensaje = 'Se copió la celda al portapapeles..'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SE_COPIO_FILA'     
SET @Mensaje = 'Se copió una fila al portapapeles.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SECTORINTERNO'     
SET @Mensaje = 'Sector Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SECTORINTERNODESCRIPCION'     
SET @Mensaje = 'Sector Interno'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SEGMENTO'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SEGMENTODESCRIP'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SEGMENTODESCRIPCION'     
SET @Mensaje = 'Segmento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SEGUNDOS'     
SET @Mensaje = 'segundos...'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SELECCIONE'     
SET @Mensaje = 'seleccione'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SESION_EXPIRADA'     
SET @Mensaje = 'Session Expirada'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SESION_VENCIDA'     
SET @Mensaje = 'sesion vencida'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SISITEMA_BACKOFFICE_MAE'     
SET @Mensaje = 'Sistema Backoffice del Mercado Abierto Electrónico'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SOLO_SE_PERMITE_MODIFICAR_1'     
SET @Mensaje = 'Solo se permite modificar un (1) registro.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SR-ONLY'     
SET @Mensaje = ''     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SUCURSAL'     
SET @Mensaje = 'Sucursal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SUCURSALDESCRIP'     
SET @Mensaje = 'Sucursal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SUCURSALDESCRIPCION'     
SET @Mensaje = 'Sucursal'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SUPERVISION'     
SET @Mensaje = 'Supervisión'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TASA'     
SET @Mensaje = 'Tasa'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TEXTONOVEDAD'     
SET @Mensaje = 'Observaciones'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPO'     
SET @Mensaje = '(*)Tipo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPO_DOCUMENTO'     
SET @Mensaje = 'Tipo Documento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPO_LOG'     
SET @Mensaje = 'Tipo de Log'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOCONFIRMACIONDESCRIPCION'     
SET @Mensaje = 'Tipo Conf.'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPODECONFIRMACION'     
SET @Mensaje = '(*)Tipos de Confirmación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPODENEGOCIACION'     
SET @Mensaje = 'Tipo de Negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPODEORDEN'     
SET @Mensaje = 'Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPODEPARTICIPANTE'     
SET @Mensaje = 'Tipo de Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPODESCRIPCION'     
SET @Mensaje = 'Tipo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOEJECUCIONDESCRIPCION'     
SET @Mensaje = 'Tipo Ejecución'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPONEGOCIACION'     
SET @Mensaje = '(*) Tipo de Negociacion'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPONEGOCIACIONDESCRIP'     
SET @Mensaje = 'Tipo Negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPONEGOCIACIONDESCRIPCION'     
SET @Mensaje = 'Tipo de negociación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOOPERACIONDESCRIP'     
SET @Mensaje = 'Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOOPERACIONDESCRIPCION'     
SET @Mensaje = 'Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOOPERATORIA'     
SET @Mensaje = 'Tipo de Operatoria'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOORDENDESCRIPCION'     
SET @Mensaje = 'Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOPARTICIPANTE'     
SET @Mensaje = 'Tipo Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOPARTICIPANTEDESCRIPCION'     
SET @Mensaje = 'Tipo de Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ULTIMOLOGINEXITOSO'
SET @Mensaje = 'Ultimo Login Exitoso'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOSORDEN'     
SET @Mensaje = '(*) Tipo de Orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOVIGENCIADESCRIPCION'     
SET @Mensaje = 'Tipo de vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TODAS_LAS_PAGINAS'     
SET @Mensaje = 'Todas las páginas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIO'     
SET @Mensaje = 'Usuario'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIOALTANOMBRE'     
SET @Mensaje = 'Usuario Carga'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIOCARGA'     
SET @Mensaje = 'Usuario Carga'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIODESCRIPCION'     
SET @Mensaje = 'Usuario'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIOMODIFNOMBRE'     
SET @Mensaje = 'Usuario Ultima Modificación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIOPARTNOMBRE'     
SET @Mensaje = 'Responsable de Cuenta'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIOULTIMAMODIFICACION'     
SET @Mensaje = 'Usuario Última Modificación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VALIDACION_DATOS'     
SET @Mensaje = 'Validación datos en {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VENCIMIENTO'     
SET @Mensaje = 'Vencimiento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VIGENCIA'     
SET @Mensaje = 'Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VIGENCIAORDEN'     
SET @Mensaje = 'Vigencia de la orden'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VIGENTE'     
SET @Mensaje = 'Vigente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VINCULACIONES'     
SET @Mensaje = 'Vinculaciones'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VINCULAROPERACION'     
SET @Mensaje = 'Vincular Operación '     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VINCULAROPERACIONES'     
SET @Mensaje = 'Vincular Operaciones'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VISTA_DE'     
SET @Mensaje = 'Vista de {0}'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ZONA'     
SET @Mensaje = 'Zona'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ZONADESCRIPCION'     
SET @Mensaje = 'Zona'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OBSERVACIONES_500'     
SET @Mensaje = 'Observaciones (max.500)'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VIEW_VINCULACION_ORDENES'     
SET @Mensaje = 'Vinculacion Ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MENU_CUENTAS'     
SET @Mensaje = 'Cuentas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOSTRAR_CEOR_CONFIRMACION'     
SET @Mensaje = 'Mostrar/Ocultar Datos Confirmación'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOSTRAR_CEOR_BCRA_PARTICIPANTE'     
SET @Mensaje = 'Mostrar/Ocultar Datos BCRA-Participante'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOSTRAR_CEOR_VIGENCIA'     
SET @Mensaje = 'Mostrar/Ocultar Datos Vigencia'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MOSTRAR_CEOR_FUENTES'     
SET @Mensaje = 'Mostrar/Ocultar Datos Fuentes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CUENTA_MONETARIA_FUTURO'     
SET @Mensaje = 'Cuenta Monetaria Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CUENTA_TENENCIA_FUTURO'     
SET @Mensaje = 'Cuenta Tenencia Futuro'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DOCUMENTO'     
SET @Mensaje = 'Numero Documento'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_LOGIN_USUARIOREQUERIDO'     
SET @Mensaje = 'Usuario es un dato requerido'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_LOGIN_PWDREQUERIDO'     
SET @Mensaje = 'Password es un dato requerido'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_LOGIN_DOCUMENTOREQUERIDO'     
SET @Mensaje = 'Documento es un dato requerido'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_LOGIN_NUMBERVALIDATION'     
SET @Mensaje = 'solo se permiten numeros'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CHANGEPASS_LOGIN'     
SET @Mensaje = 'Volver Login'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


/*Consulta de ordenes*/

SET @Codigo = 'LBL_NUMEROORDENINTERNO' 
 SET @Mensaje = 'N°' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_FECHACONCERTACION' 
 SET @Mensaje = 'Fecha Concertación' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_COMPRAVENTA' 
 SET @Mensaje = 'CompraVenta' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_PERSONADESCRIPCION' 
 SET @Mensaje = 'Persona' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_PRODUCTODESCRIPCION' 
 SET @Mensaje = 'Producto' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_MONEDADESCRIPCION' 
 SET @Mensaje = 'Moneda' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_IDESTADO' 
 SET @Mensaje = 'Estado' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_PRECIO' 
 SET @Mensaje = 'Precio' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_CANTIDAD' 
 SET @Mensaje = 'Cantidad' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_EJECUTADA' 
 SET @Mensaje = 'Ejecutada' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_REMANENTE' 
 SET @Mensaje = 'Remanente' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_NUMEROORDENMERCADO' 
 SET @Mensaje = 'Número Mercado' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_NROOPERACIONMERCADO' 
 SET @Mensaje = 'Nro Operacion Mercado' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_PRECIO' 
 SET @Mensaje = 'Precio' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_CANTIDAD' 
 SET @Mensaje = 'Cantidad' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_MONTO' 
 SET @Mensaje = 'Monto' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
               
SET @Codigo = 'LBL_IDPRODUCTO' 
 SET @Mensaje = 'Id' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_CODIGO' 
 SET @Mensaje = 'Codigo' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
                
SET @Codigo = 'LBL_DESCRIPCION' 
 SET @Mensaje = 'Descripcion' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDPERSONA' 
 SET @Mensaje = 'Id' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
            
SET @Codigo = 'LBL_NROCLIENTE' 
 SET @Mensaje = 'Nro. Cliente' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
            
SET @Codigo = 'LBL_NOMBREPERSONA' 
 SET @Mensaje = 'Nombre participante' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
            
SET @Codigo = 'LBL_NRODOCUMENTO' 
 SET @Mensaje = 'Nro. Documento' 
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--Alta-Orden
SET @Codigo = 'LBL_NUMERODOCUMENTO' 
SET @Mensaje = 'Documento'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_STOPTYPE' 
SET @Mensaje = 'Stop Type'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ORDERTYPE' 
SET @Mensaje = 'Tipo Orden'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_QUANTITY' 
SET @Mensaje = 'Cantidad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRECIOLIMITE' 
SET @Mensaje = 'Precio'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VIGENCIACANTIDAD' 
SET @Mensaje = 'TTL'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAVENCIMIENTO' 
SET @Mensaje = 'Expiration Date'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTOS'     
SET @Mensaje = 'Productos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_TCQ'     
SET @Mensaje = 'TCQ'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--FILTROS

SET @Codigo = 'LBL_NUMEROORDENMERCADO' 
SET @Mensaje = 'Número de Mercado'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACIONDESDE' 
SET @Mensaje = 'Fecha Desde'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACONCERTACIONHASTA' 
SET @Mensaje = 'Fecha Hasta'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--Acciones
SET @Codigo = 'LBL_DESCRIPCIONACCION' 
SET @Mensaje = 'Descripción'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONSULTA' 
SET @Mensaje = 'Consulta'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALIDAS' 
SET @Mensaje = 'Salidas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MODIFICACION' 
SET @Mensaje = 'Modificación'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BAJA' 
SET @Mensaje = 'Baja'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ALTA' 
SET @Mensaje = 'Alta'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IMPORTACION' 
SET @Mensaje = 'Importación'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APROBACION_AUTOMATICA' 
SET @Mensaje = 'Aprobación Automática'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EJECUCION' 
SET @Mensaje = 'Ejecución'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--AccionRol

SET @Codigo = 'LBL_SUPERVISION' 
SET @Mensaje = 'Supervisión'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FILTROACCIONUPDATE' 
SET @Mensaje = 'Nombre Acción'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_IDROL' 
SET @Mensaje = 'Rol'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--ConfiguracionSeguridad

SET @Codigo = 'LBL_TIMEOUTINICIALSESION' 
SET @Mensaje = 'Timeout Inicial (en segs)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIMEOUTEXTENSIONSESION' 
SET @Mensaje = 'Timeout Extensión Sesión (en segs)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADINTENTOSMAXIMO' 
SET @Mensaje = 'Cantidad Intentos Login'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MAXIMODIASINACTIVIDAD' 
SET @Mensaje = 'Max días Inactividad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DIASCAMBIOPASSWORD' 
SET @Mensaje = 'Días Cambio Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADPASSWORDSHISTORICAS' 
SET @Mensaje = 'Cantidad Passwords históricas'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONSIDERAMINIMOLARGOPASSWORD' 
SET @Mensaje = 'Considerar Mínimo Largo Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADMINIMOLARGOPASSWORD' 
SET @Mensaje = 'Cantidad Mínimo Largo Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONSIDERAMAXIMACANTCARACTERESCONSECUTIVOS' 
SET @Mensaje = 'Considerar Max cant caract consecutivos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADMAXIMACARACTERESCONSECUTIVOS' 
SET @Mensaje = 'Cant Max Caracteres Consecutivos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADSIMBOLOSPASSWORD' 
SET @Mensaje = 'Cantidad Símbolos Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADMAYUSCULASPASSWORD' 
SET @Mensaje = 'Cantidad Mayúsculas Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADMINUSCULASPASSWORD' 
SET @Mensaje = 'Cantidad Minúsculas Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADALFABETICOSPASSWORD' 
SET @Mensaje = 'Cant Caract. Alfabéticos Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CANTIDADNUMERICOSPASSWORD' 
SET @Mensaje = 'Cant Caract. Numéricos Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_CONSIDERACANTIDADCARACTERES' 
SET @Mensaje = 'Considerar Cantidad Caracteres'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--Cambio de clave

SET @Codigo = 'LBL_PREVIOUSPASS' 
SET @Mensaje = 'Contraseña vieja'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NEWPASSWORD' 
SET @Mensaje = 'Contraseña Nueva'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONFIRMPASSWORD' 
SET @Mensaje = 'Contraseña Confirmar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BTNACEPTAR' 
SET @Mensaje = 'Aceptar'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--Roles


SET @Codigo = 'LBL_DESCRIPCION' 
SET @Mensaje = 'Descripción'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_VALORNUMERICO' 
SET @Mensaje = 'Valor Numérico'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--Usuarios

SET @Codigo = 'LBL_USERNAME' 
SET @Mensaje = 'Nombre usuario'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBRE' 
SET @Mensaje = 'Nombre completo'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BLOQUEADO' 
SET @Mensaje = 'Bloqueado'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PROCESO' 
SET @Mensaje = 'Proceso'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOCONTROLARINACTIVIDAD' 
SET @Mensaje = 'No Controlar Inactividad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PASSWORD' 
SET @Mensaje = 'Contraseña'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--Mercados

SET @Codigo = 'LBL_CODIGOMERCADO' 
SET @Mensaje = 'Código'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DESCRIPCIONMERCADO' 
SET @Mensaje = 'Descripción'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_LIMIT' 
SET @Mensaje = 'LIMIT'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje



SET @Codigo = 'LBL_MARKET' 
SET @Mensaje = 'MARKET'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ORDERTYPE' 
SET @Mensaje = 'Tipo Orden'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_GTC' 
SET @Mensaje = 'GTC'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DAY' 
SET @Mensaje = 'DAY'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_QTY' 
SET @Mensaje = 'QTY'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_PRECIOLIMITEMERCADO' 
SET @Mensaje = 'Precio'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--Monedas

SET @Codigo = 'LBL_TIPOMONEDA' 
SET @Mensaje = 'Tipo Moneda'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--Personas

SET @Codigo = 'LBL_NROCLIENTE' 
SET @Mensaje = 'Nro Cliente'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBREPERSONA' 
SET @Mensaje = 'Nombre'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOPERSONA' 
SET @Mensaje = 'Tipo Persona'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NRODOCUMENTO' 
SET @Mensaje = 'Nro Documento'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDPERSONERIAJURIDICA' 
SET @Mensaje = 'Personeria Juridica'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--LogAuditoria

SET @Codigo = 'LBL_FECHAEVENTO' 
SET @Mensaje = 'Fecha/Hora'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USERNAME' 
SET @Mensaje = 'Usuario'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOEVENTO' 
SET @Mensaje = 'Evento'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_NOMBREENTIDAD' 
SET @Mensaje = 'Entidad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_FECHADESDE' 
SET @Mensaje = 'Fecha (desde)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAHASTA' 
SET @Mensaje = 'Fecha (hasta)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDTIPOEVENTO' 
SET @Mensaje = 'Tipo Evento'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDLOGAUDITORIACLASE' 
SET @Mensaje = 'Entidad'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--LogComando
SET @Codigo = 'LBL_REQUESTID' 
SET @Mensaje = 'RequestId'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

--LogSeguridad
SET @Codigo = 'LBL_DESCRIPCIONSEGURIDAD' 
SET @Mensaje = 'Texto'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IP' 
SET @Mensaje = 'IP'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_ORIGEN' 
SET @Mensaje = 'Origen'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--EstadoSistema

SET @Codigo = 'LBL_ESTADO' 
SET @Mensaje = 'Estado del sistema'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHAAPERTURA' 
SET @Mensaje = 'Fecha de apertura'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_FECHACIERRE' 
SET @Mensaje = 'Fecha de cierre'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EJECUCIONVALIDACION' 
SET @Mensaje = 'Ejecución validación'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_APERTURASISTEMA' 
SET @Mensaje = 'Apertura del Sistema.'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BTNDESHACER' 
SET @Mensaje = 'Deshacer'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_EJECUCION' 
SET @Mensaje = 'Ejecución'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CIERRESISTEMA' 
SET @Mensaje = 'Cierre del Sistema'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_BTNVERERROR' 
SET @Mensaje = 'Ver Error'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


--ConfiguracionSistema


SET @Codigo = 'LBL_TIPOURL' 
SET @Mensaje = 'Tipo Url'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_URL' 
SET @Mensaje = 'Url'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_USUARIO' 
SET @Mensaje = 'Usuario'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PASSWORD' 
SET @Mensaje = 'Password'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PARAMETROS' 
SET @Mensaje = 'Parametros'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_OCULTARERRORESBASEDEDATOS' 
SET @Mensaje = 'Ocultar Errores Base De Datos'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ENVIANOTIFICACIONES' 
SET @Mensaje = 'Envía Notificaciones'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PERMITEPROCESAMIENTOPARALELO' 
SET @Mensaje = 'Permite Procesamiento Paralelo'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ENVIARAGENTCODE' 
SET @Mensaje = 'Enviar Codigo de Agente'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_JWT_SECRET_KEY' 
SET @Mensaje = 'Jwt Secret Key'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_JWT_AUDIENCE_TOKEN' 
SET @Mensaje = 'Jwt Audience Token'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_JWT_ISSUER_TOKEN' 
SET @Mensaje = 'Jwt Issuer Token'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MAX_OPERATIONS_ROWS' 
SET @Mensaje = 'Max Operation Rows'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_MIN_OPERATIONS_ROWS' 
SET @Mensaje = 'Min Operation Rows'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ABSOLUTE_SERVICES_URL' 
SET @Mensaje = 'Absolute Services URL'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PATHSALIDA' 
SET @Mensaje = 'Path Salida'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIEMPOLOGSQL' 
SET @Mensaje = 'Tiempo Log SQL'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_SALDOS_COD_PRODUCTO' 
SET @Mensaje = 'Ticker'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_DESC_PRODUCTO' 
SET @Mensaje = 'Especie'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_FECHA_VENCIMIENTO' 
SET @Mensaje = 'Fecha Vencimiento'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_CODIGO_CUENTA' 
SET @Mensaje = 'Concepto'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_PRECIO_NACIONAL' 
SET @Mensaje = 'Precio ($)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_SALDOS_MONTO_NACIONAL' 
SET @Mensaje = 'Valorizacion ($)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_MONTO_DOLARES' 
SET @Mensaje = 'Valorizacion (U$S)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDOS_PRECIO_DOLARES' 
SET @Mensaje = 'Precio (u$s)'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_IDENTIFICACION_TRIBUTARIA' 
SET @Mensaje = 'Identificacion Tributaria'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_CONFIRMARORDEN'     
SET @Mensaje = 'Va a confirmar la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'MSJ_BLOQUEARORDEN'     
SET @Mensaje = 'Va a bloquear la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_ANULARBLOQUEARORDEN'     
SET @Mensaje = 'Va a anular el bloqueo de la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ANULARBLOQUEARORDEN'     
SET @Mensaje = 'Anular bloquear orden'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_CANCELARORDEN'     
SET @Mensaje = 'Va a cancelar la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_ANULARCONFIRMARORDEN'     
SET @Mensaje = 'Va a anular la confirmacion de la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_DEPURARORDEN'     
SET @Mensaje = 'Va a depurar la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ANULARDEPURARORDEN'     
SET @Mensaje = 'Anular depurar orden'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'MSJ_ANULARDEPURARORDEN'     
SET @Mensaje = 'Va a anular la depuracion de la orden número {0}. ¿Está seguro?'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ISIN'     
SET @Mensaje = 'ISIN'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TRADERS'     
SET @Mensaje = 'Traders'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CLIENTES'     
SET @Mensaje = 'Clientes'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CLIENTE'     
SET @Mensaje = 'Cliente'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ESDESISTEMA'     
SET @Mensaje = 'Es De Sistema'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PORTFOLIOS'     
SET @Mensaje = 'Portfolios'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ASOCIAR'     
SET @Mensaje = 'Asociar'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CLIENTE'     
SET @Mensaje = 'Cliente'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_HABILITADO'     
SET @Mensaje = 'Habilitado'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_CONSULTE_ADMIN'     
SET @Mensaje = 'Surgio un error en la transaccion. Por favor, consulte con su administrador'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PORDEFECTO'     
SET @Mensaje = 'Por Defecto'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'E100556'     
SET @Mensaje = 'Error al Cerrar la Orden en un Mercado Interno. No existe un Mercado Interno.'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PLAZO'     
SET @Mensaje = 'Plazo'   
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOSALDO_1'     
SET @Mensaje = 'Monedas'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOSALDO_2'     
SET @Mensaje = 'Titulos'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOSALDO_3'     
SET @Mensaje = 'Acciones'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SALDO_TOTALES'     
SET @Mensaje = 'Totales'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TELEFONO'     
SET @Mensaje = 'Telefono'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'FE00055'     
SET @Mensaje = 'Error de Concurrencia: El registro que esta tratando de modificar esta siendo modificado por otro usuario. Por favor intente de nuevo'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_UNBLOCKORDERS'     
SET @Mensaje = 'Desbloquear ordenes'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_UNBLOCKORDERPROMPT'     
SET @Mensaje = '¿Desea desbloqear las ordenes seleccionadas?'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DOBLEFACTOR'     
SET @Mensaje = 'Doble Factor'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOPRODUCTO'     
SET @Mensaje = 'Tipo de Producto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_DESCRIPCION'     
SET @Mensaje = 'Descripción'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_RESULTADO'     
SET @Mensaje = 'Resultado'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ACCION'     
SET @Mensaje = 'Acción'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'LBL_PRECIO_SALDO'     
SET @Mensaje = 'Precio c/100'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PORTFOLIO_COMPOSICION_ACTUALIZADA'     
SET @Mensaje = 'Composición del portfolio ha sido actualizada exitosamente'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_SOURCEAPPLICATION'     
SET @Mensaje = 'Aplicación Origen'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_TIPOPERSONA'     
SET @Mensaje = 'Tipo de persona'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PRODUCTO'     
SET @Mensaje = 'Producto'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_ALIQAN'     
SET @Mensaje = 'ALIQ/AN'     
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje

SET @Codigo = 'LBL_PUERTO'     
SET @Mensaje = 'Puerto'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje


SET @Codigo = 'E100016'
SET @Mensaje = 'El comando no está permitido para el usuario logueado.|| ||'
EXEC [dbo].[AMB_CodigosMensajes] @Codigo, @Mensaje
