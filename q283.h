//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
 For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].
 Note: You must do this in-place without making a copy of the array. Minimize the total number of operations.
 ***************************** Solution **************************

 ******************************** End ****************************
*/
#ifndef LEETCODE_Q283_H
#define LEETCODE_Q283_H

#include "commons.h"

class Solution {
public:
    // This seems to be an O(n^2) algorithm
    void moveZeroes(vector<int>& nums) {
        int numberOfZero = 0;
        for(int i = 0; i < nums.size(); i++) {
            if(nums[i] == 0) {
                // Erase method has linear time complexity
                nums.erase(nums.begin() + i);
                i-=1;
                numberOfZero += 1;
            }
        }
        for(int j = 0; j < numberOfZero; j++) {
            nums.push_back(0);
        }
    }
};

#endif //LEETCODE_Q283_H
