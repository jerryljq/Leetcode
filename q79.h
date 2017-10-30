//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

For example,
Given board =

[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.
 ***************************** Solution **************************
 See the code and descriptions below.
 * To avoid extra space, replace the board's char with sth like '\0' and change it back afterwards.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q79_H
#define LEETCODE_Q79_H

#include "commons.h"
class Solution {
public:
    
    int m;
    int n;
    
    bool exist(vector<vector<char>>& board, string word) {
        m = board.size();
        if(m == 0) return false;
        else {
            n = board[0].size();
        }
        for(int i = 0; i < m; i++) {
            for(int j = 0; j < n; j++) {
                if(find(board, word, i, j, 0)) {
                    return true;
                }
            }
        }
        return false;
    }
    
    bool find(vector<vector<char>>& board, string word, int i, int j, int wordIndex) {
        if(wordIndex == word.size()) return true;
        if(!(i < m) || !(j < n)) return false;
        if((i < 0) || (j < 0)) return false;
        if(word[wordIndex] != board[i][j]) return false;
        if(board[i][j] == '\0') return false;
        
        board[i][j] = '\0';
        bool left, right, up, down;
        left = find(board, word, i, j-1, wordIndex +1);
        right = find(board, word, i, j+1, wordIndex +1);
        up = find(board, word, i-1, j, wordIndex +1);
        down = find(board, word, i+1, j, wordIndex +1);
        if(left||right||up||down) return true;
        else {
            board[i][j] = word[wordIndex];
            return false;
        }
    }
};
#endif