//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.
 For example: Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.
 Follow up: Could you do it without any loop/recursion in O(1) runtime?
 ***************************** Solution **************************
 The results do not come randomly. Find the periodically rule.
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q258_H
#define LEETCODE_Q258_H

class Solution {
public:
    // A naive solution which contains two nested loops.
    int addDigits_naive(int num) {
        while (num / 10 > 0) {
            int tempNum = num;
            int result = 0;
            while (tempNum > 0) {
                result += tempNum % 10;
                tempNum = tempNum / 10;
            }
            num = result;
        }
        return num;
    }
    // This solution only takes O(1) time without any loop or recursion
    int addDigits(int num) {
        if (num == 0) return 0;
        if (num % 9 == 0) return 9;
        else return (num % 9);
    }
};

#endif //LEETCODE_Q258_H
