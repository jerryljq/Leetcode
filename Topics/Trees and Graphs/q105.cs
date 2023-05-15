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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return this.BuildTreeNode(preorder, inorder, 0, preorder.Count()-1, 0, preorder.Count()-1);
    }
    
    public TreeNode BuildTreeNode(int[] preorder, int[] inorder, int preorderleftindex, int preorderrightindex, int inorderleftindex, int inorderrightindex) {
        if (preorderleftindex > preorderrightindex || inorderleftindex > inorderrightindex) {
            return null;
        }

        var root = new TreeNode(preorder[preorderleftindex]);
        var inorderRootIndex = Array.IndexOf(inorder, preorder[preorderleftindex]);
        
        if (inorderRootIndex != -1 && inorderRootIndex >= inorderleftindex && inorderRootIndex <= inorderrightindex) {
            root.left = BuildTreeNode(preorder, inorder, preorderleftindex+1, preorderrightindex, inorderleftindex, inorderRootIndex-1);
            root.right = BuildTreeNode(preorder, inorder, inorderRootIndex-inorderleftindex+preorderleftindex+1, preorderrightindex, inorderRootIndex+1, inorderrightindex);
        }
        
        return root;
    }
}