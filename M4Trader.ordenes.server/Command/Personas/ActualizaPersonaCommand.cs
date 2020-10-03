using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System.Collections.Generic;
using System.Linq;

namespace M4Trader.ordenes.server
{ 
    [CommandType("ActualizaPersonaCommand", (int)IdAccion.Personas, TipoAplicacion.WEBEXTERNASECURITY)]
    public class ActualizaPersonaCommand : PersonaCommand
    {

        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            var entidad = (from d in context.Persona where d.IdParty == r_id select d);
            ValidateExiste(entidad.Count(), r_id, CodigosMensajes.FE_ACTUALIZA_NO_EXISTE);

            PartyEntity request = entidad.FirstOrDefault();
            request.IdPartyType = IdPartyType;
            request.Name = Name;
            request.MarketCustomerNumber = MarketCustomerNumber;
            request.DocumentNumber = DocumentNumber;
            request.IdLegalPersonality = IdLegalPersonality;
            request.TaxIdentificationNumber = TaxIdentificationNumber;
            /*if (IdTipoPersona == (byte)TipoPersona.CLIENTE && IdEmpresa.HasValue)
                request.IdEmpresa = IdEmpresa.Value;
            else
                request.IdEmpresa = null;*/
            List<int> IdParties = GetParents(Parties);
            string parties = string.Empty;
            foreach (int IdPartyFather in IdParties)
            {
                var entidades = (from d in context.PartyHierarchyEntities where d.IdPartyHijo == r_id && d.IdPartyFather == IdPartyFather select d).ToList();
                if (entidades.Count() == 0)
                {
                    var padre = (from d in context.Persona where d.IdParty == IdPartyFather select d).FirstOrDefault();
                    if ((IdPartyType == (byte)TipoPersona.CLIENTE && (padre.IdPartyType == (byte)TipoPersona.NEGOCIADOR || padre.IdPartyType == (byte)TipoPersona.LIQUIDADOR)) ||
                        (IdPartyType == (byte)TipoPersona.NEGOCIADOR && padre.IdPartyType == (byte)TipoPersona.LIQUIDADOR))
                    {
                        PartyHierarchyEntity father = new PartyHierarchyEntity()
                        {
                            IdPartyFather = IdPartyFather,
                            Party = request

                        };
                        this.AgregarAlContextoParaAlta(father);
                    } else
                    {
                        parties += padre.Name + ", ";
                    }
                }
            }
            foreach (PartyHierarchyEntity r in context.PartyHierarchyEntities.Where(p => ((!Parties.Contains(p.IdPartyFather.ToString()) || string.IsNullOrEmpty(Parties)) && p.IdPartyHijo == r_id)))
            {
                context.Remove(r);
                request.PartyItems.Remove(r);
            }
            Message = (IdParties.Count() == request.PartyItems.Count) ? "" : "No se pudo asociar la persona a algunas de las otras personas seleccionadas: " + parties.Substring(0,parties.Length - 2);
            request.Phone = Phone;

            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message });
        }

        public override void Validate()
        {
            NombreEntidad = "Persona";

            #region Requerido
            ValidateString(MarketCustomerNumber.ToString(), "Nro Cliente", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(Name, "Nombre Persona", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(IdPartyType.ToString(), "Tipo Persona", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(DocumentNumber, "Nro Documento", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            ValidateString(IdLegalPersonality.ToString(), "Personeria Juridica", CodigosMensajes.FE_ACTUALIZA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad
            if (IdPartyType == (byte)TipoPersona.CARTERAPROPIA)
            {
                var coleccion = (from d in context.Persona where d.IdPartyType == IdPartyType && d.IdParty != r_id select d);
                ValidateUnicidad(coleccion, CodigosMensajes.FE_ACTUALIZA_UNICIDAD_CARTERA_PROPIA);
            }
            #endregion Unicidad

            if (!valida)
            {
                throw fe;
            }
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