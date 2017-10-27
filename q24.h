//
// Created by Jerry Li on 2017/10/27.
//
/********************* Problem Specification *********************
Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q24_H
#define LEETCODE_Q24_H

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
    ListNode* swapPairs(ListNode* head) {
        if(head==NULL) return head;
        if(head->next == NULL) return head;
        
        ListNode *current = head;
        ListNode *temp = head->next;
        head->next = temp->next;
        temp->next = current;
        head = temp;
        current = temp->next;
              
        while(current != NULL && current->next != NULL && current->next->next != NULL) {
            ListNode *currentNext = current->next;
            ListNode *currentNextNext = currentNext->next;
            ListNode *temp = currentNextNext->next;
            current->next = currentNextNext;
            currentNextNext->next = currentNext;
            currentNext->next = temp;
            current = current->next->next;
        }
        return head;
    }
};
#endif