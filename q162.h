//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
A peak element is an element that is greater than its neighbors.

Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.

The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.

You may imagine that num[-1] = num[n] = -∞.

For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.

click to show spoilers.

Note:
Your solution should be in logarithmic complexity.
 ***************************** Solution **************************
 See the code and descriptions below.
 * Modified binary search. First decide which side the number is in or cannot be in.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q162_H
#define LEETCODE_Q162_H

#include "commons.h"
class Solution {
public:
    bool isPeek(vector<int>& nums, int i) {
        if(i-1 < 0) return nums[i+1] < nums[i];
        if(i+1 == nums.size()) return nums[i-1] < nums[i];
        return (nums[i-1] < nums[i])&&(nums[i+1] < nums[i]);
    }
    
    int findPeakElement(vector<int>& nums) {
        if(nums.size() == 0 || nums.size() == 1) return 0;
        int low = 0;
        int high = nums.size()-1;
        while(low <= high) {
            int mid = (low+high)/2;
            if(isPeek(nums, mid)) return mid;
            if(nums[mid] < nums[mid+1]) {
                low = mid+1;
                continue;
            }
            if(nums[mid] < nums[mid-1]) {
                high = mid-1;
                continue;
            }
        }
    }
};
#endif