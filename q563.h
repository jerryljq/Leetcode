//
// Created by Jerry Li on 2017/4/22.
//

#ifndef LEETCODE_Q563_H
#define LEETCODE_Q563_H

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
    int findTilt(TreeNode* root) {
        if(root == NULL) {
            return 0;
        } else {
            if(root->left == NULL && root->right == NULL) {
                return 0;
            } else {
                int diff = abs(findAddition(root->left) - findAddition(root->right));
                return diff + findTilt(root->left) + findTilt(root->right);
            }
        }
    }

    // Find the addition of all sub nodes
    int findAddition(TreeNode* root) {
        if(root == NULL) {
            return 0;
        } else {
            if(root->left == NULL && root->right == NULL) {
                return root->val;
            } else {
                return root->val + findAddition(root->left) + findAddition(root->right);
            }
        }
    }
};

#endif //LEETCODE_Q563_H