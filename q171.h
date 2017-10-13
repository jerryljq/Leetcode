//
// Created by Jerry Li on 2017/10/12.
//
/********************* Problem Specification *********************
 Given a column title as appear in an Excel sheet, return its corresponding column number.

 For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q171_H
#define LEETCODE_Q171_H

#include "commons.h"

class Solution {
public:
    int charToNum (char c) {
        if(c == 'A') return 1;
        else {
            return c-'A'+1;
        }
    }
    
    int titleToNumber(string s) {
        int result = 0;
        for(int i = 0; i < s.size(); i++) {
            result = result*26 + charToNum(s[i]);
        }
        return result;
    }
};

#endif