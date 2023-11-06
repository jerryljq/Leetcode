/*
Q21. Merge Two Sorted Lists
https://leetcode.com/problems/merge-two-sorted-lists/description

You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.
*/
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        var current1 = list1;
        var current2 = list2;
        var head = new ListNode();
        var current = head;

        while (current1 != null && current2 != null) {
            if (current1.val < current2.val) {
                current.next = current1;
                current1 = current1.next;
            } else {
                current.next = current2;
                current2 = current2.next;
            }
            
            current = current.next;
        }

        if (current1 == null) {
            current.next = current2;
        } else {
            current.next = current1;
        }

        return head.next;
    }
}