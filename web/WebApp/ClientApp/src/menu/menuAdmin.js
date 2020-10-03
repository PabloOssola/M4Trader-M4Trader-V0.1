import React from "react";




import {
  SvgIconSearch,
  SvgIconStatatics,
  SvgIconAdminUser,
  SvgIconMessageAlert,
  SvgIconPrecioPizarra
} from '../svgicons/SvgSidebarIcons';
import { makeStyles, MuiThemeProvider } from "@material-ui/core";
import AccountBalanceOutlinedIcon from '@material-ui/icons/AccountBalanceOutlined';
import InsertCommentOutlinedIcon from '@material-ui/icons/InsertCommentOutlined';
import DashboardOutlinedIcon from '@material-ui/icons/DashboardOutlined';
import MoneyOutlinedIcon from '@material-ui/icons/MoneyOutlined';
import HomeOutlinedIcon from '@material-ui/icons/HomeOutlined';

const structure = {
    Inicio : <HomeOutlinedIcon />,
    Consultas: <SvgIconSearch />,
    Estadistica: <SvgIconStatatics />,
    Administraciondeusuarios: <SvgIconAdminUser />,
    Mensajesyalertas: <InsertCommentOutlinedIcon />,
    PreciosyPizarras : <DashboardOutlinedIcon />,
    IngresaryRetirar :  <AccountBalanceOutlinedIcon/>,
    Operar : <MoneyOutlinedIcon/>

}




// const structure = [
//     { id: 0,name:"Inicio", label: "Home", link: "/app/dashboard", icon: <HomeIcon /> },
//     {
//       id: 1,
//       name: "Consultas",
//       label: "Consultas",
//       link: "/app/consultas",
//       icon: <SvgIconSearch />,
//       children: [
//         { name: "Administraciondesaldos", label: "Administración de saldos", link: "/app/consultas/administracionDeSaldos" },
//         { name: "Operacioneshistoricasdecliente",label: "Operaciones historicas de cliente", link: "/app/consultas/operacionesHistoricoCliente" },
//         { name: "Cotizacioneshistoricas", label: "Cotizaciones historicas", link: "/app/consultas/cotizacionesHistoricas" },
//         { name: "datosDelCliente", label: "Datos del cliente", link: "/app/consultas/datosDelCliente" },
//       ]
//     },
  
//     {
//       id: 2,
//       label: "Estadística",
//       name: "Estadistica",
//       link: "/app/estadistica",
//       icon: <SvgIconStatatics />,
//       children: [
//         { label: "Datos historicos", link: "/app/estadistica/datosHistorico" },
  
//       ]
//     },
  
//     {
//       id: 3,
//       name: "Administraciondeusuarios",
//       label: "Administración de usuarios",
//       link: "/app/usuarios",
//       icon: <SvgIconAdminUser />,
//       children: [
//         {  name: "Gestion", label: "Gestion", link: "/app/usuarios/gestion" },
  
//       ]
//     },
//     {
//       id: 4,
//       name: "Mensajesyalertas",
//       label: "Mensajes y alertas",
//       link: "/app/mensajes",
//       icon: <SvgIconMessageAlert />,
//       children: [
//         { name: "Crear", label: "Crear", link: "/app/mensajes/crear" },
//         { name: "Enviados", label: "Enviados", link: "/app/mensajes/enviados" },
//         { name: "Recibidos", label: "Recibidos", link: "/app/mensajes/recibidos" },
  
//       ]
//     },
//     {
//       id: 5,
//       name: "PreciosyPizarras",
//       label: "Precios y Pizarra",
//       link: "/app/preciosYPizarra",
//       icon: <SvgIconPrecioPizarra />,
//       children: [
//         { name: "Precios", label: "Precios", link: "/app/preciosYPizarra/precios" },
//         { name: "Pizarra", label: "Pizarra", link: "/app/preciosYPizarra/pizarra" },
//       ]
//     }
  
//   ];
  
  export default structure;