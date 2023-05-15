public class Solution {
    public int MyAtoi(string s) {
        int result = 0;
        int sign = 1;
        int index = 0;
        
        while (index < s.Length) {
            if (s[index] == ' ') {
                index++;
                continue;
            }
            
            if (s[index] == '-') {
                sign = -1;
                index++;
            } else if (s[index] == '+') {
                index++;
            }
            
            break;
        }
        
        while (index < s.Length) {
            if (s[index] >= '0' && s[index] <= '9') {
                int nextDigit = s[index]-'0';
                if (result > Int32.MaxValue/10 || (result == Int32.MaxValue/10 && nextDigit > Int32.MaxValue%10)) {
                    return sign == 1? Int32.MaxValue : Int32.MinValue;
                }
                result = result*10+(s[index]-'0');
                
                index++;
                continue;
            }
            break;
        }
        
        return sign*result;
        
    }
}