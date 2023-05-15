public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int targetRow = 0;
        for (int i = 0; i < matrix.Count()-1; i++) {
            if (target >= matrix[i][0] && target < matrix[i+1][0]) {
                break;
            }
            targetRow++;
        }
        return SearchArray(matrix[targetRow], target);
    }
    
    private bool SearchArray(int[] nums, int target) {
        return SearchRecursive(nums, 0, nums.Count()-1, target);
    }
    
    private bool SearchRecursive(int[] nums, int i, int j, int target) {
        if (j-i <= 1) {
            if (nums[i] == target || nums[j] == target) {
                return true;
            }
            return false;
        }
        
        int middle = (i+j)/2;
        if (nums[middle] >= target) {
            return SearchRecursive(nums, i, middle, target);
        }
        else {
            return SearchRecursive(nums, middle, j, target);
        }
    }
}