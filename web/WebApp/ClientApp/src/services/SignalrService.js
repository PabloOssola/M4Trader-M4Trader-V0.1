import * as signalR   from '@microsoft/signalr';
import { setting } from '../setting';

let connection;




function signalrService() {
     connection = new signalR.HubConnectionBuilder()
     .withUrl("/Message", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
     })
     //.withAutomaticReconnect()
     .build();


}

signalrService.prototype.dispatch = function(eventName, travel)
{
    connection.invoke(eventName, travel);
}

signalrService.prototype.connect = async function () {
    
    return connection.start();
}

signalrService.prototype.subscribe = function(eventName, callback)
{
    connection.on(eventName, callback);
}
signalrService.prototype.unsubscribe = function(eventName, callback)
{
    connection.off(eventName,callback);
}


const SignalrService = new signalrService();

export default SignalrService;