using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class AltaConfirmacionManualCommand : ABMContextCommand
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
            ConfirmacionManualEntity request = new ConfirmacionManualEntity()
            {
                IdProducto = idProducto,
                IdSourceApplication = idSourceApplication,
                IdParty = idParty
            };

            this.AgregarAlContextoParaAlta(request);

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfolioUsuario";

            #region Requerido


            #endregion Requerido

            #region Unicidad
            var coleccion = (from d in context.ConfirmacionManual where d.IdProducto == idProducto && d.IdSourceApplication == idSourceApplication && d.IdParty == idParty select d);
            ValidateUnicidad(coleccion, null , "Confirmacion Manual", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.ConfirmacionManual;
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
        public int idProducto { get; set; }

        [DataMember]
        public byte idSourceApplication { get; set; }


        [DataMember]
        public byte idParty { get; set; }


        
    }
}