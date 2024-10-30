public class Solutio
{
    public void SolveSudoku(char[][] board)
    {
        Solve(board);
    }

    // Método recursivo para aplicar backtracking
    private bool Solve(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                // Buscar una celda vacía
                if (board[i][j] == '.')
                {
                    // Intentar colocar un número del '1' al '9'
                    for (char c = '1'; c <= '9'; c++)
                    {
                        // Verificar si es válido colocar 'c' en la celda
                        if (IsValid(board, i, j, c))
                        {
                            board[i][j] = c;  // Colocar provisionalmente

                            // Intentar resolver el resto del tablero
                            if (Solve(board))
                            {
                                return true;
                            }

                            // Si no es la solución, retroceder
                            board[i][j] = '.';
                        }
                    }

                    // Si no se puede colocar ningún número, devolver false
                    return false;
                }
            }
        }

        // Si todo el tablero está lleno, devolver true
        return true;
    }

    // Método para verificar si es válido colocar un número en la posición dada
    private bool IsValid(char[][] board, int row, int col, char c)
    {
        for (int i = 0; i < 9; i++)
        {
            // Verificar si 'c' ya está en la columna
            if (board[i][col] == c)
                return false;

            // Verificar si 'c' ya está en la fila
            if (board[row][i] == c)
                return false;

            // Verificar si 'c' ya está en la subcuadrícula 3x3
            if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c)
                return false;
        }

        // Si pasa todas las pruebas, es válido colocar el número
        return true;
    }
}