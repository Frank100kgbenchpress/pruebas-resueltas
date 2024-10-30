//sin memorizacion y se va de tiempo
public class Solution 
{
    public int CherryPickup(int[][] grid) 
    {
        bool[,] mask = new bool[grid.Length,grid[0].Length];
        return Backtrack(grid,mask,0,0,0);    
    }
    int Backtrack(int[][]grid,bool[,] mask , int i,int j, int counter)
    {
        if(InvalidMove(grid,mask,i,j)) return 0;
        counter += grid[i][j];
        if(i == grid.Length-1 && j == grid[0].Length-1) return counter;
        
        mask[i,j] = true;
        int solve = Math.Max
        (
            Math.Max(Backtrack(grid,mask,i+1,j,counter),
            Backtrack(grid,mask,i-1,j, counter)),
            Math.Max(Backtrack(grid,mask,i,j+1, counter),
            Backtrack(grid,mask,i,j-1, counter))
        );
        mask[i,j] = false;
        return solve;
    }
    bool InvalidMove(int[][]grid,bool[,]mask,int i ,int j) => i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || mask[i,j] || grid[i][j] < 0;
}
//dp con array
public class Solution2 
{
    public int CherryPickup(int[][] grid) 
    {
        int n = grid.Length;
        int[,,,] dp = new int[n, n, n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    for (int l = 0; l < n; l++)
                        dp[i, j, k, l] = -2;
        
        int count(int x1, int y1, int x2, int y2)
        {
            if (x1 >= n || y1 >= n || x2 >= n || y2 >= n || grid[x1][y1] == -1 || grid[x2][y2] == -1)
                return -1;
            if (dp[x1, y1, x2, y2] > -2)
                return dp[x1, y1, x2, y2];
            int[] options = new int[]{count(x1 + 1, y1, x2 + 1, y2),
                                    count(x1, y1 + 1, x2 + 1, y2),
                                    count(x1, y1 + 1, x2, y2 + 1),
                                    count(x1 + 1, y1, x2, y2 + 1) };

            int collectedThisMove = grid[x1][y1] + grid[x2][y2];
            if (x1 == x2 && y1 == y2)
                collectedThisMove /= 2;
            int max = options.Max();
            if (max == -1)
                dp[x1, y1, x2, y2] = -1;
            else
                dp[x1, y1, x2, y2] = max + collectedThisMove;
            if (x1 == n - 1 && y1 == n - 1)
                dp[x1, y1, x2, y2] = collectedThisMove;
            return dp[x1, y1, x2, y2];
        }
        int ans = count(0, 0, 0, 0);
        return ans > 0 ? ans : 0;
    }
}
