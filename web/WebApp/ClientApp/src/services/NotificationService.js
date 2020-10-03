import { WSApiServer } from '../Api/WsApi';


function notificationService() {

}


notificationService.prototype.Enviar = async function (travel) {

    

    let promise = new Promise(async (resolve, reject) => {
        try {
          

            let result = await WSApiServer.command("NotificationCommand", travel, {});
                          
            resolve(result);
        }
        catch (error) {
            reject(error);
        }

    });

    return promise;

}

const NotificationService = new notificationService();

export {

    NotificationService
}