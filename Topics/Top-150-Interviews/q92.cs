/*
Q92. Reverse Linked List II
https://leetcode.com/problems/reverse-linked-list-ii

Given the head of a singly linked list and two integers left and right where left <= right, reverse the nodes of the list from position left to position right, and return the reversed list.
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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (left == right) return head;
        var dummyHead = new ListNode(0, head);
        var current = dummyHead;
        var currentPosition = 0;
        while (current != null && current.next != null) {
            if (currentPosition + 1 == left) {
                break;
            }
            current = current.next;
            currentPosition += 1;
        }

        current.next = this.Reverse(current.next, currentPosition+1, right);
        
        var currenttmp = dummyHead.next;
        while(currenttmp != null) {
            currenttmp = currenttmp.next;
        }

        return dummyHead.next;
    }

    private ListNode Reverse(ListNode head, int firstPosition, int breaker) {
        var dummyHead = new ListNode(0, head);
        var current = head;
        var currentPosition = firstPosition;

        while (current != null) {
            var dummyHeadNext = dummyHead.next;
            dummyHead.next = current;
            current = current.next;
            currentPosition += 1;
            dummyHead.next.next = dummyHeadNext;

            if (currentPosition - 1 == breaker) {
                break;
            }
        }

        head.next = current;

        return dummyHead.next;
    }
}