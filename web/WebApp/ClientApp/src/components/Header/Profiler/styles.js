import { makeStyles } from "@material-ui/styles";

export default makeStyles(theme => ({
  fab: {
    margin: theme.spacing(2),
  },
  profileMenu: {
    minWidth: 265,
  },
  profileMenuUser: {
    display: "flex",
    flexDirection: "column",
    padding: theme.spacing(2),
  },
  profileMenuItem: {
    color: theme.palette.text.hint,
    fontSize : "12px"
  },
  profileMenuIcon: {
    marginRight: theme.spacing(2),
    color: theme.palette.text.hint,
  },
  profileMenuLink: {
    cursor:"pointer",
    fontSize: 14,
    textDecoration: "none",
    "&:hover": {
      cursor: "pointer",
    },
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
    //color: "rgba(255, 255, 255, 0.35)",
  },
  headerIconCollapse: {
    color: "white",
  }
}));
