using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{

    public class EliminaUsuarioCommand : UsuarioCommand
    {

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            foreach (var id in Ids)
            {
                runValidations(id);
            }
        }

        private void runValidations(int id)
        {
            var entidad = (from d in context.Usuario where (d.IdUsuario == id) select d).ToList();
            ValidateExiste(entidad.Count(), id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);
            foreach (MCContext.Entidades.UsuarioEntity request in entidad)
            {
                var validacionesEstadoSistema = (from d in context.EstadoSistema where (request.IdUsuario == d.IdUsuarioApertura || request.IdUsuario == d.IdUsuarioCierre) && !d.BajaLogica select d);
                ValidaDependencias(validacionesEstadoSistema.Count(), id, CodigosMensajes.FE_EXISTE_ESTADO_SISTEMA);
            }
        }


        private void updateDependencies(int id)
        {
            var entidad = (from d in context.Usuario where (d.IdUsuario == id) select d).ToList();
            foreach (MCContext.Entidades.UsuarioEntity request in entidad)
            {
                #region Actualizo dependencias
                var historicoPasswordItems = (from d in context.HistoricoPass where d.IdUsuario == id select d);
                foreach (HistoricoPasswordEntity historicoPassword in historicoPasswordItems)
                {
                    context.Remove(historicoPassword);
                }

                var sesionesItems = (from d in context.Sesion where d.IdUsuario == id select d);
                foreach (SesionEntity sesion in sesionesItems)
                {
                    sesion.BajaLogica = true;
                }

                var customizacionUsuarioItems = (from d in context.CustomizacionUsuario where d.IdUsuario == id select d);
                foreach (CustomizacionUsuarioEntity customizacionUsuario in customizacionUsuarioItems)
                {
                    context.Remove(customizacionUsuario);
                }

                #endregion Actualizo dependencias

                request.BajaLogica = true;
                request.FechaBaja = DateTime.Now;
            }
        }


        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            foreach (var id in Ids)
            {
                updateDependencies(id);
            }
            return null;
        }

        private void ValidaDependencias(int Cantidad, int id, string Codigo)
        {
            if (Cantidad > 0)
            {
                fe = new FunctionalException();
                KeyArray keyArray;
                keyArray = new KeyArray();
                keyArray.Codigo = Codigo;
                keyArray.Parametros.Add(NombreEntidad);
                keyArray.Parametros.Add(id.ToString());
                fe.DataValidations.Add(keyArray);
                throw fe;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.BAJA;
            }
        }

        [DataMember]
        public int[] Ids { get; set; }


    }
}