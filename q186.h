//
// Created by Jerry Li on 2017/10/16.
//
/********************* Problem Specification *********************
Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Could you do it in-place without allocating extra space? 
 ***************************** Solution **************************
 See the code and descriptions below.
 ** Consider "std::reverse() function in C++"
 ** Another solution: Reverse every word in place, then reverse whole string
 ** GOTO - Q151
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q186_H
#define LEETCODE_Q186_H

#include "commons.h"

class Solution {
public:
    void reverseWord(string &s, int begin, int end) {
        while(begin < end) {
            char temp = s[end];
            s[end] = s[begin];
            s[begin] = temp;
            end--;
            begin++;
        }  
    }
    
    void reverseWords(string &s) {
        int lastBegin = 0;
        bool flag = false;
        for(int i = 0; i <= s.size(); i++) {
            if(i == s.size()) {
                if(flag) {
                    reverseWord(s, lastBegin, i-1);
                    flag = false;
                }
            }
            if(s[i] == ' ') {
                if(flag) {
                    reverseWord(s, lastBegin, i-1);
                    flag = false;
                } else {
                    continue;
                }
            } else {
                if(!flag) {
                    flag = true;
                    lastBegin = i;
                } else {
                    continue;
                }
            }
        }
        
        reverseWord(s, 0, s.size()-1);
    }
};
#endif;