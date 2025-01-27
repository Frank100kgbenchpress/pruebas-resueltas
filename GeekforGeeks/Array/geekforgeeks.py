class Solution:
    
    #Function to find the smallest positive number missing from the array.
    def missingNumber(self,arr):
        #Your code here
        dp = {}
        for i in arr: 
            dp[i] = 1
        n = 1
        while dp.get(n):
            n += 1
        return n
    