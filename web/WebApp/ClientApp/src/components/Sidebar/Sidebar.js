import React, { useState, useEffect } from "react";
import { useSelector } from 'react-redux';

import { Drawer, IconButton, List } from "@material-ui/core";
import {
  Menu as MenuIcon,
  //Home as HomeIcon,
  // NotificationsNone as NotificationsIcon,
  // //FormatSize as TypographyIcon,
  // FilterNone as UIElementsIcon,
  // BorderAll as TableIcon,
  // QuestionAnswer as SupportIcon,
  // LibraryBooks as LibraryIcon,
  // HelpOutline as FAQIcon,
  ArrowBack as ArrowBackIcon,

} from "@material-ui/icons";
import Divider from '@material-ui/core/Divider';
import ArrowForwardIcon from '@material-ui/icons/ArrowForward';

import { useTheme } from "@material-ui/styles";
import { withRouter } from "react-router-dom";
import classNames from "classnames";

// styles
import useStyles from "./styles";

// components
import SidebarLink from "./components/SidebarLink/SidebarLink";      
import AgenciaTitle from "./components/Agencia/AgenciaTitle";      
//import Dot from "./components/Dot";
import { menuGenerator } from '../../menu/MenuGenerator';

// context
import {
  toggleSidebar,
} from "../../context/LayoutContext";
import MenuService from "../../services/MenuService";
import Intro from "../Util/Intro";





function Sidebar({ location }) {
  var classes = useStyles();
  var theme = useTheme();

  // global
  var isSidebarOpened = useSelector(state => state.isSidebarOpened);

  let Agencia = useSelector(state => state.Agencia);
  // local

  var [isPermanent, setPermanent] = useState(true);
  var [structure, setStructure] = useState([]);

  useEffect(() => {
    async function ObtenerMenu() {
      let menu = await MenuService.ObtenerMenu();
      let _structure = menu.Data.top.map((item) => {

        return menuGenerator(item);

      })


      setStructure(_structure);
    }

    ObtenerMenu();

  }, []);


  useEffect(function () {
    window.addEventListener("resize", handleWindowWidthChange);
    handleWindowWidthChange();
    return function cleanup() {
      window.removeEventListener("resize", handleWindowWidthChange);
    };
  });

  return (
    <Drawer
      variant={isPermanent ? "permanent" : "temporary"}
      className={classNames(classes.drawer, {
        [classes.drawerOpen]: isSidebarOpened,
        [classes.drawerClose]: !isSidebarOpened,
      })}
      classes={{
        paper: classNames({
          [classes.drawerOpen]: isSidebarOpened,
          [classes.drawerClose]: !isSidebarOpened,
        }),
      }}
      open={isSidebarOpened}
    >
      <div className={classes.toolbar} >
        <AgenciaTitle
          isSidebarOpened={isSidebarOpened}          
          label={Agencia}
        />
      </div>
      <Divider />
      {!structure.length > 0 ? (<Intro />) : (
        <List className={classes.sidebarList}>

          {structure.map(link => (
            <SidebarLink
              key={link.id}
              location={location}
              isSidebarOpened={isSidebarOpened}
              {...link}
            />
          ))}
        </List>
      )}      
      <div className={classes.drawerButtom}>
        <IconButton
          color="inherit"
          onClick={() => toggleSidebar()}
          className={classNames(
            classes.headerMenuButton,
            classes.headerMenuButtonCollapse,
          )}
        >
          {isSidebarOpened ? (
            <ArrowBackIcon
              classes={{
                root: classNames(
                  classes.headerIcon,
                  classes.headerIconCollapse,
                ),
              }}
            />
          ) : (
              <ArrowForwardIcon
                classes={{
                  root: classNames(
                    classes.headerIcon,
                    classes.headerIconCollapse,
                  ),
                }}
              />
            )}
        </IconButton>
      </div>
    </Drawer>
  );

  // ##################################################################
  function handleWindowWidthChange() {
    var windowWidth = window.innerWidth;
    var breakpointWidth = theme.breakpoints.values.md;
    var isSmallScreen = windowWidth < breakpointWidth;

    if (isSmallScreen && isPermanent) {
      setPermanent(false);
    } else if (!isSmallScreen && !isPermanent) {
      setPermanent(true);
    }
  }
}

export default withRouter(Sidebar);
