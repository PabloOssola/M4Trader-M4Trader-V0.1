import { makeStyles } from "@material-ui/styles";
import { fade } from "@material-ui/core/styles/colorManipulator";
const drawerWidth = 260;
export default makeStyles(theme => ({
    root: {
        display: "flex",
        maxWidth: "100vw",
        overflowX: "hidden",
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
        width: `calc(100% - 260px)`,
        minHeight: "100vh",
        transition: theme.transitions.create(["width"], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    contentCenter: {
        flexGrow: 1,
        padding: theme.spacing(1),
        width: `calc(100% - 260px)`,
        //height:"300px",
        minHeight: "80vh",
        transition: theme.transitions.create(["width"], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    contentShift: {
        width: `calc(100vw - ${260 + theme.spacing(6)}px)`,
        transition: theme.transitions.create(["width"], {
            easing: theme.transitions.easing.sharp,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    fakeToolbar: {
        ...theme.mixins.toolbar,
    },
    paper: {
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
        whiteSpace: 'nowrap',
        marginBottom: theme.spacing(1),
    },
    logotype: {
        color: "white",
        marginLeft: theme.spacing(2.5),
        marginRight: theme.spacing(2.5),
        fontWeight: 500,
        fontSize: 18,
        whiteSpace: "nowrap",
        [theme.breakpoints.down("xs")]: {
            display: "none",
        },
    },
    appBar: {
        width: "100%",
        height: "64px",
        backgroundColor: theme.palette.primary.main,
        zIndex: theme.zIndex.drawer + 1,
        transition: theme.transitions.create(['width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },
    appBarShift: {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: drawerWidth,
        transition: theme.transitions.create(['width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    },

    toolbar: {
        paddingLeft: theme.spacing(2),
        paddingRight: theme.spacing(2),
    },
    hide: {
        display: "none",
    },
    grow: {
        flexGrow: 1,
    },
    headerMenu: {
        marginTop: theme.spacing(7),
    },
    headerMenuList: {
        display: "flex",
        flexDirection: "column",
    },
    headerMenuItem: {
        "&:hover, &:focus": {
            backgroundColor: theme.palette.primary.main,
            color: "white",
        },
    },
    headerMenuButton: {
        marginLeft: theme.spacing(2),
        padding: theme.spacing(0.5),
    },
    headerMenuButtonCollapse: {
        marginRight: theme.spacing(2),
    },
    headerIcon: {
        fontSize: 28,
        color: "rgba(255, 255, 255, 0.35)",
    },
    headerIconCollapse: {
        color: "white",
    },
    sectionDesktop: {
        display: 'flex'
        // [theme.breakpoints.up('md')]: {
        //   display: 'flex',
        // },
    },
    hide: {
        display: "none",
      },
      drawer: {
        width: drawerWidth,
       
        flexShrink: 0,
        whiteSpace: "nowrap",
        overflowX: "hidden"
        
      },
      drawerOpen: {
        width: drawerWidth,
        marginTop:"64px",
        overflowX: "hidden",
        transition: theme.transitions.create("width", {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.enteringScreen,
        }),
      },
      drawerClose: {
        transition: theme.transitions.create("width", {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        overflowX: "hidden",
        marginTop:"64px",
        width: theme.spacing(7) + 40,
        [theme.breakpoints.down("sm")]: {
          width: drawerWidth,
        },
      },
}));
