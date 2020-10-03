import React, { useState, Suspense, useEffect } from 'react'
import { useSelector } from 'react-redux';
import { Route, Switch, useLocation } from "react-router-dom";
import { AppBar, Toolbar, IconButton, Typography, Drawer, Divider, List } from "@material-ui/core";
import { Menu as MenuIcon, ArrowBack as ArrowBackIcon } from "@material-ui/icons";
import classNames from "classnames";
import clsx from 'clsx';
import SidebarLink from '../../components/Sidebar/components/SidebarLink/SidebarLink';
import routes from './routes';
import useStyles from "./styles";
import { useTheme } from "@material-ui/styles";


import Intro from '../../components/Util/Intro';
import { Traductor } from '../../services/I18nService';
import LinearScaleIcon from '@material-ui/icons/LinearScale';

const structure = [
    {
        id: "1",
        key: "1",
        label: Traductor.traducir("Paso1"),
        link: "/on/paso1",
        icon: <LinearScaleIcon />
    },
    {
        id: "2",
        key: "2",
        label: Traductor.traducir("Paso2"),
        link: "/on/paso2",
        icon: <LinearScaleIcon />
    },
    {
        id: "3",
        key: "3",
        label: Traductor.traducir("Paso3"),
        link: "/on/paso3",
        icon: <LinearScaleIcon />
    },
    {
        id: "4",
        key: "4",
        label: Traductor.traducir("Paso4"),
        link: "/on/paso4",
        icon: <LinearScaleIcon />
    }

];


export default function Dashboard() {
    var classes = useStyles();
    var theme = useTheme();
    let location = useLocation();
    const [isSidebarOpened, setSidebarOpened] = useState(false);
    const [isPermanent, setPermanent] = useState(true);

    let Agencia = useSelector(state => state.Agencia);

    console.log(routes);

    let toggleSidebar = function () {
        setSidebarOpened(!isSidebarOpened);
    }


    useEffect(function () {
        window.addEventListener("resize", handleWindowWidthChange);
        handleWindowWidthChange();
        return function cleanup() {
            window.removeEventListener("resize", handleWindowWidthChange);
        };
    });

    return (
        <div className={classes.root}>
            <AppBar position="fixed" className={clsx(classes.appBar, {
                [classes.appBarShift]: isSidebarOpened,
            })}>
                <Toolbar className={classes.toolbar}>

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
                                <MenuIcon
                                    classes={{
                                        root: classNames(
                                            classes.headerIcon,
                                            classes.headerIconCollapse,
                                        ),
                                    }}
                                />
                            )}
                    </IconButton>
                    <Typography variant="h6" weight="medium" className={classes.logotype}>
                        {Agencia}
                    </Typography>
                    <div className={classes.grow} />
                </Toolbar>
            </AppBar>
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
                open={isSidebarOpened}>
                {/* <div className={classes.toolbar} >
                    <AgenciaTitle
                        isSidebarOpened={isSidebarOpened}
                        label={Agencia}
                    />
                </div> */}
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

            </Drawer>
            <div className={classNames(classes.content, { [classes.contentShift]: isSidebarOpened, })}>
                <div className={classes.fakeToolbar} />
                <Switch>
                    {routes.map((route, idx) => {
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
                </Switch>
            </div>
        </div>
    )

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
