//
// Created by Jerry Li on 2017/09/06.
//
/********************* Problem Specification *********************
 Given an array and a value, remove all instances of that value in place and return the new length.
 Do not allocate extra space for another array, you must do this in place with constant memory.
 The order of elements can be changed. It doesn't matter what you leave beyond the new length.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q104_H
#define LEETCODE_Q104_H

#include "commons.h"

class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        vector<int>::iterator beginPos = nums.begin();
        for(int i = 0; i < nums.size(); i++) {
            if(nums[i] == val) {
                nums.erase(beginPos + i);
                i -= 1;
            }
        }
        return nums.size();
    }
};

#endif