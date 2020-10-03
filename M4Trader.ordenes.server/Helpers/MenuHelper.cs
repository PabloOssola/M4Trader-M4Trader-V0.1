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
        public List<MenuOrdenesItem> GetMenuOrdenesItems(byte? tipo, byte IdTipoPersona)
        {
         
            string subfolder = string.Empty;
            
            string filePath = string.Empty;

            string tipoPersonaMenu = string.Empty;

            switch (IdTipoPersona)
            {
                case 1:
                    tipoPersonaMenu = "ADMAGENCIA";
                    break;
                case 2:
                    tipoPersonaMenu = "ADMUSUARIOSAGENCIA";
                    break;
                case 3:
                    tipoPersonaMenu = "USUARIODEAGENCIA";
                    break;
                default:
                    tipoPersonaMenu = string.Empty;
                    break;  
            }

            if (System.Web.Hosting.HostingEnvironment.ApplicationID != null)
                filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Configuracion/") + subfolder + "Menu_" + tipoPersonaMenu + ".json";
            else
            {
                filePath = System.Environment.CurrentDirectory;
                filePath = Path.Combine(filePath, "Configuracion/", subfolder) + "Menu_" + tipoPersonaMenu + ".json";  
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
                if (menuOrdenesItem.items.Count == 0)
                {
                    List<Permiso> permissionsOfAction = permissions.FindAll(permission => permission.IdAccion == menuOrdenesItem.actionId);
                    allowedAction = false;
                    if (menuOrdenesItem.actionId != 0)
                    {
                        if (permissionsOfAction.Count == 1)
                        {
                            if (menuOrdenesItem.permissionMask != 0)
                            {
                                MenuAction action = actions.FirstOrDefault(a => a.ActionId == menuOrdenesItem.actionId);
                                if (action != null)
                                {
                                    int calculatedPermissionMask = menuOrdenesItem.permissionMask &
                                                                   permissionsOfAction[0].Permisos &
                                                                   action.PermisosHabilitados;
                                    if (calculatedPermissionMask == menuOrdenesItem.permissionMask)
                                        allowedAction = true;
                                }
                            }
                            else
                            {
                                allowedAction = true;
                            }
                            menuOrdenesItem.permissionPermitted = permissionsOfAction[0].Permisos;
                        }
                        else if (permissionsOfAction.Count > 1)
                            throw new M4TraderApplicationException("Error de permisos. Existe mas de un Permission para una acción dada.");
                    }
                    else
                        allowedAction = true;

                    menuOrdenesItem.allowed = allowedAction;
                }

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
                    where ((p.items.Any(c => c.allowed == true)) || (p.allowed == true))
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
