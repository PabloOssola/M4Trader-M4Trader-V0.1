import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';

function menuService()
{


}


menuService.prototype.ObtenerMenu = function()
{
    let promise = new Promise(async (resolve, reject)=>{

        try
        {
         
            let result = await WSApiServer.command("MenuCommand", { TiposAplicacion: 0 }, {});
                          
            resolve(result);
            //store.dispatch({type:"set", navigation: respuesta.navigation });
        }
        catch(error)
        {
            reject(error);
        }
              
    });


    return promise;
}    

const MenuService = new menuService();

export default MenuService;