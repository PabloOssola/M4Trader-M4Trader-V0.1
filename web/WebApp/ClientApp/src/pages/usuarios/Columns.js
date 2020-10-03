import { Traductor } from '../../services/I18nService';

    let columns = [
        {
            field: "UserName",
            title: Traductor.traducir("LBL_USERNAME"),
            options: {
                filter: true,
                sort: true,
            }
        },
        {
            field: "Nombre",
            title: Traductor.traducir("LBL_USERNAME"),
            options: {
                filter: true,
                sort: true,
            }
        }
    ];

   export {
    columns
   } 
