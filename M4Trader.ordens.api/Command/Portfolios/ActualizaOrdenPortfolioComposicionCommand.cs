using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class ActualizaOrdenPortfolioComposicionCommand : ABMContextCommand
    {
        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entities = JsonConvert.DeserializeObject<List<PortfolioComposicionEntity>>(Entidades);
            byte orden = 0;
            foreach (var entity in entities)
            {
                var pc = context.PortfoliosComposicion.FirstOrDefault(x => x.IdPortfoliosComposicion == entity.IdPortfoliosComposicion);
                if (pc == null)
                    return null;
                pc.Orden = orden;
                orden++;
            }
            return null;
        }


        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfolioComposicion";

            #region Requerido

            #endregion Requerido

            #region Unicidad

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
                return (int)IdAccion.Portfolios;
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
        public string Entidades { get; set; }
    }
}