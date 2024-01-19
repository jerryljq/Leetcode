/**
* Q678. Valid Parenthesis String
* https://leetcode.com/problems/valid-parenthesis-string/description/
Companies
Given a string s containing only three types of characters: '(', ')' and '*', return true if s is valid.

The following rules define a valid string:

Any left parenthesis '(' must have a corresponding right parenthesis ')'.
Any right parenthesis ')' must have a corresponding left parenthesis '('.
Left parenthesis '(' must go before the corresponding right parenthesis ')'.
'*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string "".

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "(*)"
Output: true
Example 3:

Input: s = "(*))"
Output: true

Constraints:

1 <= s.length <= 100
s[i] is '(', ')' or '*'.
**/
public class Solution {
    public bool CheckValidString(string s) {
        var letterStack = new Stack<int>();
        var starStack = new Stack<int>();

        for(int i = 0; i < s.Length; ++i) {
            char c = s[i];
            if (c == '(') {
                letterStack.Push(i);
            } else if (c == ')') {
                if (letterStack.Count() > 0) {
                    letterStack.Pop();
                } else if (starStack.Count() > 0) {
                    starStack.Pop();
                } else {
                    return false;
                }
            } else {
                starStack.Push(i);
            }
        }

        while (letterStack.Count() > 0 && starStack.Count() > 0) {
            if (letterStack.Peek() < starStack.Peek()) {
                letterStack.Pop();
                starStack.Pop();
            } else {
                break;
            }
        }

        return letterStack.Count() > 0? false : true;
    }
}