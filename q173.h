//
// Created by Jerry Li on 2017/10/30.
//
/********************* Problem Specification *********************
Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q173_H
#define LEETCODE_Q173_H

#include "commons.h"
/**
 * Definition for binary tree
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class BSTIterator {
public:
    
    std::vector<TreeNode*> nodeStack;
    
    BSTIterator(TreeNode *root) {
        TreeNode *current = NULL;
        if(root != NULL) {
            nodeStack.push_back(root);
            current = root->left;
            while(current != NULL) {
                nodeStack.push_back(current);
                current = current->left;
            }
        }
    }

    /** @return whether we have a next smallest number */
    bool hasNext() {
        if(nodeStack.size() != 0) return true;
        else return false;
    }

    /** @return the next smallest number */
    int next() {
        TreeNode *current = nodeStack.back();
        int result = current->val;
        TreeNode *temp = current->right;
        nodeStack.pop_back();
        while(temp != NULL) {
            nodeStack.push_back(temp);
            temp = temp->left;
        }
        return result;
    }
};

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = BSTIterator(root);
 * while (i.hasNext()) cout << i.next();
 */
#endif