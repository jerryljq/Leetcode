//
// Created by Jerry Li on 2017/10/29.
//
/********************* Problem Specification *********************
Given a collection of intervals, merge all overlapping intervals.

For example,
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].
 ***************************** Solution **************************
 See the code and descriptions below.
 ******************************** End ****************************
*/
#ifndef LEETCODE_Q56_H
#define LEETCODE_Q56_H

#include "commons.h"
/**
 * Definition for an interval.
 * struct Interval {
 *     int start;
 *     int end;
 *     Interval() : start(0), end(0) {}
 *     Interval(int s, int e) : start(s), end(e) {}
 * };
 */
class Solution {
public:
    static bool sortHelp(Interval a, Interval b) {
        return a.start < b.start;
    }
    
    bool shouldMerge(Interval interval1, Interval interval2) {
        if(interval2.start <= interval1.end) return true;
        else return false;
    }
    
    Interval merge(Interval interval1, Interval interval2) {
        int newStart = 0;
        int newEnd = 0;
        if(interval1.start < interval2.start) newStart = interval1.start;
        else newStart = interval2.start;
        if(interval1.end > interval2.end) newEnd = interval1.end;
        else newEnd = interval2.end;
        
        return Interval(newStart, newEnd);
    }
    
    vector<Interval> merge(vector<Interval>& intervals) {
        if(intervals.size() == 0 || intervals.size() == 1) return intervals;
        std::sort(intervals.begin(), intervals.end(), sortHelp);
        
        for(int i = 1; i < intervals.size(); i++) {
            if(shouldMerge(intervals[i-1], intervals[i])) {
                Interval temp = merge(intervals[i-1], intervals[i]);
                intervals[i-1] = temp;
                intervals.erase(intervals.begin()+i);
                i -= 1;
            }
        }
        return intervals;
    }
};
#endif