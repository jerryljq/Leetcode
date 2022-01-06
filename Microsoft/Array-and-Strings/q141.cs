/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return false;
        }
        
        ListNode current = head;
        ListNode current2 = head.next.next;
        
        while (current != null && current2 != null) {
            if (IsNodeEqual(current, current2)) {
                return true;
            }
            current = current.next;
            current2 = current2.next?.next ?? null;
        }
        
        return false;
    }
    
    private static bool IsNodeEqual(ListNode node1, ListNode node2) {
        return (node1.val == node2.val) && (node1.next == node2.next);
    }
}