import { MyQueue } from "../../DataStructures/Queue";

/**
 * Given two 1d vectors, implement an iterator to return their elements alternately.

Example:

Input:
v1 = [1,2]
v2 = [3,4,5,6] 
Output: [1,3,2,4,5,6]
Explanation: By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1,3,2,4,5,6].
 
Follow up:

What if you are given k 1d vectors? How well can your code be extended to such cases?
*/

// Using two pointers
// Complexity: O(1)Time and space
// For follow up: O(k)Time for next(), O(1)=>hasNext(), o(k) space
let ZigzagIterator = function ZigzagIterator(v1, v2) {
    this.vectors=[v1,v2]
    this.row=0
    this.col=0
    this.count=0
    this.totalCount=v1.length + v2.length
    
};


/**
 * @this ZigzagIterator
 * @returns {boolean}
 */
ZigzagIterator.prototype.hasNext = function hasNext() {
    return this.count<this.totalCount
    
};

/**
 * @this ZigzagIterator
 * @returns {integer}
 */
ZigzagIterator.prototype.next = function next() {
    if(!this.hasNext()){
        return
    }
    let iteration=0
    let ans
    while(iteration<this.vectors.length){
        let curr = this.vectors[this.row]
        if(this.col<curr.length){
            ans = curr[this.col]
        }
        iteration++
        this.row=(this.row+1)%this.vectors.length
        if(this.row===0){
            this.col++
        }
        if(ans!==undefined){
            this.count++
            return ans
        }
    }
    
};


// Using a queue of pointers to the given vectors
// Complexity: o(1)Time,  O(1) space if 2vectors else o(k) if k vectors
/**
 * @constructor
 * @param {Integer[]} v1
 * @param {Integer[]} v1
 */
const ZigzagIterator2 = function ZigzagIterator(v1, v2) {
    this.vectors=[v1,v2]
    this.queue=new MyQueue()
    for(let i=0;i<this.vectors.length;i++){
        if(this.vectors[i].length>0){
            // (index_of_vector, index_of_element_to_output)         
            this.queue.enqueue([i,0])
        }
    }
   
};


/**
 * @this ZigzagIterator2
 * @returns {boolean}
 */
ZigzagIterator2.prototype.hasNext = function hasNext() {
    return !this.queue.isEmpty()
    
    
    
};

/**
 * @this ZigzagIterator2
 * @returns {integer}
 */
ZigzagIterator2.prototype.next = function next() {
    if(!this.queue.isEmpty()){
        const [vec_index, elem_index] = this.queue.dequeue()
        let next_elem_index = elem_index+1
        if(next_elem_index< this.vectors[vec_index].length){
            //append the pointer for the next round
            // if there are some elements left
            this.queue.enqueue([vec_index,next_elem_index ])
        }
        return this.vectors[vec_index][elem_index]
        
    }
    
};


/**
 * Your ZigzagIterator will be called like this:
 * var i = new ZigzagIterator(v1, v2), a = [];
 * while (i.hasNext()) a.push(i.next());
*/



