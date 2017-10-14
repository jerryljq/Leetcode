//
// Created by Jerry Li on 2017/10/13.
//
/********************* Problem Specification *********************
 Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q20_H
#define LEETCODE_Q20_H

#include "commons.h"

class Solution {
public:
    char reverse(char c) {
        if (c == ')') return '(';
        if (c == '}') return '{';
        if (c == ']') return '[';
        return 0;
    }
    bool isValid(string s) {
        std::vector<char> stack;
        for(int i = 0; i < s.size(); i++) {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{') {
                stack.push_back(s[i]);
            } else if (s[i] == ')' || s[i] == ']' || s[i] == '}') {
                if(stack.size() > 0 && stack.back() == reverse(s[i])) stack.pop_back();
                else return false;
            }
        }
        if(stack.size() > 0) return false;
        return true;
    }
};
#endif