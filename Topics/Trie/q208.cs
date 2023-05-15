/// https://leetcode.com/problems/implement-trie-prefix-tree/
public class Trie {

    private TrieNode root;
    
    public Trie() {
        this.root = new TrieNode();
    }
    
    public void Insert(string word) {
        var currentNode = root;
        
        foreach (char c in word) {
            if (!currentNode.nodeList.ContainsKey(c)) {
                currentNode.nodeList[c] = new TrieNode();
            }
            currentNode = currentNode.nodeList[c];
        }
        
        currentNode.IsWord = true;
    }
    
    public bool Search(string word) {
        var currentNode = root;
        
        foreach (char c in word) {
            if (!currentNode.nodeList.ContainsKey(c)) {
                return false;
            }
            currentNode = currentNode.nodeList[c];
        }
        
        return currentNode.IsWord;
    }
    
    public bool StartsWith(string prefix) {
        var currentNode = root;
        
        foreach (char c in prefix) {
            if (!currentNode.nodeList.ContainsKey(c)) {
                return false;
            }
            currentNode = currentNode.nodeList[c];
        }
        
        return true;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> nodeList = new Dictionary<char, TrieNode>();
    public bool IsWord { get; set; } = false;
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */