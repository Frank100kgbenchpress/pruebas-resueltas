public static class Solution
{
    public static int Solve(Map map, int[] capacities) => Solve(map, capacities, new bool[map.M], 0, 0, 0, 0, int.MaxValue);
    static int Solve(Map map, int[] capacities, bool[] flag, int actualPosition, int actualKart, int actualTime, int totalTime , int best)
    {
        if(actualKart == capacities.Length)  return flag.All(x => x)? totalTime:best;
        for(int i=0;i<map.M;i++)
        {
            if(!flag[i] && map.Demand[i]<= capacities[actualKart] && map[actualPosition,i] + actualTime < best)
            {
                flag[i] = true;
                capacities[actualKart] -= map.Demand[i];
                best = Math.Min(Solve(map,capacities,flag,i,actualKart,actualTime + map[actualPosition,i],totalTime+map[actualPosition,i],best),best);
                capacities[actualKart] += map.Demand[i];
                flag[i] = false;
            }
        }
        return Solve(map,capacities,flag,0,actualKart+1,0,totalTime+map[actualPosition,0],best);
    }
    
}























/*static int Solve(Map map, int[] capacities, bool[] visited, int actualPosition, int actualKart, int actualTime, int totalTime, int bestTime)
    {
        if (actualKart == capacities.Length)
        {
            var allLionsWereVisited = visited.All(x => x == true);
            return allLionsWereVisited ? totalTime : bestTime;
        }

        for (int i = 0; i < map.M; i++)
        {
            if (!visited[i] && map.Demand[i] <= capacities[actualKart] && map[actualPosition, i] + actualTime < bestTime)
            {
                visited[i] = true;
                capacities[actualKart] -= map.Demand[i];
                bestTime = Math.Min(bestTime, Solve(map, capacities, visited, i, actualKart, actualTime + map[actualPosition, i], totalTime + map[actualPosition, i], bestTime));
                capacities[actualKart] += map.Demand[i];
                visited[i] = false;
            }
        }

        return Solve(map, capacities, visited, 0, actualKart + 1, 0, totalTime + map[actualPosition, 0], bestTime);
    }*/
