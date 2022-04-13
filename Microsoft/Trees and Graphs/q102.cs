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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var resultList = new List<IList<int>>();
        
        if (root == null) {
            return resultList;
        }
        
        var queue = new Queue<KeyValuePair<TreeNode, int>>();
        queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
        
        int currentHeight = 0;
        var levelList = new List<int>();        
        
        while(queue.Count() > 0) {
            var current = queue.Dequeue();
            
            if (current.Value > currentHeight) {
                currentHeight = current.Value;
                resultList.Add(levelList);
                levelList = new List<int>();
            }
            
            levelList.Add(current.Key.val);
            
            if (current.Key.left != null) {
                queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.left, current.Value + 1));
            }
            
            if (current.Key.right != null) {
                queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.right, current.Value + 1));
            }

        }
        
        if (levelList.Count() > 0) {
            resultList.Add(levelList);            
        }
        
        return resultList; 
    }
}