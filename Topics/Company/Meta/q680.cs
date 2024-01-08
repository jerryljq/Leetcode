/**
* 680. Valid Palindrome II
https://leetcode.com/problems/valid-palindrome-ii/description/
Given a string s, return true if the s can be palindrome after deleting at most one character from it.

Example 1:

Input: s = "aba"
Output: true
Example 2:

Input: s = "abca"
Output: true
Explanation: You could delete the character 'c'.
Example 3:

Input: s = "abc"
Output: false
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
**/
public class Solution {
    public bool ValidPalindrome(string s) {
        if (string.IsNullOrEmpty(s)) {
            return true;
        }

        int beginIndex = 0;
        int endIndex = s.Length - 1;

        while (beginIndex < endIndex) {
            if (s[beginIndex] != s[endIndex]) {
                return this.isPalindrome(s, beginIndex+1, endIndex) || this.isPalindrome(s, beginIndex, endIndex-1);
            }

            beginIndex += 1;
            endIndex -= 1;
        }

        return true;
    }

    private bool isPalindrome(string s, int beginIndex, int endIndex) {
        if (string.IsNullOrEmpty(s)) {
            return true;
        }

        while (beginIndex < endIndex) {
            if (s[beginIndex] != s[endIndex]) {
                return false;
            }
            beginIndex += 1;
            endIndex -= 1;
        }

        return true;
    }
}