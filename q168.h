//
// Created by Jerry Li on 2017/10/12.
//
/********************* Problem Specification *********************
 Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q168_H
#define LEETCODE_Q168_H

#include "commons.h"
class Solution {
public:
    char convert(int num) {
        if (num == 0) return 'Z';
        char baseline = 'A';
        return baseline + num - 1;
    }
    string convertToTitle(int n) {
        string result = "";
        vector<char> array;
        while(n > 0) {
            int remain = n % 26;
            char temp = convert(remain);
            array.push_back(temp);
            if(remain == 0) n = n/26 - 1;
            else n = n/26;
        }
        
        
        for(int i = array.size()-1; i >= 0; i--) {
            result.push_back(array[i]);
        }
        return result;
    }
};
#endif