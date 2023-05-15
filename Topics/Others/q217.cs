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
    
    private int globalDistance = 0;
    
    // Define if l1 longer than l2 distance > 0, otherwise distance < 0
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        if (l1 == null) return l2;
        if (l2 == null) return l1;
        
        var carry = AddTwoNode(l1, l2, 0);
        if (globalDistance >= 0) {
            var carryOver = AddCarryOver(l1, carry, globalDistance-1);
            if (carryOver == 1) {
                return new ListNode(1, l1);
            }
            return l1;
        }
        else {
            var carryOver = AddCarryOver(l2, carry, globalDistance-1);
            if (carryOver == 1) {
                return new ListNode(1, l2);
            }
            return l2;
        }
    }
    
    // returns the carry over.
    public int AddTwoNode(ListNode node1, ListNode node2, int distance) {
        int carryOver = 0;
        if (node1.next != null && node2.next != null) {
            carryOver = AddTwoNode(node1.next, node2.next, distance);
        }
        else if (node2.next != null) {
            distance -= 1;
            carryOver = AddTwoNode(node1, node2.next, distance);
        }
        else if (node1.next != null) {
            distance += 1;
            carryOver = AddTwoNode(node1.next, node2, distance);
        }
        else {
            this.globalDistance = distance;
            if (distance >= 0) {
                return AddNodes(node1, node2, 0);
            }
            else {
                return AddNodes(node2, node1, 0);
            }
        }
        
        if (distance == 0) {
            if (globalDistance >= 0) {
                for (int i = 0; i < globalDistance; i++) {
                    node1 = node1.next;
                }
                return AddNodes(node1, node2, carryOver);
            }
            else {
                for (int i = 0; i > globalDistance; i--) {
                    node2 = node2.next;
                }
                return AddNodes(node2, node1, carryOver);
            }
        }
        else {
            return carryOver;
        }
    }
    
    public int AddCarryOver(ListNode node, int carry, int distance) {
        if (distance < 0) {
            return carry;
        }
        int carryOver = 0;
        if (distance > 0) {
            carryOver = AddCarryOver(node, carry, distance-1);
            int x = node.val;
            int y = x + carryOver;
            node.val = y % 10;
            return y / 10;
        }
        
        int z = node.val;
        int a = z + carry;
        node.val = a % 10;
        return a / 10;
    }
    
    public int AddNodes(ListNode node1, ListNode node2, int carry) {
        int x = node1.val;
        int y = node2.val;
        int z = x + y + carry;
        node1.val = z % 10;
        return z / 10;
    }
}