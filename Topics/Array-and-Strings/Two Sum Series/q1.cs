/// https://leetcode.com/problems/two-sum/
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var numsList = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Count(); ++i) {
            numsList[nums[i]] = i;
        }
        
        for (int i = 0; i < nums.Count(); ++i) {
            var complement = target - nums[i];
            if (numsList.ContainsKey(complement) && numsList[complement] != i) {
                return new int[]{i, numsList[complement]};
            }
        }
        
        return new int[]{0,0};
    }
}