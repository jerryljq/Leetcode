/**
Q169. Majority Element

Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

 

Example 1:

Input: nums = [3,2,3]
Output: 3
Example 2:

Input: nums = [2,2,1,1,1,2,2]
Output: 2

**/
public class Solution {
    // General solution
    // O(n) time
    // O(n) space 
    public int MajorityElement(int[] nums) {
        var dict = new Dictionary<int, int>();

        foreach (var num in nums) {
            if (!dict.ContainsKey(num)) {
                dict[num] = 1;
            } else {
                dict[num] += 1;
            }

            if (dict[num] > nums.Count()/2) {
                return num;
            }
        }

        return -1;
    }

    // Optimized solution
    // O(n) time
    // O(1) Space
    public int MajorityElement_Optimized(int[] nums) {
        int? candidate = null;
        int count = 0;

        foreach (var num in nums) {
            if (count == 0) {
                candidate = num;
            }

            if (candidate == num) {
                count += 1;
            } else {
                count -= 1;
            }
        }

        return (int)candidate;
    }
}