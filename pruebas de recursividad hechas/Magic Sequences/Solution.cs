namespace MagicSequences
{
    public static class Solution
    {
        public static int CantidadMinimaEliminaciones(int[] secuencia)
        {
            int min = secuencia.Length;
            backtrack(0,0);
            bool IsMagic(int[]secuencia,int first)
            {
                if(secuencia.Length == 0) return true;
                else  if  (secuencia[first] + first == secuencia.Length - 1  ) return true; 
                else  if (secuencia[first]  > secuencia.Length - 1 - first   ) return false ; 
                else   return  IsMagic(secuencia , first + secuencia[first  ] + 1 );
            }
            void backtrack(int start,int eliminations)
            {
                if(IsMagic(secuencia,0) && eliminations < min) min = eliminations;
                if(start == secuencia.Length || eliminations == min) return ;
                int temp = secuencia[start];
                secuencia[start]  = 0; // eliminar
                backtrack(start+1,eliminations+1); // avanzar eliminando
                secuencia[start] = temp; // quitar la eliminacion
                backtrack(start+1,eliminations); // avanzar sin eliminar

            }
            return min;
        }
    }
    
}