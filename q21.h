//
// Created by Jerry Li on 2017/10/16.
//
/********************* Problem Specification *********************
 Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q21_H
#define LEETCODE_Q21_H

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
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
        ListNode *head, *curr1, *curr2;
        ListNode *result;
        curr1 = l1;
        curr2 = l2;
        if(curr1 == NULL && curr2 == NULL) return NULL;
        if(curr1 == NULL) return curr2;
        if(curr2 == NULL) return curr1;
        
        if (curr1->val < curr2->val) {
            head = curr1;
            curr1 = curr1->next;
        }
        else {
            head = curr2;
            curr2 = curr2->next;
        }
        result = head;
        while(curr1 != NULL && curr2 != NULL) {
            if(curr1->val < curr2->val) {
                head->next = curr1;
                curr1 = curr1->next;
                head = head->next;
            } else {
                head->next = curr2;
                curr2 = curr2->next;
                head = head->next;
            }
        }
        if(curr1 == NULL) head->next = curr2;
        else head->next = curr1;
        
        return result;
    }
};
#endif;