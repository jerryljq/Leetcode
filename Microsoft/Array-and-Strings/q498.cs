// https://leetcode.com/problems/diagonal-traverse/
public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        int m = mat.Count();
        int n = mat[0].Count();
        var result = new List<int>();
        
        // initial
        int i = 0, j = 0;
        bool direction = true; // true means up and false means down
        for (int index = 0; index < m+n-1; ++index) {
            while (i+j <= index && i < m && j < n) {
                if (direction == false) {
                    while (j >= 0 && i < m && j < n) {
                        result.Add(mat[i][j]);
                        
                        if (i + 1 == m) {
                            j += 1;
                            break;
                        }
                        
                        if (j == 0) {
                            i += 1;
                            break;
                        }
                        
                        j -= 1;
                        i += 1;
                    }
                }
                else {
                    while (i >= 0 && i < m && j < n) {
                        result.Add(mat[i][j]);
                        
                        if (j + 1 == n) {
                            i += 1;
                            break;
                        }
                        
                        if (i == 0) {
                            j += 1;
                            break;
                        }
                        
                        i -= 1;
                        j += 1;
                    }
                }
            }
            
            direction = !direction;
        }
        
        return result.ToArray();
    }
}