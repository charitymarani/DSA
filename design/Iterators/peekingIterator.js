/**
 * 
 Given an Iterator class interface with methods: next() and hasNext(), design and implement a PeekingIterator that support the peek() operation -- it essentially peek() at the element that will be returned by the next call to next().

Example:

Assume that the iterator is initialized to the beginning of the list: [1,2,3].

Call next() gets you 1, the first element in the list.
Now you call peek() and it returns 2, the next element. Calling next() after that still return 2. 
You call next() the final time and it returns 3, the last element. 
Calling hasNext() after that should return false.
Follow up: How would you extend your design to be generic and work with all types, not just integer?
 */


//  Approach 1
// O(1)TS
const PeekingIterator = function(iterator) {
    this.iterator =iterator;
    this.peek_value=null
    
};

/**
 * @return {number}
 */
PeekingIterator.prototype.peek = function() {
 /*
 * If there's not already a peeked value, get one out and store
 * it in the _peeked_value variable. We aren't told what to do if
 * the iterator is actually empty -- here I have thrown an exception
 * but in an interview you should definitely ask! This is the kind of
 * thing they expect you to ask about.
 
 */
    if(this.peek_value===null){
        if(!this.iterator.hasNext()){
            return
        }
        this.peek_value=this.iterator.next()
    }
    return this.peek_value
    
};

/**
 * @return {number}
 */
PeekingIterator.prototype.next = function() {
/*
*Firstly, we need to check if we have a value already
*stored in the _peeked_value variable. If we do, we need to
*return it and also set _peeked_value to null so that the value
*isn't returned again.
*/
    if (this.peek_value!==null){
        let ans = this.peek_value
        this.peek_value=null
        return ans
    }
    if(this.iterator.hasNext()){
        return this.iterator.next()
    }
    
};

/**
 * @return {boolean}
 */
PeekingIterator.prototype.hasNext = function() {
    return this.peek_value!==null || this.iterator.hasNext()
    
};


// Approach 2
// O(1)TS
const PeekingIterator2= function(iterator) {
    this.iterator =iterator;
    this._next=iterator.next()
    
};

/**
 * @return {number}
 */
PeekingIterator2.prototype.peek = function() {
 
    return this._next
    
};

/**
 * @return {number}
 */
PeekingIterator2.prototype.next = function() {
    if (this._next!==null){
        let ans = this._next
        this._next=null
        if(this.iterator.hasNext()){
            this._next=this.iterator.next()
        }
        return ans
    }
    
    
};

/**
 * @return {boolean}
 */
PeekingIterator2.prototype.hasNext = function() {
    return this._next!==null
    
};



