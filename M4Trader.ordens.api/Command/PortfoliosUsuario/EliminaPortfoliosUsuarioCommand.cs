using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    public class EliminaPortfoliosUsuarioCommand : ABMContextCommand
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
            var request = (from d in context.PortfoliosUsuario where Ids.Contains(d.IdPortfolioUsuario) select d).ToList();
            this.context.RemoveRange(request);

            return null;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override void Validate()
        {
            NombreEntidad = "PortfolioUsuario";

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
                return (int)IdAccion.PortfoliosUsuario;
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
        public int IdUsuario { get; set; }

        [DataMember]
        public List<int> IdPortfolioUsuarios { get; set; }

        [DataMember]
        public int[] Ids { get; set; }
    }
}