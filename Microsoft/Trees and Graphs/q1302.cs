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
 * https://leetcode.com/problems/deepest-leaves-sum/submissions/
 */
public class Solution {
    public int DeepestLeavesSum(TreeNode root) {
        if (root == null) return 0;
        var depthSum = new SortedList<int, int>();
        Traverse(root, 0, ref depthSum);

        return depthSum[depthSum.Keys.Count()-1];
    }

    private void Traverse(TreeNode root, int depth, ref SortedList<int, int> depthSum) {
        if (root == null) {
            return;
        }

        if (!depthSum.ContainsKey(depth)) {
            depthSum[depth] = 0;
        }
        depthSum[depth] += root.val;
        Traverse(root.left, depth+1, ref depthSum);
        Traverse(root.right, depth+1, ref depthSum);
    }
}