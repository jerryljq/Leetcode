/*
Q621. Task Scheduler
https://leetcode.com/problems/task-scheduler/description/

Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents a different task. Tasks could be done in any order. Each task is done in one unit of time. For each unit of time, the CPU could complete either one task or just be idle.
However, there is a non-negative integer n that represents the cooldown period between two same tasks (the same letter in the array), that is that there must be at least n units of time between any two same tasks.
Return the least number of units of times that the CPU will take to finish all the given tasks.

Example 1:

Input: tasks = ["A","A","A","B","B","B"], n = 2
Output: 8
Explanation: 
A -> B -> idle -> A -> B -> idle -> A -> B
There is at least 2 units of time between any two same tasks.
Example 2:

Input: tasks = ["A","A","A","B","B","B"], n = 0
Output: 6
Explanation: On this case any permutation of size 6 would work since n = 0.
["A","A","A","B","B","B"]
["A","B","A","B","A","B"]
["B","B","B","A","A","A"]
...
And so on.
Example 3:

Input: tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
Output: 16
Explanation: 
One possible solution is
A -> B -> C -> A -> D -> E -> A -> F -> G -> A -> idle -> idle -> A -> idle -> idle -> A

Constraints:

1 <= task.length <= 104
tasks[i] is upper-case English letter.
The integer n is in the range [0, 100].
*/
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var counter = new Dictionary<char, int>();
        var taskSet = new PriorityQueue<char, int>();
        foreach (var task in tasks) {
            if (!counter.ContainsKey(task)) {
                counter[task] = 0;
            }
            counter[task] += 1;
        }

        foreach (var pair in counter) {
            taskSet.Enqueue(pair.Key, -pair.Value);
        }

        int result = 0;
        int offset = 0;

        while (taskSet.Count > 0) {
            int roundTime = 0;
            var roundTask = new List<char>();
            while (roundTime <= n && taskSet.Count > 0) {
                var nextTask = taskSet.Dequeue();
                roundTask.Add(nextTask);
                counter[nextTask] -= 1;
                roundTime += 1;
            }

            if (n - roundTime >= 0) {
                offset = n - roundTime + 1;
                roundTime += offset;
            }

            result += roundTime;

            foreach (var task in roundTask) {
                if (counter[task] > 0) {
                    taskSet.Enqueue(task, -counter[task]);
                }
            }
        }

        return result - offset;
    }
}