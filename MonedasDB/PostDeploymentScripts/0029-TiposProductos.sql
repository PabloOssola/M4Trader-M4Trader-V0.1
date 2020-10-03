/******* EJECUTAR SOLO SI ES NECESARIO LA PRIMERA VEZ QUE SE AGREGA LA COLUMNA TIPO DE PRODUCTO EN LA TABLA PRODUCTO *******/

/* Tipo Producto Futuro si es Rofex 
update [Ordenes_Fix].[orden_owner].[Productos] set idtipoproducto = 6 WHERE IdProducto IN 
(SELECT IdProducto FROM [Ordenes_Fix].[orden_owner].[ProductosPorMercados] where IdMercado = 3)
*/

/* Tipo Producto Acciones si es ARPENTA 
update [Ordenes_Fix].[orden_owner].[Productos] set idtipoproducto = 4 WHERE IdProducto IN 
(SELECT IdProducto FROM [Ordenes_Fix].[orden_owner].[ProductosPorMercados] where IdMercado = 1)
*/

/* Tipo Producto Bonos si es ARPENTA 
update [Ordenes_Fix].[orden_owner].[Productos] set idtipoproducto = 3 WHERE IdProducto IN 
(SELECT IdProducto FROM [Ordenes_Fix].[orden_owner].[ProductosPorMercados] where IdMercado = 1)
*/