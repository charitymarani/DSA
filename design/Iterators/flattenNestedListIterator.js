/**
 * 
 * Given a nested list of integers, implement an iterator to flatten it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Example 1:

Input: [[1,1],2,[1,1]]
Output: [1,1,2,1,1]
Explanation: By calling next repeatedly until hasNext returns false, 
             the order of elements returned by next should be: [1,1,2,1,1].
 */

//  Approach 1
const NestedIterator = function(nestedList) {
    this.integers=[]
    this.pos=0
    this.flattenList(nestedList)
    
};
NestedIterator.prototype.flattenList=function(arr){
    console.log(arr)
    for(let item of arr){
        if(Number.isInteger(item)){
            this.integers.push(item)
        }
        else{
            this.flattenList(item)
        }
    }
}

/**
 * @this NestedIterator
 * @returns {boolean}
 */
NestedIterator.prototype.hasNext = function() {
    return this.pos<this.integers.length
    
};

/**
 * @this NestedIterator
 * @returns {integer}
 */
NestedIterator.prototype.next = function() {
    if(this.hasNext()){
        return this.integers[this.pos++]
    }
    
};

