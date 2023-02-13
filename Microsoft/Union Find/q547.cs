public class Solution {
    public int FindCircleNum(int[][] isConnected) {
        int cityCount = isConnected.Count();
        int[] root = new int[cityCount];
        int result = 0;
        
        for (int a = 0; a < cityCount; ++a) {
            root[a] = a;
        }
        
        for (int i = 0; i < isConnected.Count(); ++i) {
            for (int j = i+1; j < isConnected[i].Count(); ++j) {
                if (isConnected[i][j] == 1) {
                    // Console.WriteLine("hahaha");
                    int preRootJ = root[j];
                    int preRootI = root[i];
                    for(int b = 0; b < root.Count(); ++b) {
                        // int preRootB = root[b];
                        if (root[b] == preRootJ) {
                            root[b] = preRootI;
                        }
                        // Console.WriteLine($"{root[b]}, {root[i]}, {root[j]}, {preRootB}");
                    }
                    // Console.WriteLine("hahaha done");
                }
            }
        }
        
        for (int a = 0; a < cityCount; ++a) {
            // Console.WriteLine(root[a]);
            if (root[a] == a) {
                result += 1;
            }
        }
        
        return result;
    }
}