/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

// Note that the serialize does not need to care about format, as long as it can be consumed by deserialization.
// So the level order does not need to be taken care of.
// Do not over engineer this question, it's just a simple BFS or DFS question!!!
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) return "";
        var stringBuilder = new StringBuilder();
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            var currentNode = queue.Dequeue();
            if (currentNode == null) {
                stringBuilder.Append("null,");
            }
            else {
                stringBuilder.Append($"{currentNode.val},");
                queue.Enqueue(currentNode.left);
                queue.Enqueue(currentNode.right);
            }
        }
        return stringBuilder.ToString(); 
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data.Length == 0) return null;
        
        var nodeToken = data.Split(",");
        var root = new TreeNode(Int32.Parse(nodeToken[0]));
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;
        
        while(queue.Count > 0 && index < nodeToken.Count()) {
            var currentNode = queue.Dequeue();
            // Left
            if (!nodeToken[index].Equals("null")) {
                var newLeft = new TreeNode(Int32.Parse(nodeToken[index]));
                currentNode.left = newLeft;
                queue.Enqueue(newLeft);
            }
            index += 1;
            if (!nodeToken[index].Equals("null")) {
                var newRight = new TreeNode(Int32.Parse(nodeToken[index]));
                currentNode.right = newRight;
                queue.Enqueue(newRight);
            }
            index += 1;
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));