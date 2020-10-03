using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System;

namespace M4Trader.ordenes.server.Helpers
{
    public static class ContextHelper
    {
        public static string get(InCourseRequest inCourseRequest, string WebUrlName)
        {
            DateTime fechaDelSistema = DateTime.Today;
            Guid guidId = inCourseRequest.SecurityTokenId;
            SessionHelper.GetSesionExistente(guidId);
            MAEUserSession userSession = MAEUserSession.Instancia;
            var beEstadoSistema = CachingManager.Instance.GetFechaSistema();
            if (beEstadoSistema != null)
            {
                fechaDelSistema = beEstadoSistema.FechaSistema.Date;
                userSession.EstadoSistema = (beEstadoSistema.EstadoAbierto) ? "Abierto" : "Cerrado";
            }
            var Permissions = CachingManager.Instance.GetAllPermisosByIdUsuario(userSession.IdUsuario);
            DTOPortfolio DefaultPortfolio = CachingManager.Instance.GetPortfolioDefaultByIdUsuario(userSession.IdUsuario);
            string CodigoPortfolio = DefaultPortfolio?.Codigo;

            OrdenesAppContext context = new  OrdenesAppContext()
            {
                UserName = userSession.UserName.ToString(),
                TipoParticipante = UserHelper.getNombreTipoPersona(userSession.IdTipoPersona),
                SecurityTokenId = userSession.ID.ToString(),
                WebUrlName = WebUrlName,
                MaeAppName = "Ordenes_v_500",
                EstadoSistema = beEstadoSistema,
                FechaDelSistema = fechaDelSistema,
                FormatoFechaCorta = "dd/MM/yyyy",
                FormatoFechaCortaMoment = "DD/MM/YYYY",
                FormatoFechaHora = "dd/MM/yyyy HH:mm",
                Global = userSession.Global,
                PublicKey = userSession.PublicKey,
                IdUsuario = userSession.IdUsuario,
                IdPersona = userSession.IdPersona,
                IdTipoPersona= userSession.IdTipoPersona,
                ClientSecret = userSession.ClientSecret,
                ServerPublic = userSession.ServerPublic,  
                Nonce = userSession.Nonce,
                JavascriptAllowedCommands = userSession.JavascriptAllowedCommands,
                PermisosUsuario = userSession.PermisosUsuario,
                CodigoPortfolio = CodigoPortfolio,
                LanguageTag = userSession.ConfiguracionRegional,
                LoginRealizado = userSession.LoginRealizado
            };

            

            var s = JsonConvert.SerializeObject(context, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });

                return s;

        }
    }
}
