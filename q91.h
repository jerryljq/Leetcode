//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given an encoded message containing digits, determine the total number of ways to decode it.

For example,
Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

The number of ways decoding "12" is 2.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q91_H
#define LEETCODE_Q91_H

#include "commons.h"
class Solution {
public:
    int numDecodings(string s) {
        if(s.size() == 0) {
            return 0;
        }

        std::vector<int> result(s.size(), 0);
        // Pay attention to deal with the first two values!!
        if(s[0] != '0')
            result[0] = 1;
        if(s[1] == '0') {
            if(s[0] >= '3')
                result[1] = 0;
            else 
                result[1] = result[0];
        } else if(s[0] >= '3' || (s[0] == '2' && s[1] > '6')) {
            result[1] = result[0];
        } else {
            if(s[0] == '0')
                result[1] = 0;
            else 
                result[1] = result[0]+1;
        }
        // result.push_back(2);
        for(int i = 2; i < s.size(); i++) {
            if(s[i] >= '1' && s[i] <= '9') {
                result[i] += result[i-1];
            }
            if(s[i-1]=='1' || (s[i-1]=='2' && s[i] <= '6') ) {
                result[i] += result[i-2];
            }
        }
        return result[s.size()-1];
    }
};
#endif