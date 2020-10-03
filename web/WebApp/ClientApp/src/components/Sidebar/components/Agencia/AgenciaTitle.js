import React, { useState } from "react";
import {
    Divider,
    Typography,
} from "@material-ui/core";
import { Inbox as InboxIcon } from "@material-ui/icons";
import { Link } from "react-router-dom";
import classnames from "classnames";
import BusinessIcon from '@material-ui/icons/Business';
// styles
import useStyles from "./styles";



// components
//import Dot from "../Dot";

export default function AgenciaTitle({
    label,
    isSidebarOpened,
}) {
    var classes = useStyles();

    return (
        <div style={{ display:"flex",alignItems:"center", marginLeft: "36px" }}>
            <BusinessIcon />
            <Typography variant="h6" weight="medium"
                className={classnames(classes.linkText, classes.sectionTitle, {
                    [classes.linkTextHidden]: !isSidebarOpened,
                })}
            >
                {label}
            </Typography>
        </div>
    );

    // ###########################################################
}
