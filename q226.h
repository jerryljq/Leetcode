//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Invert a binary tree.

     4
   /   \
  2     7
 / \   / \
1   3 6   9

to

     4
   /   \
  7     2
 / \   / \
9   6 3   1
 ***************************** Solution **************************
 Seems trivial
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q226_H
#define LEETCODE_Q226_H

class Solution {
public:
    TreeNode* invertTree(TreeNode* root) {
        if(root != NULL) {
            TreeNode *temp = root->left;
            root->left = root->right;
            root->right = temp;
            root->left = invertTree(root->left);
            root->right = invertTree(root->right);
            return root;
        } else {
            return NULL;
        }
    }
};

#endif //LEETCODE_Q226_H
