//
// Created by Jerry Li on 2017/10/31.
//
/********************* Problem Specification *********************
 Imagine you have a special keyboard with the following keys:

Key 1: (A): Print one 'A' on screen.

Key 2: (Ctrl-A): Select the whole screen.

Key 3: (Ctrl-C): Copy selection to buffer.

Key 4: (Ctrl-V): Print buffer on screen appending it after what has already been printed.

Now, you can only press the keyboard for N times (with the above four keys), find out the maximum numbers of 'A' you can print on screen.

Example 1:
Input: N = 3
Output: 3
Explanation: 
We can at most get 3 A's on screen by pressing following key sequence:
A, A, A
Example 2:
Input: N = 7
Output: 9
Explanation: 
We can at most get 9 A's on screen by pressing following key sequence:
A, A, A, Ctrl A, Ctrl C, Ctrl V, Ctrl V
Note:
1 <= N <= 50
Answers will be in the range of 32-bit signed integer.
 ***************************** Solution **************************
 See the code and descriptions below.
 One method is DP. Please notice how to make the DP.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q651_H
#define LEETCODE_Q651_H

#include "commons.h"
class Solution {
public:
    int maxA(int N) {
        if(N == 0) return N;
        vector<int> result(N, 0);
        for(int s = 0; s < 3; s++) {
            result[s] = s+1;
        }
        
        for(int i = 3; i < N; i++) {
            result[i] = i+1;
            for(int j = 0; j <= i-3; j++) {
                int prevStep = result[j]*(i-j-1);
                if(prevStep > result[i])
                    result[i] = prevStep;
            }
        }
        
        return result[N-1];
    }
};
#endif