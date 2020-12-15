
/*
Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.

word1 and word2 may be the same and they represent two individual words in the list.

Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Input: word1 = “makes”, word2 = “coding”
Output: 1
Input: word1 = "makes", word2 = "makes"
Output: 3
Note:
You may assume word1 and word2 are both in the list.
*/
// time:O(N)
// space: O(1)
let shortestWordDistance = (words, word1, word2) =>{
    let same= word1===word2;
    let minDiff= words.length
    let i1 = -1
    let i2 = -1
    for(let i=0; i<words.length;i++){
        if(words[i]===word1){
            i1 = i
            if (i2>=0){
                minDiff = Math.min(i1-i2,minDiff)
            }   
            if(same){
                i2 = i1
            }
        }
                
        else if(words[i]===word2 && !same){
             i2 = i
            if(i1>=0){
                minDiff = Math.min(i2-i1,minDiff)
                
            }
                    
            
        }
               
        
    }
    return minDiff
    
    
};