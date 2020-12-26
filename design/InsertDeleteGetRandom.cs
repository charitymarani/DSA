/*Implement the RandomizedSet class:

bool insert(int val) Inserts an item val into the set if not present. Returns true if the item was not present, false otherwise.
bool remove(int val) Removes an item val from the set if present. Returns true if the item was present, false otherwise.
int getRandom() Returns a random element from the current set of elements (it's guaranteed that at least one element exists when this method is called). Each element must have the same probability of being returned.
Follow up: Could you implement the functions of the class with each function works in average O(1) time?
*/
using System;
using System.Collections.Generic;
// Time o(1)
// Space o(n)
public class RandomizedSet {
    private Dictionary<int ,int> map;
    private List<int> ls;
    // random number generator    
    Random rand = new Random();
    /** Initialize your data structure here. */
    public RandomizedSet() {
        ls = new List<int>();
        map = new Dictionary<int ,int>();
        
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) {
        if(map.ContainsKey(val)){
            return false;
        }
        map[val]=ls.Count;
        ls.Add(val);
        return true;
        
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) {
        if(!map.ContainsKey(val)){
            return false;
        }
        int pos = map[val];
        map.Remove(val);
        if(pos!=ls.Count-1){
            int lastItem = ls[ls.Count-1];
            ls[pos] = lastItem;
            map[lastItem] = pos;  
        }
        ls.RemoveAt(ls.Count-1);
       
       
        return true;
        
    }
    
    /** Get a random element from the set. */
    public int GetRandom() => ls[rand.Next(ls.Count)];
        
    
}