import React, { useState, useEffect } from "react";
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import useStyles from "../../components/Layout/styles";
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Divider from '@material-ui/core/Divider';
import Box from '@material-ui/core/Box';
import { useTheme } from "@material-ui/styles";

import { Grilla } from '../../components/Grid/Grilla';
import { Traductor } from '../../services/I18nService';
//const columns = ["Nombre", "CBU", "Cuenta", "Producto", "Cantidad", "Ultimo precio", "Var% diaria", "Gan-Perdida", "Total", "Perfil cliente"];

const columns = [{
    name: 'Nombre',
    options: {
        filter: true,
    },

},
{
    name: 'CBU',
    options: {
        filter: true,
    },

},
{
    name: 'Cuenta',
    options: {
        filter: true,
    },

},
{
    name: 'Producto',
    options: {
        filter: true,
    },

},
{
    name: 'Cantidad',
    options: {
        filter: false,
    },

},
{
    name: 'Ultimo precio',
    options: {
        filter: false,
    },

},
{
    name: 'Var% diaria',
    options: {
        filter: false,
    },

},
{
    name: 'Gan-Perdida',
    options: {
        filter: false,
    },

},
{
    name: 'Total',
    options: {
        filter: false,
    },

},
{
    name: 'Perfil cliente',
    options: {
        filter: true,
    },

},
];


const data = [


    ["J perez", "2059784632-2", "123456", "USD", "1000", "120", "-1.32", "0.05%", "113.56", "Moderado"],
    ["J perez", "2059784632-2", "896547", "Real", "1000", "120", "-1.32", "0.05%", "113.56", "Moderado"]
];

const options = {
    //filterType: 'checkbox',
    filter: true,
    selectableRows: 'multiple',
    selectableRowsHideCheckboxes: true,
    filterType: 'dropdown',
    setTableProps: () => {
        return {
            padding: 'none',
            // material ui v4 only
            size: 'small'
        };
    },
};


function ConsultasDeSaldos() {

    var classes = useStyles();
    var theme = useTheme();
    return (
        <React.Fragment>
            <CssBaseline />
            <Container className={classes.contentCenter} >

                <Grid
                    container
                    direction="column"
                    justify="center"
                    alignItems="start"
                >
                    <Grid item xs={12}>
                        <Typography component="div" variant="h4">
                            <Box lineHeight="normal" m={1}>
                                Consultas generales
                            </Box>
                        </Typography>
                    </Grid>
                </Grid>
            </Container>
        </React.Fragment>
    )

}


export default ConsultasDeSaldos;