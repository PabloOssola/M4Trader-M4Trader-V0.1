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
    public class EliminaRolCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Rol";
            KeyArray keyArray;
            //Acciones para este rol
            var resOp = SqlServerHelper.ExecuteScalar("[orden_owner].[CMD_SCRN_VAL_ROL_BAJA_EXISTEACCIONCONROL]", new { IdRol = Ids[0] });
            if ((int)resOp > 0)
            {
                //Codigo requerido
                keyArray = new KeyArray();
                keyArray.Codigo = CodigosMensajes.FE_ELIMINA_ENTIDAD_ACCION_ASOCIADA_ROL;
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
            RolEntity request;

            foreach (var id in Ids)
            {
                request = (from d in context.Rol where d.IdRol == id select d).Single();
                request.BajaLogica = true;
            }
            return null;
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
                return (int)TipoPermiso.BAJA;
            }
        }


        [DataMember]
        public short[] Ids { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}