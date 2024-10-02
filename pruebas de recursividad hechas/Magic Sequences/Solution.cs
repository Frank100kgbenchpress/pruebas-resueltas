namespace MagicSequences
{
    public class Solution
    {
        public static int CantidadMinimaEliminaciones(int[] secuencia)
        {
            int len = secuencia.Length; // Obtiene la longitud de la secuencia para escribir menos código
            int best = -1;              // mejor opcion en menos uno ya que al ser siempre mayor que 0 no hace falta llevarla a int min value

            int EraseOrNot(int index = 0, int current = 0) //backtracking
            {
                if (IsStillBest(best, len - current)) return -1;    // poda por si no es mejor opcion

                if (index > 0 && secuencia[index - 1] > len - (index+1)) return -1;     // por si no cabe en el array este camino

                if (index == len)   // si llegamos al final
                {
                    if (IsMagic(secuencia))  return len - current; // chequeamos si es magic
                    else return -1;     // si no no es opcion valida
                }

                int noErase = EraseOrNot(index + 1, current);       // recursivo en la proxima posicion
                int temp = secuencia[index];                        //guardamos cuanto vale
                int erase = -1;                                     //minimo que se necesite borrar para que sea magic
                secuencia[index] = -1;                              //ponemos la posicion en -1
                erase = EraseOrNot(index + 1, current + 1);         //llamamos recursivo
                secuencia[index] = temp;                            //deshacemos el cambio
                return Math.Max(best, Math.Max(noErase, erase));    //nos quedamos con el maximo de las opciones
            }

            return len - EraseOrNot();                              //llamamos a la funcion recursiva
        }

        public static bool IsStillBest(int best, int candidate)=>  best > candidate; // si es mejor opcion
        public static bool IsMagic(int[] secuencia) //chequea si es magic
        {
            int len = secuencia.Length;
            bool isMagic = true;

            for (int i = 0; i < len; i++)
            {
                if (secuencia[i] == -1) continue;   //si esta en -1 no se cuenta

                int aux = secuencia[i];             //si no la guardamos

                while (aux > 0)                     // recorremos
                {
                    i++;
                    if (i >= len)                   //si no cabe ya no es magic
                    {
                        isMagic = false;
                        break;
                    }
                    if (secuencia[i] != -1)         // si no seguimos avanzando
                        aux--;
                }
            }

            return isMagic;                         //devolvemos si es magic
        }
    }
     
}