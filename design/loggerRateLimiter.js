// Have a thread(or func) that does periodic cleanup after 10 secs to save memory



const Logger = function() {
    this.map={}
    
};

/**
 * Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. 
 * @param {number} timestamp 
 * @param {string} message
 * @return {boolean}
 */

Logger.prototype.shouldPrintMessage = function(timestamp, message) {
    if((message in this.map) && timestamp-this.map[message]<10){
        return false
    }
    else{
        this.map[message]=timestamp
        return true
        
    }
    
};