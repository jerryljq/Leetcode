//
// Created by Jerry Li on 2017/4/22.
//

#ifndef LEETCODE_Q561_H
#define LEETCODE_Q561_H

#endif //LEETCODE_Q561_H

class Solution {
public:
    int arrayPairSum(vector<int>& nums) {
        // Python code provided
    }
};

// This question is solved in Python
/*
*************************************************
class Solution(object):
    def arrayPairSum(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        nums.sort()

        sum = 0;

        for i in range(0, len(nums)):
            if i % 2 == 0:
                sum += nums[i]

        return sum
*************************************************
*/