import React, { Fragment, useState } from 'react'
import { Traductor } from '../../../services/I18nService';
import OperacionesService from '../../../services/OperacionesService';
import MessageService from '../../../services/MessageService';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import CircularProgress from '@material-ui/core/CircularProgress';
import CheckCircleOutlineIcon from '@material-ui/icons/CheckCircleOutline';
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import NumberFormatCustom from '../../../components/Util/NumberFormatCustom';
import NumberFormat from 'react-number-format';
import Zoom from '@material-ui/core/Zoom';
import clsx from 'clsx';

const useStyles = makeStyles((theme) => ({
    root: {
        width: '100%',
        maxWidth: 360,
        backgroundColor: theme.palette.background.paper,
    },
    paper: {
        width: '80%',
        maxHeight: 435,
    },
    ok: {
        color: "green",
        fontSize: "210px"
    },
    error: {
        color: "red",
        fontSize: "210px"
    },
    error_importe: {
        borderColor : "red"
    },
    containerok: {
        display: "flex",
        justifyContent: "center",
        alignItems: "center",

    },
    container: {
        //width: '600px',

    },
    message:{
        fontSize:"12px",
        color: theme.palette.primary.main
    }
}));




export default function DialogoCompra(props) {
    const { onClose, open, descripcion, CodigoISO, codigo, Saldo, PrecioCompra, CompraOVenta } = props;
    const clasess = useStyles();

    const [isLoading, setIsLoading] = useState(false);
    const [isFinish, setIsFinish] = useState({
        OK: false,
        IsError: false,
        Message: ''
    });
    const MaximoCompra = (Saldo / PrecioCompra).toFixed(2);
    const [values, setValues] = useState({
        importe: MaximoCompra
    });


    const handleClose = () => {
        onClose();
        setIsFinish({ OK: false, IsError: false, Message: '' });
        setIsLoading(false);
    };

    const handleChange = (event) => {
        setValues({
            ...values,
            [event.target.name]: event.target.value,
        });
    };

    const validarInput = function () {
       
        return +(values.importe) > 0;
    }

    const OnComprar = async function () {
        setIsLoading(true);        
        if (validarInput()) {
            let travel = {
                operaciones: [
                    {
                        CompraOVenta: CompraOVenta,
                        CodigoMonedaISO: CodigoISO,
                        Cantidad: values.importe,
                    }
                ]
            };
            let result = await OperacionesService.Comprar(travel);

            if (result.Data.MensajeError.length > 0) {

                setIsFinish({ OK: true, IsError: true, Message: result.Data.MensajeError[0] });
                return;
            }
            if (result.Data.MensajeOk.length > 0) {

                setIsFinish({ OK: true, IsError: false, Message: result.Data.MensajeOk[0] });
                MessageService.emit("OperacionExitosa", { CodigoISO : CodigoISO });
            }
            //
            console.log(result);

        }
        else
        {
            setIsLoading(false);   
        }

    }

    return (
        <Dialog TransitionComponent={Zoom} open={open} onClose={handleClose} aria-labelledby="form-dialog-title" disableBackdropClick disableEscapeKeyDown>
            {isLoading ? (
                <DialogContent className={clasess.container}>
                    {isFinish.OK ? (
                        <Fragment>
                            <DialogTitle id="form-dialog-title">
                                <div className={clasess.containerok}>
                                   <span className={clasess.message}>{isFinish.Message}</span>
                                </div>
                            </DialogTitle>
                            <DialogContent className={clasess.container}>
                                <div className={clasess.containerok}>
                                    {isFinish.IsError ? (<CancelOutlinedIcon className={clasess.error} />) : (<CheckCircleOutlineIcon className={clasess.ok} />)}
                                </div>
                            </DialogContent>
                            <DialogActions>
                                <Button onClick={handleClose} color="primary">
                                    {Traductor.traducir("Cerrar")}
                                </Button>
                            </DialogActions>
                        </Fragment>

                    ) : (
                            <div className={clasess.containerok}>
                                <CircularProgress disableShrink />
                            </div>
                        )}
                </DialogContent>
            ) : (
                    <Fragment>
                        <DialogTitle id="form-dialog-title"> {CompraOVenta === "C"? Traductor.traducir("TituloComprar") : Traductor.traducir("TituloVender")} {descripcion}</DialogTitle>
                        <DialogContent className={clasess.container}>
                            <DialogContentText>
                                {/* Su saldo de <NumberFormat value={Saldo} displayType={'text'} thousandSeparator={true} prefix={CodigoISO} /><br />
                                Maximo de compra <NumberFormat value={MaximoCompra} displayType={'text'} thousandSeparator={true} prefix={CodigoISO + " "} /> */}
                            </DialogContentText>
                            <TextField
                                label={CodigoISO}
                                value={values.importe}
                                onChange={handleChange}
                                name="importe"
                                id="importe"
                                prefix={codigo}
                               
                                InputProps={{
                                    inputComponent: NumberFormatCustom,
                                }}
                            />
                        </DialogContent>
                        <DialogActions>
                            <Button onClick={handleClose} color="primary">
                                {Traductor.traducir("Cancel")}
                            </Button>
                            <Button onClick={OnComprar} color="primary">
                                {CompraOVenta === "C"? Traductor.traducir("Comprar") : Traductor.traducir("Vender")}                                
                            </Button>
                        </DialogActions>
                    </Fragment>
                )
            }
        </Dialog >
    )
}
