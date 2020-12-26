/*
Implement the class ProductOfNumbers that supports two methods:

1. add(int num)

Adds the number num to the back of the current list of numbers.
2. getProduct(int k)

Returns the product of the last k numbers in the current list.
You can assume that always the current list has at least k numbers.
At any time, the product of any contiguous sequence of numbers will fit into a single 32-bit integer without overflowing.
*/

using System;
using System.Collections.Generic;
// Time o(1)
// space o(n)
public class ProductOfNumbers {
    List<int> nums=new List<int>();
    Nullable<int> last_zero =null;

    public ProductOfNumbers() {
        
    }
    
    public void Add(int num) {
        if(num==0 ||nums.Count==0|| (nums.Count>0 && nums[nums.Count-1]==0)){
            if(num==0){
                last_zero=nums.Count; 
            }
            
            nums.Add(num);
        }
        else{
           nums.Add(num*nums[nums.Count-1]) ;
        }
        
    }
    
    public int GetProduct(int k) {
        int index=nums.Count-1-k;
        if(last_zero!=null && last_zero> index ){
            return 0;
        }
        
        int numidx =nums.Count-1;
        if(k==nums.Count || nums[index]==0){
            return nums[numidx];
        }
        else{
            return nums[numidx]/nums[index];
        }
        
    }
}
