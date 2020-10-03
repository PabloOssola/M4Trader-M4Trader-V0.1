using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("ActualizarUsuarioCommand", (int)IdAccion.AdministracionUsuariosWeb, TipoAplicacion.WEBEXTERNA, TipoAplicacion.DMA)]
    public class ActualizarUsuarioCommand : ABMContextCommand
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
            UserHelper.ActualizarUsuario(IdUsuario, Nombre, LimiteOferta, LimiteOperacion, Bloqueado);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = IdUsuario != 0});
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {

        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.AdministracionUsuariosWeb;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }


        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public decimal LimiteOferta { get; set; }

        [DataMember]
        public decimal LimiteOperacion{ get; set; }

        [DataMember]
        public bool Bloqueado { get; set; }


    }
}