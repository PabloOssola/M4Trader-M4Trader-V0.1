import React, { useState, useEffect } from "react";
import { UserService } from '../../services/UserService';
import Typography from '@material-ui/core/Typography';
import { Grilla } from '../../components/Grid/Grilla';
import { Traductor } from '../../services/I18nService';
import {columns } from './Columns';


function Gestion() {
    let [usuarios, setUsuarios] = useState([])


    let options = {

    };
    useEffect(() => {

        async function obtenerUsuarios() {
            
            let usuarios = await UserService.ObtenerUsuarios();
            console.dir(usuarios);
            setUsuarios(usuarios);
        }
        obtenerUsuarios();

    }, []);

    return (
        <>
            <Grilla
                title={Traductor.traducir("LBL_USERGRID")}
                data={usuarios}
                columns={columns}
                options={options}
            />
        </>

    )
}


export default Gestion;