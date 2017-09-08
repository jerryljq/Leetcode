//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given a binary tree, find its maximum depth.
 The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_104_H
#define LEETCODE_104_H

#include "commons.h"

class Solution {
public:
    int maxDepth(TreeNode* root) {
        int maxLeft = 1;
        int maxRight = 1;
        if(root == NULL) {
            return 0;
        } else {
            if(root->left != NULL) maxLeft += maxDepth(root->left);
            if(root->right != NULL) maxRight += maxDepth(root->right);
            if(maxLeft < maxRight) return maxRight;
            else return maxLeft;
        }
    }
};

#endif //LEETCODE_104_H
