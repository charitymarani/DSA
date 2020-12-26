/*
You are asked to design a file system that allows you to create new paths and associate them with different values.

The format of a path is one or more concatenated strings of the form: / followed by one or more lowercase English letters. For example, "/leetcode" and "/leetcode/problems" are valid paths while an empty string "" and "/" are not.

Implement the FileSystem class:

bool createPath(string path, int value) Creates a new path and associates a value to it if possible and returns true. Returns false if the path already exists or its parent path doesn't exist.
int get(string path) Returns the value associated with path or returns -1 if the path doesn't exist.
 

*/
// Time o(m)=> m is number of components in a path
// Space :o(T) worst case where the trie has T nodes which are all independent

using System;
using System.Collections.Generic;

public class FileSystem {
    public class TrieNode{
        public string _name;
        public int val =-1;
        public Dictionary<string,TrieNode> children;
        public TrieNode(string name){
            children = new Dictionary<string, TrieNode>();
            _name =name;
        }
    }
    
    TrieNode root;

    public FileSystem() {
        root = new TrieNode("");
        
    }
    
    public bool CreatePath(string path, int value) {
        // Obtain all the components
        string[] components = path.Split("/");
        // Start "curr" from the root node.
        TrieNode curr = root;
        // Iterate over all the components.
        for(int i =1; i<components.Length;i++){
            string currComponent = components[i];
            if(!curr.children.ContainsKey(currComponent)){
                // If it doesn't and it is the last node, add it to the Trie.
                if (i == components.Length - 1) {
                    curr.children.Add(currComponent, new TrieNode(currComponent));
                } else {
                    return false;
                } 
            }
            curr=curr.children[currComponent];
        }
        // Value not equal to -1 means the path already exists in the trie. 
        if (curr.val != -1) {
            return false;
        }
        curr.val = value;
        return true;
        
        
    }
    
    public int Get(string path) {
        // Obtain all the components
        string[] components = path.Split("/");
        // Start "curr" from the root node.
        TrieNode curr = root;
        // Iterate over all the components.
        for(int i =1; i<components.Length;i++){
            string currComponent = components[i];
            // For each component, we check if it exists in the current node's dictionary.
            if (!curr.children.ContainsKey(currComponent)) {
                return -1;   
            }
            curr=curr.children[currComponent];
            
        }
        return curr.val;
        
        
    }
}
