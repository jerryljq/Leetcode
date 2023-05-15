/// https://leetcode.com/problems/3sum/solution/
/// Traditional 3 sum question
/// Solution without sorting
public class Solution {
    private Dictionary<int, int> numsList = new Dictionary<int, int>();
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        var result = new List<IList<int>>();
        var usedNumbers = new HashSet<int>();
        var resultSet = new HashSet<(int, int, int)>();
        
        for (int i = 0; i < nums.Count(); ++i) {
            if (!usedNumbers.Contains(nums[i])) {
                int target = 0-nums[i];
                var twoSumResults = TwoSum(nums, target, i);

                foreach (var twoSumResult in twoSumResults) {
                    var localResult = new List<int>();
                    localResult.Add(nums[i]);
                    localResult.AddRange(twoSumResult); 
                    localResult.Sort();
                    if (!resultSet.Contains((localResult[0], localResult[1], localResult[2]))) {
                        result.Add(localResult);
                        resultSet.Add((localResult[0], localResult[1], localResult[2]));
                    }
                }
                usedNumbers.Add(nums[i]);
            }
        }
        
        return result.ToList();
    }
    
    public IList<int[]> TwoSum(int[] nums, int target, int avoidIndex) {
        var result = new List<int[]>();
        
        for (int i = 0; i < nums.Count(); ++i) {
            if (i == avoidIndex) continue;
            var complement = target - nums[i];
            if (numsList.ContainsKey(complement) && numsList[complement] == avoidIndex)             
            {
                numsList[nums[i]] = avoidIndex;
                result.Add(new int[]{nums[i], complement});
            }
            numsList[nums[i]] = avoidIndex;
        }
        
        return result;
    }
}