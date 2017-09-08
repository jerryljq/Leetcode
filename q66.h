//
// Created by Jerry Li on 2017/9/6.
//

#ifndef LEETCODE_Q66_H
#define LEETCODE_Q66_H

#include "commons.h"

class Solution {
public:
    vector<int> plusOne(vector<int>& digits) {
        size_t size = digits.size();
        int temp = 0;
        for(int i = size-1; i >= 0; i--) {
            temp = digits[i] + 1;
            if(temp < 10) {
                digits[i] = temp;
                break;
            } else {
                digits[i] = temp - 10;
                if(i == 0)
                    digits.insert(digits.begin(), 1);
            }
        }

        return digits;
    }
};

#endif //LEETCODE_Q66_H
