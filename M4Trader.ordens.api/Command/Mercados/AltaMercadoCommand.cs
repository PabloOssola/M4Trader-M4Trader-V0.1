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
    public class AltaMercadoCommand : ABMContextCommand
    {

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "Mercado";


            #region Requerido
            ValidateString(Codigo, "Codigo", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Descripcion, "Descripcion", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad

            var coleccion = (from d in context.Mercado where d.Codigo.Equals(Codigo) select d);
            ValidateUnicidad(coleccion,Codigo,"Codigo", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            coleccion = (from d in context.Mercado where d.Descripcion.Equals(Descripcion) select d);
            ValidateUnicidad(coleccion, Descripcion, "Descripcion", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            coleccion = (from d in context.Mercado where d.EsInterno select d);
            ValidateUnicidad(coleccion, EsInterno.ToString(), "EsInterno", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);            
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            MercadoEntity request = new MercadoEntity()
            {
                Codigo = Codigo,
                Descripcion = Descripcion,
                EsInterno = EsInterno,
                ProductoHabilitadoDefecto = ProductoHabilitadoDefecto
            };
            this.AgregarAlContextoParaAlta(request);
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