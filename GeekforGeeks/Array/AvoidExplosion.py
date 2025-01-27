class Solution:
    def avoidExlosion(self, mix, n, danger, m):
        #code here
        
        cx =  [i for i in range(n+1)]
        hx =  [1 for i in range(n+1)]
        solve  =[]
        mergeLast = []
        
        def setof(i):
            if i == cx[i]:
                return i
            return setof(cx[i])

        def merge(a, b):
            a, b = setof(a), setof(b)
            if a == b:
                return
            
            if hx[b] > hx[a]:
                a, b = b, a
            
            mergeLast.append((a, b, cx[b]))
            hx[a] += hx[b]
            cx[b] = a
        
        for x in mix:
            a, b = x
            
            merge(a, b)
            
            
            foundE = False
            for d in danger:
                ae, be = d
                if setof(ae) == setof(be):
                    foundE = True
                    break
            
            solve.append("Yes" if not foundE else "No")
            
            if foundE:
                a, b, c = mergeLast[0]
                hx[a] -= hx[b]
                cx[b] = c
            
            mergeLast = []
                
            
        return solve


