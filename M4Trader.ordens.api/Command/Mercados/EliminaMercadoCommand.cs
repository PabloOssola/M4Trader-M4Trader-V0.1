using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class EliminaMercadoCommand : ABMContextCommand
    {
        
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Mercado";

            //KeyArray keyArray;
            ////Operaciones sin liquidar con este ente liquidador
            //var res = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_MERCADO_BAJA_EXISTEORDENACTIVA]", new { IdMercado = Ids[0] });
            //if ((int)res > 0)
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
            MercadoEntity request;

            foreach (var id in Ids)
            {
                request = (from d in context.Mercado where d.IdMercado == id select d).Single();
                context.Remove(request);
            }
            return null;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Mercados;
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