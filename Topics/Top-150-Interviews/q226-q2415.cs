
/*
Q2415. Reverse Odd Levels of Binary Tree
https://leetcode.com/problems/reverse-odd-levels-of-binary-tree/description

Given the root of a perfect binary tree, reverse the node values at each odd level of the tree.

For example, suppose the node values at level 3 are [2,1,3,4,7,11,29,18], then it should become [18,29,11,7,4,3,1,2].
Return the root of the reversed tree.

A binary tree is perfect if all parent nodes have two children and all leaves are on the same level.

The level of a node is the number of edges along the path between it and the root node.
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
    public TreeNode ReverseOddLevels(TreeNode root) {
        if (root == null) return null;
        var allNodeList = new List<List<TreeNode>>();
        var currentTempList = new List<TreeNode> { root };
        int path = -1;

        while (currentTempList.Count > 0) {
            path += 1;
            var currentLevelNode = new List<TreeNode>();
            foreach (var node in currentTempList) {
                if (node.left == null) {
                    break;
                }
                currentLevelNode.Add(node.left);
                currentLevelNode.Add(node.right);
            }

            if (path %2 == 1) {
                currentTempList.Reverse();
            }
            allNodeList.Add(currentTempList);
            currentTempList = currentLevelNode;
        }

        for (int i = 1; i < allNodeList.Count; ++i) {

            for (int j = 0; j < allNodeList[i-1].Count; ++j) {
                allNodeList[i-1][j].left = allNodeList[i][2*j];
                allNodeList[i-1][j].right = allNodeList[i][2*j+1];
            }
        }

        return root;
    }
}