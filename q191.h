//
// Created by Jerry Li on 2017/10/26.
//
/********************* Problem Specification *********************
Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3. 
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q191_H
#define LEETCODE_Q191_H

#include "commons.h"

class Solution {
public:
    int hammingWeight(uint32_t n) {
        int result = 0;
        while(n != 0) {
            n = n &(n-1);
            result += 1;
        }
        return result;
    }
};
#endif;