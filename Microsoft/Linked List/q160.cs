/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        
        if (headA == null || headB == null) {
            return null;
        }
        
        ListNode currentNode = headA;
        ListNode backupNode = headA;
        
        while (currentNode != null) {
            currentNode.val = currentNode.val *= -1;
            currentNode = currentNode.next;
        }
        
        currentNode = headB;
        
        while (currentNode != null) {
            if (currentNode.val <= 0) {
                break;
            }
            currentNode = currentNode.next;
        }
        
        while (backupNode != null) {
            backupNode.val = backupNode.val *= -1;
            backupNode = backupNode.next;
        }
        
        return currentNode;
    }
}