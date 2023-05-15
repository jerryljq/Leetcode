public class UnionFind {
    
    private int[] parent;
    
    public UnionFind(int n) {
        this.parent = new int[n];
        for (int i = 0; i < n; ++i) {
            this.parent[i] = i;
        }
    }
    
    public int find(int x) {
        while(this.parent[x] != x) {
            x = this.parent[x];
        }
        
        return x;
    }
    
    public bool merge(int a, int b) {
        int rootA = this.find(a);
        int rootB = this.find(b);
        
        if (rootA != rootB) {
            this.parent[rootA] = rootB;
            return true;
        }
        
        return false;
    }
}

public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        int groupCount = n;
        var unionFind = new UnionFind(n);
        
        var orderedLogs = logs.OrderBy(log => log[0]);
        
        foreach(var log in orderedLogs) {
            var groupConnected = unionFind.merge(log[1], log[2]);
            if (groupConnected) {
                groupCount -= 1;
            }
            
            if (groupCount == 1) {
                return log[0];
            }
        }
        
        return -1;
    }
}