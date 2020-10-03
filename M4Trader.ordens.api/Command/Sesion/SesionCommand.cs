using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class SesionCommand : UsuarioCommand
    {


        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            foreach (string Id in Ids)
            {
                CerrarSesion(Id);
            }
            return null;
        }

        private void CerrarSesion(string id)
        {
            var entidad = PersistSessionHelper.Instance.GetSessionById(new Guid(id));
            entidad.FechaFinalizacion = DateTime.Now;
            entidad.modifiedOrNew = true;
            PersistSessionHelper.Instance.AddOrUpdate(entidad);
        }

        public override void Validate()
        {

        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

        [DataMember]
        public string[] Ids { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}