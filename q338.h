//
// Created by Jerry Li on 2017/3/18.
//

#ifndef LEETCODE_Q338_H
#define LEETCODE_Q338_H

#endif //LEETCODE_Q338_H

class Solution {
public:
    vector<int> countBits(int num) {
        vector<int> resultVector;
        resultVector.push_back(0);
        for(int i = 1; i <= num; i++) {
            if(i % 2 == 1) {
                resultVector.push_back(resultVector[i-1] + 1);
            } else {
                int refBitNumber = resultVector[i-1];
                int diffAND = i & (i-1);
                if(diffAND != 0) {
                    resultVector.push_back(resultVector[diffAND]+1);
                } else {
                    resultVector.push_back(1);
                }
            }
        }
        return resultVector;
    }
};