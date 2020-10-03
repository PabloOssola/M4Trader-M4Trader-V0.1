using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.DataAccess;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("EliminaPersonaCommand", (int)IdAccion.Personas, TipoAplicacion.WEBEXTERNASECURITY)]
    public class EliminaPersonaCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Persona";

            KeyArray keyArray;
            //Operaciones sin liquidar con este ente liquidador
            //var resOp = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_PERSONA_BAJA_EXISTEORDENACTIVA]", new { IdPersona = Ids[0] });
            //if ((int)resOp > 0)
            //{
            //    //Codigo requerido
            //    keyArray = new KeyArray();
            //    keyArray.Codigo = CodigosMensajes.FE_ELIMINA_ENTIDAD_ORDENES_ACTIVAS;
            //    keyArray.Parametros.Add(NombreEntidad);
            //    fe.DataValidations.Add(keyArray);
            //    valida = false;
            //}
            //Validar que no tenga hijos
            var resOp = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_PERSONA_BAJA_EXISTENHIJOS]", new { IdPersona = Ids[0] });
            if ((int)resOp > 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.FE_ELIMINA_ENTIDAD_TIENE_HIJOS;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add("Traders");
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
            //Validar que no tenga padres
            resOp = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_PERSONA_BAJA_EXISTENPADRES]", new { IdPersona = Ids[0] });
            if ((int)resOp > 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.FE_ELIMINA_ENTIDAD_TIENE_PADRES;
                keyArray.Parametros.Add(NombreEntidad);
                fe.DataValidations.Add(keyArray);
                valida = false;
            }
            if (!valida)
            {
                throw fe;
            }

        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            PartyEntity request;

            foreach (var id in Ids)
            {
                request = (from d in context.Persona where d.IdParty == id select d).Single();
                request.BajaLogica = true;
            }
            return null;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Personas;
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