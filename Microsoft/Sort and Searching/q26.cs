// Question link: https://leetcode.com/explore/interview/card/microsoft/47/sorting-and-searching/257/

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums == null || nums.Count() == 0) {
            return 0;
        }
        
        if (nums.Count() == 1) {
            return 1;
        }
        
        int i = 0;
        int j = 1;
        
        while (j < nums.Count()) {
            if (nums[i] < nums[j]) {
                if (j-i >= 1) {
                    nums[i+1] = nums[j];
                }
                
                i++;
                j++;
            }
            else {
                j++;
            }
        }
        
        return nums.Count() - (j-i-1);
    }
}