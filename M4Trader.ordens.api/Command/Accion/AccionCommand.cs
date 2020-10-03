using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public abstract class AccionCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        abstract public override object ExecuteCommand(InCourseRequest inCourseRequest);

        abstract public override void Validate();

        protected int sumUpPermissions()
        {
            return ((int)TipoPermiso.CONSULTA) * (Consulta ? 1 : 0) +
                     ((int)TipoPermiso.SALIDAS) * (Salidas ? 1 : 0) +
                     ((int)TipoPermiso.MODIFICACION) * (Modificacion ? 1 : 0) +
                     ((int)TipoPermiso.BAJA) * (Baja ? 1 : 0) +
                     ((int)TipoPermiso.ALTA) * (Alta ? 1 : 0) +
                     ((int)TipoPermiso.IMPORTACION) * (Importacion ? 1 : 0) +
                     ((int)TipoPermiso.APROBACION_AUTOMATICA) * (Aprobacion_Automatica ? 1 : 0) +
                     ((int)TipoPermiso.EJECUCION) * (Ejecucion ? 1 : 0);
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Accion;
            }
        }

        [DataMember]
        public short r_id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

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
        public bool Importacion { get; set; }

        [DataMember]
        public bool Aprobacion_Automatica { get; set; }

        [DataMember]
        public bool Ejecucion { get; set; }
    }
}