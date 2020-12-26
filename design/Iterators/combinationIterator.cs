using System;
using System.Text;
using System.Collections.Generic;
namespace CombinationIterators
{
  // Time : o(C(n,k) *k) => k time to generate C(n,k) combinations
  // space: o(C(n,k) *k) = > k space to save C(n,k) combinations
  public class CombinationIteratorBackTracking {
    private LinkedList<string> queue;

    public CombinationIteratorBackTracking(string characters, int combinationLength) {
        queue=new LinkedList<string>();
        int k = combinationLength;
        int n = characters.Length;
        void Backtrack(int curr_index, StringBuilder curr_letters){
            if(curr_letters.Length ==k ){
               queue.AddLast(curr_letters.ToString());
               return; 
            }
            for(int i=curr_index;i<n;i++){
                curr_letters.Append(characters[i]);
                Backtrack(i+1, curr_letters);
                curr_letters.Remove(curr_letters.Length-1, 1); 
            }  
        }
        
        Backtrack(0, new StringBuilder());
    }
    
    public string Next() {
        string ans = queue.First.Value;
        queue.RemoveFirst();
        
        return ans;
        
        
    }
    
    public bool HasNext() {
        return queue.Count>0;
        
    }
}

// Time o(1)=> hasnext, o(k)=>next and o(n) for init which is o(26) at most hence o(1)
// space o(n) which is o(26) at most hence o(1)
public class CombinationIteratorIterative{
  public CombinationIteratorIterative(string characters, int combinationLength){
    k = combinationLength;
    n = characters.Length;
    ans = characters.Substring(0,k);
    input = characters;
    indexmap = new Dictionary<char, int>();
    
    for(int i=0; i<n ;i++){
        indexmap[input[i]]=i;
    }

  }
  public string Next() {
      string temp = ans;
      int i=n-1;
      int j= k-1;
      
      while(j>=0 && input[i]==temp[j]){
          j--;
          i--;
      }
      if(j<0){
          ans="";
      }
      else{
          int index = indexmap[ans[j]]+1;
          
          ans=ans.Substring(0,j) + input.Substring(index, k-j);
      }
      return temp;
      
      
  }
    
  public bool HasNext() {
      return ans != "";
      
  }

}

}