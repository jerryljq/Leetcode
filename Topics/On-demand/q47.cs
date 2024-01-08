
/*
Q47. Permutations II
https://leetcode.com/problems/permutations-ii/description/

Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

Example 1:

Input: nums = [1,1,2]
Output:
[[1,1,2],
 [1,2,1],
 [2,1,1]]
Example 2:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
 

Constraints:

1 <= nums.length <= 8
-10 <= nums[i] <= 10
*/
public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        var counterMap = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (!counterMap.ContainsKey(num)) {
                counterMap[num] = 0;
            }
            counterMap[num] += 1;
        }

        var result = new List<IList<int>>();
        var initialSet = new List<int>();
        this.PermuteSubset(initialSet, result, nums.Count(), counterMap);
        return result;
    }

    private void PermuteSubset(List<int> nums, List<IList<int>> results, int count, Dictionary<int, int> counter) {
        
        if (nums.Count == count) {
            results.Add(new List<int>(nums));
            return;
        }

        foreach (var counterPair in counter) {
            if (counterPair.Value == 0) {
                continue;
            }
            nums.Add(counterPair.Key);
            counter[counterPair.Key] -= 1;

            this.PermuteSubset(nums, results, count, counter);

            nums.RemoveAt(nums.Count-1);
            counter[counterPair.Key] += 1;
        }
    }
}