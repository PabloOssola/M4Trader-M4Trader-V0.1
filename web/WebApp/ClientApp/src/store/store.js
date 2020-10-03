import { createStore } from 'redux'

const initialState = {
  isSidebarOpened: true,
  token: "",
  userID:"1",
  messageServer : "",
  navigation : [],
  Agencia : "admin",
  loadingComplete : false,
  Theme: "",
  Idioma : "es-AR",
  Title : "",
  UserName: "",
  IdTipoPersona : 0,
  TipoPersona : "",
  IdUsuario : 0
}

const changeState = (state = initialState, { type, ...rest }) => {
  switch (type) {
    case 'set':
      return {...state, ...rest }     
    case "TOGGLE_SIDEBAR":
      return { ...state, isSidebarOpened: !state.isSidebarOpened };  
    case "LOGIN_SUCCESS":
      return { ...state, isAuthenticated: true, ...rest };
    case "TOKEN_SUCCESS":
      return { ...state, ...rest };
    case "SIGN_OUT_SUCCESS":
      return { ...state, isAuthenticated: false };
    case "AGENCIA_INTRO":
      return { ...state, ...rest };

    default:
      return state
  }
}

const store = createStore(changeState)
export default store