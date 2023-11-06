/*
Q20. Valid Parentheses

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false
 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
*/
public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach(var c in s) {
            switch(c) {
                case '{':
                case '[':
                case '(':
                    stack.Push(c);
                    break;
                case '}':
                case ']':
                case ')':
                default:
                    if (stack.Count > 0 && this.IsPair(stack.Peek(), c)) {
                        stack.Pop();
                    } else {
                        return false;
                    }
                    break;
            }
        }

        return stack.Count == 0;
    }

    private bool IsPair(char a, char b) {
        switch(a) {
            case '(':
                return b == ')';
            case '{':
                return b == '}';
            case '[':
                return b == ']';
        }

        return false;
    }
}