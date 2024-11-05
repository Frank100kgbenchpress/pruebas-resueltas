/*class Program
{
    public static int MayorCantidadDePersonas(int[,] personasPorCuadra, bool[,] talleres)  
    {  
        int filas = personasPorCuadra.GetLength(0);  
        int columnas = personasPorCuadra.GetLength(1);  
        return BuscarMaximo(0, 0, 0, 0, personasPorCuadra, talleres, filas, columnas);  
    }  

    static int BuscarMaximo(int x, int y, int distanciaSinTaller, int sumaPersonas, int[,] personasPorCuadra, bool[,] talleres, int filas, int columnas)  
    {  
        // Si estamos fuera de los límites de la matriz  
        if (InvalidMove(x,y,filas,columnas))  return 0;  
        // Si hemos recorrido más de 10 cuadras sin pasar por un taller  
        if (distanciaSinTaller > 10)  return 0;  
        // Si hemos llegado a la meta  
        if (x == filas - 1 && y == columnas - 1)  return sumaPersonas + personasPorCuadra[x, y];  
        // Contamos las personas en la celda actual  
        sumaPersonas += personasPorCuadra[x, y];  

        // Si hay un taller en la celda actual, reiniciamos la distancia  
        int nuevaDistancia = talleres[x, y] ? 0 : distanciaSinTaller + 1;  

        // Buscamos en las direcciones Este y Sur  
        int maxPersonas = 0;  
        maxPersonas = Math.Max(maxPersonas, BuscarMaximo(x + 1, y, nuevaDistancia, sumaPersonas, personasPorCuadra, talleres, filas, columnas)); // Sur  
        maxPersonas = Math.Max(maxPersonas, BuscarMaximo(x, y + 1, nuevaDistancia, sumaPersonas, personasPorCuadra, talleres, filas, columnas)); // Este  

        return maxPersonas;  
    }
    static bool InvalidMove(int x,int y,int filas ,int columnas) => x < 0 || x >= filas || y < 0 || y >= columnas;
    
     
    
    
}
*/