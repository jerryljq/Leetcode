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
#ifndef LEETCODE_Q121_H
#define LEETCODE_Q121_H

#include "commons.h"
class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int i = 0;
        int j = prices.size()-1;
        int max = 0;
        while(i < j) {
            if(prices[j] - prices[i] > max) {
                max = prices[j] - prices[i];
            }
            if(prices[i+1] < prices[i]) {
                i++;
            }
            if(prices[j-1] > prices[j]) {
                j--;
            }
            if(prices[i+1] > prices[i]&&prices[j-1] < prices[j])
                break;
        }
        return max;
    }
};
#endif