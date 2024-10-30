//chequea si el sudoku tiene solucion
using System;

public class SudokuSolver
{
    // Tamaño del tablero de Sudoku
    private static readonly int SIZE = 9;

    // Método principal para resolver el Sudoku
    public static bool SolveSudoku(int[,] board)
    {
        // Buscar una celda vacía
        for (int row = 0; row < SIZE; row++)
        {
            for (int col = 0; col < SIZE; col++)
            {
                // Si la celda está vacía (valor 0)
                if (board[row, col] == 0)
                {
                    // Intentar colocar un número del 1 al 9
                    for (int num = 1; num <= SIZE; num++)
                    {
                        // Verificar si es seguro colocar el número en la celda
                        if (IsSafe(board, row, col, num))
                        {
                            // Colocar el número en la celda
                            board[row, col] = num;

                            // Llamar recursivamente para resolver el siguiente espacio
                            if (SolveSudoku(board))
                            {
                                return true;  // Si se puede resolver, retorna verdadero
                            }

                            // Si no se puede resolver, deshacer el paso (backtrack)
                            board[row, col] = 0;
                        }
                    }

                    // Si no se puede colocar ningún número, regresar
                    return false;
                }
            }
        }

        // Si no hay más celdas vacías, el tablero está resuelto
        return true;
    }

    // Verificar si es seguro colocar un número en una celda
    private static bool IsSafe(int[,] board, int row, int col, int num)
    {
        // Verificar la fila
        for (int i = 0; i < SIZE; i++)
        {
            if (board[row, i] == num)
                return false;
        }

        // Verificar la columna
        for (int i = 0; i < SIZE; i++)
        {
            if (board[i, col] == num)
                return false;
        }

        // Verificar la subcuadrícula de 3x3
        int startRow = row - row % 3;
        int startCol = col - col % 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[startRow + i, startCol + j] == num)
                    return false;
            }
        }

        // Si pasa todas las pruebas, es seguro colocar el número
        return true;
    }

    // Método para imprimir el tablero de Sudoku
    public static void PrintBoard(int[,] board)
    {
        for (int row = 0; row < SIZE; row++)
        {
            for (int col = 0; col < SIZE; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    // Método principal para ejecutar el programa
    public static void Main(string[] args)
    {
        // Un tablero de Sudoku con algunos números dados (0 indica una celda vacía)
        int[,] board = {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        // Intentar resolver el Sudoku
        if (SolveSudoku(board))
        {
            Console.WriteLine("Sudoku resuelto:");
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("No se puede resolver este Sudoku.");
        }
    }
}
