class DSU:
    def __init__(self, N):
        self.Parent = list(range(N))
        self.Size = [1] * N

    def SetOf(self, x):
        if x == self.Parent[x]:
            return x
        self.Parent[x] = self.SetOf(self.Parent[x])
        return self.Parent[x]

    def Merge(self, x, y):
        x = self.SetOf(x)
        y = self.SetOf(y)
        if x == y:
            return False
        if self.Size[x] < self.Size[y]:
            x, y = y, x
        self.Parent[y] = x
        self.Size[x] += self.Size[y]
        return True

class Solution:
    def inside(self, i, j, n, m):
        return 0 <= i < n and 0 <= j < m

    def encode(self, i, j, m):
        return i * m + j

    def numOfIslands(self, n, m, operators):
        M = [[0] * m for _ in range(n)]
        DS = DSU(n * m)
        res = []
        cnt = 0
        xdir = [1, 0, -1, 0]
        ydir = [0, 1, 0, -1]

        for c in operators:
            i, j = c
            cnt += 1 - M[i][j]
            M[i][j] = 1
            for d in range(4):
                ni = i + xdir[d]
                nj = j + ydir[d]
                if self.inside(ni, nj, n, m) and M[ni][nj]:
                    cnt -= DS.Merge(self.encode(ni, nj, m), self.encode(i, j, m))
            res.append(cnt)

        return res


