/// https://leetcode.com/problems/making-file-names-unique/
/// Don't over complicate this problem
/// But do keep track of the smallest possible number to append to folder name
public class Solution {
    public string[] GetFolderNames(string[] names) {
        var folderNameList = new Dictionary<string, int>();
        var result = new List<string>();
        
        foreach (var name in names) {
            if (!folderNameList.ContainsKey(name)) {
                result.Add(name);
                folderNameList.Add(name, 1);
            }
            else {
                // figure out the name
                int i = folderNameList[name];
                var newName = $"{name}({i})";
                while (folderNameList.ContainsKey(newName)) {
                    i++;
                    newName = $"{name}({i})";
                }
                result.Add(newName);
                folderNameList[name] = i;
                folderNameList[newName] = 1;
            }
        }
        
        return result.ToArray();
    }
}