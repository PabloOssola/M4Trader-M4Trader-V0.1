using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class ActualizaRolCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Rol where d.IdRol == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            RolEntity request = entidad.FirstOrDefault();
            request.Descripcion = Descripcion;
            request.ValorNumerico = ValorNumerico;
            request.BajaLogica = BajaLogica;
            request.UltimaActualizacion = GetUltimaActualizacion(UltimaActualizacion);
            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Rol";

            #region Requerido
            ValidateString(Descripcion, "Descripción Corta", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateInt(ValorNumerico, "Valor Numérico", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad
            var coleccion = (from d in context.Rol where d.Descripcion.Equals(Descripcion) && d.IdRol != r_id select d);
            ValidateUnicidad(coleccion, Descripcion, "Descripcion", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);
            
            coleccion = (from d in context.Rol where d.ValorNumerico.Equals(ValorNumerico) && d.IdRol != r_id select d);
            ValidateUnicidad(coleccion, ValorNumerico.ToString(), "ValorNumerico", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Rol;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        [DataMember]
        public short r_id { get; set; } 

        [DataMember]
        public string Descripcion { get; set; }
        
        [DataMember]
        public short ValorNumerico { get; set; }
        
        [DataMember]
        public bool BajaLogica { get; set; }
        
        [DataMember]
        public string UltimaActualizacion { get; set; }
    }
}