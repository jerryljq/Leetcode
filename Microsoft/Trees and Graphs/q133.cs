/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) {
            return null;
        }
        
        var copiedNodeList = new Dictionary<int, Node>();
        
        return DeepCopy(node, ref copiedNodeList);
    }
    
    private Node DeepCopy(Node node, ref Dictionary<int, Node> copiedNodeList) {
        var copiedNode = new Node(node.val);
        copiedNodeList.Add(node.val, copiedNode);
        
        foreach (var neighborNode in node.neighbors) {
            if (copiedNodeList.ContainsKey(neighborNode.val)) {
                // Copy not required, since already copied
                copiedNode.neighbors.Add(copiedNodeList[neighborNode.val]);
            }
            else {
                // Not copied before, copy required
                var newNode = DeepCopy(neighborNode, ref copiedNodeList);
                copiedNode.neighbors.Add(newNode);
            }
        }
        
        return copiedNode;
    }
}