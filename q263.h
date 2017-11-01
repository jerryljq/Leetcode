//
// Created by Jerry Li on 2017/10/31.
//
/********************* Problem Specification *********************
 Write a program to check whether a given number is an ugly number.

Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7.

Note that 1 is typically treated as an ugly number.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q263_H
#define LEETCODE_Q263_H

#include "commons.h"
class Solution {
public:
    bool isUgly(int num) {
        for(int i = 2; i < 6; i++) {
            if(num > 1) {
                while(num%i == 0)
                    num = num / i;
            } else {
                break;
            }
        }
        if(num == 1) return true;
        else return false;
    }
};
#endif