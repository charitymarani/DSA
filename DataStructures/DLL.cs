/*
Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

Implement the MyLinkedList class:

MyLinkedList() Initializes the MyLinkedList object.
int get(int index) Get the value of the indexth node in the linked list. If the index is invalid, return -1.
void addAtHead(int val) Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
void addAtTail(int val) Append a node of value val as the last element of the linked list.
void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.

*/
using System;
public class MyLinkedList {
    public class Node{
        public int value;
        public Node next;
        public Node prev;
        
        public Node(int val){
            value=val;
            prev=null;
            next=null;
        }
    }
    private int size=0;
    private Node head, tail;

    /** Initialize your data structure here. */
    public MyLinkedList() {
        head = new Node(-1);
        tail = new Node(-1);
        head.next=tail;
        tail.prev=head;
    }
    
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get(int index) {
        if(index<0 || index>=size){
            return -1;
        }
         // choose the fastest way: to move from the head
         // or to move from the tail
        Node curr;
        if(index+1< size - index){
            curr=head;
            for(int i=0; i<index+1; ++i){
                curr=curr.next;  
            }
        }
        else{
            curr=tail;
            for(int i=0;i< size - index; ++i){
                curr=curr.prev;  
            }
        }
        return curr.value;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead(int val) {
        Node newNode = new Node(val);
        newNode.next=head.next;
        head.next.prev=newNode;
        newNode.prev=head;
        head.next=newNode;
        size++;
        
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail(int val) {
        Node newNode = new Node(val);
        newNode.next=tail;
        newNode.prev=tail.prev;
        tail.prev.next=newNode;
        tail.prev=newNode;
        size++;   
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex(int index, int val) {
        
        if(index>size) return;
        
        if(index<0) index=0;
        
        Node pred, succ;
        if(index < (size - index)){
            pred=head;
            for(int i = 0; i < index; ++i){
                pred = pred.next;  
            } 
            succ = pred.next;  
        }
        else {
            
           succ = tail;
           for (int i = 0; i < size - index; ++i){
                succ = succ.prev;
           }
           pred = succ.prev;
        }
        // Insertion
        ++size;
        Node newNode = new Node(val);
        newNode.prev=pred;
        newNode.next=succ;
        pred.next=newNode;
        succ.prev=newNode;
       
    
        
        
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex(int index) {
        // if the index is invalid, do nothing
        if (index < 0 || index >= size) return;

        // find predecessor and successor of the node to be deleted
        Node pred, succ;
        if (index < size - index) {
          pred = head;
          for(int i = 0; i < index; ++i) pred = pred.next;
          succ = pred.next.next;
        }
        else {
          succ = tail;
          for (int i = 0; i < size - index - 1; ++i) succ = succ.prev;
          pred = succ.prev.prev;
        }

        // delete pred.next 
        size--;
        pred.next = succ;
        succ.prev = pred;
        
    }
}

