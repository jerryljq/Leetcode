//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q102_H
#define LEETCODE_Q102_H

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
    vector<vector<int>> levelOrder(TreeNode* root) {
        vector<vector<int>> result;
        if(root == NULL) return result;
        
        std::queue<TreeNode*> nodeQueue;
        std::queue<TreeNode*> nodeQueueTemp;
        vector<int> tempNum;
        nodeQueue.push(root);
        while(nodeQueue.size() > 0) {
            TreeNode* temp = nodeQueue.front();
            nodeQueue.pop();
            tempNum.push_back(temp->val);
            if(temp->left) nodeQueueTemp.push(temp->left);
            if(temp->right) nodeQueueTemp.push(temp->right);
            if(nodeQueue.size() == 0) {
                while(nodeQueueTemp.size() > 0) {
                    nodeQueue.push(nodeQueueTemp.front());
                    nodeQueueTemp.pop();
                }
                result.push_back(tempNum);
                tempNum.clear();
            }
        }
        return result;
    }
};
#endif