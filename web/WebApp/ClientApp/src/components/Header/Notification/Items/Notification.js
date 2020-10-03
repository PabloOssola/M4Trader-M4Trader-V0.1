import React from 'react'
import store from '../../../../store/store';
import { useHistory } from "react-router-dom";
import { Types } from './NotificationbType';
import { Button, Typography, Badge, Box } from "@material-ui/core";
import {
    NotificationsNone as NotificationsIcon,
    ThumbUp as ThumbUpIcon,
    ShoppingCart as ShoppingCartIcon,
    LocalOffer as TicketIcon,
    BusinessCenter as DeliveredIcon,
    SmsFailed as FeedbackIcon,
    DiscFull as DiscIcon,
    Email as MessageIcon,
    Report as ReportIcon,
    Error as DefenceIcon,
    AccountBox as CustomerIcon,
    Done as ShippedIcon,
    Publish as UploadIcon,
} from "@material-ui/icons";
import { useTheme } from "@material-ui/styles";
import classnames from "classnames";
import tinycolor from "tinycolor2";

// styles
import useStyles from "./styles";



const typesIcons = {
    "e-commerce": <ShoppingCartIcon />,
    notification: <NotificationsIcon />,
    offer: <TicketIcon />,
    info: <ThumbUpIcon />,
    message: <MessageIcon />,
    feedback: <FeedbackIcon />,
    customer: <CustomerIcon />,
    shipped: <ShippedIcon />,
    delivered: <DeliveredIcon />,
    defence: <DefenceIcon />,
    report: <ReportIcon />,
    upload: <UploadIcon />,
    disc: <DiscIcon />,
};



export default function Notification({  variant, ...props }) {
    let { Idioma } = store.getState();
    let history = useHistory();
    var classes = useStyles();
    var theme = useTheme();
    console.log(props);
    const icon = getIconByType(props.type);
    var optionsDate = {
        year: 'numeric', month: 'numeric', day: 'numeric',
        hour: 'numeric', minute: 'numeric', second: 'numeric',
        hour12: false
    };

    let dateTime = new Intl.DateTimeFormat(Idioma, optionsDate).format(new Date(props.date));
    //let colorClass = classes[props.type];
    return (
        <div
            className={classnames(classes.notificationContainer, props.className, {
                [classes.notificationContained]: variant === "contained",
                [classes.notificationContainedShadowless]: props.shadowless,
            })}
            style={{
                backgroundColor:
                    variant === "contained" &&
                    theme.palette[props.color] &&
                    theme.palette[props.color].main,
            }}
        >

            <Box display="flex" flexDirection="column" borderBottom={1} >
                <Box>
                    <Typography
                        className={classnames({
                            [classes.containedTypography]: variant === "contained", 
                            [classes.info] : props.type === "info",
                            [classes.error] : props.type === "error",
                            [classes.warning] : props.type === "warning",
                            [classes.success] : props.type === "success",
                        })}
                        
                        variant={props.typographyVariant}>
                        {props.message}
                    </Typography>
                </Box>
                <Box>
                    <Typography variant="caption" color="initial">
                        {dateTime}
                    </Typography>
                </Box>

            </Box>

            {/* <div className={classes.messageContainer}>
                <Typography
                    className={classnames({
                        [classes.containedTypography]: variant === "contained",
                    })}
                    variant={props.typographyVariant}

                >
                    {props.message}
                </Typography>
                <Typography variant="caption" color="initial">
                    {props.date.toString()}
                </Typography>

            </div> */}
        </div>
    );
}

// ####################################################################
function getIconByType(type = "offer") {
    return typesIcons[type];
}
