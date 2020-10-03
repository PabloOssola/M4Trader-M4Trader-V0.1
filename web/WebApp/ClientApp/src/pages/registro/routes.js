import React from 'react';




/*Cliente*/
const Paso1 = React.lazy(() => import('./pages/paso1'));
const Paso2 = React.lazy(() => import('./pages/paso2'));
const Paso3 = React.lazy(() => import('./pages/paso3'));
const Paso4 = React.lazy(() => import('./pages/paso4'));




const routes = [
  { path: '/on/paso1', name: 'paso1', component: Paso1, type: 2 },
  { path: '/on/paso2', name: 'paso2', component: Paso2, exact: true, type: 2 },
  { path: '/on/paso3', name: 'paso3', component: Paso3, exact: true, type: 2 },
  { path: '/on/paso4', name: 'paso4', component: Paso4, exact: true, type: 2 }

];

export default routes;
