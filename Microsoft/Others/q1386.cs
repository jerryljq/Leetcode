
/// https://leetcode.com/problems/cinema-seat-allocation/
/// Point: Maximun 2 groups per row, only process reserved rows as necessary.
public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        int result = 0;
        
        var reservedMap = new Dictionary<int, List<int>>();
        
        foreach (var reservedSeat in reservedSeats) {
            if (!reservedMap.ContainsKey(reservedSeat[0])) {
                reservedMap.Add(reservedSeat[0], new List<int>());
            }
            
            reservedMap[reservedSeat[0]].Add(reservedSeat[1]);
        }
        
        int rowCountToProcess = reservedMap.Keys.Count;
        result += 2*(n-rowCountToProcess);
        
        foreach (var rowToProcess in reservedMap.Keys) {
            var currentReservedSeats = reservedMap[rowToProcess];
            int targetGroupCount = 0;
            var reservedSeatAlloc = new int[10];
            foreach (int seat in currentReservedSeats) {
                reservedSeatAlloc[seat-1] = 1;
            }
            
            if (reservedSeatAlloc[3]+reservedSeatAlloc[4]+reservedSeatAlloc[5]+reservedSeatAlloc[6] == 0) {
                targetGroupCount += 1;
                if (reservedSeatAlloc[1]+reservedSeatAlloc[2]==0 && reservedSeatAlloc[7]+reservedSeatAlloc[8]==0) {
                    targetGroupCount += 1;
                }
            }
            else {
                if (reservedSeatAlloc[1]+reservedSeatAlloc[2]+reservedSeatAlloc[3]+reservedSeatAlloc[4]==0) {
                    targetGroupCount += 1;
                }
                
                if (reservedSeatAlloc[5]+reservedSeatAlloc[6]+reservedSeatAlloc[7]+reservedSeatAlloc[8]==0) {
                    targetGroupCount += 1;
                }
            }
            result += targetGroupCount;
        }
        
        return result;
    }
}