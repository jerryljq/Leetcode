/*
Q93. Restore IP Addresses
https://leetcode.com/problems/restore-ip-addresses/description/

A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.

For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.

Example 1:

Input: s = "25525511135"
Output: ["255.255.11.135","255.255.111.35"]
Example 2:

Input: s = "0000"
Output: ["0.0.0.0"]
Example 3:

Input: s = "101023"
Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]
 

Constraints:

1 <= s.length <= 20
s consists of digits only.
*/
public class Solution {
    private List<string> result;
    public IList<string> RestoreIpAddresses(string s) {
        this.result = new List<string>();

        if (s.Length < 4) return this.result;

        this.FindValidIp(s, 0, 0, $"");

        return this.result;
    }

    private void FindValidIp(string s, int beginIndex, int depth, string prefix) {
        if (depth == 4) {
            if (beginIndex < s.Length) {
                // Invalid
                return;
            }
            // Add to final result and return
            this.result.Add(prefix.Substring(1));
        }

        int tempCumulate = 0;
        int i = beginIndex;
        while(i < s.Length) {
            tempCumulate = tempCumulate*10 + s[i] - '0';
            if (tempCumulate > 255) {
                break;
            }
            var ipPrefix = $"{prefix}.{s.Substring(beginIndex, i-beginIndex+1)}";
            FindValidIp(s, i+1, depth+1, ipPrefix);
            if (tempCumulate == 0) {
                break;
            }
            i += 1;
        }
    }
}