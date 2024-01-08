/**
 * Q236. Lowest Common Ancestor of a Binary Tree
 * Check Q1644, Q1650
 * https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
 * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T that has both p and q as descendants (where we allow a node to be a descendant of itself).”

Example 1:

Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.
Example 2:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
Example 3:
Input: root = [1,2], p = 1, q = 2
Output: 1

Constraints:
The number of nodes in the tree is in the range [2, 105].
-109 <= Node.val <= 109
All Node.val are unique.
p != q
p and q will exist in the tree.
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) {
            return null;
        }

        var parentMap = this.GenerateParentMap(root);
        var pathP = this.FindPath(parentMap, p);
        var pathQ = this.FindPath(parentMap, q);

        var indexP = pathP.Count-1;
        var indexQ = pathQ.Count-1;

        while(indexP >= 0 && indexQ >= 0 && pathP[indexP].val == pathQ[indexQ].val) {
            indexP -= 1;
            indexQ -= 1;
        }

        return pathP[indexP+1];
    }

    private Dictionary<TreeNode, TreeNode> GenerateParentMap(TreeNode root) {
        var parentMap = new Dictionary<TreeNode, TreeNode>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        parentMap.Add(root, null);

        while(queue.Count() > 0) {
            var currentNode = queue.Dequeue();
            if (currentNode.left != null) {
                parentMap.Add(currentNode.left, currentNode);
                queue.Enqueue(currentNode.left);
            }

            if (currentNode.right != null) {
                parentMap.Add(currentNode.right, currentNode);
                queue.Enqueue(currentNode.right);
            }
        }

        return parentMap;
    }

    private List<TreeNode> FindPath(Dictionary<TreeNode, TreeNode> parentMap, TreeNode node) {
        var pathList = new List<TreeNode>();

        if (!parentMap.ContainsKey(node)) {
            return pathList;
        }

        pathList.Add(node);
        var parentNode = parentMap[node];
        while(parentNode != null) {
            pathList.Add(parentNode);
            parentNode = parentMap[parentNode];
        }

        return pathList;
    }
}