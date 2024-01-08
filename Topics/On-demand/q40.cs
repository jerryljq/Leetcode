/*
Q40. Combination Sum II
https://leetcode.com/problems/combination-sum-ii/description/

Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]
 

Constraints:

1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30
*/
public class Solution {
    private IList<IList<int>> resultList;

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
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
                if (i > beginIndex && candidates[i] == candidates[i-1]) {
                    continue;
                }
                currentResultNew.Add(candidate);
                this.FindCombination(candidates, i+1, target-candidate, currentResultNew);
            } else if (candidate == target) {
                currentResultNew.Add(candidate);
                this.resultList.Add(currentResultNew);
                break;
            } else {
                return;
            }
        }
    }
}