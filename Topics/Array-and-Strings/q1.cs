public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        int targetIndex = -1;

        for(int i = 0; i < nums.Count(); i++) {
            
            var hasTarget = dict.TryGetValue(nums[i], out targetIndex);
            if (hasTarget) {
                return new int[] {i, targetIndex};
            }
            
            dict.TryAdd(target-nums[i], i);
        }
        throw new NotImplementedException();
    }
}