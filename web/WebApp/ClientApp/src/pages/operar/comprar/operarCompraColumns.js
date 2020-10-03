import { Traductor } from '../../../services/I18nService';
import moment from 'moment'

// function colValue(col, obj) {
//     let resultado = "";
//     if (col.format) {
//         if (typeof (col.format) === "function")
//             return col.format(obj[col.field]);
//         if (typeof (col.format) === "string")
//             return  col.format(obj[col.field]);

//     }

//     return obj[col.field];
// }

/*
    m.codigo, 
    m.descripcion, 
    m.CodigoISO, 
    p.Precio, 
    s.Importe, 
    s.NumeroCuenta  
*/ 
const columns = [
    { title: Traductor.traducir("ComprarCodigo"), field: 'codigo', style: { width: '100px' } },
    { title: Traductor.traducir("ComprarDescripcion"), field: 'descripcion', style: { width: '100px' }},
    { title: Traductor.traducir("ComprarCodigoISO"), field: 'CodigoISO', style: { width: '100px' } },
    { title: Traductor.traducir("ComprarPrecio"), field: 'Precio', style: { width: '100px' } },
    { title: Traductor.traducir("ComprarImporte"), field: 'Importe', style: { width: '100px' } },
    { title: Traductor.traducir("ComprarNumeroCuenta"), field: 'NumeroCuenta', style: { width: '100px' } }

]

export {
    columns
}