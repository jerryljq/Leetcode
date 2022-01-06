//
// Created by Jerry Li on 2021/01/18.
//
/********************* Problem Specification *********************
Write a function that reverses a string. The input string is given as an array of characters s.

Example 1:

Input: s = ["h","e","l","l","o"]
Output: ["o","l","l","e","h"]

Example 2:

Input: s = ["H","a","n","n","a","h"]
Output: ["h","a","n","n","a","H"]
 

Constraints:

1 <= s.length <= 105
s[i] is a printable ascii character.
 

Follow up: Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.

 /*
 **************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
using System;
using System.IO;
public class Solution {
    public void ReverseString(char[] s) {
        char temp;
        for (var i = 0; i <= s.Length/2-1; ++i) {
            temp = s[s.Length-1-i];
            s[s.Length-1-i] = s[i];
            s[i] = temp;
        }
    }
}