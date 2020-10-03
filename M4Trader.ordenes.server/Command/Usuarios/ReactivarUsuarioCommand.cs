using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{ 
    [CommandType("ReacUsrCom", (int)IdAccion.Usuarios, TipoAplicacion.WEBEXTERNASECURITY)]
    public class ReactivarUsuarioCommand : UsuarioCommand
    { 

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            foreach (int Id in Ids)
            {
                updateDependencies(Id);
            }
            return null;
        }

        private void updateDependencies(int id)
        {
            var entidad = (from d in context.Usuario where (d.IdUsuario == id) select d).ToList();
            ValidateExiste(entidad.Count(), id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);
            foreach (MCContext.Entidades.UsuarioEntity request in entidad)
            {
                request.BajaLogica = false;
                request.FechaBaja = null;
                request.FechaReactivacion = DateTime.Now;
                SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.ReactivarUser, "Usuario " + request.Username, (byte)TipoAplicacion.ORDENES);
            }
        }

        public override void Validate()
        {

        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        [DataMember]
        public int[] Ids { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}