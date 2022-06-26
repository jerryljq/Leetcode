/// https://leetcode.com/problems/count-servers-that-communicate/
/// They say this can also be solved by graph search or union-find.
/// Do they improve the performance?
public class Solution {
    public int CountServers(int[][] grid) {
        var rowServerCount = new int[grid.Count()];
        var columnServerCount = new int[grid[0].Count()];
        int allServerCount = 0;
        
        // i is row and j is column
        for(int i = 0; i < grid.Count(); ++i) {
            for(int j = 0; j < grid[0].Count(); ++j) {
                rowServerCount[i] += grid[i][j];
                columnServerCount[j] += grid[i][j];
                allServerCount += grid[i][j];
            }
        }
        
        for(int i = 0; i < grid.Count(); ++i) {
            for(int j = 0; j < grid[0].Count(); ++j) {
                if (grid[i][j] == 1) {
                    if (rowServerCount[i] == 1 && columnServerCount[j] == 1) {
                        allServerCount -= 1;
                    }
                }
            }
        }
        
        return allServerCount;
    }
}