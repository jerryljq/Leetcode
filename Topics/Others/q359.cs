public class Logger {

    private Dictionary<string, int> currentTime;
    
    public Logger() {
        this.currentTime = new Dictionary<string, int>();
    }
    
    public bool ShouldPrintMessage(int timestamp, string message) {
        if (currentTime.ContainsKey(message)) {
            if (timestamp >= currentTime[message]+10) {
                currentTime[message] = timestamp;
                return true;
            }
        }
        else 
        {
            currentTime[message] = timestamp;
            return true;
        }
        
        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */