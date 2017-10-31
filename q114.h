//
// Created by Jerry Li on 2017/10/30.
//
/********************* Problem Specification *********************
iven a binary tree, flatten it to a linked list in-place.

For example,
Given

         1
        / \
       2   5
      / \   \
     3   4   6
The flattened tree should look like:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6
click to show hints.

Hints:
If you notice carefully in the flattened tree, each node's right child points to the next node of a pre-order traversal.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q114_H
#define LEETCODE_Q114_H

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
class Solution {
public:
    void swapChild(TreeNode* root) {
        TreeNode *temp = root->left;
        root->left = root->right;
        root->right = temp;
    }
    
    void flatten(TreeNode* root) {
        if(root == NULL) return;
        swapChild(root);
        flatten(root->right);
        flatten(root->left);
        if(root->left) {
            TreeNode *temp = root;
            while(temp->right) {
                temp = temp->right;
            }
            temp->right = root->left;
            root->left = NULL;
        }
    }
};
#endif