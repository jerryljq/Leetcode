//
// Created by Jerry Li on 2017/10/31.
//
/********************* Problem Specification *********************
 Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree [1,null,2,3],
   1
    \
     2
    /
   3
return [1,3,2].


 ***************************** Solution **************************
 See the code and descriptions below.
 Iterative solution used stack to maintain the order of the nodes.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q94_H
#define LEETCODE_Q94_H

#include "commons.h"
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class RecursiveSolution {
public:    
    vector<int> inorderTraversal(TreeNode* root) {
       vector<int> result;
       recursiveTraversal(root, result);
       return result;
    }
    
    void recursiveTraversal(TreeNode *root, vector<int> &result) {
        if(root == NULL) return;
        else {
            recursiveTraversal(root->left, result);
            result.push_back(root->val);
            recursiveTraversal(root->right, result);
        }
    }
};
class IterativeSolution {
public:    
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> result;
        if(root == NULL) return result;
        vector<TreeNode*> nodeStack;
        TreeNode *current = root;
        while(current != NULL) {
            nodeStack.push_back(current);
            current = current->left;
            if(current == NULL) {
                TreeNode *temp = nodeStack.back();
                result.push_back(temp->val);
                nodeStack.pop_back();
                current = temp->right;
                while(current == NULL && nodeStack.size() > 0) {
                    TreeNode *temp = nodeStack.back();
                    result.push_back(temp->val);
                    nodeStack.pop_back();
                    current = temp->right;
                }
            }
        }
        
        return result;
    }

};
#endif