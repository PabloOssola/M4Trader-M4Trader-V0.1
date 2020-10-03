import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';





function themeService() {

}


themeService.prototype.ObtenerThema = async function (NombreUsuario) {



    let promise = new Promise(async (resolse, reject) => {
        try {
            //let LITERALES = await WSApiServer.selfApi("I18n", {});


            let theme = await WSApiServer.command("AppThemeCommand", { NombreUsuario : NombreUsuario }, {});

            

            resolse(theme);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;

}

const ThemeService = new themeService();

export {
    ThemeService
}