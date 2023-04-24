/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution_Recursive {
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        return this.isMirror(root.left, root.right);
    }
    
    public bool isMirror(TreeNode node1, TreeNode node2) {
        if (node1 == null && node2 == null) {
            return true;
        }
        else if (node1 != null && node2 != null) {
            if (node1.val != node2.val) return false;
            return this.isMirror(node1.left, node2.right) && this.isMirror(node1.right, node2.left);
        } else {
            return false;
        }
    }
}

public class Solution_Iterative {
    public bool IsSymmetric(TreeNode root) {
        if (root == null) return true;
        
        var nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);
        nodeQueue.Enqueue(root);
        
        while (nodeQueue.Count > 0) {
            var currentNodeA = nodeQueue.Dequeue();
            var currentNodeB = nodeQueue.Dequeue();
            
            if (currentNodeA == null && currentNodeB == null) continue;
            if (currentNodeA == null || currentNodeB == null) return false;
            if (currentNodeA.val != currentNodeB.val) return false;
            
            nodeQueue.Enqueue(currentNodeA.left);
            nodeQueue.Enqueue(currentNodeB.right);
            nodeQueue.Enqueue(currentNodeA.right);
            nodeQueue.Enqueue(currentNodeB.left);
        }
        
        return true;
    }
}