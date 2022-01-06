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
    public ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null) {
            return head;
        }
        
        var h = head;
        var prev = head;
        var current = head.next;
        
        while (current != null) {
            // this.Swap(ref prev, ref curr, ref currentHead);
            var tNext = current.next;
            current.next = h;
            h = current;
            prev.next = tNext;
            current = tNext;
        }
        
        return h;
    }
    
//     private void Swap (ref ListNode prev, ref ListNode current, ref ListNode h) {
//         var tNext = current.next;
//         current.next = h;
//         h = current;
//         prev.next = tNext;
//         current = tNext;
//     }
}