//
// Created by Jerry Li on 2017/10/17.
//
/********************* Problem Specification *********************
 A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.
 Return a deep copy of the list.
 ***************************** Solution **************************
 See the code and descriptions below. // Not done yet!
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q136_H
#define LEETCODE_Q136_H

#include "commons.h"
/**
 * Definition for singly-linked list with a random pointer.
 * struct RandomListNode {
 *     int label;
 *     RandomListNode *next, *random;
 *     RandomListNode(int x) : label(x), next(NULL), random(NULL) {}
 * };
 */
class Solution {
public:
    RandomListNode *copyRandomList(RandomListNode *head) {
        if(head == NULL) return NULL;
        RandomListNode *newHead = new RandomListNode(head->label);
        RandomListNode *current = head->next;
        RandomListNode *random = head->random;
        RandomListNode *currentNew = newHead;
        while(current != NULL) {
            currentNew->next = new RandomListNode(current->label);
            if(random == NULL) currentNew->random = NULL;
            else {
                currentNew->random = random - head + newHead;
            }
            current = current->next;
            random = current->random;
            currentNew = currentNew->next;
        }
        currentNew->next = NULL;
        if(random == NULL) currentNew->random = NULL;
        else &(currentNew->random) = random - head + newHead;
    }
};