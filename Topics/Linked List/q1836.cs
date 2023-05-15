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
 /// https://leetcode.com/problems/remove-duplicates-from-an-unsorted-linked-list/
 /// Use a fake head in this situation in case head needs to be removed.
public class Solution {
    public ListNode DeleteDuplicatesUnsorted(ListNode head) {
        var valueCountList = new Dictionary<int, int>();
        var currentNode = head;
        
        while (currentNode != null) {
            if (!valueCountList.ContainsKey(currentNode.val)) {
                valueCountList.Add(currentNode.val, 1);
            }
            else {
                valueCountList[currentNode.val] += 1;
            }
            
            currentNode = currentNode.next;
        }
        
        var newHead = new ListNode(0, head);
              
        currentNode = newHead;
        var currentNext = currentNode?.next;
        while (currentNext != null) {
            if (valueCountList[currentNext.val] > 1) {
                currentNode.next = currentNext.next;
                currentNext = currentNode.next;
                continue;
            }
            currentNode = currentNode.next;
            currentNext = currentNode?.next;
        }
        
        return newHead.next;
    }
}