/**
Q229. Majority Elements II

Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

Example 1:

Input: nums = [3,2,3]
Output: [3]
Example 2:

Input: nums = [1]
Output: [1]
Example 3:

Input: nums = [1,2]
Output: [1,2]
 

Constraints:

1 <= nums.length <= 5 * 104
-109 <= nums[i] <= 109
**/
public class Solution {
    // General
    // O(n) Time
    // O(n) Space
    public IList<int> MajorityElement(int[] nums) {
        var dict = new Dictionary<int, int>();
        var result = new List<int>();

        foreach (var num in nums) {
            if (!dict.ContainsKey(num)) {
                dict[num] = 1;
            } else {
                dict[num] += 1;
            }
        }

        foreach (var key in dict.Keys) {
            if (dict[key] > nums.Count()/3) {
                result.Add(key);
            }
        }

        return result;
    }

    // Optimized - can be generalized to n/x majority elements
    // O(n) Time
    // O(1) Space
    public IList<int> MajorityElement_Optimized(int[] nums) {
        int? candidateA = null;
        int? candidateB = null;
        int countA = 0;
        int countB = 0;

        foreach(var num in nums) {
            if (countA == 0 && candidateB != num) {
                candidateA = num;
            }

            if (countB == 0 && candidateA != num) {
                candidateB = num;
            }

            if (candidateA == num) countA += 1;
            if (candidateB == num) countB += 1;
            if (candidateA != num && candidateB != num) {
                countA -= 1;
                countB -= 1;
            }
        }

        countA = 0;
        countB = 0;

        foreach (var num in nums) {
            if (candidateA != null && num == candidateA) countA += 1;
            if (candidateB != null && num == candidateB) countB += 1;
        }

        var result = new List<int>();

        if (countA > nums.Count()/3) result.Add((int)candidateA);
        if (countB > nums.Count()/3) result.Add((int)candidateB);

        return result;
    }
}