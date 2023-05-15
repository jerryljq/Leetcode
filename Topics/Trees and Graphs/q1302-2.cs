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
 * https://leetcode.com/problems/deepest-leaves-sum/description/
 */
public class Solution {

    private int maxDepth = 0;
    private int result = 0;

    public int DeepestLeavesSum(TreeNode root) {
        if (root == null) return 0;
        maxDepth = 0;
        result = 0;
        Traverse(root, 0);

        return this.result;
    }

    private void Traverse(TreeNode root, int depth) {
        if (root == null) {
            return;
        }

        if (depth > this.maxDepth) {
            this.maxDepth = depth;
            this.result = root.val;
        } else if (depth == this.maxDepth) {
            this.result += root.val;
        }

        Traverse(root.left, depth+1);
        Traverse(root.right, depth+1);
    }
}