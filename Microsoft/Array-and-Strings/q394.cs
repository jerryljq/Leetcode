/// https://leetcode.com/problems/decode-string/
/// Recursion and stack should be used.
public class Solution {
    public string DecodeString(string s) {
        return Decode(s, 0, s.Length-1);
    }
    
    private string Decode(string s, int begin, int end) {
        if (begin == end) {
            return s[begin].ToString();
        }
        
        int count = 1;
        var result = new StringBuilder();
        var stack = new Stack<(char, int)>();
        int index = begin;
        bool shouldIgnore = false;
        bool startCount = false;
        
        while (index <= end)
        {
            if (s[index] >= '0' && s[index] <= '9') {
                if (!shouldIgnore) {
                    if (startCount) {
                        count = count * 10 + s[index] - '0';
                    } else {
                        count = s[index] - '0';
                        startCount = true;
                    }
                }
                index += 1;
            } else if (s[index] == '[') {
                stack.Push(('[', index));
                index += 1;
                shouldIgnore = true;
                startCount = false;
            } else if (s[index] == ']') {
                var lastLeft = stack.Pop();
                if (stack.Count() == 0) {
                    var nextString = Decode(s, lastLeft.Item2+1, index-1);
                    for (int j = 0; j < count; ++j) {
                        result.Append(nextString);
                    }
                    count = 1;
                    shouldIgnore = false;
                }
                index += 1;
            } else {
                if (!shouldIgnore) {
                    result.Append(s[index]);
                }
                index += 1;
            }
        }        
        
        return result.ToString();
    }
}