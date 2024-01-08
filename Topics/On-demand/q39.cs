/*
Q39. Combination Sum
https://leetcode.com/problems/combination-sum/description/

Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the 
frequency of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
Example 3:

Input: candidates = [2], target = 1
Output: []
 

Constraints:

1 <= candidates.length <= 30
2 <= candidates[i] <= 40
All elements of candidates are distinct.
1 <= target <= 40
*/
public class Solution {
    private IList<IList<int>> resultList;

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        this.resultList = new List<IList<int>>();
        if (candidates.Count() == 0) {
            return this.resultList;
        }        
        Array.Sort(candidates);
        this.FindCombination(candidates, 0, target, new List<int>());

        return this.resultList;
    }

    private void FindCombination(int[] candidates, int beginIndex, int target, IList<int> currentResult) {
        for (int i = beginIndex; i < candidates.Count(); ++i) {
            var candidate = candidates[i];
            var currentResultNew = new List<int>(currentResult);
            if (candidate < target) {
                // Keep finding don't return
                currentResultNew.Add(candidate);
                this.FindCombination(candidates, i, target-candidate, currentResultNew);
            } else if (candidate == target) {
                currentResultNew.Add(candidate);
                this.resultList.Add(currentResultNew);
            } else {
                return;
            }
        }
    }
}