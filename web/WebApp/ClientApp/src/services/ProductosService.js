import { WSApiServer } from '../Api/WsApi';
import store from '../store/store';

function productosService()
{

}

productosService.prototype.ObtenerProductos = function(pageNumber,pageSize)
{


    let promise = new Promise(async (resolse, reject) => {
        try {

            let filtros = {
                PageNumber : pageNumber,
                PageSize : pageSize
            };
          
            let data = await WSApiServer.execQueryGridHelper("QRY_SCRN_MONEDASYSALDOSBYPERSONA",filtros ,true);


            resolse(data);
        }
        catch (error) {
            reject(error);
        }

    })

    return promise;
}



const ProductosService = new productosService();


export default  ProductosService;
