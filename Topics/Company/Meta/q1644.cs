/**
* Q1644. Lowest Common Ancestor of a Binary Tree II
* https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-ii/
* Check Q236, Q1650
Given the root of a binary tree, return the lowest common ancestor (LCA) of two given nodes, p and q. If either node p or q does not exist in the tree, return null. All values of the nodes in the tree are unique.
According to the definition of LCA on Wikipedia: "The lowest common ancestor of two nodes p and q in a binary tree T is the lowest node that has both p and q as descendants (where we allow a node to be a descendant of itself)". A descendant of a node x is a node y that is on the path from node x to some leaf node.

Example 1:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.
Example 2:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5. A node can be a descendant of itself according to the definition of LCA.
Example 3:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 10
Output: null
Explanation: Node 10 does not exist in the tree, so return null.

Constraints:
The number of nodes in the tree is in the range [1, 104].
-109 <= Node.val <= 109
All Node.val are unique.
p != q

Follow up: Can you find the LCA traversing the tree, without checking nodes existence?
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

        if (pathP.Count == 0 || pathQ.Count == 0) return null;

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