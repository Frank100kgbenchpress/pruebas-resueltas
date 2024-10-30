namespace Torres
{
    public class Juego
    {
        public static int MayorEliminacion(bool[,] tablero)
        {
            int maxComidas = 0;
            MayorEliminacionAux();
            return maxComidas;

            void MayorEliminacionAux()
            {
                for(int x = 0; x < tablero.GetLength(0); x++)
                {
                    for(int y = 0; y < tablero.GetLength(1); y++)
                    {
                        if (!tablero[x, y]) continue;
                        tablero[x,y] = false;
                        EatTorres( x, y, 0);
                        tablero[x,y] = true;
                    }
                }
            }

            void EatTorres( int x, int y, int comidas)
            {
                int[] dx = { 0, 1, 0, -1 };
                int[] dy = { 1, 0, -1, 0 };

                for (int d = 0; d < dx.Length; d++)
                {
                    bool seComio = false;
                    for(int k = 1; k < Math.Max(tablero.GetLength(0), tablero.GetLength(1)) && !seComio; k++)
                    {
                        int comerX = x + dx[d] * k;
                        int comerY = y + dy[d] * k;
                        int despuesX = x + dx[d] * (k + 1);
                        int despuesY = y + dy[d] * (k + 1);

                        if (!MovimientoValido(comerX, comerY)) break;
                        if (!tablero[comerX, comerY]) continue;
                        if (!MovimientoValido(despuesX, despuesY) || tablero[despuesX, despuesY]) break;

                        seComio = true;

                        for(int i = 1; ; i++)
                        {
                            int destinoX = x + dx[d] * (k + i);
                            int destinoY = y + dy[d] * (k + i);

                            if(!MovimientoValido(destinoX,destinoY) || tablero[destinoX, destinoY]) break;

                            maxComidas = Math.Max(maxComidas, comidas + 1);
                            tablero[comerX, comerY] = false;
                            EatTorres( destinoX, destinoY, comidas + 1);
                            tablero[comerX, comerY] = true;
                        }
                    }
                }
            }

            bool MovimientoValido(int x, int y)    => x >= 0 && x < tablero.GetLength(0) && y>= 0 && y < tablero.GetLength(1) ; 
            
        }
    }
}