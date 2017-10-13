//
// Created by Jerry Li on 2017/10/13.
//
/********************* Problem Specification *********************
Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q53_H
#define LEETCODE_Q53_H

#include "commons.h"

class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        if (nums.size() == 0) return 0;
        int dpArray[nums.size()];
        dpArray[0] = nums[0];
        for(int i = 1; i < nums.size(); i++) {
            if(dpArray[i-1] > 0) {
                dpArray[i] = dpArray[i-1] + nums[i];
            } else {
                dpArray[i] = nums[i];
            }
        }
        int result = dpArray[0];
        for(int i = 0; i < nums.size(); i++) {
            if(dpArray[i] > result) {
                result = dpArray[i];
            }
        }
        return result;
    }
};

#endif