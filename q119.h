//
// Created by Jerry Li on 2016/9/6.
//

#ifndef LEETCODE_Q119_H
#define LEETCODE_Q119_H

#include "commons.h"

class Solution {
public:
    vector<int> getRow(int rowIndex) {
        vector<int> result;
        if(rowIndex == 0) {
            result.push_back(1);
            return result;
        }
        double fac[rowIndex+1];
        fac[0] = 1.00;
        for(int i = 1; i < rowIndex+1; i++) {
            fac[i] = (double)i * fac[i-1];
        }
        for(int k = 0; k < rowIndex+1; k++) {
            double temp = fac[rowIndex]/fac[rowIndex-k]/fac[k];
            string vartemp = std::to_string(temp);
            int temp2 = atoi(vartemp.c_str());
            result.push_back(temp2);
        }
        return result;
    }
};

#endif //LEETCODE_Q119_H
