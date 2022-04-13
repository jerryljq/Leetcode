//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:
[
  [3],
  [20,9],
  [15,7]
]
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q103_H
#define LEETCODE_Q103_H

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
    vector<vector<int>> zigzagLevelOrder(TreeNode* root) {
            vector<vector<int>> result;
            if(root == NULL) return result;

            std::deque<TreeNode*> nodeQueue;
            std::deque<TreeNode*> nodeQueueTemp;
            std::deque<int> tempNum;
            nodeQueue.push_back(root);
            int layer = 0;
            while(nodeQueue.size() > 0) {
                TreeNode* temp = nodeQueue.front();
                nodeQueue.pop_front();
                
                if(layer % 2 == 0) tempNum.push_back(temp->val);
                else tempNum.push_front(temp->val);
                
                if(temp->left) nodeQueueTemp.push_back(temp->left);
                if(temp->right) nodeQueueTemp.push_back(temp->right);
                if(nodeQueue.size() == 0) {
                    while(nodeQueueTemp.size() > 0) {
                        nodeQueue.push_back(nodeQueueTemp.front());
                        nodeQueueTemp.pop_front(); 
                    }
                
                vector<int> tempVec;
                while(tempNum.size() > 0) {
                    tempVec.push_back(tempNum.front());
                    tempNum.pop_front();
                }
                
                result.push_back(tempVec);
                tempNum.clear();
                layer += 1;
            }
        }
        return result;
    }
};
#endif