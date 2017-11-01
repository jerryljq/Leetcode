//
// Created by Jerry Li on 2017/10/31.
//
/********************* Problem Specification *********************
 Description:

Count the number of prime numbers less than a non-negative number, n.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q204_H
#define LEETCODE_Q204_H

#include "commons.h"
class Solution {
public:
    int countPrimes(int n) {
        std::vector<bool> isPrime(n, true);
        isPrime[0] = false;
        int count = 0;
        for(int i = 2; i < n; i++) {
            if(isPrime[i-1] == true) {
                count += 1;
                for(int j = 2; i*j < n; j++) {
                    isPrime[i*j-1] = false;
                }
            }
        }
        return count;
    }
};
#endif