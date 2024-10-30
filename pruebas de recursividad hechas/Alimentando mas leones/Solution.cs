namespace Leones
{
    class Solution
    {
        public static int Solve(Map map, int[] capacities)
        {
            bool[] flag = new bool[map.M];
            return Backtrack(map, capacities, 0, 0,  0,flag,int.MaxValue,0 );
            int Backtrack(Map map,int[] capacities, int i , int workers ,  int distance,bool[]flag,int best,int total)
            {
                if (workers == capacities.Length) return flag.All(x => x == true) ? total : best;
                for(int j = 0 ; j < map.M ; j++)
                {
                    if(flag[j] == false && capacities[workers]-map.Demand[j] >= 0 && map[i,j]+distance < best)
                    {
                        flag[j] = true;
                        capacities[workers] -= map.Demand[j];
                        best = Math.Min(best, Backtrack(map, capacities, j, workers,  distance+map[i,j],flag,best,total+map[i,j]));
                        flag[j] = false;
                        capacities[workers] += map.Demand[j];
                    }
                }
                return Backtrack(map, capacities, 0, workers + 1,  0,flag,best,total+map[i,0]);
            }   
        }
    }   
}