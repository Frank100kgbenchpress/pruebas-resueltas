from typing import List

class  DSU:
    
    def __init__(self, n):
        self.c = [i  for i in range(n)]
        self.h = [1 for i in range(n)]
        
    def setof(self, x):
        if x == self.c[x]:
            return x
        self.c[x] = self.setof(self.c[x])
        return self.c[x]
    
    def merge(self, x, y):
        x, y = self.setof(x), self.setof(y)
        
        if (x == y): return 0
        
        if (self.h[x] < self.h[y]): x, y = y, x
        
        self.c[y] = x
        self.h[x] += self.h[y]
        
        return 1

