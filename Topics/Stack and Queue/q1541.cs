/// https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string/
/// Stack
public class Solution {
    public int MinInsertions(string s) {
        var stack = new Stack<char>();
        int count = 0;
        int i = 0;
        
        while(i < s.Length) {
            if (s[i] == '(') {
                stack.Push(s[i]);
                i++;
            }
            else {
                if (stack.Count != 0 && stack.Peek() == '(') {
                    // Check if next is )
                    if (i < s.Length-1 && s[i+1] == ')') {
                        stack.Pop();
                        i += 2;
                        continue;
                    } else {
                        stack.Pop();
                        count += 1;
                        i += 1;
                        continue;
                    }
                } else {
                    if (i < s.Length-1 && s[i+1] == ')') {
                        i += 2;
                        count += 1;
                        continue;
                    } else if (i < s.Length-1 && s[i+1] == '(') {
                        i += 1;
                        count += 2;
                        continue;
                    } else {
                        stack.Push(s[i]);
                        i++;
                    }
                }
            }
        }
        
        int leftCount = 0;
        int rightCount = 0;
        foreach(char c in stack) {
            if (c == '(') {
                leftCount += 1;
            }
            else {
                rightCount += 1;
            }
        }
        
        return count + rightCount/2 + 2*(rightCount%2) + 2*leftCount;
    }
}