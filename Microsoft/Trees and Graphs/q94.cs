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
public class RecursiveSolution {
    public IList<int> InorderTraversal(TreeNode root) {
        
        var resultList = new List<int>();
        this.Traverse(root, ref resultList);
        
        return resultList;
    }
    
    private void Traverse(TreeNode root, ref List<int> resultList) {
        if (root == null) {
            return;
        }
        
        Traverse(root.left, ref resultList);
        resultList.Add(root.val);
        Traverse(root.right, ref resultList);
    }
}

public class IterativeSolution {
    public IList<int> InorderTraversal(TreeNode root) {
        
        var resultList = new List<int>();
        
        var stack = new Stack<TreeNode>();
        
        var currentNode = root;
        while (currentNode != null) {
            stack.Push(currentNode);
            currentNode = currentNode.left;
        }
        
        while (stack.Count() > 0) {
            var current = stack.Pop();
            resultList.Add(current.val);
            
            if (current.right != null) {
                stack.Push(current.right);
                
                var tempRight = current.right.left;
                while (tempRight != null) {
                    stack.Push(tempRight);
                    tempRight = tempRight.left;
                }
            }
        }
        
        return resultList;
    }
}