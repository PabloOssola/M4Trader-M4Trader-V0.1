using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class ActualizaMonedaCommand : ABMContextCommand
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
            var entidad = (from d in context.Moneda where d.IdMoneda == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            MonedaEntity request = entidad.FirstOrDefault();
            request.Codigo = Codigo;
            request.Descripcion = Descripcion;
            //request.TipoMoneda = TipoMoneda;
            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Moneda";

            #region Requerido
            ValidateString(Codigo, "Código", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripción", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);

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
                return (int)IdAccion.Monedas;
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
        public byte r_id { get; set; } 

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string TipoMoneda { get; set; }
    }
}