import heapq
class Solution:

    def kthSmallest(self, arr,k):
        pq = []
        for i in arr:
            heapq.heappush(pq, -i)
            if len(pq) > k:
                heapq.heappop(pq)
        return -heapq.heappop(pq)