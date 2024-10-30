using System;
using System.Collections.Generic;

class Subconjunto // todas las posibles separaciones
{
    static void Main()
    {
        int[] array = { 1, 2, 3 };
        List<List<int>> subsets = GetSubsets(array); // subconjuntos

        foreach (var subset in subsets)
        {
            Console.Write("{ ");
            foreach (var item in subset)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }
    }

    static List<List<int>> GetSubsets(int[] array)
    {
        List<List<int>> result = new List<List<int>>();
        int subsetCount = (1 << array.Length); // 2^n subsets

        for (int i = 0; i < subsetCount; i++)
        {
            List<int> subset = new List<int>();
            for (int j = 0; j < array.Length; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subset.Add(array[j]);
                }
            }
            result.Add(subset);
        }

        return result;
    }
}

class Combinatoria // no repite nada
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 4 };
        int combinationSize = 2; // Cambia este valor para obtener combinaciones de distinto tamaño
        List<List<int>> combinations = GetCombinations(array, combinationSize);

        foreach (var combination in combinations)
        {
            Console.Write("{ ");
            foreach (var item in combination)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }
    }

    static List<List<int>> GetCombinations(int[] array, int combinationSize)
    {
        List<List<int>> result = new List<List<int>>();
        GenerateCombinations(array, combinationSize, 0, new List<int>(), result);
        return result;
    }

    static void GenerateCombinations(int[] array, int combinationSize, int start, List<int> currentCombination, List<List<int>> result)
    {
        if (currentCombination.Count == combinationSize)
        {
            result.Add(new List<int>(currentCombination));
            return;
        }

        for (int i = start; i < array.Length; i++)
        {
            currentCombination.Add(array[i]);
            GenerateCombinations(array, combinationSize, i + 1, currentCombination, result);
            currentCombination.RemoveAt(currentCombination.Count - 1); // backtrack
        }
    }
}


class VariacionesConRepeticion // cogerse a el mismo es una opcion
{
    static void Main()
    {
        int[] array = { 1, 2, 3 };
        int variationSize = 2; // Cambia este valor para obtener variaciones de distinto tamaño
        List<List<int>> variations = GetVariationsWithRepetition(array, variationSize);

        foreach (var variation in variations)
        {
            Console.Write("{ ");
            foreach (var item in variation)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }
    }

    static List<List<int>> GetVariationsWithRepetition(int[] array, int variationSize)
    {
        List<List<int>> result = new List<List<int>>();
        GenerateVariations(array, variationSize, new List<int>(), result);
        return result;
    }

    static void GenerateVariations(int[] array, int variationSize, List<int> currentVariation, List<List<int>> result)
    {
        if (currentVariation.Count == variationSize)
        {
            result.Add(new List<int>(currentVariation));
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            currentVariation.Add(array[i]);
            GenerateVariations(array, variationSize, currentVariation, result);
            currentVariation.RemoveAt(currentVariation.Count - 1); // backtrack
        }
    }
}


class VariacionesSinRepeticion // escoge los casos aunque sea el mismo al reves 
{
    static void Main()
    {
        int[] array = { 1, 2, 3 };
        int variationSize = 2; // Cambia este valor para obtener variaciones de distinto tamaño
        List<List<int>> variations = GetVariationsWithoutRepetition(array, variationSize);

        foreach (var variation in variations)
        {
            Console.Write("{ ");
            foreach (var item in variation)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }
    }

    static List<List<int>> GetVariationsWithoutRepetition(int[] array, int variationSize)
    {
        List<List<int>> result = new List<List<int>>();
        bool[] used = new bool[array.Length]; // Para marcar los elementos usados
        GenerateVariations(array, variationSize, new List<int>(), result, used);
        return result;
    }

