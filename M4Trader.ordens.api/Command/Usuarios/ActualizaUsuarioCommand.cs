using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server
{

    public class ActualizaUsuarioCommand : UsuarioCommand
    {
        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "Usuario";

            #region Requerido
            ValidateString(UserName, "Usuario", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Nombre, "Nombre", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateInt(this.IdPersona, "Id Persona", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(RolesUsuario, "Roles", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);


            #endregion Requerido


            #region Unicidad

            var coleccion = (from d in context.Usuario where d.Username == UserName && d.IdUsuario != r_id select d);
            ValidateUnicidad(coleccion, UserName, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }

        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Usuario where d.IdUsuario == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            MCContext.Entidades.UsuarioEntity request = entidad.FirstOrDefault();
            
            string oldUserName = request.Username;
            bool oldBloqueado = request.Bloqueado;
            request.Bloqueado = Bloqueado;
            request.IdPersona = IdPersona;
            request.Username = UserName;
            request.Nombre = Nombre;
            request.NoControlarInactividad = NoControlarInactividad;
            request.Proceso = Proceso;
            List<short> Roles = GetRolesUsuario(RolesUsuario);
            foreach (short rolId in Roles)
            {
                var entidadRolUsuario = (from d in context.RolUsuario where d.IdUsuario == r_id && d.IdRol == rolId select d).ToList();
                if (entidadRolUsuario.Count() == 0)
                {
                    RolUsuarioEntity rolUsuarioRequest = new RolUsuarioEntity()
                    {
                        IdUsuario = request.IdUsuario,
                        IdRol = rolId,

                    };
                    this.AgregarAlContextoParaAlta(rolUsuarioRequest);
                }
            }
            foreach(RolUsuarioEntity r in context.RolUsuario.Where(p => !RolesUsuario.Contains(p.IdRol.ToString()) && p.IdUsuario == r_id))
            {

                    context.Remove(r);
             
            }
            if (!Bloqueado && oldBloqueado)
            {
                request.CantidadIntentos = 0;
                request.UltimoLoginExitoso = DateTime.Now;
            }
            SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.ActualizaUser, "Usuario actualizado: " + request.Username, (byte)TipoAplicacion.ORDENES);
            return null;
        }


        private List<short> GetRolesUsuario(string RolesUsuario)
        {
            List<short> col = new List<short>();

            foreach (var permiso in RolesUsuario.Split(','))
            {
                col.Add(short.Parse(permiso));
            }
            return col;
        }

        public override void ExecuteAfterSuccess()
        {

        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.MODIFICACION;
            }
        }

    }
}