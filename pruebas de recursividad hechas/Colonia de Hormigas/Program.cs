namespace hormigas
{
    class Program
    {
        public static int[] Solve(int[,] colony, int threshold)
        {
            bool[,] mask = new bool[colony.GetLength(0),colony.GetLength(1)]; // mascara booleana para las posiciones en las que se estuvo
            List<int> solve = new();    // lista que vamos a mandar al Backtrack para alterarla a medida que vayamos moviendo en la matriz
            List<int> aux = new();      // lista auxiliar que usamos para actualizar el mejor camino para retornar
            int max = int.MinValue;     // entero para verificar si hubo mejor camino en el Backtrack
            Backtrack(colony,mask,threshold,0,0,0,solve,ref max,aux);   //llamado al metodo Backtrack
            
            List<int> result = new List<int>(aux); // Lista que vamos a llenar con el resultado del llamado recursivo
            aux.Reverse();                          // como la hormiga tiene que regresar por donde mismo volvio seria simplemente añadirle a la lista la misma lista al reves
            result.AddRange(aux.Skip(1));           // añadimos a la lista la lista invertida quitando el primer elemento para que no se repitan primero y ultimo
            return result.ToArray();                // la retornamos
        }
        static void Backtrack(int[,]colony,bool[,]mask,int threshold,int i , int j , int counter, List<int> solve,ref int best,List<int> aux)
        {
            if(InvalidMove(colony,mask,i,j)) return ; // chequea todo tipo de movimientos no correctos para no realizar accion
            counter += colony[i,j];                   // quiere decir que el movimiento ya es correcto por tanto vamos a actualizar el contador
            
            if(counter >= threshold) return;          //si el contador se exede al tope detenemos el movimiento        
            mask[i,j] = true;                         // al haber realizado todas las acciones correspondientes en la casilla la ponemos en la mascara para el backtrack no repetir casillas
            solve.Add((i* colony.GetLength(1))+ j);   //añadimos a la lista la casilla con la formula correspondiente al problema
            if(counter > best)                        // si se encuentra un camino mejor
            {
                best = counter;                         // actualizamos la variable best
                aux.Clear();                            // limpiamos la lista auxiliar para que quite el recorrido viejo
                aux.AddRange(solve);                    // le añadimos el recorrido nuevo
            }        
            Backtrack(colony, mask, threshold, i + 1, j, counter, solve,ref best,aux); // Down
            Backtrack(colony, mask, threshold, i - 1, j, counter, solve,ref best,aux); // Up
            Backtrack(colony, mask, threshold, i, j + 1, counter, solve,ref best,aux); // Right
            Backtrack(colony, mask, threshold, i, j - 1, counter, solve,ref best,aux); // Left
            mask[i,j] = false;                             // al realizar el Backtrack deshacemos nuestra accion en la casilla
            solve.RemoveAt(solve.Count -1);                 // y deshacemos nuestra accion en la lista
        }
        // este es el que chequea movimientos invalidos en la matriz 
        static bool InvalidMove(int[,]colony,bool[,]mask,int i , int j) => i < 0 || i >= colony.GetLength(0) || j < 0 || j >= colony.GetLength(1) || mask[i,j] || colony[i,j] < 0;
        static void Main()
        {
            int[,] colony1 = 
            {
                {1,  1, 0, 6,  0, -1, -1, -1 },
                {3,  0, 0, 0,  0, -1, -1, -1 },
                {1,  0, 5, 2,  0,  0,  0,  0 },
                {0,  0, 0, 9,  7,  7,  0,  9 },
                {-1, 0, 0, 1,  0,  2,  0,  4 },
                {-1,-1, 4, 0,  4,  0,  0,  0 },
                {-1,-1, 0, 0,  0, -1, -1, -1 },
                {-1,-1,-1,-1, -1, -1, -1, -1 },
            };
            int[,] colony2 =
            {
                {7,  5, 0, 0,  -1, -1, -1, -1 },
                {0,  0, 2, 0,  0, -1, -1, -1 },
                {2,  0, 8, 0,  0,  0,  0,  0 },
                {0,  1, 1, 7,  2,  0,  3,  4 },
                {0, 0, 0, 0,  0,  0,  0,  4 },
                {-1,-1, -1, -1,  -1,  0,  2,  0 },
                {-1,-1, 0, 0,  0, 0, 0, 0 },
                {-1,-1,0,1, 0, 7, 4, 0 },
            };
            int[,] colony3 =
            {
                {0,  2, 8, 0,  -1, -1 },
                { -1, -1, 0,  6, -1, -1 },
                {8,  -1, 0, 0,  -1,  -1 },
                {0,  -1, 0, 7,  -1,  -1},
                {2, 0, 0,  0, 3,  -1},
                {4,0, 2, 0,  6,  -1 },
            };
            int threshold = 28;

            Console.WriteLine("Solve");
            int[] road = Solve(colony1, threshold);
            foreach (int item in road)
                Console.Write(item + " ");
             

            Console.ReadKey();
        }
    
    }
}