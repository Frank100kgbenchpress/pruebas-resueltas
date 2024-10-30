public static class Solution
{
    public static void Main()
    {
        int[,] matrix = new int[,]{{0, 1, 1, 3},
                           {1, 0, 3, 1},
                           {1, 3, 0, 5},
                           {3, 1, 5, 0}};

        int[] start = new int[]{0, 3, 1, 1};
        int[] end = new int[]{0, 7, 2, 4};
        Map map = new Map(matrix, start, end);
        //Esto debe tener costo 7
        Console.WriteLine(GetRoutes(map, 2));
    }
    // 
    static int GetRoutes(Map map, int n)
    {
        n = map.N < n ? map.N : n;
        return GetRoute(new bool[map.N],n,0,0,0,int.MaxValue);
        int GetRoute(bool[] flag, int worker, int time,int totalTime,int actualPos,int bestTime)
        {
            if(worker == 0) return flag.All(x => x)? totalTime : bestTime;
            for(int i = 0 ; i < map.N;i++)
            {
                if(map.IsOnTime(i,time + map[actualPos,i]) && !flag[i] && time + map[actualPos,i] < bestTime)
                {
                    flag[i] = true;
                    bestTime = Math.Min(bestTime,GetRoute(flag,worker,time+map[actualPos,i],totalTime + +map[actualPos,i],i,bestTime));
                    flag[i] = false;
                }
            }
            return GetRoute(flag,worker-1,0,totalTime + map[actualPos,0],0,bestTime);
        }
        
    }

}