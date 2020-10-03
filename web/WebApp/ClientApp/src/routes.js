import React from 'react';


// pages
const Dashboard = React.lazy(() => import('./pages/dashboard'));
const AdministracionDeSaldos = React.lazy(() => import('./pages/consultas/AdministracionDeSaldos'));
const ConsultasDeSaldos = React.lazy(() => import('./pages/consultas/ConsultasDeSaldos'));
const Gestion = React.lazy(() => import('./pages/usuarios/Gestion'));
const UsuariosPanel = React.lazy(() => import('./pages/usuarios/UsuariosPanel'));
const AdminAlertasCrear = React.lazy(() => import('./pages/mensajes/admin/AdminAlertasCrear'));
const AdminAlertasEnviados = React.lazy(() => import('./pages/mensajes/admin/AdminAlertasEnviados'));
const AdminAlertasRecibidas = React.lazy(() => import('./pages/mensajes/admin/AdminAlertasRecibidas'));
const AdminAlertas = React.lazy(() => import('./pages/mensajes/admin/AdminAlertas'));



/*Cliente*/ 
const MisSaldos = React.lazy(() => import('./pages/usuarios/MisSaldos'));
const MisConsultas = React.lazy(() => import('./pages/usuarios/MisConsultas'));
const MisTransferencias = React.lazy(() => import('./pages/usuarios/MisTransferencias'));
const ClienteAlertasCrear = React.lazy(() => import('./pages/mensajes/cliente/ClienteAlertasCrear'));
const ClienteAlertasEnviados = React.lazy(() => import('./pages/mensajes/cliente/ClienteAlertasEnviados'));
const ClienteAlertasRecibidas = React.lazy(() => import('./pages/mensajes/cliente/ClienteAlertasRecibidas'));
const ClienteAlertas = React.lazy(() => import('./pages/mensajes/cliente/ClienteAlertas'));
const MiDashboard = React.lazy(() => import('./pages/dashboard/cliente/MiDashboard'));
const MisIngresos = React.lazy(() => import('./pages/fondos/cliente/MisIngresos'));
const MisFondos = React.lazy(() => import('./pages/fondos/cliente/MisFondos'));

const OperarDashboard = React.lazy(() => import('./pages/operar/comprar/OperarComprar'));



const routes = [
  { path: '/', exact: true, name: 'Dashboard', type:2 },
  { path: '/app/dashboard', name: 'Dashboard', component: Dashboard ,  type:2},
  { path: '/app/consultas/saldos', name: 'Saldos', component: AdministracionDeSaldos, exact: true,  type:2 },
  { path: '/app/consultas', name: 'Saldos', component: ConsultasDeSaldos, exact: true,  type:2 },
  { path: '/app/usuarios', name: 'UsuariosPanel', component: UsuariosPanel, exact: true,  type:2 },
  { path: '/app/usuarios/gestion', name: 'Gestion', component: Gestion, exact: true,  type:2 },
  { path: '/app/mensajes', name: 'PanelMensajes', component: AdminAlertas, exact: true,  type:2 },
  { path: '/app/mensajes/crear', name: 'Crear', component: AdminAlertasCrear, exact: true,  type:2 },
  { path: '/app/mensajes/enviados', name: 'Enviados', component: AdminAlertasEnviados, exact: true,  type:2 },
  { path: '/app/mensajes/recibidos', name: 'recibidos', component: AdminAlertasRecibidas, exact: true,  type:2 },

  
  /* Cliente*/
  { path: '/app/dashboard', name: 'Dashboard', component: MiDashboard,  type:3 },
  { path: '/app/misconsultas/missaldos', name: 'MisSaldos', component: MisSaldos, exact: true,  type:3 },
  { path: '/app/misconsultas', name: 'MisConsultas', component: MisConsultas, exact: true,  type:3 },
  { path: '/app/misconsultas/mistransferencias', name: 'MisTransferencias', component: MisTransferencias, exact: true,  type:3 },
  { path: '/app/mismesajes', name: 'PanelMisMensajes', component: ClienteAlertas, exact: true,  type:3 },
  { path: '/app/mismesajes/crear', name: 'Crear', component: ClienteAlertasCrear, exact: true,  type:3 },
  { path: '/app/mismensajes/enviados', name: 'Enviados', component: ClienteAlertasEnviados, exact: true,  type:3 },
  { path: '/app/mismensajes/recibidos', name: 'recibidos', component: ClienteAlertasRecibidas, exact: true,  type:3 },
  { path: '/app/misingresos/ingresar', name: 'Ingresos', component: MisIngresos, exact: true,  type:3 },
  { path: '/app/misingresos', name: 'Fondos', component: MisFondos, exact: true,  type:3 },
  { path: '/app/operar', name: 'Fondos', component: OperarDashboard, exact: true,  type:3 },
  
 
];

export default routes;
