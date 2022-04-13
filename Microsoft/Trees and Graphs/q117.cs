/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) {
            return root;
        }
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        
        while (queue.Count() > 0) {
            var levelCount = queue.Count();
            for (int i = 0; i < levelCount; i++) {
                var current = queue.Dequeue();
                if (i < levelCount - 1) {
                    current.next = queue.Peek();
                }
                if (current.left != null) {
                    queue.Enqueue(current.left);
                }
                if (current.right != null) {
                    queue.Enqueue(current.right);
                }
            }
        }
        
        return root;
    }
}