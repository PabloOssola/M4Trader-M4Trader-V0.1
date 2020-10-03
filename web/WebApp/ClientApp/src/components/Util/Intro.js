import React from "react";
import CircularProgressWithLabel from './CircularProgressWithLabel';
import { Container } from "@material-ui/core";
import { makeStyles } from "@material-ui/styles";



let useStyle = makeStyles((theme)=>({
    container : {
        display : "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh"
    }
}));


function Intro() {
    const classes = useStyle();
    const [progress, setProgress] = React.useState(10);

    React.useEffect(() => {
        const timer = setInterval(() => {
            setProgress((prevProgress) => (prevProgress >= 100 ? 10 : prevProgress + 10));
        }, 800);
        return () => {
            clearInterval(timer);
        };
    }, []);

    return (
        <Container maxWidth="lg" className={classes.container}>       
            <CircularProgressWithLabel value={progress} />
      </Container>
        
    )
}



export default Intro;
