import React from 'react';
import store from '../store/store';

import { WSApiServer } from '../Api/WsApi';
import { I18nService } from '../services/I18nService';
import SignalrService from '../services/SignalrService';

async function loginUser(login, password, history, setIsLoading, setError) {



  setError(false);
  setIsLoading(true);

  if (!!login && !!password) {


    try {

      let args = {
        NombreUsuario: login,
        Password: password
      }

      let travel = await WSApiServer.command("AutenticarUsuario", args, {});

      let result = travel.Data;
      if (result.Status == 1) {
        store.dispatch({ type: 'TOKEN_SUCCESS', token: result.Token });
        store.dispatch({
          type: 'LOGIN_SUCCESS',
          UserName: login,
          IdUsuario: result.IdUsuario,
          IdTipoPersona: result.IdTipoPersona,
          TipoPersona: result.TipoPersona
        });

        localStorage.setItem('id_token', 1);

        let signalR = await SignalrService.connect();
        SignalrService.dispatch("Notify", result.IdUsuario || 1);
        

        history.push('/app/dashboard');
        return;
      }

      if (result.Status == 3)
        setError({ Message: result.Message, Status: result.Status });


      setIsLoading(false);

    }
    catch (d) {
      store.dispatch({ type: "LOGIN_FAILURE" });
      setError(true);
      setIsLoading(false);
    }
  }
}

async function loadI18n() {
  return await I18nService.ObtenerLiterales();
}

function signOut(history) {

  localStorage.removeItem("id_token");
  store.dispatch({ type: "SIGN_OUT_SUCCESS" });
  history.push("/login");
};

export { loginUser, signOut, loadI18n };