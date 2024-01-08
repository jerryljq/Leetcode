/*
Q125. Valid Palindrome
https://leetcode.com/problems/valid-palindrome/description

A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/
public class Solution {
    public bool IsPalindrome(string s) {
        int head = 0;
        int tail = s.Length-1;

        while (head <= tail) {
            var lowerHead = Char.ToLower(s[head]);
            var lowerTail = Char.ToLower(s[tail]);
            if (!this.IsAlphabetical(lowerHead)) {
                head += 1;
                continue;
            }

            if (!this.IsAlphabetical(lowerTail)) {
                tail -= 1;
                continue;
            }

            if (lowerHead != lowerTail) {
                return false;
            }

            head += 1;
            tail -= 1;
        }

        return true;
    }

    private bool IsAlphabetical(char c) {
        return (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');
    }
}