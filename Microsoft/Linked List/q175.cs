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
        if (list1 == null && list2 == null) {
            return null;
        }
        
        if (list1 == null) {
            return list2;
        }
        
        if (list2 == null) {
            return list1;
        }
        
        ListNode baseList, otherList;
        
        if (list1.val >= list2.val) {
            baseList = list2;
            otherList = list1;
        }
        else {
            baseList = list1;
            otherList = list2;
        }
        
        ListNode currentOther = otherList;
        ListNode currentBase = baseList;
        
        while (currentOther != null) {
            if (currentBase.next == null) {
                currentBase.next = currentOther;
                break;
            }
            
            if (currentBase.next.val <= currentOther.val) {
                currentBase = currentBase.next;
                continue;
            }
            
            var tempOtherNext = currentOther.next;
            var tempBaseNext = currentBase.next;
            
            currentBase.next = currentOther;
            currentOther.next = tempBaseNext;
            
            currentBase = currentBase.next;
            currentOther = tempOtherNext;
        }
        
        return baseList;
    }
}