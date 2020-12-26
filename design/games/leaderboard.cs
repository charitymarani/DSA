/*
Design a Leaderboard class, which has 3 functions:

addScore(playerId, score): Update the leaderboard by adding score to the given player's score. If there is no player with such id in the leaderboard, add him to the leaderboard with the given score.
top(K): Return the score sum of the top K players.
reset(playerId): Reset the score of the player with the given id to 0 (in other words erase it from the leaderboard). It is guaranteed that the player was added to the leaderboard before calling this function.
Initially, the leaderboard is empty.

*/
/*
Complexity Analysis

Time Complexity:

O(logN) for addScore. This is because each addition to the BST takes a logarithmic time for search. The addition itself once the location of the parent is known, takes constant time.
O(logN) for reset since we need to search for the score in the BST and then update/remove it. Note that this complexity is in the case when every player always maintains a unique score.
It takes O(K) for our top function since we simply iterate over the keys of the TreeMap and stop once we're done considering K scores. Note that if the data structure doesn't provide a natural iterator, then we can simply get a list of all the key-value pairs and they will naturally be sorted due to the nature of this data structure. In that case, the complexity would be 
O(N) since we would be forming a new list.

Space Complexity:

O(N) used by the scores dictionary. Also, if you obtain all the key-value pairs in a new list in the top function, then an additional 
O(N) would be used. 

*/
using System;
using System.Collections.Generic;

public class Leaderboard {
    Dictionary<int, int> scores;
    SortedDictionary<int,int> sortedscores;

    public Leaderboard() {
        scores = new Dictionary<int,int>();
        sortedscores = new SortedDictionary<int,int>();
        
    }
    
    public void AddScore(int playerId, int score) {
        if(!scores.ContainsKey(playerId)){
            scores[playerId] = score;
            if(sortedscores.ContainsKey(-score)){
                sortedscores[-score]++;
            }
            else{
                sortedscores[-score]=1;
            }
            
        }
        else{
            int preScore = scores[playerId] ;
            int val = sortedscores[-preScore];
            if(val==1){
                sortedscores.Remove(-preScore);
            }
            else{
               sortedscores[-preScore]=val-1;
                
            }
            int newScore = val+score;
            scores[playerId]=newScore;
            if(sortedscores.ContainsKey(-newScore)){
                sortedscores[-newScore]++;
            }
            else{
                sortedscores[-newScore]=1;
            }
            
        }
        
    }
    
    public int Top(int K) {
        int count=0, total=0;
        foreach(var item in sortedscores){
            int times = sortedscores[item.Key];
            for(int i=0; i<times ;i++){
                total+= -item.Key;
                count++;
                if(count==K){
                    break;
                }
            }
            if(count==K){
                break;
            }
        }
        return total;
        
    }
    
    public void Reset(int playerId) {
        int preScore = scores[playerId];
        if(sortedscores[-preScore]==1){
            sortedscores.Remove(-preScore);
        }
        else{
            sortedscores[-preScore]-=1;
        }
        scores.Remove(playerId);
        
    }
}

