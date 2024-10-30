namespace Weboo.Examen;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

public static class Solution
{
    public static int CantidadMoleculas(string[] muestraAtomos, bool[,] muestraEnlaces,string[] sentinelaAtomos, bool[,] sentinelaEnlaces)
    {
        int n = muestraAtomos.Length;
        int m = sentinelaAtomos.Length;
        HashSet<string> uniqueMatches = new(); // Conjunto para almacenar coincidencias únicas

        // Función para verificar si el subgrafo en la muestra coincide con la molécula sentinela
        bool EsSubgrafoValido(int[] mapeo)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    // Verificar solo cuando el enlace existe en sentinela, ignorando enlaces externos
                    if (sentinelaEnlaces[i, j] && !muestraEnlaces[mapeo[i], mapeo[j]])  return false;
                    if (!sentinelaEnlaces[i, j] && muestraEnlaces[mapeo[i], mapeo[j]])  return false;
                }
            }
            return true;
        }

        // Función recursiva para probar todas las combinaciones de mapeos
        void Backtrack(int idx, bool[] visitado, int[] mapeo)
        {
            if (idx == m)
            {
                if (EsSubgrafoValido(mapeo))
                {
                    // Convertir el mapeo a un string ordenado para asegurar unicidad
                    Array.Sort(mapeo);
                    uniqueMatches.Add(string.Join(",", mapeo));
                }
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!visitado[i] && muestraAtomos[i] == sentinelaAtomos[idx])
                {
                    visitado[i] = true;
                    mapeo[idx] = i;
                    Backtrack(idx + 1, visitado, mapeo);
                    visitado[i] = false;
                }
            }
        }

        // Llamar a la función de backtracking
        Backtrack(0, new bool[n], new int[m]);
        return uniqueMatches.Count; // Devolver el número de coincidencias únicas
    }
}
