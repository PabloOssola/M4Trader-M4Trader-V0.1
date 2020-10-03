import React from "react";

import { ThemeProvider } from "@material-ui/styles";
import { CssBaseline } from "@material-ui/core";

import { crearThema } from "./themes/index";
import App from "./components/App";
import Intro from "./components/Util/Intro";

import { useSelector } from 'react-redux'
import { SnackbarProvider } from 'notistack';


function Main() {
  let Theme = useSelector(state => state.Theme);
  let Idioma = useSelector(state => state.Idioma);
  let loadingComplete = useSelector(state => state.loadingComplete);

  let themeFinal = crearThema(Theme, Idioma);
  console.dir(themeFinal);

  return (
    <ThemeProvider theme={themeFinal}>
      <CssBaseline />
      {!loadingComplete ? (<Intro />) :
        (
          <SnackbarProvider 
            maxSnack={3}            
            anchorOrigin={{
              vertical: 'bottom',
              horizontal: 'right',
            }}>
            <App />
          </SnackbarProvider>
        )
      }

    </ThemeProvider>

  );

}

export default Main;




