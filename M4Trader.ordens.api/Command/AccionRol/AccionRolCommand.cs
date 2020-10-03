using M4Trader.ordenes.server.CQRSFramework.ABM;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.services.Entities;
using System.Linq;

namespace M4Trader.ordenes.server
{
    public abstract class AccionRolCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        abstract public override object ExecuteCommand(InCourseRequest inCourseRequest);

        abstract public IQueryable<AccionRolEntity> GetAccionRoles();

        public override void Validate()
        {
            NombreEntidad = "AccionRol";

            #region Requerido
            ValidateInt(IdRol, "Rol", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(IdAccion, "Acción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(sumUpPermissions(),"Permisos",CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad

            var entidad = GetAccionRoles();
            string descRol = (from r in context.Rol where r.IdRol == IdRol select r).FirstOrDefault().Descripcion;
            string descAccion = (from a in context.Acciones where a.IdAccion == IdAccion select a).FirstOrDefault().Descripcion;
            ValidateUnicidad(entidad, "Rol", descRol, "Acción", descAccion, r_id == 0 ? CodigosMensajes.FE_ALTA_UNICIDAD_2CAMPOS:CodigosMensajes.FE_ACTUALIZA_UNICIDAD_2CAMPOS);
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        protected int sumUpPermissions()
        {
            int permisosAccion = (from a in context.Acciones where a.IdAccion == IdAccion select a).FirstOrDefault().HabilitarPermisos;
            return   (((int)TipoPermiso.CONSULTA & permisosAccion)* (Consulta ? 1 : 0)) + 
                     (((int)TipoPermiso.SALIDAS & permisosAccion)* (Salidas ? 1 : 0)) +
                     (((int)TipoPermiso.MODIFICACION & permisosAccion)* (Modificacion ? 1 : 0)) +
                     (((int)TipoPermiso.BAJA & permisosAccion) * (Baja ? 1 : 0)) +
                     (((int)TipoPermiso.ALTA & permisosAccion)* (Alta ? 1 : 0)) +
                     (((int)TipoPermiso.SUPERVISION & permisosAccion) * (Supervision ? 1 : 0)) +
                     (((int)TipoPermiso.IMPORTACION & permisosAccion) * (Importacion ? 1 : 0)) +
                     (((int)TipoPermiso.APROBACION_AUTOMATICA & permisosAccion) * (Aprobacion_Automatica ? 1 : 0)) +
                     (((int)TipoPermiso.EJECUCION & permisosAccion) * (Ejecucion ? 1 : 0));
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }
        
        public override int GetIdAccion
        {
            get
            {
                return (int)server.Entities.IdAccion.AccionRol;
            }
        }

        [DataMember]
        public short r_id { get; set; }

        [DataMember]
        public short IdRol { get; set; }

        [DataMember]
        public short IdAccion { get; set; }

        [DataMember]
        public string UltimaActualizacion { get; set; }

        [DataMember]
        public bool Consulta { get; set; }

        [DataMember]
        public bool Salidas { get; set; }

        [DataMember]
        public bool Modificacion { get; set; }

        [DataMember]
        public bool Baja { get; set; }

        [DataMember]
        public bool Alta { get; set; }

        [DataMember]
        public bool Supervision { get; set; }

        [DataMember]
        public bool Importacion { get; set; }

        [DataMember]
        public bool Aprobacion_Automatica { get; set; }

        [DataMember]
        public bool Ejecucion { get; set; }  
    }
}