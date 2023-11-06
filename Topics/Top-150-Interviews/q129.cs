/*
Q129. Sum Root to Leaf Numbers
https://leetcode.com/problems/sum-root-to-leaf-numbers/description

You are given the root of a binary tree containing digits from 0 to 9 only.

Each root-to-leaf path in the tree represents a number.

For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
Return the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will fit in a 32-bit integer.

A leaf node is a node with no children.
*/
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

    private List<int> sumList = new List<int>();

    public int SumNumbers(TreeNode root) {
        if (root == null) return 0;
        Traverse(root, 0);

        int result = 0;
        foreach(var sum in this.sumList) {
            result += sum;
        }

        return result;
    }

    private void Traverse(TreeNode root, int baseNum) {
        if (root == null) return;
        if (root.left == null && root.right == null) {
            this.sumList.Add(baseNum*10 + root.val);
            return;
        }

        var newBase = baseNum*10 + root.val;
        Traverse(root.left, newBase);
        Traverse(root.right, newBase);
    }
}