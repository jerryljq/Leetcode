//
// Created by Jerry Li on 2017/10/30.
//
/********************* Problem Specification *********************
Implement a trie with insert, search, and startsWith methods.

Note:
You may assume that all inputs are consist of lowercase letters a-z.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q208_H
#define LEETCODE_Q208_H

#include "commons.h"
class TrieNode {
public:
    TrieNode() {
        nodeArray = new vector<TrieNode*>(26, NULL);
        isWord = false;    
    }
    
    void setNode(char c, TrieNode *node) {
        nodeArray->at(c-'a') = node;
    }
    
    void setEnd() {
        isWord = true;
    }
    
    bool getEnd() {
        return isWord;
    }
    
    TrieNode* getNode(char c) {
        return nodeArray->at(c-'a');
    }
    
private:
    std::vector<TrieNode*>* nodeArray;
    bool isWord;
    
};

class Trie {
public:
    
    TrieNode *head;
    
    /** Initialize your data structure here. */
    Trie() {
        head = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    void insert(string word) {
        TrieNode *current = head;
        for(int i = 0; i < word.size(); i++) {
            TrieNode *getNodeRes = current->getNode(word[i]);
            if(getNodeRes) {
                current = getNodeRes;
            } else {
                TrieNode *newNode = new TrieNode();
                current->setNode(word[i], newNode);
                current = newNode;
            }
        }
        current->setEnd(); 
    }
    
    /** Returns if the word is in the trie. */
    bool search(string word) {
        TrieNode *current = head;
        for(int i = 0; i < word.size(); i++) {
            TrieNode *foundNode = current->getNode(word[i]);
            if(foundNode == NULL) return false;
            current = foundNode;
        }
        if(current->getEnd()) return true;
        else return false;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    bool startsWith(string prefix) {
        TrieNode *current = head;
        for(int i = 0; i < prefix.size(); i++) {
            TrieNode *foundNode = current->getNode(prefix[i]);
            if(foundNode == NULL) return false;
            current = foundNode;
        }
        return !(current == NULL);
    }
};

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.insert(word);
 * bool param_2 = obj.search(word);
 * bool param_3 = obj.startsWith(prefix);
 */
#endif