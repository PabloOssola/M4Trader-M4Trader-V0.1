import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';
import { ClassSharp } from '@material-ui/icons';


function traductor() {
    this.LITERALES = {};

}

traductor.prototype.cargarLiterales = function (data) {
    this.LITERALES = data;


}

traductor.prototype.traducir = function (label) {
    let traduccion = this.LITERALES[label] || label;

    return traduccion;

}

function i18nService() {

}

const Traductor = new traductor();
i18nService.prototype.ObtenerLiterales = async function (NombreUsuario) {



    let promise = new Promise(async (resolse, reject) => {
        try {
            //let LITERALES = await WSApiServer.selfApi("I18n", {});


            let result = await WSApiServer.command("AppLiteralesCommand", { NombreUsuario : NombreUsuario }, {});
            
            Traductor.cargarLiterales(result.Data.LITERALES);

            resolse(result);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;

}

const I18nService = new i18nService();

export {
    Traductor,
    I18nService
}