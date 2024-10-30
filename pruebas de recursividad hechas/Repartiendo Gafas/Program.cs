using System.ComponentModel;

class Program
{
    public static int[] NoelSolve(int[] glassForCity, int maxGasol, int[,] map)
    {
        List<int> solve = new(); // Lista para la mejor ruta
        List<int> road = new() { 0 }; // Inicia la ruta en la ciudad 0
        bool[] flag = new bool[glassForCity.Length]; // Para controlar qué ciudades han sido visitadas
        BackTrack(maxGasol);                            // Inicia la búsqueda recursiva
        void BackTrack(int maxGasol)
        {
            int last = road[road.Count -1];             // La última ciudad visitada es la última de la lista road
            if(last == 0 && road.Count > 1)             // Si regresamos a la ciudad 0 y hemos visitado más de una ciudad
            {
                int glasses = 0;
                for(int i = 0; i < road.Count;i++)      // Calcula el total de vidrio recolectado en esta ruta
                {
                    if(!flag[road[i]])                  // Si la ciudad no ha sido visitada aún
                    {
                        glasses += glassForCity[road[i]];   // Suma el vidrio de la ciudad
                        flag[road[i]] = true;               // Marca la ciudad como visitada
                    }
                }
                // Si la cantidad de vidrio es mayor que la mejor solución actual, actualiza la solución
                if(glasses > solve.Sum(city =>glassForCity[city]))
                {
                    solve.Clear();                                   // Limpia la solución actual
                    solve.AddRange(road);                            // Añade la nueva ruta como la mejor solución
                }
                for(int i = 0; i< road.Count ; i++)                 // Desmarcar ciudades para continuar explorando otras rutas
                    flag[road[i]] = false;
            }
            
                if(maxGasol >= 0)
                {
                    for(int j = 0;j < glassForCity.Length;j++)
                    {
                        if(ValidMove(map,maxGasol,j,last))          // Si la ciudad j es un movimiento válido desde la última ciudad visitada
                        {
                            road.Add(j);                            // Añade la ciudad j a la ruta
                            BackTrack(maxGasol - map[last,j]);      // Llama recursivamente
                            road.RemoveAt(road.Count-1);            // Elimina la ciudad actual (backtracking)
                        }
                    }
                }
 
            
        } 
        return solve.ToArray(); // Devuelve la mejor ruta encontrada
    }
    // Verifica si el movimiento entre dos ciudades es válido basado en la gasolina disponible y la matriz de distancias
    static bool ValidMove(int[,] map, int maxGasol, int next, int lastCity) => map[lastCity, next] != 0 && map[lastCity, next] != -1 && maxGasol - map[lastCity, next] >= 0;
    
    static void Main(string[] args)
    {   
        // Test 1
        int[,] map1 = { { 0, 10, -1, 10 }, { 10, 0, 15, -1 }, { -1, 15, 0, -1 }, { 10, -1, -1, 0 }, };
        int[] glassForCity1 = { 0, 32, 10, 43 };
        int maxGasol1 = 49;

        // Test 2
        int[,] map2 = { { 0, 10, -1, 10 }, { 10, 0, 10, -1 }, { -1, 10, 0, -1 }, { 10, -1, -1, 0 }, };
        int[] glassForCity2 = { 5, 10, 15, 20 };
        int maxGasol2 = 30;

        // Test 3
        int[,] map3 = { { 0, 10, -1, -1 }, { 10, 0, 11, 13 }, { -1, 11, 0, 12 }, { -1, 13, 12, 0 }, };
        int[] glassForCity3 = { 1, 2, 3, 4 };
        int maxGasol3 = 50;

        int[] solve = NoelSolve(glassForCity1, maxGasol1, map1);

        foreach(int city in solve) 
            Console.Write(city + " ");



        Console.ReadKey();
    }
}
