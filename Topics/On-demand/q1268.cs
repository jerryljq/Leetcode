/*
Q1268. Search Suggestions System
https://leetcode.com/problems/search-suggestions-system/description/

You are given an array of strings products and a string searchWord.
Design a system that suggests at most three product names from products after each character of searchWord is typed. Suggested products should have common prefix with searchWord. If there are more than three products with a common prefix return the three lexicographically minimums products.
Return a list of lists of the suggested products after each character of searchWord is typed.

Example 1:
Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
Output: [["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]]
Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"].
After typing m and mo all products match and we show user ["mobile","moneypot","monitor"].
After typing mou, mous and mouse the system suggests ["mouse","mousepad"].
Example 2:
Input: products = ["havana"], searchWord = "havana"
Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
Explanation: The only word "havana" will be always suggested while typing the search word.

Constraints:
1 <= products.length <= 1000
1 <= products[i].length <= 3000
1 <= sum(products[i].length) <= 2 * 104
All the strings of products are unique.
products[i] consists of lowercase English letters.
1 <= searchWord.length <= 1000
searchWord consists of lowercase English letters.
*/
public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        var result = new List<IList<string>>();
        var trie = new Trie();
        foreach (var product in products) {
            trie.Add(product);
        }

        Console.WriteLine("Added Trie");
        
        for (int i = 1; i <= searchWord.Length; ++i) {
            var searchString = searchWord.Substring(0, i);
            var trieNode = trie.FindNodeForPrefix(searchString);
            if (trieNode == null) {
                result.Add(new List<string>());
            } else {
                var words = trieNode.GetWords();
                result.Add(words);
            }
        }

        return result;
    }
}

public class TrieNode {
    public TrieNode[] SubTries {get; set;}
    public bool IsWord {get; set;}
    public string prefix {get; set;}

    public TrieNode(string prefix = "") {
        this.SubTries = new TrieNode[26];
        for (int i = 0; i < 26; ++i) {
            this.SubTries[i] = null;
        }
        this.IsWord = false;
        this.prefix = prefix;
    }

    public IList<string> GetWords() {
        var result = new List<string>();
        var stack = new Stack<TrieNode>();
        stack.Push(this);

        while (result.Count < 3 && stack.Count() > 0) {
            var node = stack.Pop();
            if (node.IsWord == true) {
                result.Add(node.prefix);
            }
            for (int i = 25; i >= 0; --i) {
                if (node.SubTries[i] != null) {
                    stack.Push(node.SubTries[i]);
                }
            }
        }

        return result;
    }
}

public class Trie {
    private TrieNode root;

    public Trie() {
        this.root = new TrieNode();
    }

    public void Add(string word) {
        var currentNode = this.root;
        for (int i = 0; i < word.Length; ++i) {
            int index = word[i] - 'a';
            var newNode = currentNode.SubTries[index];
            if (newNode == null) {
                newNode = new TrieNode($"{currentNode.prefix}{word[i]}");
            }
            if (i == word.Length-1) {
                newNode.IsWord = true;
            }
            currentNode.SubTries[index] = newNode;
            currentNode = newNode;
        }
    }

    public TrieNode FindNodeForPrefix(string prefix) {
        var currentNode = this.root;
        for (int i = 0; i < prefix.Length; ++i) {
            if (currentNode.SubTries[prefix[i] - 'a'] == null) {
                return null;
            }

            currentNode = currentNode.SubTries[prefix[i] - 'a'];
        }

        return currentNode;
    }
}