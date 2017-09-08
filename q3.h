//
// Created by Jerry Li on 2017/9/7.
//
/********************* Problem Specification *********************
 Given a string, find the length of the longest substring without repeating characters.
 Examples:
 Given "abcabcbb", the answer is "abc", which the length is 3.
 Given "bbbbb", the answer is "b", with the length of 1.
 Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/

#ifndef LEETCODE_Q3_H
#define LEETCODE_Q3_H

#include "commons.h"

class Solution {
public:
    int lengthOfLongestSubstring(string s) {
        int length = 0;
        int begin = 0, end = 0;
        int size = s.size();
        set<char> charCollection;

        while(begin < size && end < size) {
            if(charCollection.find(s[end]) == charCollection.end()) {
                charCollection.insert(s[end]);
                end++;
                if(end - begin > length)
                    length = end - begin;
            } else {
                charCollection.erase(s[begin]);
                begin++;
            }
        }
        
        return length;
    }
};

#endif //LEETCODE_Q3_H
