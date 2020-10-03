using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class AltaRolCommand : ABMContextCommand
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
            RolEntity request = new RolEntity()
            {
                Descripcion = Descripcion,
                ValorNumerico = ValorNumerico,
                BajaLogica = false
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
            NombreEntidad = "Rol";

            #region Requerido
            ValidateString(Descripcion, "Descripción", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(ValorNumerico, "Valor Numérico", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);

            #endregion Requerido

            #region Unicidad
            var coleccion = (from d in context.Rol where d.Descripcion.Equals(Descripcion) && d.IdRol != r_id  && d.BajaLogica == false select d);
            ValidateUnicidad(coleccion, Descripcion, "Descripción", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);

            coleccion = (from d in context.Rol where d.ValorNumerico.Equals(ValorNumerico) && d.IdRol != r_id && d.BajaLogica == false select d);
            ValidateUnicidad(coleccion,ValorNumerico.ToString(), "Valor Numérico", CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CAMPO);

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
                return (int)IdAccion.Rol;
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
        public string Descripcion { get; set; }
        
        [DataMember]
        public short ValorNumerico { get; set; }
        
        [DataMember]
        public bool BajaLogica { get; set; }
        
        [DataMember]
        public string UltimaActualizacion { get; set; }
    }
}