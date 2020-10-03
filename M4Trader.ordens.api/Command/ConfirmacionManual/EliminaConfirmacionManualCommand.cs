using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class EliminaConfirmacionManualCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            ConfirmacionManualEntity request;
            foreach (int id in Ids)
            {
                request = (from d in context.ConfirmacionManual where d.IdConfirmacionManual == id select d).FirstOrDefault();
                context.Remove(request);
            }
            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "ConfirmacionManual";

            #region Requerido

            #endregion Requerido

            #region Unicidad
            
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
                return (int)IdAccion.ConfirmacionManual;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.BAJA;
            }
        }

        [DataMember]
        public int[] Ids { get; set; }
    }
}