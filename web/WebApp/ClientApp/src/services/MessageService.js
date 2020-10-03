import  signals  from 'signals';

const events = {};

function messageService()
{
    


};


function getOrCreateEvent(eventName)
{
    if(!events[eventName])
    {
        events[eventName] = new signals.Signal();
    }

    return events[eventName];
}

messageService.prototype.subscribe = function(eventName, callback)
{   

    getOrCreateEvent(eventName).add(callback);
    
};

messageService.prototype.unsubscribe = function(eventName, callback)
{
    getOrCreateEvent(eventName).remove(callback);
};

messageService.prototype.emit = function(eventName, payload)
{
    getOrCreateEvent(eventName).dispatch(payload);
};




const MessageService = new messageService();


export default MessageService;
