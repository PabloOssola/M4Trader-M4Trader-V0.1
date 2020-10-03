import React, { Suspense } from "react";
import {
  Route,
  Switch,
  Redirect,
  withRouter,
} from "react-router-dom";
import classnames from "classnames";
import { useSelector } from 'react-redux';
import store from '../../store/store';
// styles
import useStyles from "./styles";

// components
import Header from "../Header";
import Sidebar from "../Sidebar";
import { loadI18n } from '../../context/UserContext';
import Intro from '../Util/Intro';





// routes config
import routes from '../../routes';


function Layout(props) {
  var classes = useStyles();
  let { IdTipoPersona } = store.getState();
  // global
  let isSidebarOpened = useSelector(state => state.isSidebarOpened);



  return (
    <div className={classes.root}>
      <>
        <Header history={props.history} />
        <Sidebar />
        <div
          className={classnames(classes.content, {
            [classes.contentShift]: isSidebarOpened,
          })}
        >
          <div className={classes.fakeToolbar} />

          <Switch>
            {routes.filter(t => t.type === IdTipoPersona).map((route, idx) => {
              return route.component && (
                <Route
                  key={idx}
                  path={route.path}
                  exact={route.exact}
                  name={route.name}
                  render={props => (
                    <Suspense fallback={<Intro />}>
                      <route.component {...props} />
                    </Suspense>
                  )} />
              )
            })}
            <Redirect from="/" to="/home" />
          </Switch>
        </div>
      </>
    </div>
  );
}

export default withRouter(Layout);
