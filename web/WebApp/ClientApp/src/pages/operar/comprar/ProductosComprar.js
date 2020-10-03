import React from 'react';
import { Traductor } from '../../../services/I18nService';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import classesName from 'classnames';
import Paper from '@material-ui/core/Paper';
import RowComprar from './RowComprar';
import Grid from '@material-ui/core/Grid'


const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    textAlign: "left",
    fontSize: "14px",
    fontWeight: "500",
    padding: theme.spacing(1),


  },
  paper_moneda: {
    textAlign: "left",
    fontSize: "14px",
    fontWeight: "500",
    padding: theme.spacing(1),
    backgroundColor: theme.palette.primary.main,


  },
  paper_saldo: {
    textAlign: "left",
    fontSize: "14px",
    fontWeight: "500",
    padding: theme.spacing(1),
    backgroundColor: theme.palette.primary.main,


  },
  moneda: {

    fontSize: "14px",
    fontWeight: "500",
    color: theme.palette.common.white,
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
  saldo : {
    fontSize: "14px",
    fontWeight: "500",
    color: theme.palette.common.white,
    width: "300px"
  }
}));





export default function ProductosComprar({ columns, rows, title }) {
  const classes = useStyles();

  return (
    <Grid container spacing={1}>
      <Grid item className={classes.moneda}>
        <Paper className={classes.paper_moneda}>
  <span className={classes.moneda}>{Traductor.traducir("Mondea (en pesos)")}</span>
        </Paper>
      </Grid>
      <Grid item className={classes.comprar}>
        <Paper className={classes.paper}>
          <span className={classes.comprar}>{Traductor.traducir("Comprar")}</span>
        </Paper>
      </Grid>
      <Grid item className={classes.vender}>
        <Paper className={classes.paper}>
          <span className={classes.vender}>{Traductor.traducir("Vender")}</span>
        </Paper>
      </Grid>
      <Grid item className={classes.saldo}>
        <Paper className={classes.paper_saldo}>
          <span className={classes.saldo}>{Traductor.traducir("Saldo")}</span>
        </Paper>
      </Grid>
      {rows.map((row, index) => {
        return (
          <RowComprar key={row.CodigoISO} row={row} />
        )
      })
      }
      
    </Grid>

  );
}
