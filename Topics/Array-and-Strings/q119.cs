// https://leetcode.com/problems/pascals-triangle-ii/
public class Solution {
    public IList<int> GetRow(int rowIndex) {
        var result = new List<IList<int>>();
        
        for (int i = 0; i < rowIndex+1; ++i) {
            if (i == 0) {
                result.Add(new List<int> {1});
            }
            else if (i == 1) {
                result.Add(new List<int> {1, 1});
            }
            else {
                var localResult = new List<int>{1};
                for (int j = 1; j < i; ++j) {
                    localResult.Add(result[i-1][j-1]+result[i-1][j]);
                }
                localResult.Add(1);
                result.Add(localResult);
            }
        }
        
        return result[rowIndex];
    }
}