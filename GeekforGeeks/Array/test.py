class Solution(object):
    def countSubarrays(self, nums):
        """
        :type nums: List[int]
        :rtype: int
        """
        i = 0
        j = 2
        result = 0
        while j < len(nums):
            c = (i + j) / 2
            if nums[c]/2 == nums[i]+ nums[j]:
                result +=1
            i+=1
            j+=1
        return result