/*
    Given the head of a linked list, remove the nth node from the end of the list and return its head.

    Leetcode Link: https://leetcode.com/problems/remove-nth-node-from-end-of-list/description/
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if (head == null) return null;
        if (head.next == null && n > 0) return null;
        
        var dummyHead = new ListNode(val: 0, next: head);
        
        ListNode current = dummyHead;
        ListNode currentAfterN = dummyHead;
        int counter = 0;
        
        while (current.next != null) {
            current = current.next;
            if (counter < n) {
                counter += 1;
            } else {
                currentAfterN = currentAfterN.next;
            }
        }
        
        if (currentAfterN != null) {
            currentAfterN.next = currentAfterN.next?.next ?? null;
        }
        
        return dummyHead.next;
    }
}