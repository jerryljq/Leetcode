/**
 * Q1676. Lowest Common Ancestor of a Binary Tree IV
 * https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iv/description/
 * See 236, 1644, 1650
Given the root of a binary tree and an array of TreeNode objects nodes, return the lowest common ancestor (LCA) of all the nodes in nodes. All the nodes will exist in the tree, and all values of the tree's nodes are unique.
Extending the definition of LCA on Wikipedia: "The lowest common ancestor of n nodes p1, p2, ..., pn in a binary tree T is the lowest node that has every pi as a descendant (where we allow a node to be a descendant of itself) for every valid i". A descendant of a node x is a node y that is on the path from node x to some leaf node.

Example 1:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], nodes = [4,7]
Output: 2
Explanation: The lowest common ancestor of nodes 4 and 7 is node 2.
Example 2:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], nodes = [1]
Output: 1
Explanation: The lowest common ancestor of a single node is the node itself.
Example 3:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], nodes = [7,6,2,4]
Output: 5
Explanation: The lowest common ancestor of the nodes 7, 6, 2, and 4 is node 5.

Constraints:

The number of nodes in the tree is in the range [1, 104].
-109 <= Node.val <= 109
All Node.val are unique.
All nodes[i] will exist in the tree.
All nodes[i] are distinct.
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        if (root == null) {
            return null;
        }

        var parentMap = this.GenerateParentMap(root);
        var paths = new List<TreeNode>[nodes.Count()];

        for (int i = 0; i < nodes.Count(); ++i) {
            paths[i] = this.FindPath(parentMap, nodes[i]);
        }

        var referencePath = paths[0];
        TreeNode previousVal = null;
        var index = 0;

        while (referencePath.Count-1-index >= 0) {
            var currentVal = referencePath[referencePath.Count-1-index];
            bool isValid = true;
            for (int i = 1; i < paths.Count(); ++i) {
                var currentPath = paths[i];
                int currentPathCount = currentPath.Count;
                if (currentPathCount-1-index < 0 || currentPath[currentPathCount-1-index].val != currentVal.val) {
                    isValid = false;
                    break;
                }
            }

            if (!isValid) {
                break;
            } 

            previousVal = currentVal;
            index += 1;
        }

        return previousVal;
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