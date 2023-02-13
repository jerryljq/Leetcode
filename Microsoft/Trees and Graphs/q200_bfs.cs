/// https://leetcode.com/problems/number-of-islands/
/// BFS version of this question
public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0;
        
        for (int i = 0; i < grid.Count(); ++i) {
            for (int j = 0; j < grid[i].Count(); ++j) {
                if (grid[i][j] == '1') {
                    count += 1;
                    search(grid, i, j);
                }
            }
        }
        
        return count;
    }
    
    private void search(char[][] grid, int x, int y) {
        var colCount = grid.Count();
        var rowCount = grid[0].Count();
        
        if (x >= colCount || y >= rowCount || x < 0 || y < 0 || grid[x][y] == '0') {
            return;
        }
        
        grid[x][y] = '0';
        
        search(grid, x+1, y);
        search(grid, x, y+1);
        search(grid, x-1, y);
        search(grid, x, y-1);
    }
}