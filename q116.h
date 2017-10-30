//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Given a binary tree

    struct TreeLinkNode {
      TreeLinkNode *left;
      TreeLinkNode *right;
      TreeLinkNode *next;
    }
Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

Note:

You may only use constant extra space.
You may assume that it is a perfect binary tree (ie, all leaves are at the same level, and every parent has two children).
For example,
Given the following perfect binary tree,
         1
       /  \
      2    3
     / \  / \
    4  5  6  7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \  / \
    4->5->6->7 -> NULL
 ***************************** Solution **************************
 See the code and descriptions below.
 * BFS is trival. But constant memory requires some modification.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q116_H
#define LEETCODE_Q116_H

#include "commons.h"
/**
 * Definition for binary tree with next pointer.
 * struct TreeLinkNode {
 *  int val;
 *  TreeLinkNode *left, *right, *next;
 *  TreeLinkNode(int x) : val(x), left(NULL), right(NULL), next(NULL) {}
 * };
 */
class Solution {
public:
    void connect(TreeLinkNode *root) {
        cout << "here" << endl;
        if(root == NULL) return;
        // root->next = NULL;
        TreeLinkNode *current = root;
        TreeLinkNode *begin = root->left;
        
        while(begin != NULL) {
            while(current != NULL) {
                // cout << current->val << endl;
                current->left->next = current->right;
                // current->right->next = NULL;
                if(current->next != NULL) {
                    current->right->next = current->next->left;
                }
                current = current->next;
            }
            current = begin;
            begin = begin->left;
        }
    }
};
#endif