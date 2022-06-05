/// https://leetcode.com/problems/design-in-memory-file-system/
/// Key point: Nothing, pay attention to details!!! Remember to sort the result for ls command.
public class FileSystem {

    private PathNode fileTree;
    
    public FileSystem() {
        fileTree = new PathNode("/");
    }
    
    public IList<string> Ls(string path) {
        if (string.IsNullOrEmpty(path)) {
            return new List<string>();
        }
        var result = new List<string>();
        if (path.Equals("/")) {
            result.AddRange(fileTree.folders.Keys.ToList());
            result.AddRange(fileTree.files.Keys.ToList());
            result.Sort();
            return result;
        }
        
        var fileNameBreakLoc = path.LastIndexOf('/');
        var realPath = path.Substring(0, fileNameBreakLoc);
        var fileName = path.Substring(fileNameBreakLoc+1, path.Length-fileNameBreakLoc-1);
        
        var folderNames = realPath.Split("/");
        PathNode currentNode = fileTree;
        foreach (var folderName in folderNames) {
            if (string.IsNullOrEmpty(folderName)) {
                continue;
            }
            if (currentNode.folders.ContainsKey(folderName)) {
                currentNode = currentNode.folders[folderName];
                // Console.WriteLine($"ls - currentNode is ${currentNode.pathName}");
            }
            else {
                result.Sort();
                return result;
            }
        }
        
        if (currentNode.files.ContainsKey(fileName)) {
            result.Add(fileName);
            result.Sort();
            return result;
        }
        
        if (!currentNode.folders.ContainsKey(fileName)) {
            result.Sort();
            return result;
        }
        
        currentNode = currentNode.folders[fileName];
        // Console.WriteLine($"ls - currentNode is ${currentNode.pathName}");
        
        result.AddRange(currentNode.folders.Keys.ToList());
        result.AddRange(currentNode.files.Keys.ToList());
        result.Sort();
        return result;
    }
    
    public void Mkdir(string path) {
        if (string.IsNullOrEmpty(path)) {
            return;
        }
        
        var folderNames = path.Split("/");
        PathNode currentNode = fileTree;
        foreach (var folderName in folderNames) {
            if (string.IsNullOrEmpty(folderName)) {
                continue;
            }
            if (!currentNode.folders.ContainsKey(folderName)) {
                currentNode.AddFolder(folderName);
            }
            currentNode = currentNode.folders[folderName];
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        var fileNameBreakLoc = filePath.LastIndexOf('/');
        if (fileNameBreakLoc < 0) return;
        var path = filePath.Substring(0, fileNameBreakLoc);
        var fileName = filePath.Substring(fileNameBreakLoc+1, filePath.Length-fileNameBreakLoc-1);
        
        var folderNames = path.Split("/");
        PathNode currentNode = fileTree;
        foreach (var folderName in folderNames) {
            if (string.IsNullOrEmpty(folderName)) {
                continue;
            }
            
            if (!currentNode.folders.ContainsKey(folderName)) {
                currentNode.AddFolder(folderName);
            }
            currentNode = currentNode.folders[folderName];
        }
        
        currentNode.AddFile(fileName, content);
    }
    
    public string ReadContentFromFile(string filePath) {
        var fileNameBreakLoc = filePath.LastIndexOf('/');
        if (fileNameBreakLoc < 0) return String.Empty;
        
        var path = filePath.Substring(0, fileNameBreakLoc);
        var fileName = filePath.Substring(fileNameBreakLoc+1, filePath.Length-fileNameBreakLoc-1);
        
        var folderNames = path.Split("/");
        PathNode currentNode = fileTree;
        foreach (var folderName in folderNames) {
            if (string.IsNullOrEmpty(folderName)) {
                continue;
            }
            
            if (!currentNode.folders.ContainsKey(folderName)) {
                return String.Empty;
            }
            currentNode = currentNode.folders[folderName];
        }
        
        if (currentNode.files.ContainsKey(fileName)) {
            return currentNode.files[fileName];
        }
        
        return String.Empty;
    }
}

public class PathNode {
    public string pathName;
    public Dictionary<string, PathNode> folders;
    public Dictionary<string, string> files;
    
    public PathNode(string pathName) {
        this.pathName = pathName;
        folders = new Dictionary<string, PathNode>();
        files = new Dictionary<string, string>();
    }
    
    public void AddFolder(string folderName) {
        folders.TryAdd(folderName, new PathNode(folderName));
        Console.WriteLine($"Added Folder {folderName}");
    }
    
    public void AddFile(string fileName, string content) {
        if (files.ContainsKey(fileName)) {
            files[fileName] = $"{files[fileName]}{content}";
            Console.WriteLine($"Appended file {fileName}");
        }
        else {
            files[fileName] = content;
            Console.WriteLine($"Added file {fileName}");
        }
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */