/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        int small = -1;
        int large = -1;
        
        if (p.val <= q.val) {
            small = p.val;
            large = q.val;
        }
        else {
            small = q.val;
            large = p.val;
        }
        
        var currentNode = root;
        
        while (currentNode != null) {
            if (currentNode.val < small) {
                currentNode = currentNode.right;
            }
            else if (currentNode.val > large) {
                currentNode = currentNode.left;
            }
            else {
                return currentNode;
            }
        }
        
        return root;
    }
}