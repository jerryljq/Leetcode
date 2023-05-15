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
    public int KthSmallest(TreeNode root, int k) {
        var result = new List<int>();
        this.Traversal(root, k, ref result);
        
        return result[k-1];
    }
    
    private void Traversal(TreeNode root, int k, ref List<int> result) {
        if (root == null || result.Count() >= k) {
            return;
        }
        
        this.Traversal(root.left, k, ref result);
        result.Add(root.val);
        this.Traversal(root.right, k, ref result);
    }
}