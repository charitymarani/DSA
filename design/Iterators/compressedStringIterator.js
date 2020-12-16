// "L1e2t1C1o1d1e1"
const StringIterator = function(compressedString) {
    this.res=compressedString
    this.ptr=this.num=0
    this.ch=''
    
};

/**
 * @return {character}
 */
StringIterator.prototype.next = function() {
    if (!this.hasNext()){
        return ' '
    }
    if(this.num===0){
        this.ch=this.res.charAt(this.ptr++);
        let c = this.res.charAt(this.ptr);
        
        while(this.ptr < this.res.length && Number.isInteger(+c)){
            // "0".charCodeAt(0)=>48
            this.num= this.num*10 + 
            this.res.charCodeAt(this.ptr++)-48;
            c = this.res.charAt(this.ptr);
        }
    }
    this.num--;
    return this.ch;
    
};

/**
 * @return {boolean}
 */
StringIterator.prototype.hasNext = function() {
    return this.ptr!=this.res.length || this.num!=0
    
};

