//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.
 ***************************** Solution **************************
 See the code and descriptions below.
 * Modified binary search. First decide which side the number is in or cannot be in.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q33_H
#define LEETCODE_Q33_H

#include "commons.h"

class Solution {
public:
    int search(vector<int>& nums, int target) {
        int low = 0;
        int high = nums.size()-1;
        
        if(high == -1) return -1;
        
        while(low < high) {
            int mid = (low+high)/2;
            if(nums[mid] == target) return mid;
            if(nums[low] > nums[mid]) {
                // Peak in left
                if(target <= nums[high] && target > nums[mid]) {
                    low = mid+1;
                } else {
                    high = mid-1;
                }
            } else {
                // Peak in right
                if(target < nums[mid] && target >= nums[low]) {
                    high = mid-1;
                } else{
                    low = mid+1;
                }
            }   
        }
        
        if(nums[low] == target) return low;
        else return -1;
    }
};
#endif