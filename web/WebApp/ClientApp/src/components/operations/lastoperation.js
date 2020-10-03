import React from 'react';
import { columns,data} from './Columns';
import { Grilla } from '../../components/Grid/Grilla';




export default function LastOperation()
{




    return (
        <Grilla
            title="Info"
            columns={columns}
            data={data}
        />
        

    )

};
