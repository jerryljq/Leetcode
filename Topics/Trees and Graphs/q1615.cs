/// https://leetcode.com/problems/maximal-network-rank/
// Just an easy Graph problem, key point is only adjascent pairs will cause duplicate route.
public class Solution {
    private Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
    
    public int MaximalNetworkRank(int n, int[][] roads) {
        
        for (int i = 0; i < n; ++i) {
            map[i] = new List<int>();
        }
        
        for (int i = 0; i < roads.Count(); ++i) {
            Add(roads[i][0], roads[i][1]);
        }
        
        int result = 0;
        
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i == j) continue;
                
                int tempDist = map[i].Count + map[j].Count;

                if (map[i].Contains(j) && map[j].Contains(i)) {
                    tempDist-=1;
                }
                result = tempDist > result? tempDist : result;
            }
        }
        
        return result;
    }
    
    private void Add(int key, int value) {
        this.map[key].Add(value);
        this.map[value].Add(key);
    }
}