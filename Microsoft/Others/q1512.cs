public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        int numOfGoodPair = 0;
        
        for (int i = 0; i < nums.Length-1; i++) {
            for (int j = i+1; j < nums.Length; j++) {
                if (nums[i] == nums[j]) {
                    numOfGoodPair += 1;
                }
            }
        }
        
        return numOfGoodPair;
    }
}