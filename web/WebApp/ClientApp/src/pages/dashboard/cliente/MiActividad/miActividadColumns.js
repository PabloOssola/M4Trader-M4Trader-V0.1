import React from 'react';
import { Traductor } from '../../../../services/I18nService';
import moment from 'moment'
import NumberFormat from 'react-number-format';

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


const columns = [
    { title: Traductor.traducir("NroOperacion"), field: 'NroOperacion', style: { width: '100px' } },
    { title: Traductor.traducir("FechaOperacion"), field: 'FechaOperacion', style: { width: '100px' }, format: function (data) { return moment(data.FechaOperacion).format('LLL'); } },
    { title: Traductor.traducir("CodigoMonedaCompra"), field: 'CodigoMonedaCompra', style: { width: '100px' } },
    { title: Traductor.traducir("CodigoMonedaVenta"), field: 'CodigoMonedaVenta', style: { width: '100px' } },
    { title: Traductor.traducir("Cantidad"), field: 'Cantidad', style: { width: '100px' } , format: function (data) { return (<NumberFormat  value={data.Cantidad} displayType={'text'} thousandSeparator={true}  />); }},
    { title: Traductor.traducir("Monto"), field: 'Monto', style: { width: '100px' } , format: function (data) { return (<NumberFormat  value={data.Monto} displayType={'text'} thousandSeparator={true}  />); }},
    { title: Traductor.traducir("Precio"), field: 'Precio', style: { width: '100px' } , format: function (data) { return (<NumberFormat  value={data.Precio} displayType={'text'} thousandSeparator={true}  />); }}

]

export {
    columns
}