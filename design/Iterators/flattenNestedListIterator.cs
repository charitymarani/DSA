/*
Given a nested list of integers, implement an iterator to flatten it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.
**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */

// Time: o(1) if value is int else (N+L)/N =>L/N??
// Space: o(D) max depth of recursion(nesting of lists)
using System;
using System.Collections.Generic;


public class NestedIterator {
    IEnumerator<NestedInteger>  generator;
    Nullable<int> peeked=null;
    public NestedIterator(IList<NestedInteger> nestedList) {
        generator= int_generator(nestedList).GetEnumerator();
        
    }
    public IEnumerable<NestedInteger> int_generator(IList<NestedInteger> nestedList ){
        foreach(var nested in nestedList ){
            if(nested.IsInteger()){
                yield return nested;
            }
            else{
                foreach(var value in int_generator(nested.GetList()) ){
                    yield return value;
                }
            }
        }
    }
    public bool HasNext() {
        if(peeked != null){
            return true;
        }
        
        if(generator.MoveNext()){
            peeked = generator.Current.GetInteger();
            return true;
            
        }
            
        else{
            return false;
        }
        
    }

    public int Next() {
        var nextInt = (int)peeked;
        peeked =null;
        return nextInt;
       
        
    }
}

