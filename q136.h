//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given an array of integers, every element appears twice except for one. Find that single one.
 Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?ove, the last stone will always be removed by your friend.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q136_H
#define LEETCODE_Q136_H

class Solution {
public:
    // This naive version is based on brute-force method. It requires O(n^2) time but no extra space.
    int singleNumber_naive(vector<int>& nums) {
        for (int i = 0; i < nums.size(); i++) {
            bool find = false;
            for (int j = 0; j < nums.size(); j++) {
                if(j != i) {
                    if (nums[i] == nums[j]) {
                        find = true;
                    }
                }
            }
            if (find == false) {
                return nums[i];
            }
        }
        return 0;
    }
    // This algorithm sorts the array first and then find the different number. The sort process takes O(n*log(n)) time with no more space
    int singleNumber_sort(vector<int>& nums) {
        sort(nums.begin(), nums.end());
        if(nums[0] != nums[1]) return nums[0];
        if(nums[nums.size()-1] != nums[nums.size()-2]) return nums[nums.size()-1];
        for(int i = 0; i < nums.size(); i++) {
            if(nums[i] == nums[i+1]) {
                i += 1;
            } else {
                return nums[i];
            }
        }
        return 0;
    }
    // The best method. This uses XOR logic computation. This method takes linear time and no extra space.
    int singleNumber_best(vector<int>& nums) {
        int result = 0;
        for(int i = 0; i < nums.size(); i++) {
            result = result ^ nums[i];
        }
        return result;
    }
};

#endif //LEETCODE_Q136_H
