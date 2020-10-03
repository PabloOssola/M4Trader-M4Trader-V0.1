import React from 'react'
import { withRouter } from 'react-router-dom';
import {
    Breadcrumbs,
    Link,
    Typography,
    Divider,
    Box
    //,
    // Link
} from "@material-ui/core";

import {Traductor} from '../../../services/I18nService';
// styles
import useStyles from "./styles";

function HeaderBreadcrumbs(props) {
    const classes = useStyles();
    const { history, location } = props;
    const pathnames = location.pathname.split('/').filter((x) => x);

    return (
        <Box className={classes.container}>
        <Breadcrumbs aria-label="breadcrumb" classes={{separator : classes.separator}}>
            {/* {pathnames.length > 0 ?
                <Link color="textSecondary" variant="subtitle1" onClick={() => history.push('/')} >
                    Home
                </Link>
                :
                <Typography variant="subtitle1" color="textSecondary">
                    Home
                </Typography>
            } */}

            {pathnames.map((name, index) => {
                const routeTo = `/${pathnames.slice(0, index + 1).join('/')}`;
                const isLast = index === pathnames.length - 1;
                let nameTrad  = Traductor.traducir(name);
                return isLast ? (
                    <Typography key={name} variant="subtitle1"  className={classes.path}>
                        {nameTrad}
                    </Typography>
                )
                    :
                    (
                        <Link className={classes.path} key={name} onClick={() => history.push(routeTo)}>{Traductor.traducir(nameTrad)}</Link>
                    )
            })}


        </Breadcrumbs>
        </Box>
    )
}

export default withRouter(HeaderBreadcrumbs);