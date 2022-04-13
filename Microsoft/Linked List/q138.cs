/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }
        
        Node currentNode = head;
        
        while (currentNode != null) {
            var tempNext = currentNode.next;
            currentNode.next = new Node(currentNode.val);
            currentNode.val *= -1;
            currentNode.next.next = tempNext;
            currentNode.next.random = currentNode.random;
            currentNode = tempNext;
        }
        
        currentNode = head;
        Node newHead = head.next;
        
        while (currentNode != null) {
            var currentNewNode = currentNode.next;
            if (currentNewNode.random != null) {
                currentNewNode.random = currentNode.random.next; 
            }
            
            currentNode = currentNewNode.next;
        }
        
        currentNode = head;
        
        while (currentNode != null) {
            var currentNewNode = currentNode.next;
            var tempNext = currentNewNode.next;
            
            currentNode.next = tempNext;
            currentNewNode.next = tempNext?.next ?? null;
            
            currentNode = currentNode.next;
        }
        
        return newHead;
    }
}