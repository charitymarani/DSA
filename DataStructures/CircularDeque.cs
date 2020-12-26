/*
Design your implementation of the circular double-ended queue (deque).

Your implementation should support following operations:

MyCircularDeque(k): Constructor, set the size of the deque to be k.
insertFront(): Adds an item at the front of Deque. Return true if the operation is successful.
insertLast(): Adds an item at the rear of Deque. Return true if the operation is successful.
deleteFront(): Deletes an item from the front of Deque. Return true if the operation is successful.
deleteLast(): Deletes an item from the rear of Deque. Return true if the operation is successful.
getFront(): Gets the front item from the Deque. If the deque is empty, return -1.
getRear(): Gets the last item from Deque. If the deque is empty, return -1.
isEmpty(): Checks whether Deque is empty or not. 
isFull(): Checks whether Deque is full or not.

*/

using System;
public class MyCircularDeque {
    private int[] deque;
    private int capacity;
    private int size=0;
    private int head=0, tail=0;

    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        deque = new int[k];
        capacity=k;
        
    }
    
    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value) {
        if(!IsFull()){
            if(!IsEmpty()){
                head= (head-1)%capacity;  
            }
            if(head<0){
                head=capacity-1;
            }
            deque[head]=value;
            size++;
            return true;
        }
        return false;
        
    }
    
    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value) {
        if(!IsFull()){
            if(!IsEmpty()){
                tail= (tail+1)%capacity;  
            }
            deque[tail]=value;
            size++;
            return true;
        }
        return false;
        
    }
    
    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront() {
        if(!IsEmpty()){
            size--;
            if(!IsEmpty()){
                head=(head+1)%capacity;
            }
            return true;
            
        }
        return false;
        
    }
    
    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast() {
        if(!IsEmpty()){
            size--;
            if(!IsEmpty()){
                tail=(tail-1)%capacity;
            }
            if(tail<0){
                tail=capacity-1;
            }
            return true;
            
        }
        return false;
        
    }
    
    /** Get the front item from the deque. */
    public int GetFront() {
        return IsEmpty() ? -1 : deque[head];
    }
    
    /** Get the last item from the deque. */
    public int GetRear() {
         return IsEmpty() ? -1 : deque[tail];
        
    }
    
    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty() {
        return size==0;
        
    }
    
    /** Checks whether the circular deque is full or not. */
    public bool IsFull() {
        return size==capacity;
        
    }
}
