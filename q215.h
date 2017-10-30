//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

For example,
Given [3,2,1,5,6,4] and k = 2, return 5.

Note: 
You may assume k is always valid, 1 ≤ k ≤ array's length.
 ***************************** Solution **************************
 See the code and descriptions below.
 * Learned this Selection Algorithm in CMPT307
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q215_H
#define LEETCODE_Q215_H

#include "commons.h"
class Solution {
public:
    int findKthLargest(vector<int>& nums, int k) {
        if(nums.size() == 0) return -1;
        if(nums.size() == 1) return nums[0];
        return quickSelect(nums, k-1, 0, nums.size()-1);
    }
    
    void swap(vector<int>& nums, int a, int b) {
        int temp = nums[a];
        nums[a] = nums[b];
        nums[b] = temp;
    }
    
    int quickSelect(vector<int>& nums, int k, int begin, int end) {
        int pivot = nums[begin];
        int pivotIndex = begin;
        
        int j = begin+1;
        int m = end;
        
        while(j <= m) {
            if(nums[j] > pivot) {
                swap(nums, j, pivotIndex);
                pivotIndex = j;
                j++;
            } else {
                swap(nums, j, m);
                m--;
            }
        }
        if(pivotIndex == k) return pivot;
        else if(pivotIndex < k) return quickSelect(nums, k, pivotIndex+1, end);
        else return quickSelect(nums, k, begin, pivotIndex);
    }
};
#endif