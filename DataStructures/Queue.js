export const MyQueue = function(){
  this. store={}
  this.top=0
  this.bottom=0
}

MyQueue.prototype.enqueue = function(val){
  this.store[this.top]=val
  this.top++

}
MyQueue.prototype.dequeue=function(){
  if(!this.isEmpty()){
    let ans = this.store[this.bottom]
    delete this.store[this.bottom]
    this.bottom++
    return ans

  }
  
}
MyQueue.prototype.peek()=function(){
  if(!this.isEmpty()){
    return this.store[this.bottom]
  }

}
MyQueue.prototype.isEmpty=function(){
  return this.top===this.bottom
}
MyQueue.prototype.size =function(){
  return this.top=this.bottom
}
