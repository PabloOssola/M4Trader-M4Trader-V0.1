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
    [CommandType("AltaPersonaCommand", (int)IdAccion.Personas, TipoAplicacion.WEBEXTERNASECURITY, TipoAplicacion.ORDENES)]
    public class AltaPersonaCommand : PersonaCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            PartyEntity request = new PartyEntity();
            request.IdPartyType = IdPartyType;
            request.Name = Name;
            request.MarketCustomerNumber = MarketCustomerNumber;
            request.DocumentNumber = DocumentNumber;
            request.IdLegalPersonality = IdLegalPersonality;
            request.TaxIdentificationNumber = TaxIdentificationNumber;
            List<int> listParties = GetParents(Parties);
            foreach (int IdFather in listParties)
            {
                var IdPartyTypeFather = (from d in context.Persona where d.IdParty == IdFather select d).FirstOrDefault().IdPartyType;
                if ((IdPartyType == (byte)TipoPersona.CLIENTE && (IdPartyTypeFather == (byte)TipoPersona.NEGOCIADOR || IdPartyTypeFather == (byte)TipoPersona.LIQUIDADOR))||
                    (IdPartyType == (byte)TipoPersona.NEGOCIADOR && IdPartyTypeFather == (byte)TipoPersona.LIQUIDADOR))
                {                    
                    PartyHierarchyEntity father = new PartyHierarchyEntity()
                    {
                        IdPartyFather = IdFather,
                        Party = request

                    };
                    request.PartyItems.Add(father);
                }
            }
            Message = (listParties.Count() == request.PartyItems.Count) ? "" : "La nueva persona no pudo ser asociada a algunas de las otras personas.";
            request.Phone = Phone;

            this.AgregarAlContextoParaAlta(request);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { Ok = true, Message });
        }
        
        public override void Validate()
        {
            NombreEntidad = "Persona";

            #region Requerido
            ValidateString(MarketCustomerNumber.ToString(), "Nro Cliente", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(Name, "Nombre Persona", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(IdPartyType.ToString(), "Tipo Persona", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(DocumentNumber, "Nro Documento", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            ValidateString(IdLegalPersonality.ToString(), "Personeria Juridica", CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
            #endregion Requerido

            #region Unicidad
            if (IdPartyType == (byte)TipoPersona.CARTERAPROPIA)
            {
                var coleccion = (from d in context.Persona where d.IdPartyType == IdPartyType && d.IdParty != r_id select d);
                ValidateUnicidad(coleccion, CodigosMensajes.FE_ALTA_UNICIDAD_CARTERA_PROPIA);
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
                return (int)TipoPermiso.ALTA;
            }
        }
    }
}