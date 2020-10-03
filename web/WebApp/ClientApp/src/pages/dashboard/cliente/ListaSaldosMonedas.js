import React, { useState, useEffect, useRef } from 'react';
import Grid from '@material-ui/core/Grid';
import SaldosService from '../../../services/SaldosService';
import SaldoMoneda from './SaldoMoneda';

export default function ListaSaldosMonedas() {

    let [listaSaldos, setListaSaldos] = useState([]);

    useEffect( ()=> {    
        /* consultar saldos en monedas */
        async function fetchData()
        {
            
            let saldos = await SaldosService.ObtenerSaldos();

            console.log(saldos);
    
            setListaSaldos(saldos);
        }
        fetchData();

    }, []);

    return (
        <Grid container spacing={1}>
            {listaSaldos.map(moneda => {
                return(
                    <Grid item key={moneda.IdMoneda}>
                        <SaldoMoneda moneda={moneda} />
                    </Grid>
                )
            })}
        </Grid>
    )
}
