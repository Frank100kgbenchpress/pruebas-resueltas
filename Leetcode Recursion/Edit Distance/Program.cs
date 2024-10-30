public class StringIgualesHaciendoCambios //reemplazar,insertar y borrar 
{
    Dictionary<(int,int),int> memo = new();
    public int MinDistance(string word1, string word2)     => MinDistanceRec(word1, word1.Length, word2, word2.Length);
    int MinDistanceRec(string word1, int m, string word2, int n)
    { 
        if (m ==0) return n;    // Caso base: si uno de los dos strings está vacío
        if (n ==0) return m;    // hay que insertarle el otro completo
        if (memo.ContainsKey((m, n))) return memo[(m, n)]; //chequear memoria
        if (word1[m -1] == word2[n -1]) memo[(m, n)] = MinDistanceRec(word1, m -1, word2, n -1);
        else
        {
            int insert = MinDistanceRec(word1, m, word2, n -1); // insertar es correr un puntero
            int delete = MinDistanceRec(word1, m -1, word2, n); // borrar es correr el otro puntero
            int replace = MinDistanceRec(word1, m -1, word2, n -1); // reemplazar es correr ambos
            memo[(m, n)] = Math.Min(insert, Math.Min(delete, replace)) +1; // guardamos el minimo de todos
            
        }
        return memo[(m,n)];
    }
}
public class StringIgualesBorrando
{  
    private Dictionary<(int, int), int> memo = new();  
    public int MinDistance(string word1, string word2)  
    {    
        int lcsLength = LCS(word1, word2, word1.Length, word2.Length);  
        return (word1.Length - lcsLength) + (word2.Length - lcsLength);  
    }  

    int LCS(string word1, string word2, int i, int j)  
    {  
     
        if (i ==0 || j ==0) return 0;   // Caso base: si uno de los strings llega a ser vacío      
        if (memo.ContainsKey((i, j)))  return memo[(i, j)]; // Verificar si el resultado ya está en la memoria  
        if (word1[i -1] == word2[j -1])  memo[(i, j)] =1 + LCS(word1, word2, i -1, j -1);   // Si los caracteres coinciden  
        else 
        {  
            // Caracteres diferentes: probamos ambas opciones y tomamos el máximo 
            int option1 = LCS(word1, word2, i -1, j); // Eliminar de word1 
            int option2 = LCS(word1, word2, i, j -1); // Eliminar de word2 
            memo[(i, j)] = Math.Max(option1, option2);  
        }  
        return memo[(i, j)];  
    }  
}  
  

public class StringIgualesBorrandoPeroSumarLosCaracteresBorrados
{  
    Dictionary<(int, int), int> memo = new();  

    public int MinimumDeleteSum(string s1, string s2)     => Calculate(s1, s2,0,0);  
    int Calculate(string s1, string s2, int i, int j)  
    {  
        // Caso base: si uno de los strings ya estaba completamente procesado 
        if (i == s1.Length)  
        {  
            int cost =0;  
            while (j < s2.Length)   // Sumar costo de eliminar todos los caracteres restantes de s2  
            {  
                cost += s2[j];  
                j++;  
            }  
            return cost;  
        }  
        if (j == s2.Length)  
        {  
            int cost =0;  
            while (i < s1.Length)   // Sumar costo de eliminar todos los caracteres restantes de s1  
            {  
                cost += s1[i];  
                i++;  
            }  
            return cost;  
        }  

   
        if (memo.ContainsKey((i, j)))  return memo[(i, j)];     // Verificar si el resultado ya está calculado (memorización)  
        int costIfRemoveS1 = s1[i] + Calculate(s1, s2, i +1, j); // Costo si se elimina el carácter actual de s1 
        int costIfRemoveS2 = s2[j] + Calculate(s1, s2, i, j +1); // Costo si se elimina el carácter actual de s2 
        int result = 0;  
        if (s1[i] == s2[j])  result = Calculate(s1, s2, i +1, j +1);   // Si los caracteres son iguales, no hay costo de eliminación  
        else result = Math.Min(costIfRemoveS1, costIfRemoveS2);         // Tomar el mínimo de eliminar de s1 o eliminar de s2
        memo[(i, j)] = result;// Guardar el resultado en la memoria  
        return result;  
    }  
}
