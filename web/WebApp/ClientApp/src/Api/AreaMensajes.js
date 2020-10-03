import React from 'react';
import { toast } from 'react-toastify';
import Notification from '../components/Notification/Notification';
import useStyles from "./styles";

/**
 *                     toast('🦄 Wow so easy!', {
                        position: "top-right",
                        autoClose: 5000,
                        hideProgressBar: false,
                        closeOnClick: true,
                        pauseOnHover: true,
                        draggable: true,
                        progress: undefined,
                        });
 */

let handleNotificationCall;
let errorToastId;
let retryErrorNotification;

let notificationsPosition = 2;
let setErrorToastId;
const positions = [
    toast.POSITION.TOP_LEFT,
    toast.POSITION.TOP_CENTER,
    toast.POSITION.TOP_RIGHT,
    toast.POSITION.BOTTOM_LEFT,
    toast.POSITION.BOTTOM_CENTER,
    toast.POSITION.BOTTOM_RIGHT,
  ];
  

function AreaMensajes() {
    const classes = useStyles();

    handleNotificationCall = notificationCall;

    return (<br/>);

    function sendNotification(componentProps, options) {

        return toast(
            <Notification
                {...componentProps}
                className={classes.notificationComponent}
            />,
            options,
        );
    }

    function notificationCall(notificationType) {
        var componentProps;

        if (errorToastId && notificationType === "error") return;

        switch (notificationType) {
            case "info":
                componentProps = {
                    type: "feedback",
                    message: "New user feedback received",
                    variant: "contained",
                    color: "primary",
                };
                break;
            case "error":
                componentProps = {
                    type: "message",
                    message: "Message was not sent!",
                    variant: "contained",
                    color: "secondary",
                    extraButton: "Resend",
                    extraButtonClick: retryErrorNotification,
                };
                break;
            default:
                componentProps = {
                    type: "shipped",
                    message: "The item was shipped",
                    variant: "contained",
                    color: "success",
                };
        }

        var toastId = sendNotification(componentProps, {
            type: notificationType,
            position: positions[notificationsPosition],
            progressClassName: classes.progress,
            onClose: notificationType === "error" && (() => setErrorToastId(null)),
            className: classes.notification,
        });
    }
    

}

function Notify(type) {
    if (handleNotificationCall)
        handleNotificationCall(type);
}



export {
    AreaMensajes,
    Notify
}