import React, { useState } from 'react';
import { Link } from "react-router-dom";
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';

import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { CircularProgress } from "@material-ui/core";
import { loginUser } from '../../context/UserContext';
import { Traductor } from '../../services/I18nService';


function Copyright() {
    return (
        <Typography variant="body2" color="textSecondary" align="center">
            {'Copyright © '}
            <Link  to="/" color="inherit" href="">
                M4Trader
      </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const useStyles = makeStyles((theme) => ({
    paper: {
        marginTop: theme.spacing(8),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.secondary.main,
    },
    form: {
        width: '100%', // Fix IE 11 issue.
        marginTop: theme.spacing(1),
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
    },
}));

function Login(props) {
    const classes = useStyles();

    // global


    // local
    // let activeTabId = 0;
    var [isLoading, setIsLoading] = useState(false);
    var [error, setError] = useState({ Status: 0, Message: "" });
    // var [activeTabId, setActiveTabId] = useState(0);
    //var [nameValue, setNameValue] = useState("");
    var [loginValue, setLoginValue] = useState("");
    var [passwordValue, setPasswordValue] = useState("");


    return (
        <Container component="main" maxWidth="xs">
            <CssBaseline />
            <div className={classes.paper}>
                <Avatar className={classes.avatar}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="subtitle2" >
                    {Traductor.traducir("LBL_INGRESAR")}
                </Typography>
                {
                    error.Status == 3 && (
                        <Typography variant="subtitle2" style={{ color: "red", textAlign: "center" }}>
                            {error.Message}
                        </Typography>)


                }
                <form className={classes.form} noValidate>
                    <TextField

                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        id="email"
                        InputProps={{
                            classes: {
                                underline: classes.textFieldUnderline,
                                input: classes.textField,
                            },
                        }}
                        value={loginValue}
                        onChange={e => setLoginValue(e.target.value)}
                        label={Traductor.traducir("LBL_USUARIO")}
                        name="email"
                        autoComplete="email"
                        autoFocus
                    />
                    <TextField
                        variant="outlined"
                        margin="normal"
                        required
                        fullWidth
                        name="password"
                        label={Traductor.traducir("LBL_CLAVE")}
                        type="password"
                        id="password"
                        autoComplete="current-password"
                        value={passwordValue}
                        onChange={e => setPasswordValue(e.target.value)}
                        InputProps={{
                            classes: {
                                underline: classes.textFieldUnderline,
                                input: classes.textField,
                            },
                        }}
                    />
                    <FormControlLabel
                        control={<Checkbox value="remember" color="primary" />}
                        label={Traductor.traducir("LBL_RECORDARME")}
                    />
                    {isLoading ? (
                        <CircularProgress size={26} className={classes.loginLoader} />
                    ) : (

                            <Button
                                type="submit"
                                fullWidth
                                variant="contained"
                                color="primary"
                                className={classes.submit}
                                disabled={
                                    loginValue.length === 0 || passwordValue.length === 0
                                }
                                onClick={() =>
                                    loginUser(
                                        loginValue,
                                        passwordValue,
                                        props.history,
                                        setIsLoading,
                                        setError,
                                    )
                                }

                            >
                                Login
                            </Button>
                        )}
                    < Grid container spacing={2}>
                        <Grid item xs>
                            <Link to="/" variant="body2">
                                {Traductor.traducir("LBL_RECUPERARCONTRASENIA")}
                            </Link>
                        </Grid>
                        <Grid item xs>
                            <Link to="/registrarse" variant="body2">
                                {Traductor.traducir("LBL_RESGITRARSE")}
                            </Link>
                        </Grid>
                    </Grid>
                </form>
            </div>
            <Box mt={8}>
                <Copyright />
            </Box>
        </Container >
    );
}

export default Login;