/**
Design and implement an iterator to flatten a 2d vector. It should support the following operations: next and hasNext.

Example:

Vector2D iterator = new Vector2D([[1,2],[3],[4]]);

iterator.next(); // return 1
iterator.next(); // return 2
iterator.next(); // return 3
iterator.hasNext(); // return true
iterator.hasNext(); // return true
iterator.next(); // return 4
iterator.hasNext(); // return false
 * 
 */
// Brute force approach
// O(NM) time; O(N)space
class Vector2D{
  constructor(v){
    this.pos=-1
    // We need to iterate over the 2D vector, getting all the integers
    // out of it and putting them into the nums list.
    this.nums=[]
    for(let i=0;i<v.length;i++){
      for(let j=0;j<v[i].length;j++){
        this.nums.push(v[i][j])
      }
    }

  }

  next(){
    return this.nums[++this.pos]

  }
  hasNext(){

    return this.pos + 1 < this.nums.length
  }
}

// Two pointer
class Vector2D{
  constructor(v){
    this.vector = v
    this.inner = 0
    this.outer = 0

  }
  //  If the current outer and inner point to an integer, this method does nothing.
  //  Otherwise, inner and outer are advanced until they point to an integer.
  // If there are no more integers, then outer will be equal to vector.length
  // when this method terminates.
  advance_to_next(){
    // While outer is still within the vector, but inner is over the 
    // end of the inner list pointed to by outer, we want to move
    // forward to the start of the next inner vector.
    while (this.outer < this.vector.length && this.inner ===this.vector[this.outer].length){
      this.outer ++
      this.inner = 0

    }
            

  }
  next(){
    // Ensure the position pointers are moved such they point to an integer,
    // or put outer = vector.length.
    this.advance_to_next()
    // Return current element and move inner so that is after the current
    // element.
    let result = this.vector[this.outer][this.inner]
    this.inner ++
    return result

  }
  hasNext(){
    // Ensure the position pointers are moved such they point to an integer,
    // or put outer = vector.length.
    this.advance_to_next()
    // If outer = vector.length then there are no integers left, otherwise
    // we've stopped at an integer and so there's an integer left.
    return this.outer < this.vector.length
       

  }
       
        
}

  