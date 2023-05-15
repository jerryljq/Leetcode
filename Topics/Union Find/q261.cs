public class UnionFind {
    private int[] parent;
    
    public UnionFind(int n) {
        this.parent = new int[n];
        for (int i = 0; i < n; ++i) {
            this.parent[i] = i;
        }
    }
    
    public int findRoot(int n) {
        while(this.parent[n] != n) {
            n = this.parent[n];
        }
        
        return n;
    }
    
    public bool merge(int a, int b) {
        int rootA = this.findRoot(a);
        int rootB = this.findRoot(b);
        
        if (rootA == rootB) {
            return false;
        }
        
        this.parent[rootA] = rootB;
        return true;
    }
}


public class Solution {
    
    public bool ValidTree(int n, int[][] edges) {
        
        if (edges.Count() != n-1) return false;
        
        var unionFind = new UnionFind(n);
        
        foreach(var edgePair in edges) {
            if (unionFind.merge(edgePair[0], edgePair[1]) == false) {
                return false;
            }
        }
        
        return true;
    }
}