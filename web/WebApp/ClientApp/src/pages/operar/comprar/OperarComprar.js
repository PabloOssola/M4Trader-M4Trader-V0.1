import React, { useState, useEffect, useCallback, useRef } from 'react';
import ProductosService from '../../../services/ProductosService';
import SaldosService from '../../../services/SaldosService';
import MessageService from '../../../services/MessageService';
import { Traductor } from '../../../services/I18nService';
import TablePagination from '@material-ui/core/TablePagination';
import Paper from '@material-ui/core/Paper';
import { columns } from './operarCompraColumns';
import ProductosComprar from './ProductosComprar';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import NumberFormat from 'react-number-format';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import anime from 'animejs/lib/anime.es.js';

const useStyles = makeStyles((theme) => ({
    root: {
        width: '1000px',
    },
    container: {
        maxHeight: 440,
    },
    tituloSaldo: {
        marginBottom: theme.spacing(1)
    },

    saldoMonedaLocal: {
        fontSize: "34px",
        fontWeight: "500",
        color: "green"

    },
    saldoMonedaLocalTitulo: {
        color: theme.palette.text.primary,
        fontSize: "20px",
        fontWeight: "500"
    },
    card: {

        minWidth: 275,
        padding: theme.spacing(1),
        textAlign: "left",
        width: "100%",
        '&:hover': {
            backgroundColor: "#206ba91c",
            color: "white"

        }
    }
}));




export default function OperarComprar() {
    let classes = useStyles();
    let pageRef = useRef();
    let rowsPerPageRef = useRef();
    let operacionTerminada = useRef([]);
    

    let [data, setData] = useState([]);

    let [saldoMonedaLocal, setSaldoMonedaLocal] = useState({ Importe: 0, CodigoISO: '', codigo: '', descripcion: '' });
    let [saldoLocalAnime, setSaldoLocalAnime] = useState({ Importe: 0, CodigoISO: '', codigo: '', descripcion: '' });

    let saldoMonedaLocalRef = useRef(saldoMonedaLocal);

    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(10);


    let ObtenerProductos = useCallback(async (pageNumber, pageSize) => {

        let result = await ProductosService.ObtenerProductos(pageNumber, pageSize);


        for (let index = 0; index < result.length; index++) {
            const element = result[index];
            if (operacionTerminada.current.includes(element.CodigoISO)) {
                element.operacionTermina = true;
                let pos = operacionTerminada.current.indexOf(element.CodigoISO);
                operacionTerminada.current.splice(pos, 1);
            }
            else {
                element.operacionTermina = false;
            }

        }
        console.log(result);
        setData(result);

    }, [])
    let ObtenerSaldoMonedaLocal = useCallback(async (pageNumber, pageSize) => {

        let result = await SaldosService.ObtenerSaldoMonedaLocal(pageNumber, pageSize);

        console.log(result);
        if (result.length > 0) {
            setSaldoMonedaLocal(result[0]);
            
        }

    }, [])

    const OnOperacionExitosa = useCallback((data) => {
        operacionTerminada.current.push(data.CodigoISO);
        ObtenerSaldoMonedaLocal();
        ObtenerProductos(pageRef.current > 0 ? pageRef.current : 1, rowsPerPageRef.current);

    }, []);

    const handleChangePage = (event, newPage) => {
        ObtenerProductos(newPage, rowsPerPage);
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {

        setRowsPerPage(+event.target.value);
        ObtenerProductos(1, +event.target.value);
        setPage(0);
    };

    let animeSaldoLocal = useCallback(() => {
        let myObject = {
            Importe: saldoMonedaLocalRef.current.Importe,
            CodigoISO: saldoMonedaLocal.CodigoISO, 
            codigo: saldoMonedaLocal.codigo, 
            descripcion: saldoMonedaLocal.descripcion
        }

        debugger;
        anime({
            targets: myObject,
            Importe: saldoMonedaLocal.Importe,
            easing: 'linear',
            round: 2,
            update: function () {
                setSaldoLocalAnime(myObject);
            }
        });

    }, [saldoMonedaLocal]);




    useEffect(() => {
        pageRef.current = page;
        rowsPerPageRef.current = rowsPerPage;
        
    });
    // useEffect(() => {
    //     animeSaldoLocal();
    //     saldoMonedaLocalRef.current = saldoMonedaLocal;
    // },[saldoMonedaLocal]);

    useEffect(() => {
        ObtenerSaldoMonedaLocal();
        ObtenerProductos(1, 5);

        MessageService.subscribe("OperacionExitosa", OnOperacionExitosa);

        return () => {
            MessageService.unsubscribe("OperacionExitosa", OnOperacionExitosa);
        }

    }, []);



    return (
        <div className={classes.root}>
            <div className={classes.tituloSaldo}>
                <Card className={classes.card} variant="outlined">
                    <CardContent>
                        <NumberFormat className={classes.saldoMonedaLocal} value={saldoMonedaLocal.Importe} displayType={'text'} thousandSeparator={true} prefix={`${saldoMonedaLocal.CodigoISO} `} />
                    </CardContent>
                </Card >
            </div>
            <ProductosComprar

                columns={columns}
                rows={data}
                title={Traductor.traducir("ProductosComprar")}
            />
            <TablePagination
                rowsPerPageOptions={[5, 10, 25, 100]}
                component="div"
                count={data.length}
                rowsPerPage={rowsPerPage}
                page={page}
                onChangePage={handleChangePage}
                onChangeRowsPerPage={handleChangeRowsPerPage}
            />
        </div >
    )
}
