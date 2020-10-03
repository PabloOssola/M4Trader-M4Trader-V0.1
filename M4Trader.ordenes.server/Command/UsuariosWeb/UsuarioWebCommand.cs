using M4Trader.ordenes.server.CQRSFramework.ABM;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using M4Trader.ordenes.server.Helpers;

namespace M4Trader.ordenes.server
{
    public abstract class UsuarioWebCommand : ABMContextCommand
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
            return true;
        }

        abstract public override void Validate();

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.AdministracionUsuariosWeb;
            }
        }


        [DataMember]
        public short r_id { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int IdPersona { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}