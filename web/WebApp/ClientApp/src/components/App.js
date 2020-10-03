import React from "react";
import { HashRouter, Route, Switch, Redirect  } from "react-router-dom";
import { useSelector } from 'react-redux';
// components
import Layout from "./Layout";

// pages
import Error from "../pages/error";
import Login from "../pages/login";
import Registro from '../pages/registro/Dashboard';




export default function App() {

  const isAuthenticated = useSelector((state) => state.isAuthenticated);

  //let match = useRouteMatch("/registrarse");


  return (
    <HashRouter>
      <Switch>        
        <Route exact path="/" render={() => <Redirect to="/app/dashboard" />} />
        <Route
          exact
          path="/app"
          render={() => <Redirect to="/app/dashboard" />}
        />
        <PrivateRoute path="/app" component={Layout} />
        <PublicRoute exact path="/registrarse" component={Registro} />
        <PublicRoute exact path="/login" component={Login} />
        <Route component={Error} />
      </Switch>
    </HashRouter>
  );

  // #######################################################################

  function PrivateRoute({ component, ...rest }) {

    return (
      <Route
        {...rest}
        render={props =>
          isAuthenticated ? (
            React.createElement(component, props)
          ) : (
              <Redirect
                to={{
                  pathname: "/login",
                  state: {
                    from: props.location,
                  },
                }}
              />
            )
        }
      />
    );
  }

  function PublicRoute({ component, ...rest }) {
    return (
      <Route
        {...rest}
        render={props =>
          isAuthenticated ? (
            <Redirect
              to={{
                pathname: "/",
              }}
            />
          ) : (

              React.createElement(component, props)
            )
        }
      />
    );
  }
}
