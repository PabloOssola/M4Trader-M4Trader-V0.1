import React, { useState, useEffect } from 'react';
import { Traductor } from '../../../services/I18nService';
import Box from '@material-ui/core/Box';
import useStyles from "./styles";
import Grid from '@material-ui/core/Grid'
import ListaSaldosMonedas from './ListaSaldosMonedas';
import MiActividadSaldos from './MiActividad/MiActividadSaldos';
import Button from '@material-ui/core/Button'
import Typography from '@material-ui/core/Typography'




export default function MiDashboard() {
    let classes = useStyles();
    let TituloMisSaldos = Traductor.traducir("TituloMisSaldos");
    let TituloMiActividad = Traductor.traducir("TituloMiActividad");
    return (
        <Box className={classes.container}>
            <Grid container spacing={2} direction="column">
                <Grid item className={classes.misSaldos}>
                    <Box >
                        <Typography variant="h6" color="initial">
                            {TituloMisSaldos}
                        </Typography>
                    </Box>
                    <ListaSaldosMonedas />
                </Grid>
                <Grid item className={classes.miActividad}>
                    <Box >
                        <Typography variant="h6" color="initial">
                            {TituloMiActividad}
                        </Typography>
                    </Box>
                    <MiActividadSaldos/>
                </Grid>
            </Grid>
        </Box>

    )
}
