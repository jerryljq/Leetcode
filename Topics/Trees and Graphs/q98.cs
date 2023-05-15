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
    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }
        
        var isLeftBST = IsValidBST(root.left);
        var isRightBST = IsValidBST(root.right);
        
        if (root.left != null) {
            var maxLeft = this.Max(root.left);
            if (maxLeft >= root.val) {
                return false;
            }
        }
        
        if (root.right != null) {
            var minRight = this.Min(root.right);
            if (minRight <= root.val) {
                return false;
            }
        }
        
        return isLeftBST && isRightBST;
    }
    
    private int Min(TreeNode node) {
        if (node == null) {
            throw new ArgumentNullException();
        }
        
        var currentNode = node;
        while (currentNode.left != null) {
            currentNode = currentNode.left;
        }
        
        return currentNode.val;
    }
    
    private int Max(TreeNode node) {
        if (node == null) {
            throw new ArgumentNullException();
        }
        
        var currentNode = node;
        while (currentNode.right != null) {
            currentNode = currentNode.right;
        }
        
        return currentNode.val;
    }
}