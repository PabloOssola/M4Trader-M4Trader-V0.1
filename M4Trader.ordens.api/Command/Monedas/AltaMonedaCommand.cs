using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;
using M4Trader.ordenes.server.Entities;

namespace M4Trader.ordenes.server
{
    public class AltaMonedaCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            MonedaEntity request = new MonedaEntity()
            {
                Codigo = Codigo,
                Descripcion = Descripcion,
                TipoMoneda = TipoMoneda,
            };
            this.AgregarAlContextoParaAlta(request);
            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Moneda";

            #region Requerido
            ValidateString(Codigo, "Código", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);

            #endregion Requerido

            #region Unicidad
            var coleccion = (from d in context.Moneda where d.Codigo.Equals(Codigo) && d.IdMoneda != r_id select d);
            ValidateUnicidad(coleccion, Codigo, "Codigo", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            coleccion = (from d in context.Moneda where d.Descripcion.Equals(Descripcion) && d.IdMoneda != r_id select d);
            ValidateUnicidad(coleccion, Descripcion, "Descripción", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

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
                return (int)IdAccion.Monedas;
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
        public byte r_id { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public byte TipoMoneda { get; set; }
    }
}