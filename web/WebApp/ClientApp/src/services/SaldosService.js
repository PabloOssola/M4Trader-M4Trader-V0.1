import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';

function saldosService()
{

}

saldosService.prototype.ObtenerSaldos = function()
{


    let promise = new Promise(async (resolse, reject) => {
        try {
            //let LITERALES = await WSApiServer.selfApi("I18n", {});
            
            let filtros = {

            };
            
            let data = await WSApiServer.execQueryGridHelper("QRY_SCRN_SALDOSBYMONEDA",filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}
saldosService.prototype.ObtenerSaldoMonedaLocal = function()
{


    let promise = new Promise(async (resolse, reject) => {
        try {
            //let LITERALES = await WSApiServer.selfApi("I18n", {});
            
            let filtros = {

            };
           
            let data = await WSApiServer.execQueryGridHelper("QRY_SCRN_MONEDALOCALYSALDOSBYPERSONA",filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}



const SaldosService = new saldosService();


export default SaldosService;