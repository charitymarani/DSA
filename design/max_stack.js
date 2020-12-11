/**
 * Using one stack
 * time complexity: o(N) for popMax, 0(1) for the rest
 * Space complexity: o(N) where N is maxSize of stack
 */
const last = (arr) =>(arr[arr.length-1])

var MaxStack = function() {
    this.stack=[]
    
    
};

/** 
 * @param {number} x
 * @return {void}
 */
MaxStack.prototype.push = function(x) {
    let currMax =x
    if(this.stack.length){
        currMax= Math.max(x, last(this.stack)[1])
    }
    this.stack.push([x, currMax])
    
};

/**
 * @return {number}
 */
MaxStack.prototype.pop = function() {
   return this.stack.pop()[0]
    
};

/**
 * @return {number}
 */
MaxStack.prototype.top = function() {
    return last(this.stack)[0]
    
};

/**
 * @return {number}
 */
MaxStack.prototype.peekMax = function() {
    return last(this.stack)[1]
    
};

/**
 * @return {number}
 */
MaxStack.prototype.popMax = function() {
        let m= this.peekMax()
        let temp=[]
        while(last(this.stack)[0]!=m){
            temp.push(this.stack.pop())
        }
        this.stack.pop()
        while(temp.length){
            this.push(temp.pop()[0])
        }
        return m
    
    
};

/** 
 * Your MaxStack object will be instantiated and called as such:
 * var obj = new MaxStack()
 * obj.push(x)
 * var param_2 = obj.pop()
 * var param_3 = obj.top()
 * var param_4 = obj.peekMax()
 * var param_5 = obj.popMax()
 */