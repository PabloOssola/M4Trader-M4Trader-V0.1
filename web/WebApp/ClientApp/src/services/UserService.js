import { WSApiServer } from '../Api/WsApi';


function userService() {

}


userService.prototype.ObtenerUsuarios = async function () {

    

    let promise = new Promise(async (resolse, reject) => {
        try {
            //let LITERALES = await WSApiServer.selfApi("I18n", {});

            let filtros = {
                PageNumber: 1,
                PageSize: 20
            };
            let queryName = "USUARIOS";
            let data = await WSApiServer.execQueryGridHelper(`QRY_SCRN_${queryName}_GRID_MAIN_ALL`,filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;

}

const UserService = new userService();

export {

    UserService
}