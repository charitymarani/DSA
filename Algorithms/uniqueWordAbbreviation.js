/**
 * 
 * The abbreviation of a word is a concatenation of its first letter, the number of characters between the first and last letter, and its last letter. If a word has only two characters, then it is an abbreviation of itself.

For example:

dog --> d1g because there is one letter between the first letter 'd' and the last letter 'g'.
internationalization --> i18n because there are 18 letters between the first letter 'i' and the last letter 'n'.
it --> it because any word with only two characters is an abbreviation of itself.
Implement the ValidWordAbbr class:

ValidWordAbbr(String[] dictionary) Initializes the object with a dictionary of words.
boolean isUnique(string word) Returns true if either of the following conditions are met (otherwise returns false):
There is no word in dictionary whose abbreviation is equal to word's abbreviation.
For any word in dictionary whose abbreviation is equal to word's abbreviation, that word and word are the same.
 */
// Brute force
// o(n) time , o(1)space
const ValidWordAbbr = function(dictionary) {
    this.dict=dictionary   
};

/** 
 * @param {string} word
 * @return {boolean}
 */
ValidWordAbbr.prototype.isUnique = function(word) {
    let n =word.length
    for(let s of this.dict){
        if(word===s){
            continue
        }
        m=s.length
        if(m===n && s.charAt(0)===word.charAt(0) && s.charAt(m-1)===word.charAt(m-1)){
            return false
        }
    }
    return true
    
};
// Hahtable and set approach
//  Time: o(n) for preprocessing and o(1) isUnique()
// Space: o(n)
const ValidWordAbbr2 = function(dictionary) {
    this.abbrDict={}
    this.dict=new Set(dictionary)
    
    for(let s of this.dict){
        let abbr =this.toAbbr(s)
        this.abbrDict[abbr]=!this.abbrDict[abbr]
        
    }
    
};

/** 
 * @param {string} word
 * @return {boolean}
 */
ValidWordAbbr2.prototype.isUnique = function(word) {
    let abbr= this.toAbbr(word)
    let hasAbbr =this.abbrDict[abbr]
    return hasAbbr===undefined||(hasAbbr && this.dict.has(word))
    
};
ValidWordAbbr2.prototype.toAbbr=function(word){
    let n = word.length
    if(n<=2){
        return word
    }
    let count=n-2
    return word.charAt(0)+ count.toString()+word.charAt(n-1)
}