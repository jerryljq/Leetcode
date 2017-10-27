//
// Created by Jerry Li on 2017/10/26.
//
/********************* Problem Specification *********************
 Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

 For example,
 Given the following matrix:

 [
  [ 1, 2, 3 ],
  [ 4, 5, 6 ],
  [ 7, 8, 9 ]
 ]
 You should return [1,2,3,6,9,8,7,4,5].
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q54_H
#define LEETCODE_Q54_H

#include "commons.h"
class Solution {
public:
    vector<int> spiralOrder(vector<vector<int>>& matrix) {
        vector<int> result;
        int topBound = 0;
        int botBound = matrix.size() -1;
        if(botBound == -1) return result;
        int leftBound = 0;
        int rightBound = matrix[0].size()-1;
        if(rightBound == -1) return result;
        while(leftBound <= rightBound || topBound <= botBound) {
            // left -> right
            if(topBound <= botBound) {
                for(int i = leftBound; i <= rightBound; i++) {
                    result.push_back(matrix[topBound][i]);
                }
                topBound += 1;
            }
            // up -> down
            if(leftBound <= rightBound) {
                for(int j = topBound; j <= botBound; j++) {
                    result.push_back(matrix[j][rightBound]);
                }
                rightBound -= 1;
            }
            // right -> left
            if(topBound <= botBound) {
                for(int k = rightBound; k >= leftBound; k--) {
                    result.push_back(matrix[botBound][k]);
                }
                botBound -= 1;
            }
            // bottom -> top
            if(leftBound <= rightBound) {
                for(int l = botBound; l >= topBound; l--) {
                    result.push_back(matrix[l][leftBound]);
                }
                leftBound += 1;
            }
        }
        return result;
    }
};
#endif