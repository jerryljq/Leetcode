/*
Question Link:
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

See q122 for an advanced version.

*/

public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Count() == 0) return 0;

        int leftMin = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < prices.Count(); ++i) {
            if (prices[i] <= leftMin) {
                leftMin = prices[i];
            } else {
                var profit = prices[i] - leftMin;
                if (profit >= maxProfit) {
                    maxProfit = profit;
                }
            }
        }

        return maxProfit;
    }
}