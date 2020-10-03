using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.Exceptions;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.MCContext.Entidades;
using M4Trader.ordenes.services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace M4Trader.ordenes.server
{
    [DataContract]
    [CommandType("AltaChtCmnd", (int)IdAccion.Chat, TipoAplicacion.DMA)]
    public class AltaChatCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            int IdChat = ChatHelper.CrearChat(Nombre, EsGrupo);

            ChatEntity chat = this.context.Chats.Find(IdChat);


            if (chat!=null)
            {
                foreach (string idUsuario in Usuarios.Split(','))
                {
                    ChatUsuarioEntity request = new ChatUsuarioEntity()
                    {
                        IdUsuario = short.Parse(idUsuario),
                        Fecha = DateTime.Now,
                        EsOwner = false,
                        IdChat = IdChat

                    };
                    this.AgregarAlContextoParaAlta(request);
                }
                ChatUsuarioEntity owner = new ChatUsuarioEntity()
                {
                    IdUsuario = IdUsuario,
                    Fecha = DateTime.Now,
                    EsOwner = EsGrupo,//Si es grupo es el owner, sino, no, por ser chat individual.
                    IdChat = IdChat

                };
                this.AgregarAlContextoParaAlta(owner);
            }
            ChatHelper.InformarNuevoGrupo(chat, Usuarios, IdUsuario);
            return null;

        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return true;
            }
        }

        public override void Validate()
        {

            NombreEntidad = "Chat";
            if (!EsGrupo)
            {
                var coleccion = (from cu  in context.ChatUsuarios
                                 join cu2 in context.ChatUsuarios on cu.IdChat equals cu2.IdChat
                                      where cu.IdUsuario == IdUsuario
                                      && cu2.IdUsuario == Int32.Parse(Usuarios)
                                 select cu);
                ValidateUnicidad(coleccion, "Usuarios", "Chat", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);


            }
            else
            {
                if (string.IsNullOrEmpty(Nombre))
                {
                    ValidateString(Nombre, Nombre, CodigosMensajes.FE_ALTA_REQUERIDO_CAMPO);
                }
                var coleccion = (from c in context.Chats
                                 where c.Nombre == Nombre
                                 select c);
                ValidateUnicidad(coleccion, "Nombre", "Chat", CodigosMensajes.FE_ALTA_UNICIDAD_CAMPO);
            }
            if (!valida)
            {
                throw fe;
            }
        }

        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Chat;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }


        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public string Usuarios { get; set; }

        [DataMember]
        public bool EsGrupo { get; set; }


    }
}