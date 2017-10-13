//
// Created by Jerry Li on 2017/10/12.
//
/********************* Problem Specification *********************
 Reverse a singly linked list.
 ***************************** Solution **************************
 See the code and descriptions below. Don't forget to link head->next to NULL.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q206_H
#define LEETCODE_Q206_H

#include "commons.h"

class Solution {
public:
    // Iterative solution
    ListNode* reverseList_Iterative(ListNode* head) {
        ListNode *next = NULL;
        ListNode *prev = NULL;
        ListNode *curr = head;
        while(curr != NULL) {
            next = curr->next;
            curr->next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }

    // Recursive solution
    ListNode* reverseList_Recursive(ListNode* head) {
        // To be done.
        return head;
    }
};

#endif //LEETCODE_Q206_H