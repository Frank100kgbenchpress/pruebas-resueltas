namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ejemplo 1

            bool[,] tablero = new bool[8, 8];

            //tablero[1, 2] = tablero[1, 4] = tablero[3, 2] = tablero[4, 7] =
              //tablero[4, 0] = tablero[4, 5] = tablero[6, 2] = tablero[7, 4] = true;
            //Console.WriteLine(CaminoSeguro.LongitudMinimaRutaSegura(tablero));
            #endregion

            #region Ejemplo 2

            //bool[,] tablero = new bool[8, 8];

            //tablero[1, 0] = tablero[1, 1] = tablero[1, 2] = tablero[1, 3] = tablero[1, 4]
              //  = tablero[1, 5] = tablero[1, 6] = tablero[1, 7] = true;
            //Console.WriteLine(CaminoSeguro.LongitudMinimaRutaSegura(tablero));
            #endregion

            #region Ejemplo 3

            //bool[,] tablero = new bool[8, 8];

            //tablero[3, 0] = tablero[3, 1] = tablero[3, 2] = tablero[3, 3] = tablero[3, 4]
              //  = tablero[3, 5] = tablero[4, 7] = tablero[6, 7] = true;
            //Console.WriteLine(CaminoSeguro.LongitudMinimaRutaSegura(tablero));
            #endregion

            //bool[,] tablero = new bool[8, 8];

            //tablero[3, 0] = tablero[3, 1] = tablero[3, 2] = tablero[3, 3] = tablero[3, 4]
              //  = tablero[3, 5] = tablero[3, 6] = tablero[3, 7] = true;
            
            //tablero[1, 4] = tablero[1, 5] = tablero[2, 6] = tablero[2, 2] = tablero[4, 2] = tablero[5, 1]
              //  = tablero[5, 3] = tablero[6, 2] = true;
            //tablero[0, 6] = tablero[1, 6] = true;

            tablero[0, 1] = tablero[0, 2] = tablero[0, 3] = tablero[0, 4] = tablero[0, 5] = tablero[1, 7] =
                tablero[2, 7] = tablero[3, 7] = tablero[4, 7] = tablero[4, 2] = tablero[4, 3] = tablero[5, 2] =
                tablero[6, 2] = tablero[7, 6] = tablero[7, 7] = true;
            Console.WriteLine(CaminoSeguro.LongitudMinimaRutaSegura(tablero));

        }
    }
}
