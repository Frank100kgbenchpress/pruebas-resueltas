namespace Caminante
{
    
    public class Caminante
    {
        /// <summary>
        /// Dada una secuencias de cajas y la diferencia posible entre alturas,
        /// determinar el número de combinaciones posibles de estas cajas.
        /// </summary>
        /// <param name="cajas">Combinación inicial de cajas</param>
        /// <param name="alturaMax">Diferencia entre las alturas de dos cajas
        /// colocadas de forma consecutivas en el rio</param>
        /// <returns>El número de combinaciones posibles de las cajas</returns>
        public static int CantidadCombinacionesCajas(int[] cajas, int alturaMax)
        {
            if(cajas.Length == 0) return 0;
            int[] combinaciones = new int[cajas.Length];
            return Combinaciones(cajas,alturaMax,0,combinaciones); 
        }
        static int Combinaciones(int[]cajas,int alturaMax, int pos , int[] combinaciones)
        {
            int cantidad = 0;
            if(pos == cajas.Length)
            {
                if(CumpleConAltura(combinaciones,cajas,alturaMax)) return 1;
                pos = 0;
            }
            else
            {
                for(int i = 0 ; i < 2; i++)
                {
                    combinaciones[pos] = i;
                    cantidad += Combinaciones(cajas, alturaMax, pos + 1, combinaciones);
                }
            }
            return cantidad;
        }
        static bool CumpleConAltura(int[]combinaciones,int[]cajas,int altura)
        {
            int [] auxiliar=  LlenarArray(combinaciones, cajas);
            if (Auxiliar(auxiliar))
            {
                for (int j = 0; j < auxiliar.Length; j++)
                {
                    if (j + 1 < auxiliar.Length && auxiliar[j]!= 0 && auxiliar[j +1]!= 0)
                    {
                        if (Math.Abs(auxiliar[j] - auxiliar[j + 1]) > altura)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
        static int [] LlenarArray(int [] combinaciones, int [] cajas)
        { 
            int pos = 0;
            int[] auxiliar = new int[cajas.Length];
            for (int i = 0; i < combinaciones.Length; i++)
            {
                if (combinaciones[i] == 1)
                {
                    auxiliar[pos] = cajas[i];
                    pos++;
                }
            }
            return auxiliar;
        }
        public static bool Auxiliar(int [] alturas)
        {
            int count=0;
            for(int i=0; i< alturas.Length; i++ )
            {
                if(alturas[i]> 0)    count++;
            }
            return count >= 2 ? true : false;
        }
    }
}