namespace Examen
{
    class CaminoSeguro
    {
        public static int LongitudMinimaRutaSegura(bool[,] tablero)
        {
            // Poda: Verificar si hay una fila completa de `true`
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                bool filaBloqueada = true;
                for (int col = 0; col < tablero.GetLength(1); col++)
                {
                    if (!tablero[fila, col])
                    {
                        filaBloqueada = false;
                        break;
                    }
                }
                if (filaBloqueada)  return 0; // Salida inmediata si hay una fila completa de `true`
            }
            bool[,] MueveRey = new bool[tablero.GetLength(0), tablero.GetLength(1)];
            int mejorcantidaddepasos = int.MaxValue;
            CalculodeLaLongitudMinima(tablero, MueveRey, tablero.GetLength(0) - 1, 0, 1, ref mejorcantidaddepasos);
            return mejorcantidaddepasos == int.MaxValue ? 0 : mejorcantidaddepasos;
        }

        static void CalculodeLaLongitudMinima(bool[,] tablero, bool[,] MueveRey, int i, int j, int pasoactual, ref int mejor)
        {
            //Poda anadida ya no se demora
            MueveRey[i, j] = true;
            
            if (i == 0 && j == tablero.GetLength(1) - 1)
                if (pasoactual < mejor)    mejor = pasoactual;
            if (pasoactual > mejor)
            {
                MueveRey[i, j] = false;
                return;
            }
            int[] dx = { -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };

            for (int k = 0; k < 8; k++)
            {
                int i1 = i + dx[k % 3];
                int j1 = j + dy[k];

                if (Amenazado(tablero, i1, j1) || MueveRey[i1, j1]) continue; // si no se pudo mover que no lo haga
                if (tablero[i1, j1])    //si hay un peon
                {
                    tablero[i1, j1] = false;    //comemos
                    CalculodeLaLongitudMinima(tablero, MueveRey, i1, j1, pasoactual + 1, ref mejor);//llamamos con el peon comido
                    tablero[i1, j1] = true;     //quitamos
                }
                else
                    CalculodeLaLongitudMinima(tablero, MueveRey, i1, j1, pasoactual + 1, ref mejor); // seguimos avanzando
            }
            MueveRey[i, j] = false; //deshacemos cambios
        }

        static bool Amenazado(bool[,] tablero, int i, int j)
        {
            if(InvalidMove(i,j,tablero))    return true;
            //peones amenazan
            if(i != tablero.GetLength(0) - 1 && j != tablero.GetLength(1) - 1 && tablero[i + 1, j + 1])
                return true;
            if(i != 0 && j != 0 && tablero[i - 1, j - 1])
                return true;
            if(i != tablero.GetLength(0) - 1 && j != 0 && tablero[i + 1, j - 1])
                return true;
            if(i != 0 && j != tablero.GetLength(1) - 1 && tablero[i - 1, j + 1])
                return true;
            return false;
        }
        static bool InvalidMove(int i , int j , bool[,]tablero) => i < 0 || j < 0 || i >= tablero.GetLength(0) || j >= tablero.GetLength(1);
    }
}