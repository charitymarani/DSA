/*
Design your implementation of the circular queue. The circular queue is a linear data structure in which the operations are performed based on FIFO (First In First Out) principle and the last position is connected back to the first position to make a circle. It is also called "Ring Buffer".

One of the benefits of the circular queue is that we can make use of the spaces in front of the queue. In a normal queue, once the queue becomes full, we cannot insert the next element even if there is a space in front of the queue. But using the circular queue, we can use the space to store new values.

Implementation the MyCircularQueue class:

MyCircularQueue(k) Initializes the object with the size of the queue to be k.
int Front() Gets the front item from the queue. If the queue is empty, return -1.
int Rear() Gets the last item from the queue. If the queue is empty, return -1.
boolean enQueue(int value) Inserts an element into the circular queue. Return true if the operation is successful.
boolean deQueue() Deletes an element from the circular queue. Return true if the operation is successful.
boolean isEmpty() Checks whether the circular queue is empty or not.
boolean isFull() Checks whether the circular queue is full or not.
*/
// Time 0(1)
// Space o(n)
using System;

public class MyCircularQueue {
    
    
    private int[] _queue;
    private int _count=0;
    private int _capacity;
    private int _head=0;
    

    public MyCircularQueue(int k) {
        _capacity = k;
        _queue=new int[k];
        
        
    }
    
    public bool EnQueue(int value) {
        if(_count==_capacity){
            return false;
        }
        _queue[(_head+_count)%_capacity]=value;
        _count++;
        return true;
        
    }
    
    public bool DeQueue() {
        if(_count==0){
            return false;
        }
        _head=(_head+1)%_capacity;
        _count--;
        return true;
        
    }
    
    public int Front() {
        if(_count==0){
            return -1;
        }
        return _queue[_head];
        
    }
    
    public int Rear() {
        if (_count == 0) return -1;
        int tailIndex = (_head + _count - 1) % _capacity;
        return _queue[tailIndex];
    }
    
    public bool IsEmpty() {
        return _count==0;
        
    }
    
    public bool IsFull() {
        return _count==_capacity;
        
    }
}