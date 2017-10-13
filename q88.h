//
// Created by Jerry Li on 2017/10/12.
//
/********************* Problem Specification *********************
 Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
 ***************************** Solution **************************
 See the code and descriptions below. From back is more efficient.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q88_H
#define LEETCODE_Q88_H

#include "commons.h"

class Solution {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) {
        int index1 = m-1;
        int index2 = n-1;
        int index = m+n-1;
        
        while(index1 >= 0 && index2 >= 0) {
            if(nums1[index1] > nums2[index2]) {
                nums1[index] = nums1[index1];
                index--;
                index1--;
            } else {
                nums1[index] = nums2[index2];
                index--;
                index2--;
            }
        }
        
        while(index2 >= 0) {
            nums1[index] = nums2[index2];
            index--;
            index2--;
        }
    }
};

#endif