import { Traductor } from '../../services/I18nService';

    let columns = [
        {
            field: "Nombre",
            title: Traductor.traducir("LBL_NOMBRE"),
            options: {
                filter: true,
                sort: true,
            }
        },
        {
            field: "Cantidad",
            title: Traductor.traducir("LBL_CANTIDAD"),
            options: {
                filter: true,
                sort: true,
            }
        },
        {
            field: "Moneda",
            title: Traductor.traducir("LBL_MONEDA"),
            options: {
                filter: true,
                sort: true,
            }
        },
        {
            field: "Precio",
            title: Traductor.traducir("LBL_PRECIO"),
            options: {
                filter: true,
                sort: true,
            }
        },

    ];

    let data = [
        {Nombre : "Jorgue" ,Cantidad : "100", Moneda:"USD",Precio:"125.03"  },
        {Nombre : "Carlos" ,Cantidad : "100", Moneda:"REAL",Precio:"125.03"  },
        {Nombre : "Juan" ,Cantidad : "100", Moneda:"USD",Precio:"125.03"  },
        {Nombre : "Pedro" ,Cantidad : "100", Moneda:"EURO",Precio:"125.03"  },
    ]

   export {
    columns,
    data
   } 
