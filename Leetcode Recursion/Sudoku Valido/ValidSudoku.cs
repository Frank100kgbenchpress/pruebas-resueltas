//dada una entrada chequea si la entrada es un sudoku valido sin resolver
public class Solution 
{
    public bool IsValidSudoku(char[][] board) =>ValidateBoard(board,0,0);
    bool ValidateBoard(char[][] board , int i , int j)
    {
        if(i == 9) return true; // si llego hasta la ultima fila sin problema es valido
        if(j == 9) return ValidateBoard(board,i+1,0); // si llego a la ultima columna que pruebe con la proxima fila
        if(board[i][j] == '.') return ValidateBoard(board,i,j+1); // ignorar espacios en blanco
        if(!IsSafe(board,i,j,board[i][j])) return false;            // si el metodo que chequea que sea valido da falso pues no es valido
        return ValidateBoard(board,i,j+1);                          // si esta posicion es valida que cambie de columna

    }
    bool IsSafe(char[][] board,int i,int j, int num)
    {
        for(int k = 0 ; k < 9;k++)
        {
            if(k != j && board[i][k] == num ) return false; // si recorriendo las filas hay uno igual no es valido
        }
        for(int l = 0 ; l < 9 ; l++)
        {
            if(l != i && board[l][j] == num) return false; // si recorriendo las columnas hay uno igual no es valido
        }
        int startRow = i - i % 3;                           // variable auxiliar para chequear 3x3
        int startCol = j - j % 3;
        for(int l = 0 ; l < 3 ; l++)
        {
            for(int k = 0; k < 3 ; k++)                     //chequea si alguno del 3x3 esta duplicado
            {
                if ((startRow + l != i || startCol + k != j) &&board[startRow + l][startCol + k] == num) return false;
            }
        }
        
        return true;                                        //si no paso por ninguna es segura esa posicion
    }
}