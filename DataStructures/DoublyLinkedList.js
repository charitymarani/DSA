export const Node = function(key, value, prev=null, next=null){
  this.key=key
  this.value=value;
  this.prev=prev
  this.next=next
}

export const DLL = function(){

  this.head = new Node(-1)
  this.tail = new Node(-1)
  this.head.next=this.tail
  this.tail.prev=this.head

  this.map={}
}
// setHead
DLL.prototype.setHead=function(key, value=null){
  let newNode = new Node(key, value)
  newNode.next = this.head.next
  newNode.prev = this.head
  this.head.next.prev=newNode
  this.head.next=newNode
  if(this.exists(key)){
    this.map[key].push(newNode)
  }
  else{
    this.map[key]=[newNode]
  }
  

}
// setTail
DLL.prototype.setTail=function(key, value=null){
  let newNode = new Node(key, value)
  newNode.next = this.tail
  newNode.prev = this.tail.prev
  this.tail.prev.next=newNode
  this.tail.prev=newNode
  if(this.exists(key)){
    this.map[key].push(newNode)
  }
  else{
    this.map[key]=[newNode]
  }
}
DLL.prototype.exists=function(key){
  return key in this.map
}
DLL.prototype.remove=function(key){
  if(this.exists(key)){
    let node= last(this.map[key])
    node.prev.next=node.next
    node.next.prev=node.prev
    this.map[key].pop()
    if(!this.map[key].length){
      delete this.map[key]
    }
    
  }
}

// DLL.prototype.update=function(key, value){
//   if(this.exists(key)){
//     this.map[key].value=value
//   }

// }


let dll =new DLL()

dll.setHead('foo', 1)
dll.setHead('bar', 2)
console.log(dll)