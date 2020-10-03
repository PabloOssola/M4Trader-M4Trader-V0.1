using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.CQRSFramework.ABM;
using M4Trader.ordenes.server.CQRSFramework.CQRS;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.server.Models;
using Mae.Ordenes.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using M4Trader.ordenes.services.Entities;

namespace M4Trader.ordenes.server
{
    [CommandType("MenuCommand", (int)IdAccion.Menu, TipoAplicacion.API)]
    public class MenuCommand : ABMContextCommand
    {
        public override object ExecuteCommand(InCourseRequest inCourseRequest)
        {
            List<MenuOrdenesItem> menuPrincipal = null;
            MenuHelper ms = new MenuHelper();
            var user = MAEUserSession.Instancia;
            menuPrincipal = ms.GetMenuOrdenesItems(TiposAplicacion, user.IdTipoPersona);
            //menuPrincipal.Insert(0, AddHomeMenu());
            var menuBottom = CreateBottomMenu();
            menuPrincipal = FillMenuDictionary(menuPrincipal);
            // menuBottom = FillMenuDictionary(menuBottom);
            return ExecutionResult.ReturnInmediatelyAndQueueOthers(new { top = menuPrincipal, foot = menuBottom });
        }

        private List<MenuOrdenesItem> FillMenuDictionary(List<MenuOrdenesItem> menuPrincipal)
        {
            var user = MAEUserSession.Instancia;
            if (user.MenuDic == null)
                user.MenuDic = new Dictionary<string, string>();

            var encryptor = new AESEncryptor();

            foreach (MenuOrdenesItem menu in menuPrincipal)
            {
                if (menu.items.Any())
                {
                    foreach (MenuOrdenesItem item in menu.items)
                    {
                        var key = item.url;//encryptor.DynamicEncryption(item.url);
                        if (!user.MenuDic.ContainsValue(item.url))
                        {
                            user.MenuDic.Add(key, item.url);
                            item.url = key;
                        }
                        else
                        {
                            item.url = user.MenuDic.FirstOrDefault(x => x.Value == item.url).Key;
                        }
                    }

                }
                else
                {
                    var key = menu.url;//encryptor.DynamicEncryption(menu.url);
                    if (!user.MenuDic.ContainsValue(menu.url))
                    {
                        user.MenuDic.Add(key, menu.url);
                        menu.url = key;
                    }
                    else
                    {
                        menu.url = user.MenuDic.FirstOrDefault(x => x.Value == menu.url).Key;
                    }
                }
            }

            return menuPrincipal;

        }

        private MenuOrdenesItem AddHomeMenu()
        {
            return new MenuOrdenesItem() { key = 1, actionId = 0, allowed = true, className = "", icon = "Home", permissionMask = 0,name= "Inicio", title = "Inicio", url = "/app/dashboard" };
        }

        private List<MenuOrdenesItem> CreateBottomMenu()
        {
            var bm = new List<MenuOrdenesItem>();
            bm.Add(new MenuOrdenesItem() { key = 1, actionId = 0, allowed = true, className = "", icon = "fa fa-power-off", permissionMask = 0, title = "Desconectar", url = "Main/TimeoutRedirect" });
            return bm;
        }

        public override bool needTransactionalBevahiour()
        {
            return false;
        }

        public override bool RefrescarCache
        {
            get
            {
                return false;
            }
        }


        public override int GetIdAccion
        {
            get
            {
                return (int)IdAccion.Menu;
            }
        }

        public override int GetIdPermiso
        {
            get
            {
                return (int)TipoPermiso.CONSULTA;
            }
        }

        protected virtual List<MenuAction> DoGetActions()
        {
            var acciones = CachingManager.Instance.GetAllAcciones();
            List<MenuAction> actions = acciones.ConvertAll<MenuAction>(a => new MenuAction
            {
                ActionId = a.IdAccion,
                PermisosHabilitados = a.HabilitarPermisos,
                Description = a.Descripcion
            });

            return actions;
        }
        [DataMember]
        public byte? TiposAplicacion { get; set; }
    }
}