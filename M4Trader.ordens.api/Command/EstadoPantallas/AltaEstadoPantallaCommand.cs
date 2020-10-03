using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class AltaEstadoPantallaCommand : ABMContextCommand
    {

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "EstadoPantalla";
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            CustomizacionUsuarioEntity request = new CustomizacionUsuarioEntity()
            {
                IdUsuario = MAEUserSession.Instancia.IdUsuario,
                Codigo = Codigo,
                Valor = Valor
            };
            this.AgregarAlContextoParaAlta(request);
            return null;
        }
        

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.OrdenarPantallas;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.EJECUCION;
            }
        }

        [DataMember]
        public int r_id { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }


        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Valor { get; set; }


        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}