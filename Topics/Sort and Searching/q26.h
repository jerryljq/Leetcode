//
// Created by Jerry Li on 2017/9/6.
//
/********************* Problem Specification *********************
 Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
 Do not allocate extra space for another array, you must do this in place with constant memory.
 * For a advanced version, refer to q80.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q26_H
#define LEETCODE_Q26_H

#include "commons.h"

class Solution {
public:
    int removeDuplicates(vector<int>& nums) {
        if(nums.size() > 0) {
            size_t size = nums.size();
            int firstElement = nums[0];
            for(int i = 1; i < nums.size(); i++) {
                if(nums[i] == firstElement) {
                    nums.erase(nums.begin() + i);
                    i -= 1;
                } else {
                    firstElement = nums[i];
                }
            }
            return nums.size();
        } else {
            return 0;
        }
    }
};

#endif //LEETCODE_Q26_H
