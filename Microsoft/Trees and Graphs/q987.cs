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
 * https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/description/
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var nodeList = new SortedList<int, SortedList<int, List<int>>>();
        this.Traverse(root, 0, 0, ref nodeList);

        var nodeListOrdered = nodeList.Values;
        var result = new List<IList<int>>();
        foreach (var colDict in nodeListOrdered) {
            var rowResult = new List<int>();
            foreach(var colList in colDict.Values) {
                rowResult.AddRange(colList.OrderBy(x => x).ToList());
            }
            result.Add(rowResult);
        }

        return result;
    }

    private void Traverse(TreeNode root, int row, int col, ref SortedList<int, SortedList<int, List<int>>> nodeList) {

        if (root == null) {
            return;
        }

        if (!nodeList.ContainsKey(col)) {
            nodeList[col] = new SortedList<int, List<int>>();
        }
        if (!nodeList[col].ContainsKey(row)) {
            nodeList[col][row] = new List<int>();
        }
        nodeList[col][row].Add(root.val);

        Traverse(root.left, row+1, col-1, ref nodeList);
        Traverse(root.right, row+1, col+1, ref nodeList);
    }
}