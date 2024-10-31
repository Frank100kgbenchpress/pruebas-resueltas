namespace SolucionCaminosEnergia
{
    public class Examen
    {
        public static bool HayCamino(int[,] matriz, int f1, int c1, int f2, int c2, int consumoMaximo)     => DFS(matriz, f1, c1, f2, c2, consumoMaximo, new bool[matriz.GetLength(0),matriz.GetLength(1)], 0);
        
        static bool DFS(int[,] matriz, int x, int y, int destX, int destY, int consumoMaximo, bool[,] visited, int currentConsumption)
        {
            if (x == destX && y == destY)    return currentConsumption <= consumoMaximo;    // si llegamos al dedstino chequeamos que cumpla la condicion
            visited[x, y] = true;       //marcamos la casilla       

            // Movimiento a la derecha
            if (IsValid(matriz, x, y + 1, visited))
            {
                int additionalCost = CalculateEnergyCost(matriz[x, y], matriz[x, y + 1]);
                if (currentConsumption + additionalCost <= consumoMaximo)   // chqueamos que no se pase del consumo maximo
                {
                    if (DFS(matriz, x, y + 1, destX, destY, consumoMaximo, visited, currentConsumption + additionalCost))    return true;   // si se pudo llegar damos true
                }
            }
            // Movimiento hacia abajo
            if (IsValid(matriz, x + 1, y, visited))
            {
                int additionalCost = CalculateEnergyCost(matriz[x, y], matriz[x + 1, y]);
                if (currentConsumption + additionalCost <= consumoMaximo)
                {
                    if (DFS(matriz, x + 1, y, destX, destY, consumoMaximo, visited, currentConsumption + additionalCost))    return true;
                }
            }

            // Movimiento a la izquierda
            if (IsValid(matriz, x, y - 1, visited))
            {
                int additionalCost = CalculateEnergyCost(matriz[x, y], matriz[x, y - 1]);
                if (currentConsumption + additionalCost <= consumoMaximo)
                {
                    if (DFS(matriz, x, y - 1, destX, destY, consumoMaximo, visited, currentConsumption + additionalCost))    return true;
                }
            }
            // Movimiento hacia arriba
            if (IsValid(matriz, x - 1, y, visited))
            {
                int additionalCost = CalculateEnergyCost(matriz[x, y], matriz[x - 1, y]);
                if (currentConsumption + additionalCost <= consumoMaximo)
                {
                    if (DFS(matriz, x - 1, y, destX, destY, consumoMaximo, visited, currentConsumption + additionalCost))    return true;
                }
            }
            visited[x, y] = false;  // deshacemos la marca de la casilla
            return false;           // y salimos que no hubo ninguna solucion
        }
        static bool IsValid(int[,] matriz, int x, int y, bool[,] visited) => x >= 0 && x < matriz.GetLength(0) && y >= 0 && y < matriz.GetLength(1) && !visited[x, y];  // chequea movimientos validos
        static int CalculateEnergyCost(int current, int next)    => next <= current ? 1 : 1 + (next - current); //calcula el consumo de energia
    }
}