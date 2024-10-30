namespace Weboo.Examen;

using System;
using System.Collections.Generic;
public static class Solution
{
    public static int CantidadMoleculas(string[] muestraAtomos, bool[,] muestraEnlaces,string[] sentinelaAtomos, bool[,] sentinelaEnlaces)
    {
        int n = muestraAtomos.Length;
        int m = sentinelaAtomos.Length;
        HashSet<string> uniqueMatches = new(); // Conjunto para almacenar coincidencias únicas
        Backtrack(0, new bool[n], new int[m]);  // Llamar a la función de backtracking del tipo TSM con un array para guardar nuestos atomos
        return uniqueMatches.Count; // Devolver el número de coincidencias únicas

        bool EsSubgrafoValido(int[] mapeo)  // Función para verificar si el subgrafo en la muestra coincide con la molécula sentinela
        {
            for (int i = 0; i < m; i++)     // recorremos toda la matriz de sentinela para verificar que no hay diferencias (con 2 punteros i y j para ver el camino)
            {
                for (int j = i + 1; j < m; j++)
                {   
                    if (sentinelaEnlaces[i, j] && !muestraEnlaces[mapeo[i], mapeo[j]])  return false;   // Verificar solo cuando el enlace existe en sentinela, ignorando enlaces externos
                    if (!sentinelaEnlaces[i, j] && muestraEnlaces[mapeo[i], mapeo[j]])  return false;
                }
            }
            return true;                // si no la hay es un subgrafo valido
        }

        // Función recursiva para probar todas las combinaciones de mapeos
        void Backtrack(int idx, bool[] visitado, int[] mapeo)   // del tipo TSM
        {
            if (idx == m)   // caso base si recorrimos toda la sentinela
            {
                if (EsSubgrafoValido(mapeo))    // chequeamos si el mapeo es valido
                {
                    
                    Array.Sort(mapeo);  // Convertir el mapeo a un string ordenado para asegurar unicidad
                    uniqueMatches.Add(string.Join(",", mapeo)); // como es un hashset si se repite no lo va a añadir
                }
                return;
            }

            for (int i = 0; i < n; i++)     // for por cada atomo de la muestra tipo TSM
            {
                if (!visitado[i] && muestraAtomos[i] == sentinelaAtomos[idx])   // si no esta puesto y coninciden los atomos
                {
                    visitado[i] = true;                                         //marcamos como usado
                    mapeo[idx] = i;                                             // guardamos el indice
                    Backtrack(idx + 1, visitado, mapeo);                        //llamamos recursivamente con para llenar el proximo indice
                    visitado[i] = false;                                        //deshacemos para buscar otras soluciones
                }
            }
        }

        
    }
}
