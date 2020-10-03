import defaultTheme from "./default";

import { createMuiTheme } from "@material-ui/core";

import AdminLogo from "../images/defult.jpg";
import * as locales from '@material-ui/core/locale';
import marine from './demo/marine.json';
import gris from './demo/gris.json';


// const overrides = {
//   logo : AdminLogo,
//   typography: {
//     h1: {
//       fontSize: "3rem",
//     },
//     h2: {
//       fontSize: "2rem",
//     },
//     h3: {
//       fontSize: "1.64rem",
//     },
//     h4: {
//       fontSize: "1.5rem",
//     },
//     h5: {
//       fontSize: "1.285rem",
//     },
//     h6: {
//       fontSize: "1.142rem",
//     },
//   },
// };

function crearThema(overrides, idioma) {

  if (locales[idioma])
    return createMuiTheme({ ...defaultTheme, ...overrides }, locales[idioma]);
  else
    return createMuiTheme({ ...defaultTheme, ...overrides });

}
export {
  crearThema
}

// export default {
//   default: createMuiTheme({ ...defaultTheme, ...overrides }),
//   admin : createMuiTheme({ ...defaultTheme, ...overrides }),
//   AgenciaJupiter : createMuiTheme({ ...defaultTheme, ...overrides }),
//   AgenciaExchange: createMuiTheme({ ...defaultTheme, ...overrides })
// };


