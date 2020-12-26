/*
Design a Phone Directory which supports the following operations:

 

get: Provide a number which is not assigned to anyone.
check: Check if a number is available or not.
release: Recycle or release a number.
*/
using system;
using System.Collections.Generic;

// Time 0(1)
// Space 0(1) best case, o(maxnumber) worst case
public class PhoneDirectory {
    private LinkedList<(int,int)> _pool;
    private HashSet<int> _assigned;
    /** Initialize your data structure here
        @param maxNumbers - The maximum numbers that can be stored in the phone directory. */
    public PhoneDirectory(int maxNumbers) {
        _pool = new LinkedList<(int,int)>();
        _pool.AddFirst((0, maxNumbers-1));
        _assigned = new HashSet<int>();
        
    }
    
    /** Provide a number which is not assigned to anyone.
        @return - Return an available number. Return -1 if none is available. */
    public int Get() {
        if(_pool.Count==0){
            return -1;
        }
        int fro = _pool.First.Value.Item1;
        int to = _pool.First.Value.Item2;
        _pool.RemoveFirst();
        if(fro + 1 <= to){ // move left interval boundary to the right, if it is still possible
            _pool.AddLast((fro + 1, to)); // put interval back to the queue
        }
        _assigned.Add(fro);

        return fro;
        
    }
    
    /** Check if a number is available or not. */
    public bool Check(int number) {
        return !_assigned.Contains(number);
        
    }
    
    /** Recycle or release a number. */
    public void Release(int number) {
        if(Check(number)){
            return;
        }
        _assigned.Remove(number);
        _pool.AddLast((number, number));
        
        
    }
}
