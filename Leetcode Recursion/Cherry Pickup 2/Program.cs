using System.Drawing;


public class CherryPickup2
{
    public int CherryPickup(int[][] grid) 
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[,,,] memo = FillArray(rows,cols,-1);
        return Backtrack(0, 0, cols - 1, grid, memo);
    }
    int[,,,] FillArray(int rows,int cols,int number)
    {
        int[,,,] memo = new int[rows,cols,cols,rows];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                for(int k = 0; k < cols; k++)
                {
                    for(int l = 0; l < rows; l++)
                    {
                        memo[i,j,k,l] = number;
                    }
                }
            }
        }
        return memo;
    }

    int Backtrack(int row, int col1, int col2, int[][] grid, int[,,,] memo) 
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        if (row == rows) return 0; // Límite del grid
        if (memo[row, col1, col2, row] != -1) return memo[row, col1, col2, row]; // Devuelve si ya está calculado

        // Recoger cerezas actuales
        int result = grid[row][col1];
        if (col1 != col2)     result += grid[row][col2];
        

        // Calculamos los movimientos posibles para ambos robots
        int maxCherries = 0;
        for (int newCol1 = col1 - 1; newCol1 <= col1 + 1; newCol1++) 
        {
            for (int newCol2 = col2 - 1; newCol2 <= col2 + 1; newCol2++) 
            {
                if (newCol1 >= 0 && newCol1 < cols && newCol2 >= 0 && newCol2 < cols) 
                {
                    maxCherries = Math.Max(maxCherries, Backtrack(row + 1, newCol1, newCol2, grid, memo));
                }
            }
        }

        result += maxCherries;
        memo[row, col1, col2, row] = result; // Guardamos en memoización
        return result;
    }
}

