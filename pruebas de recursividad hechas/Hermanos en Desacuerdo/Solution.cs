namespace Weboo.Examen.Extra
{
    public class Padre
    {
        public static void ResuelveVacaciones(int[,] ciudades, out int[] viaje1, out int[] viaje2)
        {
            int[] hijo1 = new int[ciudades.GetLength(0)]; // viajes actuales del primer hijo
            int[] hijo2 = new int[ciudades.GetLength(0)];   // viajes actuales del segundo hijo
            int[] result1 = new int[ciudades.GetLength(0)]; // solucion hijo 1
            int[] result2 = new int[ciudades.GetLength(0)]; //solucion hijo 2
            int minimo = int.MaxValue;                      //minimo de gasto
            Backtrack(0);                                   //llamado al metodo recursivo estilo traveling sales man 
            void Backtrack(int visitadas)                   //metodo TSM
            {
                if(visitadas == ciudades.GetLength(0))      //si visitamos todas
                {
                    int gasto = CalcularGasto(hijo1,hijo2,ciudades);    //calculamos su gasto
                    if(gasto < minimo)                      //si fue menor
                    {
                        minimo = gasto;                     //actualizamos mejor gasto
                        Array.Copy(hijo1,result1,hijo1.Length); //guardamos en el array resultado este viaje
                        Array.Copy(hijo2,result2,hijo2.Length);
                    }
                    return;                                 //salimos
                }
                for(int i = 0; i < ciudades.GetLength(0); i ++) //sacar las combinaciones de ciudades
                {
                    if(hijo1[i] != 0)   continue;               //si el array de viajes es distinto de 0 significa que ya visitamos esa ciudad
                    for(int j = 0 ; j < ciudades.GetLength(0); j ++)    //sacamos posibles viajes
                    {       
                        if(hijo2[j] !=0 || i == j) continue;        //si el segundo hijo ha viajado a esa ciudad o el hermano  esta ahi no vale
                        hijo1[i] = hijo2[j] = visitadas;            // ya que fue valido ponermos a ambos a visitar
                        Backtrack(visitadas + 1);                   //llamamos recursivo con otra visita
                        hijo1[i] = hijo2[j] = 0;                    //deshacemos para la proxima posibilidad
                    }
                }
            }
            viaje1 = result1;                                       //devolvemos mejor solucion
            viaje2 = result2;
        }
        static int CalcularGasto(int[]v1,int[]v2,int[,]ciudades)    //metodo para calcular el gasto de los viajes
        {
            int result = 0;
            for (int i = 0; i < v1.Length - 1; i++)
                result += ciudades[v1[i], v1[i + 1]] + ciudades[v2[i], v2[i + 1]];
            return result;
        }
    }
}