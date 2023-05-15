public class Solution {
    public int DominantIndex(int[] nums) {
        if (nums.Count() == 1) {
            return 0;
        }
        
        int largestIndex = 0;
        int secondLargestIndex = 1;
        
        for (int i = 1; i < nums.Count(); ++i) {
            if (nums[i] > nums[largestIndex]) {
                secondLargestIndex = largestIndex;
                largestIndex = i;
            }
            
            if (nums[i] < nums[largestIndex] && nums[i] > nums[secondLargestIndex]) {
                secondLargestIndex = i;
            }
        }
        
        if (nums[largestIndex] >= 2*nums[secondLargestIndex]) {
            return largestIndex;
        }
        else 
        {
            return -1;
        }
    }
}