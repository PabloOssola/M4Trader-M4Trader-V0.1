import React from "react";
import {
  Grid,
  LinearProgress,
  Select,
  OutlinedInput,
  MenuItem, AppBar, IconButton, Toolbar, Typography, BottomNavigation,

} from "@material-ui/core";
import { useTheme } from "@material-ui/styles";
// import {
//   ResponsiveContainer,
//   ComposedChart,
//   AreaChart,
//   LineChart,
//   Line,
//   Area,
//   PieChart,
//   Pie,
//   Cell,
//   YAxis,
//   XAxis,
// } from "recharts";

// styles
import useStyles from "./styles";

// components
import mock from "./mock";
import Widget from "../../components/Widget";
import PageTitle from "../../components/PageTitle";
import { productos } from './productos';
import LastOperation from '../../components/operations/lastoperation';
import { Badge/*, Button*/ } from "../../components/Wrappers/Wrappers";
import { useDispatch } from 'react-redux';
import { Menu as MenuIcon } from '@material-ui/icons'

export default function Dashboard(props) {
  var classes = useStyles();
  var theme = useTheme();

  const dispatch = useDispatch();

  dispatch({ type: "set", Title: "Inicio" });

  // // local
  // var [mainChartState, setMainChartState] = useState("monthly");


  return (
    <div>Tablero principal</div>
  );
}



