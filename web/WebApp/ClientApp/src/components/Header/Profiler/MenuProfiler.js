import React, { useState } from 'react'
import { useHistory } from "react-router-dom";
import store from '../../../store/store';
import { signOut } from '../../../context/UserContext';
import { Traductor } from '../../../services/I18nService';
import classNames from "classnames";
import {
    IconButton,
    Menu,
    MenuItem,
    Typography,
    Tooltip 
} from "@material-ui/core";

import { Person as AccountIcon } from "@material-ui/icons";

import useStyles from "./styles";


export default function MenuProfiler() {

    var classes = useStyles();
    let history = useHistory();
    var [profileMenu, setProfileMenu] = useState(null);
    var { UserName } = store.getState();

    return (
        <>
            <Tooltip title={UserName}>
                <IconButton
                    aria-haspopup="true"
                    color="inherit"
                    className={classes.headerMenuButton}
                    aria-controls="profile-menu"
                    onClick={e => setProfileMenu(e.currentTarget)}
                >
                    <AccountIcon classes={{ root: classes.headerIcon }} />
                </IconButton>
            </Tooltip>
            <Menu
                id="profile-menu"
                open={Boolean(profileMenu)}
                anchorEl={profileMenu}
                onClose={() => setProfileMenu(null)}
                className={classes.headerMenu}
                classes={{ paper: classes.profileMenu }}
                disableAutoFocusItem
            >
                <div className={classes.profileMenuUser}>
                    <Typography variant="subtitle1" weight="medium">
                        {UserName}
                    </Typography>
                </div>
                <MenuItem
                    className={classNames(
                        classes.profileMenuItem,
                        classes.headerMenuItem,
                    )}>
                    <AccountIcon className={classes.profileMenuIcon} /> {Traductor.traducir("Profile")}
                </MenuItem>
                <div className={classes.profileMenuUser}>
                    <Typography
                        className={classes.profileMenuLink}
                        color="primary"
                        onClick={() => signOut(history)}
                    >
                        {Traductor.traducir("SignOut")}
                    </Typography>
                </div>
            </Menu>
        </>
    )
}
