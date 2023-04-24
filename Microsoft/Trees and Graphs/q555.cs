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
public class Solution {
    public int MaxDepth_Recursive(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        int leftDepth = this.MaxDepth_Recursive(root.left) + 1;
        int rightDepth = this.MaxDepth_Recursive(root.right) + 1;
        
        return leftDepth < rightDepth ? rightDepth : leftDepth;
    }

    public int MaxDepth_Iterative(TreeNode root) {
        
    }
}