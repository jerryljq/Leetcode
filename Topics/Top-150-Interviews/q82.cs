/*
Q82. Remove Duplicates from Sorted List II
https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description

Given the head of a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. Return the linked list sorted as well.
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
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null) return null;
        var dummyHead = new ListNode(0, head);

        var previous = dummyHead;
        var current = head;
        int counter = 1;

        while (current != null && current.next != null) {
            if (current.next.val == current.val) {
                counter += 1;
            } else {
                if (counter > 1) {
                    previous.next = current.next;
                    counter = 1;
                } else {
                    previous = current;
                }
            }

            current = current.next;
        }

        if (counter > 1) {
            previous.next = current.next;
        }

        return dummyHead.next;
    }
}