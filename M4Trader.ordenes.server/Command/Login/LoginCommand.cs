using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public abstract class LoginCommand : ABMContextCommand
    {
        abstract public override object ExecuteCommand(InCourseRequest inCourseRequest);
    
        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Login;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        public string IP { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
    }
}