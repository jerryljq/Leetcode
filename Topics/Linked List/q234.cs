/*
    Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
    Leetcode Link:
    https://leetcode.com/problems/palindrome-linked-list/description/
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
    public bool IsPalindrome(ListNode head) {
        // Find the node, whose next will be the begin of rotation
        int counter = 0;
        ListNode current = head;
        while (current != null) {
            counter += 1;
            current = current.next;
        }

        if (counter == 1) return true;

        current = head;
        int count = 0;
        while (current != null) {
            count += 1;
            if (count == counter/2+counter%2+1) {
                break;
            }
            current = current.next;
        }

        // Now current is the node start the rotation
        ListNode newHead = current;
        while (current.next != null) {
            // Put next to head
            ListNode temp = current.next;
            current.next = temp.next;
            temp.next = newHead;
            newHead = temp;
        }

        ListNode tempA = head;
        ListNode tempB = newHead;

        while (tempA != null && tempB != null) {
            if (tempA.val != tempB.val) {
                return false;
            }
            tempA = tempA.next;
            tempB = tempB.next;
        }
        
        return true;
    }
}