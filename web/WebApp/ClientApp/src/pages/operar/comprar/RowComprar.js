import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import classesName from 'classnames';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid'
import ProductosService from '../../../services/ProductosService';
import ButtonBase from '@material-ui/core/ButtonBase';
import Tooltip from '@material-ui/core/Tooltip';
import Typography from '@material-ui/core/Typography';
import Zoom from '@material-ui/core/Zoom';
import NumberFormat from 'react-number-format';
import clsx from 'clsx';

import DialogoCompra from './DialogoCompra';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        padding: theme.spacing(1),
        textAlign: "left",
        width: "100%",
        '&:hover': {
            backgroundColor: "#206ba91c",
            color: "white"

        }

    },
    paper_vender: {
        padding: theme.spacing(1),
        textAlign: "left",
        width: "100%",
        '&:hover': {
            backgroundColor: "#debbbb",
            color: "white"

        }

    },
    paper_comprar: {
        padding: theme.spacing(1),
        textAlign: "left",
        width: "100%",
        '&:hover': {
            backgroundColor: "#9fb39f;",
            color: "white"

        }

    },
    paper_saldo: {
        padding: theme.spacing(1),
        textAlign: "left",
        width: "100%",
        '&:hover': {
            backgroundColor: "#206ba91c",
            color: "white"

        }

    },
    moneda: {

        fontSize: "12px",
        fontWeight: "500",
        color: theme.palette.text.primary,
        width: "300px"
    },
    comprar: {

        fontSize: "14px",
        fontWeight: "500",
        color: "green",
        width: "200px"
    },
    vender: {

        fontSize: "14px",
        fontWeight: "500",
        color: "red",
        width: "200px"
    },
    saldo: {

        fontSize: "12px",
        fontWeight: "500",
        color: theme.palette.text.primary,
        width: "300px"
    },
    buttonBase: {
        width: "100%"
    },
    fab: {
        margin: theme.spacing(2),
    },
}));

const useStylesBootstrap = makeStyles((theme) => ({
    // arrow: {
    //     color: theme.palette.common.black,
    // },
    // tooltip: {
    //     backgroundColor: theme.palette.common.black,
    // },
}));

function BootstrapTooltip(props) {
    const classes = useStylesBootstrap();

    return <Tooltip arrow classes={classes} {...props} />;
}

export default function RowComprar({ row }) {
    const classes = useStyles();
    const [openCompra, setOpenCompra] = useState(false);
    const [openVenta, setOpenVenta] = useState(false);
    const [operacionTermina, setOperacionTermina] = useState(row.operacionTermina);

    let OnCompra = function () {
        setOpenCompra(true);
    }
    let OnVenta = function () {
        setOpenVenta(true);
    }
    let OnCloseCompra = function () {
        setOpenCompra(false);
        setOpenVenta(false);
    }


    // useEffect(() => {
    //     setTimeout(() => {
    //         debugger;
    //         setOperacionTermina(false);
    //     }, 4000);
    // },[row.operacionTermina]);

    return (
        <React.Fragment>

            <Grid item className={classes.moneda}>
                <Paper className={classes.paper}>
                    <span className={classes.moneda}>{row.descripcion}</span>
                </Paper>
            </Grid>

            <Grid item className={classes.comprar}>
                {/* 
                <BootstrapTooltip title={
                    <React.Fragment>
                        <Typography variant="h4" color="inherit">Comprar {row.CodigoISO}</Typography>
                        <Typography variant="h6"><em>su saldo es</em> <b>{row.SaldoVenta}</b></Typography>
                    </React.Fragment>
                } TransitionComponent={Zoom} placement="right"> */}

                <ButtonBase variant="text" color="default" classes={{ root: classes.buttonBase }} onClick={OnVenta}>
                    <Paper className={classes.paper_comprar}>
                        <NumberFormat className={classes.comprar} value={row.PrecioCompra} displayType={'text'} thousandSeparator={true} prefix={'$'} />
                    </Paper>

                </ButtonBase>

                {/* </BootstrapTooltip> */}
                <DialogoCompra CompraOVenta="V" open={openVenta} onClose={OnCloseCompra} descripcion={row.descripcion} codigo={row.codigo} PrecioCompra={row.PrecioCompra} CodigoISO={row.CodigoISO} Saldo={row.SaldoVenta} />
            </Grid>
            <Grid item className={classes.vender}>
                {/* <BootstrapTooltip title={
                    <React.Fragment>
                        <Typography variant="h4" color="inherit">Vender {row.CodigoISO}</Typography>
                        <Typography variant="h6"><em>su saldo es</em> <b>{row.SaldoCompra}</b></Typography>
                    </React.Fragment>
                } TransitionComponent={Zoom} placement="right"> */}

                <ButtonBase variant="text" color="default" classes={{ root: classes.buttonBase }} onClick={OnCompra}>
                    <Paper className={classes.paper_vender}>
                        <NumberFormat className={classes.vender} value={row.PrecioVenta} displayType={'text'} thousandSeparator={true} prefix={'$'} />
                    </Paper>
                </ButtonBase>

                {/* </BootstrapTooltip> */}
                <DialogoCompra CompraOVenta="C" open={openCompra} onClose={OnCloseCompra} descripcion={row.descripcion} codigo={row.codigo} PrecioCompra={row.PrecioVenta} CodigoISO={row.CodigoISO} Saldo={row.SaldoCompra} />
            </Grid>
            <Grid item className={classes.saldo}>
                <Paper className={clsx(classes.paper_saldo, { 'operacion-animation': operacionTermina })}>
                    <NumberFormat className={classes.saldo} value={row.SaldoVenta} displayType={'text'} thousandSeparator={true} prefix={row.codigo} />
                </Paper>
            </Grid>
        </React.Fragment>
    )
};
