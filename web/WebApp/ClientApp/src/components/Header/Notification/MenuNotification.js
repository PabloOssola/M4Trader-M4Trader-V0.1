import React, { useState, useEffect, useCallback, useRef } from 'react';
import { useHistory } from "react-router-dom";
import store from '../../../store/store';
import useStyles from "./styles";
import { useSnackbar } from 'notistack';
import { Traductor } from '../../../services/I18nService';
import Notification from './Items/Notification';
//demo
import notificationsDemo from './notificationDemo';
import SignalrService from '../../../services/SignalrService';

import {
    IconButton,
    Menu,
    MenuItem,
    Typography,
    Tooltip,
    Badge,
    Box
} from "@material-ui/core";


import {

    NotificationsNone as NotificationsIcon,

} from "@material-ui/icons";
let count = 1000;


export default function MenuNotification() {
    let classes = useStyles();
    let history = useHistory();
    let notificationsRef = useRef([]);
    let { IdTipoPersona, TipoPersona } = store.getState();
    let rutaNotificaciones = "";

    if (IdTipoPersona === 1)
        rutaNotificaciones = '';
    if (IdTipoPersona === 2)
        rutaNotificaciones = '/app/mensajes/recibidos';
    if (IdTipoPersona === 3)
        rutaNotificaciones = '/app/mismensajes/recibidos';


    let verTodo = Traductor.traducir("VerNotificaciones");
    let TituloNotificaciones = Traductor.traducir("TituloNotificaciones");

    const { enqueueSnackbar, closeSnackbar } = useSnackbar();

    let [notifications, setNotifications] = useState([]);

    let [notificationsMenu, setNotificationsMenu] = useState(null);
    let [isNotificationsUnread, setIsNotificationsUnread] = useState(true);


    const onNewMessage = useCallback(
        (travel) => {

            let _noficaciones = notificationsRef.current;
            let wraper = notificationsDemo.find(t => t.type === travel.type);
            enqueueSnackbar(travel.message, { variant: travel.type, autoHideDuration: 1000 });
            console.log(travel);
            _noficaciones.push({
                id: ++count,
                ...travel
            });


            // notificationsDemo.push({
            //     ...wraper,
            //     message: travel.message,
            //     id: ++count
            // })
            setNotifications([..._noficaciones]);
            setIsNotificationsUnread(true);
        },
        []
    )

    useEffect(() => {
        notificationsRef.current = notifications;

    }, [notifications])

    useEffect(() => {
        SignalrService.subscribe("NewMessage", onNewMessage);
        return () => {
            SignalrService.unsubscribe("NewMessage", onNewMessage);
        }
    }, [])

    return (
        <>
            <Tooltip title={Traductor.traducir("Notificaciones")}>
                <IconButton
                    color="inherit"
                    aria-haspopup="true"
                    aria-controls="mail-menu"
                    onClick={e => {
                        setNotificationsMenu(e.currentTarget);
                        setIsNotificationsUnread(false);

                    }}
                    className={classes.headerMenuButton}
                >
                    <Badge
                        badgeContent={isNotificationsUnread ? notifications.length : null}
                        color="secondary"
                    >
                        <NotificationsIcon classes={{ root: classes.headerIcon }} />
                    </Badge>
                </IconButton>
            </Tooltip>
            <Menu
                id="notifications-menu"
                open={Boolean(notificationsMenu)}
                anchorEl={notificationsMenu}
                onClose={() => {
                    setNotificationsMenu(null);
                    setNotifications([]);
                }}
                className={classes.headerMenu}
                disableAutoFocusItem
            >
                {notifications.length > 0 &&
                    <MenuItem
                        key={-1}
                        className={classes.headerMenuItem}>
                        <Box display="flex" flexDirection="column"  >
                            <Box>
                                <Typography variant="subtitle1" color="inherit">
                                    {TituloNotificaciones}
                                </Typography>
                            </Box>
                        </Box>
                    </MenuItem>
                }
                {notifications.slice(Math.max(notifications.length - 5, 0)).map((notification, index) => (

                    <MenuItem
                        key={notification.id}
                        onClick={() => setNotificationsMenu(null)}
                        className={classes.headerMenuItem}
                    >
                        <Notification  {...notification} typographyVariant="inherit" />
                    </MenuItem>
                ))}

                <MenuItem
                    key={0}
                    onClick={() => {
                        setNotificationsMenu(null);
                        history.push(rutaNotificaciones);
                    }}
                    className={classes.headerMenuItem}
                >
                    <Box display="flex" flexDirection="column"  >
                        <Box>
                            <Typography variant="subtitle2" color="inherit">
                                {verTodo}
                            </Typography>
                        </Box>
                    </Box>
                </MenuItem>
            </Menu>
        </>
    )
}
