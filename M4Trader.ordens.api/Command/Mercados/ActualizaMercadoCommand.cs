using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ActualizaMercadoCommand : ABMContextCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Mercado";

            #region Requerido
            ValidateString(Codigo, "Codigo", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripcion", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad
            var coleccion = (from d in context.Mercado where d.Codigo.Equals(Codigo) && d.IdMercado != r_id select d);
            ValidateUnicidad(coleccion, Codigo, "Codigo", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);
            coleccion = (from d in context.Mercado where d.Descripcion.Equals(Descripcion) && d.IdMercado != r_id select d);
            ValidateUnicidad(coleccion, Descripcion, "Descripcion", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);
            coleccion = (from d in context.Mercado where d.EsInterno && d.IdMercado != r_id select d);
            ValidateUnicidad(coleccion, EsInterno.ToString(), "EsInterno", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Mercado where d.IdMercado == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            MercadoEntity request = entidad.FirstOrDefault();
            request.Codigo = Codigo;
            request.Descripcion = Descripcion;
            request.EsInterno = EsInterno;
            request.ProductoHabilitadoDefecto = ProductoHabilitadoDefecto;
            return null;
        }


        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Mercados;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        [DataMember]
        public byte r_id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool EsInterno { get; set; }
        [DataMember]
        public bool ProductoHabilitadoDefecto { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}