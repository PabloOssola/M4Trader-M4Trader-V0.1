const notificaciones = [
    {
        id: 0,
        type: "info",       
        message: "Check out this awesome ticket",
        date : new Date()
    },
    {
        id: 1,
      
        type: "success",
        subtype:"tranferencia",
        message: "What is the best way to get ...",
        date : new Date()
    },
    {
        id: 2,        
        type: "warning",
        subtype:"tranferencia",
        message: "This is just a simple notification",
        date : new Date()
    },
    {
        id: 3,        
        type: "error",
        subtype:"tranferencia",
        message: "This is just a simple notification",
        date : new Date()
    },
    // {
    //     id: 3,
    //     color: "primary",
    //     type: "e-commerce",
    //     subtype:"tranferencia",
    //     message: "12 new orders has arrived today",
    // },

];


export default notificaciones;