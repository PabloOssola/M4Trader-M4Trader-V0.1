import React, { useState, useEffect, useCallback } from 'react';
import OperacionesService from '../../../../services/OperacionesService';
import { columns } from './miActividadColumns';
import { Traductor } from '../../../../services/I18nService';
import TablePagination from '@material-ui/core/TablePagination';
import Paper from '@material-ui/core/Paper';
import MisOperaciones from './MisOperaciones';
import { makeStyles, withStyles } from '@material-ui/core/styles';


const useStyles = makeStyles({
    root: {
        width: '100%',
    },
    container: {
        maxHeight: 440,
    },
});

export default function MiActividadSaldos() {
    let classes = useStyles();
    let [data, setData] = useState([]);
    const [page, setPage] = React.useState(0);
    const [rowsPerPage, setRowsPerPage] = React.useState(5);


    let ObtenerOperaciones = useCallback(async (pageNumber, pageSize) => {

        let result = await OperacionesService.ObtenerOperaciones(pageNumber, pageSize);
        console.log(result);
        setData(result);

    }, [])

    const handleChangePage = (event, newPage) => {
        ObtenerOperaciones(newPage + 1, rowsPerPage);
        setPage(newPage);
    };

    const handleChangeRowsPerPage = (event) => {

        setRowsPerPage(+event.target.value);
        ObtenerOperaciones(1, +event.target.value);
        setPage(0);
    };



    useEffect(() => {

        ObtenerOperaciones(1, 5);

    }, []);
    let TotalRows = data.length > 0 ? data[0].TotalRows : 0;
    const emptyRows = rowsPerPage - Math.min(rowsPerPage, TotalRows - page * rowsPerPage);

    return (
        <Paper className={classes.root}>
            <MisOperaciones
                emptyRows={emptyRows}
                columns={columns}
                rows={data}
                title={Traductor.traducir("MiActividadTituloGrilla")}
            />
            <TablePagination
                rowsPerPageOptions={[5, 10, 25, 100]}
                component="div"
                count={TotalRows}
                rowsPerPage={rowsPerPage}
                page={page}
                onChangePage={handleChangePage}
                onChangeRowsPerPage={handleChangeRowsPerPage}
            />
        </Paper >

    )
}
