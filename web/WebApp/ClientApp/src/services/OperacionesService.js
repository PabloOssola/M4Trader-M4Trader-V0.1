import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';

function operacionesService()
{

}

operacionesService.prototype.ObtenerOperaciones = function(pageNumber,pageSize)
{


    let promise = new Promise(async (resolse, reject) => {
        try {

            let filtros = {
                PageNumber : pageNumber,  
                PageSize : pageSize
            };
          
            let data = await WSApiServer.execQueryGridHelper("QRY_SCRN_OPERACIONESBYPERSONA",filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}
operacionesService.prototype.ObtenerMovimientos = function(IdOperacion)
{


    let promise = new Promise(async (resolse, reject) => {
        try {

            let filtros = {
                IdOperacion : IdOperacion
            };
          
            let data = await WSApiServer.execQueryGridHelper("QRY_SCRN_MOVIMIENTOSBYOPERACION",filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}


operacionesService.prototype.Comprar = function(travel)
{


    let promise = new Promise(async (resolse, reject) => {
        try {

            let options = {
                
            };
          
            let data = await WSApiServer.command("ConcertarOperacionCommand",travel ,options);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}


const OperacionesService = new operacionesService();


export default  OperacionesService;
