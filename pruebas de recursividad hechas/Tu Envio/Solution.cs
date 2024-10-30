namespace Weboo.Examen
{
    public class TuEnvio
    {
       public static int CombustibleDiario(int[] pesos, int[,] combustible)
        {
            if(combustible.GetLength(0) == 1) return 0;
            bool[] flag = new bool[pesos.Length]; // Para marcar las ciudades ya visitadas
            int best = int.MaxValue;
            int totalOrdenes = pesos.Length - 1; // Cantidad de órdenes a entregar (excluyendo el almacén)

            Backtrack(0, 0, pesos[0], 0); // Iniciar en el almacén con peso máximo y ninguna orden entregada
            
            return best == int.MaxValue ? -1 : best;

            void Backtrack(int gasto, int index, int peso, int visitados)
            {
                // Si hemos entregado todas las órdenes, comparamos el gasto total incluyendo el regreso al almacén
                if (visitados == totalOrdenes)
                {
                    best = Math.Min(best, gasto + combustible[index, 0]); // Regresar al almacén
                    return;
                }
                bool hayCamino = false;
                // Intentar visitar todas las órdenes desde el punto actual
                for (int i = 1; i <= totalOrdenes; i++) // Saltar el índice 0 porque es el almacén
                {
                    if (!flag[i] && peso >= pesos[i]) // Si la orden no ha sido entregada y cabe en el camión
                    {
                        // Marcar la orden como entregada
                        flag[i] = true;
                        int nuevoPeso = peso - pesos[i]; // Actualizar el peso
                        int nuevoGasto = gasto + combustible[index, i]; // Actualizar el gasto
                        Backtrack(nuevoGasto, i, nuevoPeso, visitados + 1); // Ir a la siguiente orden
                        flag[i] = false;        // Deshacer los cambios al retroceder
                        hayCamino = true;
                    }
                }
                if (!hayCamino && index != 0)       // Si no podemos entregar más órdenes, volvemos al almacén
                {
                    Backtrack(gasto + combustible[index, 0], 0, pesos[0], visitados); // Regresar al almacén y reiniciar el peso
                }
            }
        }

    }
}
