namespace Weboo.Examen
{
    public class Pelotas 
    {
        public static int EnlazaOptimo(int[] pelotas)     => EnlazaRecursivo(pelotas, 0, pelotas.Length - 1);
        //usando 2 punteros
        static int EnlazaRecursivo(int[] pelotas, int i, int j) 
        {
            if (i == j) return 0; // Caso base: una sola pelota no requiere enlace

            int minCosto = int.MaxValue;

            // Divide en todos los posibles puntos de corte entre i y j
            for (int k = i; k < j; k++) 
            {
                int costoIzquierda = EnlazaRecursivo(pelotas, i, k);
                int costoDerecha = EnlazaRecursivo(pelotas, k + 1, j);
                int costoEnlace = (pelotas[i] == pelotas[k + 1]) ? 0 : 1;

                int costoTotal = costoIzquierda + costoDerecha + costoEnlace;
                minCosto = Math.Min(minCosto, costoTotal);
            }

            return minCosto;
        }
    }
}
