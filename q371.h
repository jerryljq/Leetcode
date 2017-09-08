//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 *  Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.
    Example:
    Given a = 1 and b = 2, return 3.
 ***************************** Solution **************************
 *  See computer organization course material.
 *  Reference: http://www.cnblogs.com/kiven-code/archive/2012/09/15/2686922.html
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q371_H
#define LEETCODE_Q371_H

#include "commons.h"

class Solution {
public:
    int getSum(int a, int b) {

        int tmp1 = a;
        int tmp2 = b;

        while (tmp2 != 0) {
            int tmp3 = tmp1;
            tmp1 = tmp1 ^ tmp2;
            tmp2 = (tmp3 & tmp2) << 1;
        }

        return tmp1;
    }
};

#endif //LEETCODE_Q371_H
