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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        
        var t1 = l1;
        var t2 = l2;
        
        var t3 = l1;
        bool pivot = false;
        
        while (t3 != null) {
            t3.val = (t1?.val ?? 0)+ (t2?.val ?? 0);
            if (pivot == true) {
                t3.val += 1;
            }
            if (t3.val >= 10) {
                t3.val -= 10;
                pivot = true;
            }
            else {
                pivot = false;
            }
            
            t1 = t1?.next ?? null;
            t2 = t2?.next ?? null;
            
            if (t1 == null) {
                t3.next = t2;
            }
            if (t2 == null) {
                t3.next = t1;
            }
            
            if ((t3.next == null && pivot == true) || (t1 != null || t2 != null)) {
                t3.next = new ListNode();
            }
            
            t3 = t3.next;
        }
        
        return l1;
    }
}