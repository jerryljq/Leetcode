/**
* 314. Binary Tree Vertical Order Traversal
Hint
Given the root of a binary tree, return the vertical order traversal of its nodes' values. (i.e., from top to bottom, column by column).

If two nodes are in the same row and column, the order should be from left to right.

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
 *  

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: [[9],[3,15],[20],[7]]
Example 2:


Input: root = [3,9,8,4,0,1,7]
Output: [[4],[9],[3,0,1],[8],[7]]
Example 3:


Input: root = [3,9,8,4,0,1,7,null,null,null,2,5]
Output: [[4],[9,5],[3,0,1],[8,2],[7]]
 

Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
 */
public class Solution {
    private Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return result;
        int minCol = 0;
        int maxCol = 0;
        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));

        while (queue.Count() > 0) {
            var currentNodePos = queue.Dequeue();
            if (!this.dict.ContainsKey(currentNodePos.Item2)) {
                this.dict[currentNodePos.Item2] = new List<int>();
            }
            this.dict[currentNodePos.Item2].Add(currentNodePos.Item1.val);
            if (currentNodePos.Item2 < minCol) {
                minCol = currentNodePos.Item2;
            } else if (currentNodePos.Item2 > maxCol) {
                maxCol = currentNodePos.Item2;
            }

            if (currentNodePos.Item1.left != null) {
                queue.Enqueue((currentNodePos.Item1.left, currentNodePos.Item2-1));
            }

            if (currentNodePos.Item1.right != null) {
                queue.Enqueue((currentNodePos.Item1.right, currentNodePos.Item2+1));
            }
        }
        
        // var keys = this.dict.Keys.ToList();
        // keys.Sort();
        // foreach (var key in keys) {
        //     result.Add(this.dict[key]);
        // }
        for (int i = minCol; i <= maxCol; ++i) {
            if (this.dict.ContainsKey(i)) {
                result.Add(this.dict[i]);
            }
        }

        return result;
    }
}