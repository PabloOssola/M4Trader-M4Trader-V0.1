import React, { useState, useEffect } from "react";
import { UserService } from '../../services/UserService';
import Typography from '@material-ui/core/Typography';
import { Grilla } from '../../components/Grid/Grilla';
import { Traductor } from '../../services/I18nService';
import {columns } from './Columns';



function UsuariosPanel() {
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
            <Typography variant="h1" color="initial">
                Panel general de usuarios
            </Typography>
        </>

    )
}


export default UsuariosPanel;