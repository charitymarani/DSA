/*
Question:

Design a class which receives a list of words in the constructor, and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list. Your method will be called repeatedly many times with different parameters. 

Example:
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Input: word1 = “coding”, word2 = “practice”
Output: 3
Input: word1 = "makes", word2 = "coding"
Output: 1
Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.

*/
// Time complexity=>O(N), space O(n)
// Note constructor takes O(N)time and space and function takes max(loc1.length, loc2.length)~O(n)
let WordDistance = function(words){
    this.locations ={}
    //Prepare a mapping from a word to all it's locations (indices).
    for(let i=0;i<words.length;i++){
        if(words[i] in this.locations){
            this.locations[words[i]].push(i)
        }
        else{
            this.locations[words[i]]=[i]
        }
        
    }
        
};

/** 
 * @param {string} word1 
 * @param {string} word2
 * @return {number}
 */
WordDistance.prototype.shortest = function(word1, word2){
    let loc1= this.locations[word1]
    let loc2= this.locations[word2]
    let i1=0
    let i2=0
    let minDiff= +Infinity
    while(i1<loc1.length && i2<loc2.length){
        minDiff = Math.min(minDiff ,Math.abs(loc1[i1]-loc2[i2]))
        if(loc1[i1]<loc2[i2]){
            i1++
        }
        else{
            i2++
        }
    }
    return minDiff
    
};
let obj = new WordDistance(["practice", "makes", "perfect", "coding", "makes"])
console.log(obj.shortest("coding", "practice"))