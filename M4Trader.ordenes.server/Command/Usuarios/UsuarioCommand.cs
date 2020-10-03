using M4Trader.ordenes.server.CQRSFramework.ABM;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server
{ 
    public abstract class UsuarioCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        abstract public override object ExecuteCommand(InCourseRequest inCourseRequest);

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        abstract public override void Validate();

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Usuarios;
            }
        }


        [DataMember]
        public short r_id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public bool Bloqueado { get; set; }
        [DataMember]
        public bool NoControlarInactividad { get; set; }
        [DataMember]
        public bool Proceso { get; set; }
        [DataMember]
        public string RolesUsuario { get; set; }
        [DataMember]
        public string UltimaActualizacion { get; set; }
    }
}