import { makeStyles } from "@material-ui/styles";


export default makeStyles(theme => ({
  path: {
    color: "white",
    // marginLeft: theme.spacing(2.5),
    // marginRight: theme.spacing(2.5),
    fontWeight: 300,
    fontSize: 14,
    height:"20px",
    textTransform: "capitalize",
    whiteSpace: "nowrap",
    [theme.breakpoints.down("xs")]: {
      display: "none",
    },
    cursor: "pointer"
  },

  container:{
    position: "absolute",   
    left: "10px",
    bottom: "10px"
    

  },
  separator:{
    color: "white"
  }

}));
