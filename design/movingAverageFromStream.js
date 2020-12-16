// circular queue
// tail=(head+1)modsize
var MovingAverage = function(size) {
    this.size=size
    this.queue=new Array(this.size).fill(0)
    this.head=this.window_sum=0
    //  numbe rof elements seen so far
    this.count=0
    
};

/** 
 * @param {number} val
 * @return {number}
 */
MovingAverage.prototype.next = function(val) {
    this.count++
    //  calculate new sum by shifting window
    let tail = (this.head+1)%this.size
    this.window_sum = this.window_sum-this.queue[tail] + val
    // move to next head
    this.head=(this.head+1)%this.size
    this.queue[this.head]=val
    return this.window_sum/Math.min(this.size, this.count)
    
};
