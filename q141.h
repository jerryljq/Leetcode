//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given a linked list, determine if it has a cycle in it. 
 Can you solve it without using extra space? 
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q141_H
#define LEETCODE_Q141_H

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
    bool hasCycle(ListNode *head) {
        ListNode *temp1 = head;
        ListNode *temp2 = head;
        while(temp1 != NULL && temp2 != NULL) {
            temp1 = temp1->next;
            if(temp2->next == NULL) return false;
            temp2 = temp2->next->next;
            if(temp1 == temp2) return true;
        }
        return false;
    }
};
#endif
