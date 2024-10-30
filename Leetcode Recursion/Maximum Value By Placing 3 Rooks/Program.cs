public class Solution  
    {  
        private long maxSum = long.MinValue;  

        public long MaximumValueSum(int[][] board)  
        {  
            int m = board.Length;  
            int n = board[0].Length;  
            
            // Llamada recursiva  
            PlaceRooks(board, 0, new bool[m], new bool[n], 0, 0);  
            
            return maxSum;  
        }  

        private void PlaceRooks(int[][] board, int row, bool[] usedRows, bool[] usedCols, int count, long currentSum)  
        {  
            if (count == 3) // Hemos colocado 3 torres  
            {  
                maxSum = Math.Max(maxSum, currentSum);  
                return;  
            }  

            if (row >= board.Length) return;  

            for (int col = 0; col < board[0].Length; col++)  
            {  
                // Verificar si la fila o columna ya están ocupadas  
                if (!usedRows[row] && !usedCols[col])  
                {  
                    // Colocar la torre  
                    usedRows[row] = true;  
                    usedCols[col] = true;  

                    // Llamar recursivamente para la siguiente torre  
                    PlaceRooks(board, row + 1, usedRows, usedCols, count + 1, currentSum + board[row][col]);  

                    // Retroceder (backtrack)  
                    usedRows[row] = false;  
                    usedCols[col] = false;  
                }  
            }  

            // Llamar también a la siguiente fila sin colocar una torre  
            PlaceRooks(board, row + 1, usedRows, usedCols, count, currentSum);  
        }  
    }