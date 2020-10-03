import React, { useState, useCallback, useRef } from 'react';
import classesName from 'classnames';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Box from '@material-ui/core/Box';
import Collapse from '@material-ui/core/Collapse';
import IconButton from '@material-ui/core/IconButton';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Typography from '@material-ui/core/Typography';
import KeyboardArrowUpOutlinedIcon from '@material-ui/icons/KeyboardArrowUpOutlined';
import KeyboardArrowDownOutlinedIcon from '@material-ui/icons/KeyboardArrowDownOutlined';
import DetailsOutlinedIcon from '@material-ui/icons/DetailsOutlined';
import LinearProgress from '@material-ui/core/LinearProgress';

import { Traductor } from '../../../../services/I18nService';
import OperacionesService from '../../../../services/OperacionesService';
import Fade from '@material-ui/core/Fade';
import Grow from '@material-ui/core/Grow';
import clsx from 'clsx';
import Grid from '@material-ui/core/Grid'
import NumberFormat from 'react-number-format';

const useRowStyles = makeStyles((theme) => ({

    root: {
        width: '100%',
    },
    container: {
        maxHeight: 440,
    },
    loading:
    {
        // display: "flex",
        // justifyContent: "center",
        // height : "50px"
        width: '100%',
        '& > * + *': {
            marginTop: theme.spacing(2),
        },
        height: "134.89px",
        display:"flex",
        alignItems:"center"
    },
    movimientos: {
        width: "50%"

    },
    head: {
        backgroundColor: theme.palette.primary.light,
        color: theme.palette.common.white,
    },
    debito: {
        color: "red"

    },
    credito: {
        color: "green"
    }

}));

const useStyles = makeStyles({
    root: {
        width: '100%',
    },
    container: {
        maxHeight: 440,
    },
});

const StyledTableCell = withStyles((theme) => ({
    head: {
        backgroundColor: theme.palette.primary.main,
        color: theme.palette.common.white,
        fontSize: "13px",
        fontWeight: "300"
    },
    body: {
        fontSize: 11,
    },
}))(TableCell);

const StyledTableRow = withStyles((theme) => ({
    root: {
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
    }
}))(TableRow);


function Row(props) {
    const { row, columns } = props;
    let movIsPullRef = useRef(false);
    const Idoperacion = useRef(row.idoperacion);
    const [open, setOpen] = React.useState(false);
    const [isLoading, setIsLoading] = useState(true);
    const [movimientos, setMovimientos] = useState([]);
    const classes = useRowStyles();

    const ObtenerMovimientos = useCallback(async () => {

        if (movIsPullRef.current === false) {
            let _movimientos = await OperacionesService.ObtenerMovimientos(Idoperacion.current);
            movIsPullRef.current = true;
            setIsLoading(false);
            setMovimientos([..._movimientos]);
        }

    });

    return (
        <React.Fragment>
            <StyledTableRow className={classesName(classes.head)} hover>
                {/* <StyledTableCell>
                    <IconButton aria-label="expand row" size="small" onClick={() => { if (!open) { ObtenerMovimientos(); } setOpen(!open); }}>
                        {open ? <KeyboardArrowUpOutlinedIcon /> : <KeyboardArrowDownOutlinedIcon />}
                    </IconButton>
                </StyledTableCell> */}
                {columns.map((col, index) => {
                    if (index == 0) {
                        return (
                            <StyledTableCell key={index} align="right">
                                <Grid container>
                                    <Grid item style={{ display: "flex", alignItems: "center" }}>
                                        <IconButton aria-label="expand row" size="small" onClick={() => { if (!open) { ObtenerMovimientos(); } setOpen(!open); }}>
                                            {open ? <KeyboardArrowUpOutlinedIcon /> : <KeyboardArrowDownOutlinedIcon />}
                                        </IconButton>
                                    </Grid>
                                    <Grid item style={{ display: "flex", alignItems: "center" }}>
                                        {col.format ? col.format(row) : row[col.field]}
                                    </Grid>
                                </Grid>
                            </StyledTableCell>
                        )
                    }

                    return (
                        <StyledTableCell key={index} align="left"> { col.format ? col.format(row) : row[col.field]}</StyledTableCell>
                    )
                })}
            </StyledTableRow>
            <StyledTableRow>
                <StyledTableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={7}>
                    <Collapse in={open} timeout={!isLoading?500:700} unmountOnExit >
                        {isLoading ? (
                            <div className={classes.loading}>
                                {/* <CircularProgress size="20px"/> */}
                                <LinearProgress style={{ width:"100%" }}/>
                            </div>

                        ) : (
                                <Grow in={!isLoading} timeout={800}>
                                    <Box margin={1}>
                                        <Typography variant="subtitle2" gutterBottom component="div">
                                            {Traductor.traducir("DetalleMisOperaciones")}
                                        </Typography>
                                        <Table size="small" aria-label="purchases" className={classes.movimientos}>
                                            <TableHead>
                                                <TableRow hover>
                                                    <StyledTableCell>{Traductor.traducir("MovimientoTipo")}</StyledTableCell>
                                                    <StyledTableCell>{Traductor.traducir("MovimientoImporte")}</StyledTableCell>
                                                    <StyledTableCell align="left">{Traductor.traducir("MovimientoMoneda")}</StyledTableCell>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                {movimientos.map((mov, index) => (
                                                    <TableRow key={index} hover>
                                                        <StyledTableCell className={clsx({ [classes.debito]: mov.Codigo === 1, [classes.credito]: mov.Codigo === 2 })}>{mov.TipoMovimiento}</StyledTableCell>
                                                        <StyledTableCell component="th" scope="row" className={clsx({ [classes.debito]: mov.Codigo === 1, [classes.credito]: mov.Codigo === 2 })}>
                                                            <NumberFormat value={mov.Importe} displayType={'text'} thousandSeparator={true} prefix={mov.CodigoMoneda} />
                                                        </StyledTableCell>
                                                        <StyledTableCell align="left" className={clsx({ [classes.debito]: mov.Codigo === 1, [classes.credito]: mov.Codigo === 2 })}>{mov.Moneda}</StyledTableCell>
                                                    </TableRow>
                                                ))}
                                            </TableBody>
                                        </Table>
                                    </Box>
                                </Grow>
                            )}
                    </Collapse>
                </StyledTableCell>
            </StyledTableRow>
        </React.Fragment >
    );
}

export default function MisOperaciones({ columns, rows, title, emptyRows }) {
    let classes = useStyles();
    return (
        <TableContainer className={classes.container}>
            <Table aria-label="collapsible table" size="small">
                <TableHead>
                    <TableRow>
                        {/* <StyledTableCell align="left" style={{ width: '24px' }}><DetailsOutlinedIcon /></StyledTableCell> */}
                        {columns.map((col, index) => {
                            return (
                                <StyledTableCell key={index} align="left" style={{ ...col.style }}>{col.title}</StyledTableCell>
                            )
                        })}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {rows.map((row, index) => (
                        <Row key={row.idoperacion} row={row} columns={columns} />
                    ))}
                    {emptyRows > 0 && (
                        <StyledTableRow style={{ height: (43) * emptyRows + (emptyRows) }}>
                            <StyledTableCell colSpan={7} />
                        </StyledTableRow>
                    )}
                </TableBody>
            </Table>
        </TableContainer>
    );
}
