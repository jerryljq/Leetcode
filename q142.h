//
// Created by Jerry Li on 2017/10/26.
//
/********************* Problem Specification *********************
 Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
 Note: Do not modify the linked list.
 ***************************** Solution **************************
 Can you solve it without using extra space?
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q142_H
#define LEETCODE_Q142_H

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
    ListNode *detectCycle(ListNode *head) {
        ListNode *temp1 = head;
        ListNode *temp2 = head;
        while(temp1 != NULL && temp2 != NULL) {
            temp1 = temp1->next;
            if(temp2->next == NULL) return NULL;
            temp2 = temp2->next->next;
            if(temp2 == NULL) return NULL;
            if(temp1 == temp2) break;
        }
        ListNode *temp3 = head;
        while(temp2 != temp3) {
            temp2 = temp2->next;
            temp3 = temp3->next;
        }
        return temp2;
    }
};
#endif
