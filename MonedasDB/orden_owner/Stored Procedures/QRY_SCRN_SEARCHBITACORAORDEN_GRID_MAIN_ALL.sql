CREATE PROCEDURE orden_owner.QRY_SCRN_DMA_SEARCHBITACORAORDEN_GRID_MAIN_ALL    
@IdOrden bigint = NULL

AS    
BEGIN    
 SET NOCOUNT ON;    
    
 ;WITH pg AS    
  (    
   SELECT   
   l.Fecha  
   , Observaciones = l.DetalleAccion  
   , EstadoDescripcion = e.Descripcion  
   , IdEstado = l.IdEstadoOrden
   , AccionDescripcion = a.Descripcion  
   , UsuarioDescripcion = u.Nombre  
   , l.IdUsuario 
   , PersonaDescripcion = p.Name
   , MotivoCancelacionDescripcion = m.Descripcion
   --, s.Descripcion AS Source
   from orden_owner.LogBitacoraOrdenes l    
   INNER JOIN shared_owner.Usuarios u on u.IdUsuario = l.IdUsuario    
   INNER JOIN shared_owner.Parties p on p.IdParty = u.IdPersona
   INNER JOIN orden_owner.EstadosOrden e on e.IdEstadoOrden = l.IdEstadoOrden  
   INNER JOIN shared_owner.LogCodigoAccion a on a.IdLogCodigoAccion = l.CodigoAccion  
   LEFT JOIN shared_owner.MotivosBaja m on m.IdMotivoBaja = l.IdMotivoCancelacion
  -- LEFT JOIN orden_owner.SourcesApplication s ON l.IdSourceApplication = s.IdSourceApplication
   WHERE (@IdOrden IS NULL OR l.IdOrden = @IdOrden)    
  )    
     
 SELECT * FROM pg    
 ORDER BY Fecha 
END 