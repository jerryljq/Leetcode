/*
* Q1650. Lowest Common Ancestor of a Binary Tree III
* https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/description/
* Check Q236, Q1644
* 
Given two nodes of a binary tree p and q, return their lowest common ancestor (LCA).
Each node will have a reference to its parent node. The definition for Node is below:
class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
According to the definition of LCA on Wikipedia: "The lowest common ancestor of two nodes p and q in a tree T is the lowest node that has both p and q as descendants (where we allow a node to be a descendant of itself)."

Example 1:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
Output: 3
Explanation: The LCA of nodes 5 and 1 is 3.
Example 2:
Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5 since a node can be a descendant of itself according to the LCA definition.
Example 3:
Input: root = [1,2], p = 1, q = 2
Output: 1

Constraints:
The number of nodes in the tree is in the range [2, 105].
-109 <= Node.val <= 109
All Node.val are unique.
p != q
p and q exist in the tree.
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        var pathP = this.FindPath(p);
        var pathQ = this.FindPath(q);

        if (pathP.Count == 0 || pathQ.Count == 0) return null;

        var indexP = pathP.Count-1;
        var indexQ = pathQ.Count-1;

        while(indexP >= 0 && indexQ >= 0 && pathP[indexP].val == pathQ[indexQ].val) {
            indexP -= 1;
            indexQ -= 1;
        }

        return pathP[indexP+1];
    }

    private List<Node> FindPath(Node node) {
        var pathList = new List<Node>();
        if (node == null) return pathList;

        pathList.Add(node);
        var parentNode = node.parent;
        while(parentNode != null) {
            pathList.Add(parentNode);
            parentNode = parentNode.parent;
        }

        return pathList;
    }
}