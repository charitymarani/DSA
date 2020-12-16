/**
 * Design a data structure that accepts a stream of integers and checks if it has a pair of integers that sum up to a particular value.

Implement the TwoSum class:

TwoSum() Initializes the TwoSum object, with an empty array initially.
void add(int number) Adds number to the data structure.
boolean find(int value) Returns true if there exists any pair of numbers whose sum is equal to value, otherwise, it returns false.
 */

// Sorted list approach
// Complexity: Time=>nlogn(find) worst case,add(0(1)) and space=> o(n) worst case
const TwoSum = function() {
    this.nums=[]
    this.is_sorted=false
    
};

/**
 * Add the number to an internal data structure.. 
 * @param {number} number
 * @return {void}
 */
TwoSum.prototype.add = function(number) {
    this.nums.push(number)
    this.is_sorted=false
    
};

/**
 * Find if there exists any pair of numbers which sum is equal to the value. 
 * @param {number} value
 * @return {boolean}
 */
TwoSum.prototype.find = function(value) {
    if(!this.is_sorted){
        this.nums.sort((a,b)=>a-b)
        this.is_sorted=true
    }
    let low=0
    let high =this.nums.length-1
    while(low<high){
        let curr = this.nums[low]+this.nums[high]
        if(curr<value){
            low++
        }
        else if(curr>value){
            high--
        }
        else{
            return true
        }
    }
    return false
    
};


// Hash table approach
// o(n)time (find), o(1)(add)
// 0(n)space
var TwoSum = function() {
    this.nums={}
   
    
};

/**
 * Add the number to an internal data structure.. 
 * @param {number} number
 * @return {void}
 */
TwoSum.prototype.add = function(number) {
    if(number in this.nums){
        this.nums[number]++
    }
    else{
        this.nums[number]=1
    }
    
};

/**
 * Find if there exists any pair of numbers which sum is equal to the value. 
 * @param {number} value
 * @return {boolean}
 */
TwoSum.prototype.find = function(value) {
    for(num in this.nums){
        let comple = value-num
        if(Number(num) !==comple){
            if(comple in this.nums){
                return true
            }
        }
        else if(this.nums[num]>1){
            return true
        }
    }
    return false
    
    
};



