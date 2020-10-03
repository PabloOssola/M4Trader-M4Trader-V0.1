using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Configuration;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    public class ActualizaConfiguracionSistemaCommand : ABMContextCommand
    {

        public override bool needTransactionalBevahiour()
        {
            return true;
        }

        public override void Validate()
        {
            NombreEntidad = "ConfiguracionSistema";

            #region Requerido

            #endregion Requerido

            if (!valida)
            {
                throw fe;
            }
        }

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.ConfiguracionSistema
                           .Include(d => d.ConfiguracionSistemaUrls)
                           where d.IdConfiguracionSistema == r_id
                           select d);

            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            ConfiguracionSistemaEntity request = entidad.FirstOrDefault();

            request.OcultarErroresBaseDeDatos = OcultarErroresBaseDeDatos;
            request.PathSalida = PathSalida;
            request.TiempoLogSQL = TiempoLogSQL;
            request.PermiteProcesamientoParalelo = PermiteProcesamientoParalelo;
            request.EnviaNotificaciones = EnviaNotificaciones;
            request.AbsoluteServicesURL = AbsoluteServicesURL;
            request.EnviarAgentCode = EnviarAgentCode;
            request.ApiServicePort = ApiServicePort;
            request.JwtSecretKey = JwtSecretKey;
            request.JwtAudienceToken = JwtAudienceToken;
            request.JwtIssuerToken = JwtIssuerToken;
            request.MaxOperationRows = MaxOperationRows;
            request.MinOperationRows = MinOperationRows;

            request.ConfiguracionSistemaUrls = (from d in context.ConfiguracionSistemaUrls
                                                where d.IdConfiguracionSistema == r_id
                                                select d).ToList();
            var nuevasUrls = ConfiguracionSistemasUrls.Where(p => (!request.ConfiguracionSistemaUrls.Any(p2 => p2.IdConfiguracionSistemaUrls == p.IdConfiguracionSistemaUrls) || p.IdConfiguracionSistemaUrls == 0));
            foreach (ConfiguracionSistemaUrls r in nuevasUrls)
            {
                ConfiguracionSistemaUrlsEntity e = new ConfiguracionSistemaUrlsEntity
                {
                    Url = r.Url,
                    TipoUrl = r.TipoUrl.ToString(),
                    Usuario = r.Usuario,
                    Password = r.Password,
                    IdConfiguracionSistemaUrls = r.IdConfiguracionSistemaUrls,
                    Parametros = r.Parametros
                };
                request.ConfiguracionSistemaUrls.Add(e);
            }

            var eliminadasUrls = request.ConfiguracionSistemaUrls.Where(p => !ConfiguracionSistemasUrls.Any(p2 => p.IdConfiguracionSistemaUrls == p2.IdConfiguracionSistemaUrls));

            foreach (ConfiguracionSistemaUrlsEntity r in eliminadasUrls)
            {
                context.Remove(r);
            }

            return null;
        }

        public override void ExecuteAfterSuccess()
        {
            OrdenesApplication.Instance.RefreshConfiguracionSistema(false);
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.ConfiguracionSistema;
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
        public short r_id { get; set; }
        [DataMember]
        public bool EnviaNotificaciones { get; set; }
        [DataMember]
        public string AbsoluteServicesURL { get; set; }
        [DataMember]
        public bool EnviarAgentCode { get; set; }
        [DataMember]
        public ConfiguracionSistemaUrls[] ConfiguracionSistemasUrls { get; set; }
        [DataMember]
        public bool OcultarErroresBaseDeDatos { get; set; }
        [DataMember]
        public string PathSalida { get; set; }
        [DataMember]
        public int TiempoLogSQL { get; set; }
        [DataMember]
        public bool PermiteProcesamientoParalelo { get; set; }
        [DataMember]
        public int ApiServicePort { get; set; }
        [DataMember]
        public string JwtSecretKey { get; set; }
        [DataMember]
        public string JwtAudienceToken { get; set; }
        [DataMember]
        public string JwtIssuerToken { get; set; }
        [DataMember]
        public byte MaxOperationRows { get; set; }
        [DataMember]
        public byte MinOperationRows { get; set; }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }
    }
}