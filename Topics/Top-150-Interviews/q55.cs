/*
Q55. Jump Game
https://leetcode.com/problems/jump-game/description

You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
 

Constraints:

1 <= nums.length <= 104
0 <= nums[i] <= 105
*/
public class Solution {
    public bool CanJump(int[] nums) {
        int c = nums.Count();
        var arrayList = new bool[c];
        arrayList[c-1] = true;

        for (int i = c-2; i >= 0; --i) {
            for (int step = 0; step <= nums[i]; ++step) {
                if (i + step < c) {
                    if (arrayList[i+step] == true) {
                        arrayList[i] = true;
                        break;
                    }
                } else {
                    arrayList[i] = false;
                    break;
                }
            }
        }

        return arrayList[0];
    }
}