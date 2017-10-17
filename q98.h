//
// Created by Jerry Li on 2017/10/17.
//
/********************* Problem Specification *********************
 Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
Example 1:
    2
   / \
  1   3
Binary tree [2,1,3], return true.
Example 2:
    1
   / \
  2   3
Binary tree [1,2,3], return false.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#include "commons.h"
// Definition for a binary tree node.
struct TreeNode {
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

class Solution {
public:
    int findMax(TreeNode* root) {
        if(root->right != NULL) {
            int max = findMax(root->right);
            if (max > root->val) return max;
            else return root->val;
        } else {
            return root->val;
        }
    }

    int findMin(TreeNode* root) {
        if(root->left != NULL) {
            int min = findMin(root->left);
            if (min < root->val) return min;
            else return root->val;
        } else {
            return root->val;
        }
    }

    bool isValidBST(TreeNode* root) {
        if(root == NULL) return true;
        if(!root->left && !root->right) {
            return true;
        }
        bool left = isValidBST(root->left);
        bool right = isValidBST(root->right);
        int maxLeft;
        int minRight;
        if(root->left) {
            maxLeft = findMax(root->left);
            left = left && (maxLeft < root->val);
        }
        if(root->right) {
            minRight = findMin(root->right);
            right = right && (minRight > root->val);
        }
        
        return left && right;
    }  
};