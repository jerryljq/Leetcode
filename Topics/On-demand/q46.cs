/*
Q46. Permutations
https://leetcode.com/problems/permutations/description/

Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:
Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:
Input: nums = [1]
Output: [[1]]

Constraints:
1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.
*/
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        return this.PermuteSubset(nums, 0);
    }

    private IList<IList<int>> PermuteSubset(int[] nums, int beginning) {
        var result = new List<IList<int>>();
        if (beginning == nums.Count()-1) {
            result.Add(new List<int>() { nums[nums.Count()-1] });
            return result;
        }

        var subsetPerms = this.PermuteSubset(nums, beginning+1);
        foreach (var subsetPerm in subsetPerms) {
            for(int i = 0; i <= subsetPerm.Count; ++i) {
                var newPerm = new List<int>(subsetPerm);
                newPerm.Insert(i, nums[beginning]);
                result.Add(newPerm);
            }
        }

        return result;
    }
}