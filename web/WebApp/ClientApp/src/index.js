import React from "react";
import ReactDOM from "react-dom";

import * as serviceWorker from "./serviceWorker";
import { Provider } from 'react-redux'
import store from './store/store';
import { I18nService } from './services/I18nService';
import { ThemeService } from './services/ThemeService';
import './scss/style.scss';

import Main from './main';

let urlParams = new URLSearchParams(window.location.search);

ReactDOM.render(
  <Provider store={store}>
    <Main />
  </Provider>,
  document.getElementById("root"),
);
let NombreUsuario = 'admin';


if (urlParams.has("name")) {
  NombreUsuario = urlParams.get("name");
}
window.history.pushState({}, document.title, window.location.pathname);
store.dispatch({ type: "AGENCIA_INTRO", Agencia: NombreUsuario });


init(NombreUsuario);


async function init(NombreUsuario) {
  let travelLiterales = await I18nService.ObtenerLiterales(NombreUsuario);
  let theme = await ThemeService.ObtenerThema(NombreUsuario);


  

  store.dispatch({ type: "set", loadingComplete: true, Theme: theme.Data.ThemeJSON, Idioma: travelLiterales.Data.Idioma });

}



// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
