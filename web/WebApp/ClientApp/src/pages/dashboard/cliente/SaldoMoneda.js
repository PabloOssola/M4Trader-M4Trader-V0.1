import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import clsx from 'clsx';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid'
import ButtonBase from '@material-ui/core/ButtonBase';
import {Traductor} from '../../../services/I18nService';
import NumberFormat from 'react-number-format';

const useStyles = makeStyles((theme) => ({
    root: {
        minWidth: 275,
    },
    bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
    },
    title: {
        fontSize: 14,
    },
    pos: {
        marginBottom: 12,
    },
    shape: {
        backgroundColor: theme.palette.primary.main,
        width: 40,
        height: 40,
    },
    shapeCircle: {
        borderRadius: '50%',
    },

    saldo: {
        fontSize: "16px",
        color:"green"
    },
    saldoPendiente : {
        fontSize: "14px",
        color:"blue"
    },
    containerMoneda: {
        display: "flex"
    },
    moneda: {
        fontSize: "20px",
        color: theme.palette.primary.main,
        fontWeight: "600",
        height: "30px",
        display: "flex",
        alignItems: "center"
    },
    monedades: {
        fontSize: "12px",
        color: theme.palette.primary.main,
        height: "30px",
        marginLeft: "5px",
        display: "flex",
        alignItems: "center"
    },
    cardAction: {
        display: 'block',
        textAlign: 'initial'
    }
}));


export default function SaldoMoneda({ moneda }) {
    const classes = useStyles();
    const bull = <span className={classes.bullet}>•</span>;
    const { CodigoISO,Codigo, Saldo, MonedaDescripcion, SaldoPendiente } = moneda;


    return (
        <ButtonBase
            className={classes.cardAction}
            onClick={event => {  }}>
            <Card className={classes.root} variant="outlined">
                <CardContent>
                    <div className={classes.containerMoneda}>
                        <div className={classes.moneda}>{CodigoISO}</div>
                        <div className={classes.monedades}>{MonedaDescripcion}</div>
                    </div>
                    <div className={classes.saldo} >
                    {Traductor.traducir("SaldoActual")} <NumberFormat className={classes.saldo} value={Saldo} displayType={'text'} thousandSeparator={true} prefix={Codigo} />
                    </div>
                    <div className={classes.saldoPendiente} >
                    {Traductor.traducir("SaldoPendiente")} <NumberFormat className={classes.saldo} value={SaldoPendiente} displayType={'text'} thousandSeparator={true} prefix={Codigo} />
                    </div>
                </CardContent>
            </Card >
        </ButtonBase>
    );

}   
