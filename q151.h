//
// Created by Jerry Li on 2017/10/16.
//
/********************* Problem Specification *********************
  Given an input string, reverse the string word by word.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Update (2015-02-12):
For C programmers: Try to solve it in-place in O(1) space.
 ***************************** Solution **************************
 See the code and descriptions below.
 ** Consider "std::reverse() function in C++"
 ** Another solution: Reverse every word in place, then reverse whole string
 ** GOTO - Q186
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q151_H
#define LEETCODE_Q151_H

#include "commons.h"

class Solution {
public:
    void reverseWords(string &s) {
        std::vector<string> stack;
        int lastBegin = 0;
        bool countFlag = false;
        for(int i = 0; i <= s.size(); i++) {
            if(i != s.size()) {
                if(s[i] == ' ') {
                    if(countFlag) {
                        stack.push_back(s.substr(lastBegin, i-lastBegin));
                        countFlag = false;
                    }
                } else {
                    if(!countFlag) {
                        countFlag = true;
                        lastBegin = i;
                    }
                }
            } else {
                if(countFlag) stack.push_back(s.substr(lastBegin, i-lastBegin));
            }
            
        }
        s = "";
        for(int i = stack.size()-1; i >= 0; i--) {
            s += stack[i];
            if (i != 0) s += " ";
        }
    }
};
#endif;