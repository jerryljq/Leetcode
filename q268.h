//
// Created by Jerry Li on 2017/10/16.
//
/********************* Problem Specification *********************
  Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

For example,
Given nums = [0, 1, 3] return 2.

Note:
Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity? 
 ***************************** Solution **************************
 Obvious. GOTO q287.
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q268_H
#define LEETCODE_Q268_H

#include "commons.h"

class Solution {
public:
    int missingNumber(vector<int>& nums) {
        int result = 0;
        for(int i = 0; i < nums.size(); i++) {
            result += nums[i];
        }
        int idealResult = nums.size()*(nums.size()+1)/2;
        return idealResult - result;
    }
};
#endif //LEETCODE_Q268_H
