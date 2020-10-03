using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ActualizaEstadoPantallaCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "EstadoPantalla";
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {

            var entidad = (from d in context.EstadoPantalla where d.IdUsuario == MAEUserSession.Instancia.IdUsuario && d.Codigo == Codigo select d);
            if (entidad.Count() > 0)
            {

                CustomizacionUsuarioEntity request = entidad.FirstOrDefault();
                request.Valor = Valor;
            }
            else
            {
                var alta = new CustomizacionUsuarioEntity()
                {
                    IdUsuario = MAEUserSession.Instancia.IdUsuario,
                    Codigo = Codigo,
                    Valor = Valor
                };
                this.AgregarAlContextoParaAlta(alta);
            }
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
                return false;
            }
        }
    }
}