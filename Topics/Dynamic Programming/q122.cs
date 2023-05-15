/*
Question Link:
https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/

You are given an integer array prices where prices[i] is the price of a given stock on the ith day.

On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.

Find and return the maximum profit you can achieve.

See q123 for a more advanced version.
*/

public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Count() <= 1) return 0;

        int maxProfit = 0;

        for (int i = 1; i < prices.Count(); ++i) {
            if (prices[i] - prices[i-1] > 0) {
                maxProfit += prices[i] - prices[i-1];
            }
        }

        return maxProfit;
    }
}

