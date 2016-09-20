//
// Created by Jerry Li on 2016/9/20.
//
/********************* Problem Specification *********************
 Given two strings s and t which consist of only lowercase letters.
 String t is generated by random shuffling string s and then add one more letter at a random position.
 Find the letter that was added in t.
 ***************************** Solution **************************
 The idea is similar to q136, use logic XOR.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q389_H
#define LEETCODE_Q389_H

class Solution {
public:
    // This solution gives O(s+t) time complexity, which is linear
    char findTheDifference(string s, string t) {
        int result = 0;
        for(int i = 0; i < s.size(); i++) {
            result = result ^ (int)s[i];
        }
        for(int j = 0; j < t.size(); j++) {
            result = result ^ (int)t[j];
        }
        return (char)result;
    }
};

#endif //LEETCODE_Q389_H
