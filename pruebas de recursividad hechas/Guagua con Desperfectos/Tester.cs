using System;  

class Program  
{  
    public static void Main()  
    {  
        // Ejemplo de uso  
        int[,] personasPorCuadra = {  
            { 1, 2, 0 },  
            { 3, 0, 4 },  
            { 0, 5, 6 }  
        };  

        bool[,] talleres = {  
            { false, false, false },  
            { true, false, false },  
            { false, true, false }  
        };  

        int resultado = MayorCantidadDePersonas(personasPorCuadra, talleres);  
        Console.WriteLine("Mayor cantidad de personas: " + resultado); // Esperado: 9  
    }  

    public static int MayorCantidadDePersonas(int[,] personasPorCuadra, bool[,] talleres)  
    {  
        int filas = personasPorCuadra.GetLength(0);  
        int columnas = personasPorCuadra.GetLength(1);  
        int[,] dp = new int[filas, columnas];  
        bool[,] visited = new bool[filas, columnas];  

        // Inicializamos el DP con -1 para indicar que no se ha visitado  
        for (int i = 0; i < filas; i++)  
            for (int j = 0; j < columnas; j++)  
                dp[i, j] = -1;  

        return BuscarMaximo(0, 0, 0, 0, personasPorCuadra, talleres, dp, visited);  
    }  

    private static int BuscarMaximo(int x, int y, int distanciaSinTaller, int sumaPersonas, int[,] personasPorCuadra, bool[,] talleres, int[,] dp, bool[,] visited)  
    {  
        // Verificar límites  
        if (x < 0 || x >= personasPorCuadra.GetLength(0) || y < 0 || y >= personasPorCuadra.GetLength(1))  
            return 0;  

        // Verificar si se ha recorrido más de 10 cuadras sin pasar por un taller  
        if (distanciaSinTaller > 10)  
            return 0;  

        // Si ya hemos calculado este estado, devolver el resultado almacenado  
        if (dp[x, y] != -1)  
            return dp[x, y];  

        // Sumar las personas en la celda actual  
        sumaPersonas += personasPorCuadra[x, y];  

        // Si hay un taller en la celda actual, reiniciar la distancia  
        int nuevaDistancia = talleres[x, y] ? 0 : distanciaSinTaller + 1;  

        // Si estamos en la celda final, devolver la suma de personas  
        if (x == personasPorCuadra.GetLength(0) - 1 && y == personasPorCuadra.GetLength(1) - 1)  
        {  
            dp[x, y] = sumaPersonas;  
            return sumaPersonas;  
        }  

        // Buscar en las direcciones Este y Sur  
        int maxPersonas = 0;  
        maxPersonas = Math.Max(maxPersonas, BuscarMaximo(x + 1, y, nuevaDistancia, sumaPersonas, personasPorCuadra, talleres, dp, visited)); // Sur  
        maxPersonas = Math.Max(maxPersonas, BuscarMaximo(x, y + 1, nuevaDistancia, sumaPersonas, personasPorCuadra, talleres, dp, visited)); // Este  

        // Almacenar el resultado en el DP  
        dp[x, y] = maxPersonas;  
        return maxPersonas;  
    }  
}