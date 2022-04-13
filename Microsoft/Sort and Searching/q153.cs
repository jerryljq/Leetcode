public class Solution {
    public int FindMin(int[] nums) {
        if (nums[0] < nums[nums.Count()-1]) {
            return nums[0];
        }
        
        return this.FindMinRecursive(nums, 0, nums.Count()-1);
    }
    
    private int FindMinRecursive(int[] nums, int left, int right) {
        if (left == right) {
            return nums[left];
        }
        else if (right - left == 1) {
            if (nums[right] < nums[left]) {
                return nums[right];
            }
            else {
                return nums[left];
            }
        }
        else {
            int middle = (left+right)/2;
            if (nums[middle] > nums[0]) {
                return FindMinRecursive(nums, middle, right);
            }
            else {
                return FindMinRecursive(nums, left, middle);
            }
        }
    }
}