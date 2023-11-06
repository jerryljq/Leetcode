/*
    Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

    The first node is considered odd, and the second node is even, and so on.

    Note that the relative order inside both the even and odd groups should remain as it was in the input.

    You must solve the problem in O(1) extra space complexity and O(n) time complexity.

    Leetcode Link: https://leetcode.com/problems/odd-even-linked-list/description/
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
    public ListNode OddEvenList(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return head;
        }
        // Find the count of the nodes
        int count = 0;
        ListNode current = head;
        ListNode end = current;
        while (current != null) {
            count += 1;
            end = current;
            if (count %2 == 1 && current.next != null && current.next.next == null) {
                count += 1;
                break;
            } 
            current = current.next;
        }
        // Move the nodes to the back
        // count is the number of nodes, end is the last node, current is null
        int index = 1;
        current = head;
        while (index < count-1) {
            if (current != null && current.next != null) {
                var evenNext = current.next;
                current.next = evenNext.next;
                var endNext = end.next;
                end.next = evenNext;
                evenNext.next = endNext;
                end = evenNext;
                current = current.next;
                index += 2;
            }
            else {
                break;
            }
        }

        return head;
    }
}