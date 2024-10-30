
using System;
using System.Collections.Generic;
using System.Linq;

public class Map
{
    private int[,] Distances { get; set; }
    public int M { get; private set; }
    public int[] A { get; private set; }
    public int[] B { get; private set; }

    public Map(int[,] distances, int[] A, int[] B)
    {
        Distances = distances;
        M = Distances.GetLength(0);
        this.A = A;
        this.B = B;
    }

    public int this[int i, int j]
    {
        get => Distances[i,j];
    }

    public bool IsTypeA(int node)
    {
        return A.Contains(node);
    }

    public bool IsTypeB(int node)
    {
        return B.Contains(node);
    }
}

public class Solution
{
    public static int Solve(Map map, int n)
    {
        int m = map.M;
        var allIslands = Enumerable.Range(1, m - 1).ToArray();
        var result = int.MaxValue;
        // Inicializar las rutas de cada barco y comenzar el backtracking
        List<int>[] routes = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            routes[i] = new List<int>();
        }
        Backtrack(routes, 0);

        return result; // Return the minimum cost

        // Generar combinaciones de rutas
        void Backtrack(List<int>[] routes, int index)
        {
            if (index == allIslands.Length)          // si las visitamos todas
            {
                // Verificar y calcular el costo
                int cost = CalculateCost(map, routes);  //calculamos costo de la ruta
                result = Math.Min(cost,result);         // actualizamos mejor opcion si es necesario
                return;                                 //salimos
            }

            // Asignar la isla actual a un barco
            for (int i = 0; i < n; i++)
            {
                routes[i].Add(allIslands[index]);       //anadimos ruta
                Backtrack(routes, index + 1);           //llamamos con el siguiente barco
                routes[i].RemoveAt(routes[i].Count - 1); // backtrack
            }
        }

        // Función que calcula el costo de una asignación de rutas
        int CalculateCost(Map map, List<int>[] routes)
        {
            int totalCost = 0;
            foreach (var route in routes)
            {
                if (route.Count == 0) continue;
                
                // Verificar que las islas A sean antes que B
                bool visitedB = false;
                foreach (var island in route)
                {
                    if (map.IsTypeB(island)) visitedB = true;
                    if (visitedB && map.IsTypeA(island)) return int.MaxValue; // Ruta inválida
                }

                // Calcular la distancia para esta ruta
                int routeCost = map[0, route[0]]; // De 0 a la primera isla
                for (int i = 1; i < route.Count; i++)
                {
                    routeCost += map[route[i - 1], route[i]];
                }
                routeCost += map[route[^1], 0]; // Regreso a 0
                totalCost += routeCost;
            }
            return totalCost;
        }
    }
}

// Ejemplo de uso con el caso del PDF
public class Program
{
    public static void Main()
    {
        int[,] distances = {
            { 0, 1, 1, 3 },
            { 1, 0, 3, 1 },
            { 1, 3, 0, 1 },
            { 3, 1, 1, 0 }
        };
        int[] A = { 1, 2 };
        int[] B = { 3 };
        
        Map map = new Map(distances, A, B);
        int result = Solution.Solve(map, 2);
        Console.WriteLine(result); // Debería imprimir 7
    }
}
