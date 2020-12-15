/*
Question:

Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.

Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Input: word1 = “coding”, word2 = “practice”
Output: 3
Input: word1 = "makes", word2 = "coding"
Output: 1
Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.

*/

// Bruteforce => O(n)^2 Time, O(1) space
let shortestDistance = (words, word1, word2) =>{
    let minDistance=words.length
    for(let i=0;i<words.length;i++){
        if(words[i]===word1){
            for(let j=0;j<words.length;j++){
                if(words[j]===word2){
                    minDistance=Math.min(minDistance, Math.abs(i-j))
                }
            }
        }
    }
    return minDistance;
    
};

// One pass => O(NM)Time(N is list length, M is total length of words1 and words2)
//          => O(1)Space
let shortestDistance = (words, word1, word2)=> {
    let minDistance=words.length
    let i1=-1
    let i2=-1
    for(let i=0;i<words.length;i++){
        if(words[i]===word1){
            i1=i
        }
        else if(words[i]===word2){
            i2=i
        }
        if(i1!==-1 && i2!==-1){
            minDistance=Math.min(minDistance, Math.abs(i1-i2))
            
        }
    }
    return minDistance;
    
};