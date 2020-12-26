/*
Design a hit counter which counts the number of hits received in the past 5 minutes.

Each function accepts a timestamp parameter (in seconds granularity) and you may assume that calls are being made to the system in chronological order (ie, the timestamp is monotonically increasing). You may assume that the earliest timestamp starts at 1.

It is possible that several hits arrive roughly at the same time.

*/

// Time: hit=> 0(1), GetHits => o(N) worst case, N is num of timestamps
//  space : o(N)
using system;
using System.Collections.Generic;
namespace HitCounting{
    public class HitCounter {
        private Queue<int> hits; 

        /** Initialize your data structure here. */
        public HitCounter() {
            this.hits = new Queue<int>();
            
        }
        
        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp) {
            this.hits.Enqueue(timestamp);
            
        }
        
        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp) {
            while(this.hits.Count!=0){
                int diff = timestamp-this.hits.Peek();
                if(diff>=300) this.hits.Dequeue();
                else break;
            }
            return this.hits.Count;
            
        }
   }  
   // Time: hit=> o(1) , GetHits => o(1) best case(if everything is repeated in one timestamp), o(N )worst
   // space: hit=> o(1), GetHits => o(1) best case, o(N )worst
   public class HitCounter2 {
    private LinkedList<(int,int)> hits; 
    private int total;

    /** Initialize your data structure here. */
    public HitCounter() {
        this.hits = new LinkedList<(int, int)>();
        this.total=0;
        
    }
    
    /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
    public void Hit(int timestamp) {
        if(this.hits.Count ==0 || this.hits.Last.Value.Item1 !=timestamp){
            // Insert the new timestamp with count = 1
            this.hits.AddLast((timestamp,1));   
        }else{
            // Update the count of latest timestamp by incrementing the count by 1

            // Obtain the current count of the latest timestamp 
            int preCount = this.hits.Last.Value.Item2;
            this.hits.RemoveLast();
            this.hits.AddLast((timestamp, preCount+1));
            
        }
        // Increment total
        this.total++;
        
    }
    
    /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
    public int GetHits(int timestamp) {
        while(this.hits.Count!=0){
            int diff = timestamp-this.hits.First.Value.Item1;
            if(diff>=300) {
                // Decrement total by the count of the oldest timestamp
                this.total -= this.hits.First.Value.Item2;
                this.hits.RemoveFirst();
                
            }
            else break;
        }
        return this.total;
        
    }
}


}

