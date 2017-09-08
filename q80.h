//
// Created by Jerry Li on 2017/9/6.
//
/********************* Problem Specification *********************
 Follow up for "Remove Duplicates":
 What if duplicates are allowed at most twice?
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q80_H
#define LEETCODE_Q80_H

#include "commons.h"

class Solution {
public:
    int removeDuplicates(vector<int>& nums) {
        if(nums.size() > 0) {
            size_t size = nums.size();
            int firstElement = nums[0];
            bool hasSecondDuplicateAppeared = false;
            for(int i = 1; i < nums.size(); i++) {
                if(nums[i] == firstElement) {
                    if(hasSecondDuplicateAppeared) {
                        nums.erase(nums.begin() + i);
                        i -= 1;
                    } else {
                        hasSecondDuplicateAppeared = true;
                    }
                } else {
                    firstElement = nums[i];
                    hasSecondDuplicateAppeared = false;
                }
            }
            return nums.size();
        } else {
            return 0;
        }
    }
};

#endif //LEETCODE_Q80_H
