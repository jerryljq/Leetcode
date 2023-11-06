/*
61. Rotate List
https://leetcode.com/problems/rotate-list/description

Given the head of a linked list, rotate the list to the right by k places.

Example 1:

Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]
Example 2:

Input: head = [0,1,2], k = 4
Output: [2,0,1]

Constraints:

The number of nodes in the list is in the range [0, 500].
-100 <= Node.val <= 100
0 <= k <= 2 * 109
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
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || k == 0) return head;

        var current = head;
        int count = 0;

        while (current != null) {
            count += 1;
            current = current.next;
        }

        var rotateStep = k % count;

        if (rotateStep == 0) {
            return head;
        }

        var startingPos = count - rotateStep;

        current = head;
        int pos = 1;

        while (pos < startingPos) {
            pos += 1;
            current = current.next;
        }

        var newHead = current.next;
        current.next = null;
        current = newHead;
        while (current.next != null) {
            current = current.next;
        }

        current.next = head;

        return newHead;
    }
}