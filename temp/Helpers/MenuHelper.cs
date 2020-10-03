using M4Trader.ordenes.server.Caching;
using M4Trader.ordenes.server.Entities;
using M4Trader.ordenes.services.Exceptions;
using M4Trader.ordenes.server.Models;
using M4Trader.ordenes.services.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace M4Trader.ordenes.server.Helpers
{

    public class MenuHelper
    {
        public List<MenuOrdenesItem> GetMenuOrdenesItems(byte? tipo)
        {
            //List<MenuOrdenesItem> menuAllItems = new List<MenuOrdenesItem>();
            //List<MenuOrdenesItem> menuItemsWithPermissions = new List<MenuOrdenesItem>();

            string subfolder = string.Empty;
            switch (tipo)
            {
                case (byte)TipoAplicacion.WEBEXTERNASECURITY:
                    subfolder = "Security/";
                    break;
                case (byte)TipoAplicacion.WEBEXTERNA:
                    subfolder = "Extranet/";
                    break;
                case (byte)TipoAplicacion.MOBILE:
                    subfolder = "Mobile/";
                    break;
                default: 
                    break;
            }

            string filePath = string.Empty;

            if (System.Web.Hosting.HostingEnvironment.ApplicationID != null)
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Configuracion/") + subfolder + "Menu.json";
            else
            {
                filePath = System.Environment.CurrentDirectory;
                filePath = Path.Combine(filePath, "Configuracion/", subfolder) + "Menu.json";  
            }
            var jsonString = File.ReadAllText(filePath);
            MenuOrdenes menu = JsonConvert.DeserializeObject<MenuOrdenes>(jsonString);
            var topMenu = menu.top;

            MAEUserSession M4TraderUserSession = MAEUserSession.Instancia; 
            List<MenuAction> actions = this.DoGetActions();
            List<Permiso> permissions = CachingManager.Instance.GetAllPermisosByIdUsuario(M4TraderUserSession.IdUsuario);

            bool allowedAction = false;
            foreach (var menuOrdenesItem in topMenu)
            {

                foreach (var item in menuOrdenesItem.items)
                {
                    List<Permiso> permissionsOfAction = permissions.FindAll(permission => permission.IdAccion == item.actionId);
                    allowedAction = false;
                    if (item.actionId != 0)
                    {
                        if (permissionsOfAction.Count == 1)
                        {
                            if (item.permissionMask != 0)
                            {
                                MenuAction action = actions.FirstOrDefault(a => a.ActionId == item.actionId);
                                if (action != null)
                                {
                                    int calculatedPermissionMask = item.permissionMask &
                                                                   permissionsOfAction[0].Permisos &
                                                                   action.PermisosHabilitados;
                                    if (calculatedPermissionMask == item.permissionMask)
                                        allowedAction = true;
                                }
                            }
                            else
                            {
                                allowedAction = true;
                            }
                            item.permissionPermitted = permissionsOfAction[0].Permisos;
                        }
                        else if (permissionsOfAction.Count > 1)
                            throw new M4TraderApplicationException("Error de permisos. Existe mas de un Permission para una acción dada.");
                    }
                    else
                        allowedAction = true;

                    item.allowed = allowedAction;

                }
            }

            foreach (var menuOrdenesItem in topMenu)
            {
                for (var i = 0; i < menuOrdenesItem.items.Count; i++)
                {
                    if (!menuOrdenesItem.items[i].allowed)
                    {
                        menuOrdenesItem.items.RemoveAt(i);
                        i--;
                    }
                }

            }

            return (from p in topMenu
                    where p.items.Any(c => c.allowed == true)
                    select p).ToList<MenuOrdenesItem>();

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
        
    }
}