    static void GenerateVariations(int[] array, int variationSize, List<int> currentVariation, List<List<int>> result, bool[] used)
    {
        if (currentVariation.Count == variationSize)
        {
            result.Add(new List<int>(currentVariation));
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true; // Marcar como usado
                currentVariation.Add(array[i]);
                GenerateVariations(array, variationSize, currentVariation, result, used);
                currentVariation.RemoveAt(currentVariation.Count - 1); // backtrack
                used[i] = false; // Desmarcar para otras variaciones
            }
        }
    }
}
class MazeSolver
{
    public static int MinStepHome(bool[,] map, (int, int) home)
{
    int best = 0;
    bool[,] mask = new bool[map.GetLength(0), map.GetLength(1)];
    int rows = map.GetLength(0);
    int cols = map.GetLength(1);

    return Backtrack(0, 0) ? best : -1;

    bool Backtrack(int i, int j)
    {
        // Si la posición es inválida, ya fue visitada, o es un hueco, retorna falso
        if (mask[i, j] || map[i, j]) return false;

        // Marca la celda como visitada
        mask[i, j] = true;
        best++;

        // Si hemos llegado a casa, retorna verdadero
        if (i == home.Item1 && j == home.Item2) return true;

        // Movimientos circulares: asegura que los movimientos sean válidos usando aritmética modular
        if (
            Backtrack((i + 1) % rows, (j + 3) % cols) ||  // Mover abajo-derecha
            Backtrack((i - 1 + rows) % rows, (j + 3) % cols) ||  // Mover arriba-derecha
            Backtrack((i + 3) % rows, (j + 1) % cols) ||  // Mover derecha-abajo
            Backtrack((i + 3) % rows, (j - 1 + cols) % cols)  // Mover derecha-arriba
        )
        {
            return true;
        }

        // Si no hay camino, desmarcar y retroceder
        best--;
        mask[i, j] = false;
        return false;
    }
}

}

class Pascal
{
    public IList<IList<int>> Generate(int numRows) 
    {
        if(numRows == 1) return new List<IList<int>> { new List<int> {1}};
        var triangle = Generate(numRows-1);
        var prevR = triangle[triangle.Count-1];
        var newR = new List<int> {1};
        for(int i = 1 ; i < prevR.Count; i ++)
        {
            newR.Add(prevR[i-1]+ prevR[i]);
        }
        newR.Add(1);
        triangle.Add(newR);
        return triangle;


    }
    public IList<int> GetRow(int rowIndex) 
    {  
        int[][] dp = new int[rowIndex + 1][];  
        for (int i = 0; i <= rowIndex; i++) 
        {  
            dp[i] = new int[rowIndex + 1];  
            Array.Fill(dp[i], -1);  
        }  
    
        List<int> result = new List<int>(rowIndex + 1);  
        for (int j = 0; j <= rowIndex; j++) 
        {  
            result.Add(Check(rowIndex, j, dp));  
        }  
        return result;  
    }  
    
    int Check(int i,int j, int[][] dp)
    {
        if(i==0 && j ==0) return 1;
        if(dp[i][j] != -1) return dp[i][j];
        int left  = (j > 0)? Check(i-1,j-1,dp) : 0;
        int right = (j < i)? Check(i-1,j,dp) : 0;
        dp[i][j] = left + right;
        return dp[i][j];
    }
}


public class WordBreakSolution
{
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        Dictionary<int,bool> memo = new();
        return Backtrack(s,wordSet,0,memo);
    }
    bool Backtrack(string s , HashSet<string> wordSet ,int start, Dictionary<int,bool> memo)
    {
        if(start == s.Length) return true;
        if(memo.ContainsKey(start)) return memo[start];
        for(int end = start; end <= s.Length;end++)
        {
            string substring = s.Substring(start,end-start);
            if(wordSet.Contains(substring))
            {
                if(Backtrack(s,wordSet,end,memo))
                {
                    memo[start] = true;
                    return true;
                }
            }
        }
        memo[start] = false;
        return false;
    }
}
public class WordBreak2Solution 
{
    public IList<string> WordBreak(string s, IList<string> wordDict) 
    {
        // Convertir wordDict en un HashSet para búsqueda rápida
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        
        // Memoización para almacenar las soluciones de subcadenas
        Dictionary<string, IList<string>> memo = new();

        return Backtrack(s, wordSet, memo);
    }

    private IList<string> Backtrack(string s, HashSet<string> wordSet, Dictionary<string, IList<string>> memo) {
        // Si ya calculamos la solución para esta subcadena, devolvemos el resultado memoizado
        if (memo.ContainsKey(s)) return memo[s];
        
        List<string> result = new();
        // Caso base: si la cadena está vacía, devolvemos una lista con una cadena vacía
        if (s.Length == 0) 
        {
            result.Add("");
            return result;
        }

        // Probar cada prefijo de la cadena
        for (int i = 1; i <= s.Length; i++) 
        {
            string prefix = s.Substring(0, i);

            // Si el prefijo está en el diccionario
            if (wordSet.Contains(prefix)) 
            {
                // Realizar una llamada recursiva con el resto de la cadena
                IList<string> subList = Backtrack(s.Substring(i), wordSet, memo);
                
                // Agregar el prefijo a cada posible solución
                foreach (string sub in subList) 
                {
                    if (sub.Length == 0) 
                    {
                        result.Add(prefix);
                    } 
                    else 
                    {
                        result.Add(prefix + " " + sub);
                    }
                }
            }
        }

        // Guardar el resultado en el diccionario de memoización
        memo[s] = result;

        return result;
    }
}