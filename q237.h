//
// Created by Jerry Li on 2017/10/13.
//
/********************* Problem Specification *********************
  Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.

Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function. 
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q237_H
#define LEETCODE_Q237_H

#include "commons.h"
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
    void deleteNode(ListNode* node) {
        ListNode *curr = node;
        while(curr->next != NULL) {
            curr->val = curr->next->val;
            if(curr->next->next == NULL) {
                curr->next = NULL;
            } else 
                curr = curr->next;
        }
        
    }
};
#endif;
