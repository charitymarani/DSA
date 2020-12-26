/*
Design a stack which supports the following operations.

Implement the CustomStack class:

CustomStack(int maxSize) Initializes the object with maxSize which is the maximum number of elements in the stack or do nothing if the stack reached the maxSize.
void push(int x) Adds x to the top of the stack if the stack hasn't reached the maxSize.
int pop() Pops and returns the top of stack or -1 if the stack is empty.
void inc(int k, int val) Increments the bottom k elements of the stack by val. If there are less than k elements in the stack, just increment all the elements in the stack.
 

*/
using System;
using System.Collections.Generic;
// Time 0(1)
// Space o(maxsize)
public class CustomStack {
    int index = -1;
    List<int> stack;
    int[] increment;
    public CustomStack(int maxSize) {
        stack = new List<int>();
        increment = new int[maxSize];
        
        
    }
    
    public void Push(int x) {
        if(stack.Count==increment.Length){
            return;
        }
        stack.Add(x);
        index++;
        
    }
    
    public int Pop() {
        if(index==-1){
            return -1;
        }
        int last = stack[index];
        int incre = increment[index];
        if (index>0){
            increment[index-1]+=increment[index];
        }
        increment[index]=0;
        stack.RemoveAt(index);
        index--;
        return  last + incre;
        
    }
    
    public void Increment(int k, int val) {
        if(index==-1){
            return;
        }
        if(index<k){
            increment[index]+=val;
        }
        else{
            increment[k-1]+=val;
        }
        
    }
}
