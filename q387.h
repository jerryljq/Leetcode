//
// Created by Jerry Li on 2017/10/26.
//
/********************* Problem Specification *********************
Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

Examples:

s = "leetcode"
return 0.

s = "loveleetcode",
return 2.
Note: You may assume the string contain only lowercase letters.
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q387_H
#define LEETCODE_Q387_H

#include "commons.h"

class Solution {
public:
    int firstUniqChar(string s) {
        std::map<char, int> charMap;
        for(int i = 0; i < s.size(); i++) {
            char temp = s[i];
            if(charMap.find(temp) == charMap.end()) {
                charMap.insert(std::pair<char, int>(temp, i));
            } else {
                charMap[temp] = -1;
            }
        }
        int minIndex = s.size();
        for(auto& it:charMap) {
            if(it.second != -1 && it.second < minIndex) {
                minIndex = it.second;
            }
        }
        if(minIndex == s.size()) minIndex = -1;
        return minIndex;
    }
};
#endif