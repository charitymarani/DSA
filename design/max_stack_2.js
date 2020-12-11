import { DLL } from '../DataStructures/DoublyLinkedList';
// TO BE CONTINUED. MIMIC TREEMAPS IN JAVA => map.lastkey() returns largest key
// o(logn) and 0(1) for top()


const last = (arr) =>(arr[arr.length-1])
const MaxStack = function() {
    this.stack=new DLL()
    this.size=0
    this.maxStack=[]
    
    
};

/** 
 * @param {number} x
 * @return {void}
 */
MaxStack.prototype.push = function(x) {
    if(!this.size || x > last(this.maxStack)[0]){
        this.maxStack.push([x,1])
    }
    else if(x===last(this.maxStack)[0]){
      last(this.maxStack)[1]++;
    }
    this.stack.setHead(x)
    this.size++;
    
};

/**
 * @return {number}
 */
MaxStack.prototype.pop = function() {
   if(this.size){
     let key=this.stack.head.next.key
     this.stack.remove(key)
     if(key===last(this.maxStack)[0]){
       last(this.maxStack)[1]--;
       if(!last(this.maxStack)[1]){
         this.maxStack.pop()
       }
     }
     
     this.size--;
     return key

   }
   
    
};

/**
 * @return {number}
 */
MaxStack.prototype.top = function() {
    if(this.size){
     let key=this.stack.head.next.key
     return key

   }
    
};

/**
 * @return {number}
 */
// MaxStack.prototype.peekMax = function() {
//     if(this.size){
//      return last(this.maxStack)[0]

//    }
    
// };

// /**
//  * @return {number}
//  */
// MaxStack.prototype.popMax = function() {
//         let m= this.peekMax()
//         last(this.maxStack)[1]--
//         if(!last(this.maxStack)[1]){
//           this.maxStack.pop()
//         }
//         this.stack.remove(m)
//         return m
    
    
// };

/** 
 * Your MaxStack object will be instantiated and called as such:
 * var obj = new MaxStack()
 * obj.push(x)
 * var param_2 = obj.pop()
 * var param_3 = obj.top()
 * var param_4 = obj.peekMax()
 * var param_5 = obj.popMax()
 */

//  let obj=new MaxStack()
//  obj.push(5)
//  obj.push(1)
//  obj.push(5)
//  let param_2 = obj.pop()
//  let param_3 = obj.top()
// let param_5 = obj.popMax()
// let param_4 = obj.peekMax()
 