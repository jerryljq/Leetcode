/*
Q216. Combination Sum III
https://leetcode.com/problems/combination-sum-iii/description/

Find all valid combinations of k numbers that sum up to n such that the following conditions are true:

Only numbers 1 through 9 are used.
Each number is used at most once.
Return a list of all possible valid combinations. The list must not contain the same combination twice, and the combinations may be returned in any order.

Example 1:

Input: k = 3, n = 7
Output: [[1,2,4]]
Explanation:
1 + 2 + 4 = 7
There are no other valid combinations.
Example 2:

Input: k = 3, n = 9
Output: [[1,2,6],[1,3,5],[2,3,4]]
Explanation:
1 + 2 + 6 = 9
1 + 3 + 5 = 9
2 + 3 + 4 = 9
There are no other valid combinations.
Example 3:

Input: k = 4, n = 1
Output: []
Explanation: There are no valid combinations.
Using 4 different numbers in the range [1,9], the smallest sum we can get is 1+2+3+4 = 10 and since 10 > 1, there are no valid combination.
 

Constraints:

2 <= k <= 9
1 <= n <= 60
*/
public class Solution {
    private IList<IList<int>> resultList;
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var candidates = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        this.resultList = new List<IList<int>>();
        this.FindCombination(candidates, 0, n, new List<int>(), k);
        return this.resultList;
    }

    private void FindCombination(int[] candidates, int beginIndex, int target, IList<int> currentResult, int k) {
        for (int i = beginIndex; i < candidates.Count(); ++i) {
            var candidate = candidates[i];
            var currentResultNew = new List<int>(currentResult);
            if (candidate < target) {
                // Keep finding don't return
                currentResultNew.Add(candidate);
                this.FindCombination(candidates, i+1, target-candidate, currentResultNew, k);
            } else if (candidate == target) {
                currentResultNew.Add(candidate);
                if (currentResultNew.Count == k) {
                    this.resultList.Add(currentResultNew);
                }
            } else {
                return;
            }
        }
    }
}