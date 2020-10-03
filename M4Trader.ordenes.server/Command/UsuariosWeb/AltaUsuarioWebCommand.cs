using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.server.MCContext.Entidades.Logging;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [CommandType("AltaUsuarioWebCommand", (int)IdAccion.AdministracionUsuariosWeb, TipoAplicacion.DMA, TipoAplicacion.WEBEXTERNASECURITY)]
    public class AltaUsuarioWebCommand : UsuarioWebCommand
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
            ValidateString(Name, "Nombre", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido


            #region Unicidad

            var coleccion = (from d in context.Usuario where d.Username == UserName select d);
            ValidateUnicidad(coleccion, UserName, NombreEntidad, CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);

            #endregion Unicidad

            validarIgualdad(Password, ConfirmPassword, NombreEntidad, CodeMensajes.ERR_CLAVES_VERIFICACION);

            if (!valida)
            {
                throw fe;
            }

        }

        
        public override void ExecuteAfterSuccess()
        {
            AgregarChats(UserName);
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            UsuarioEntity requestUsuario = new UsuarioEntity()
            {
                Username = UserName,
                Pass = MAETools.HashMD5(Password),
                Nombre = Name,
                Bloqueado = false,
                NoControlarInactividad = false,
                ConfiguracionRegional = "es-AR",
                Proceso = false,
                UltimaModificacionPassword = DateTime.Now,
                UltimoLoginExitoso = DateTime.Now,
                Email = Email,
                IdPersona = IdPersona,
                Portfolio = new List<PortfolioUsuarioEntity>()
            };

            if (CachingManager.Instance.GetPersonaById(IdPersona).IdPartyType == (int)TipoPersona.ADMUSERS)
            {
                requestUsuario.IdPersona = CachingManager.Instance.GetIdPersonaAdministradaById(IdPersona);

                List<DTOPortfolio> portfolios = CachingManager.Instance.GetPortfoliosByIdPersona(IdPersona);
                foreach (DTOPortfolio por in portfolios)
                {
                    AgregarPortfolio(requestUsuario, por.IdPortfolio);
                }
                AgregarLimites(requestUsuario, LimiteOferta, LimiteOperacion);
            }

            AgregarRolesPorDefecto(requestUsuario);
            AgregarAlContextoParaAlta(requestUsuario);
            
            SessionHelper.InsertarLogSeguridad((byte)LogCodigoAccionSeguridad.AltaUsuario, "Nuevo user: " + UserName, (byte)TipoAplicacion.ORDENES);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message = "Se creó el usuario correctamente" });
        }

        private void AgregarChats(string userName)
        {
            UsuarioEntity usuarioOrigen = CachingManager.Instance.GetUsuarioByUsername(UserName);
            List<UsuarioEntity> usuarios = CachingManager.Instance.GetAllUsuarios();
            foreach (UsuarioEntity u in usuarios)
            {

                ChatEntity chat = new ChatEntity()
                {
                    Nombre = "Chat",
                    EsGrupo = false,
                    Fecha = DateTime.Now
                };
                ChatUsuarioEntity chatUsuario = new ChatUsuarioEntity()
                {
                    IdUsuario = u.IdUsuario,
                    EsOwner = false,
                    Fecha = DateTime.Now
                };
                ChatUsuarioEntity chatUsuarioDestino = new ChatUsuarioEntity()
                {
                    IdUsuario = usuarioOrigen.IdUsuario,
                    EsOwner = false,
                    Fecha = DateTime.Now
                };
                chat.ChatUsuarioItems.Add(chatUsuario);
                chat.ChatUsuarioItems.Add(chatUsuarioDestino);
                context.Add(chat);
                context.SaveChanges();
            }
        }

        private void AgregarRolesPorDefecto(MCContext.Entidades.UsuarioEntity usuario)
        {
            List<RolEntity> listaRoles = CachingManager.Instance.GetAllRoles();
            string[] roles = { "Ingreso al Sistema","Consultas Generales","Cliente", "DMA"};
            foreach (string rol in roles) {
                RolUsuarioEntity request = new RolUsuarioEntity()
                {
                    Usuario = usuario,
                    IdRol = listaRoles.Find(x => x.Descripcion == rol).IdRol

                };
                usuario.RolUsuarioItems.Add(request);
            }
        }

        private void AgregarLimites(MCContext.Entidades.UsuarioEntity usuario, decimal limiteOferta, decimal limiteOperacion)
        {
            UsuariosLimitesEntity ul = new UsuariosLimitesEntity();
            ul.IdUsuario = usuario.IdUsuario;
            ul.LimiteOferta = limiteOferta;
            ul.LimiteOperacion = limiteOperacion;

            usuario.Limites = ul;
        }

        private void AgregarPortfolio(MCContext.Entidades.UsuarioEntity usuario, short idportfolio)
        {
            PortfolioUsuarioEntity pu = new PortfolioUsuarioEntity();
            pu.IdUsuario = usuario.IdUsuario;
            pu.IdPortfolio = idportfolio;
            pu.PorDefecto = true;

            usuario.Portfolio.Add(pu);
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.ALTA;
            }
        }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ConfirmPassword { get; set; }

        [DataMember]
        public decimal LimiteOferta { get; set; }

        [DataMember]
        public decimal LimiteOperacion { get; set; }

        [DataMember]
        public bool CreaUsuarioTercero { get; set; }
    }

}