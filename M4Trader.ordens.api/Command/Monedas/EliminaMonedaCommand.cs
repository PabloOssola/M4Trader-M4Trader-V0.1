using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class EliminaMonedaCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Moneda";

            //KeyArray keyArray;
            ////Operaciones sin liquidar con este ente liquidador
            //var resOp = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_MONEDA_BAJA_EXISTEORDENACTIVA]", new { IdMoneda = Ids[0] });
            //if ((int)resOp > 0)
            //{
            //    //Codigo requerido
            //    keyArray = new KeyArray();
            //    keyArray.Codigo = CodigosMensajes.FE_ELIMINA_ENTIDAD_ORDENES_ACTIVAS;
            //    keyArray.Parametros.Add(NombreEntidad);
            //    fe.DataValidations.Add(keyArray);
            //    valida = false;
            //}
            //if (!valida)
            //{
            //    throw fe;
            //}

        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            MonedaEntity request;

            foreach (var id in Ids)
            {
                request = (from d in context.Moneda where d.IdMoneda == id select d).Single();
                context.Remove(request);
            }
            return null;
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
                return (int)TipoPermiso.BAJA;
            }
        }


        [DataMember]
        public byte[] Ids { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}