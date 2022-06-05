public class Solution {
    public bool Exist(char[][] board, string word) {
        var candidateList = new List<(int i, int j)>();
        for(int i = 0; i < board.Length; ++i) {
            for(int j = 0; j < board[i].Length; ++j) {
                if (board[i][j] == word[0]) {
                    candidateList.Add((i, j));
                }
            }   
        }
        
        if (word.Length == 1) return candidateList.Count > 0;
        
        foreach (var candidate in candidateList) {
            if (Match(board, word, 0, candidate.Item1, candidate.Item2)) {
                return true;
            }
        }
        
        return false;
    }
    
    private bool Match(char[][]board, string word, int matchingIndex, int currentLeft, int currentRight) {

        if (matchingIndex == word.Length-1) return true;
        
        var currentCandidate = new List<(int i, int j)>();
        if (currentLeft + 1 < board.Length && board[currentLeft+1][currentRight] == word[matchingIndex+1] && board[currentLeft+1][currentRight] != '*') {
            currentCandidate.Add((currentLeft+1, currentRight));
        }
        
        if (currentLeft - 1 >= 0 && board[currentLeft-1][currentRight] == word[matchingIndex+1] && board[currentLeft-1][currentRight] != '*') {
            currentCandidate.Add((currentLeft-1, currentRight));
        }
        
        if (currentRight + 1 < board[0].Length && board[currentLeft][currentRight+1] == word[matchingIndex+1] && board[currentLeft][currentRight+1] != '*') {
            currentCandidate.Add((currentLeft, currentRight+1));
        }
        
        if (currentRight - 1 >= 0 && board[currentLeft][currentRight - 1] == word[matchingIndex+1] && board[currentLeft][currentRight-1] != '*') {
            currentCandidate.Add((currentLeft, currentRight-1));
        }
        
        var previousChar = board[currentLeft][currentRight];
        board[currentLeft][currentRight] = '*';
        foreach (var candidate in currentCandidate) {
            if (Match(board, word, matchingIndex+1, candidate.Item1, candidate.Item2)) {
                return true;
            }
        }
        
        board[currentLeft][currentRight] = previousChar;
            
        return false;
    }
}