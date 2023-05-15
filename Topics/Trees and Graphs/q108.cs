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
    public TreeNode SortedArrayToBST(int[] nums) {
        return this.convert(ref nums, 0, nums.Length-1);
    }
    
    private TreeNode convert(ref int[] nums, int begin, int end) {
        if (begin > end) {
            return null;
        }
        
        var index = (begin+end)/2;
        var treeNode = new TreeNode(val: nums[index]);
        treeNode.left = this.convert(ref nums, begin, index-1);
        treeNode.right = this.convert(ref nums, index+1, end);
        
        return treeNode;
    }
}