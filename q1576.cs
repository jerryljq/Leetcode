//
// Created by Jerry Li on 2021/01/18.
//
/********************* Problem Specification *********************
Given a string s containing only lower case English letters and the '?' character, convert all the '?' characters into lower case letters such that the final string does not contain any consecutive repeating characters. You cannot modify the non '?' characters.

It is guaranteed that there are no consecutive repeating characters in the given string except for '?'.

Return the final string after all the conversions (possibly zero) have been made. If there is more than one solution, return any of them. It can be shown that an answer is always possible with the given constraints.

Example 1:

Input: s = "?zs"
Output: "azs"
Explanation: There are 25 solutions for this problem. From "azs" to "yzs", all are valid. Only "z" is an invalid modification as the string will consist of consecutive repeating characters in "zzs".
Example 2:

Input: s = "ubv?w"
Output: "ubvaw"
Explanation: There are 24 solutions for this problem. Only "v" and "w" are invalid modifications as the strings will consist of consecutive repeating characters in "ubvvw" and "ubvww".
Example 3:

Input: s = "j?qg??b"
Output: "jaqgacb"
Example 4:

Input: s = "??yw?ipkj?"
Output: "acywaipkja"
 

Constraints:

1 <= s.length <= 100
s contains only lower case English letters and '?'.

 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
using System;
using System.IO;

public class Solution {
    public string ModifyString(string s) {
        var strBuilder = new StringBuilder(s);
        for (int i = 0; i < s.Length; ++i) {
            if (s[i] == '?') {
                for (char charToReplace = 'a'; charToReplace <= 'z'; ++charToReplace) {
                    if (IsReplacementValid(strBuilder, i-1, charToReplace) && IsReplacementValid(strBuilder, i+1, charToReplace)) {
                        strBuilder[i] = charToReplace;
                        break;
                    }
                }
            }
        }
        
        return strBuilder.ToString();
    }
    
    private bool IsReplacementValid (StringBuilder s, int indexToVerify, char charToReplace) {
        if (indexToVerify < 0 || indexToVerify >= s.Length) {
            return true;
        }
        else {
            if (s[indexToVerify] == '?' || s[indexToVerify] != charToReplace) {
                return true;
            }
        }
        
        return false;
    }
}