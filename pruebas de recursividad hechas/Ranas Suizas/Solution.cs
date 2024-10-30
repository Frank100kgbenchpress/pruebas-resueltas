namespace Ranas
{
    class Charco
    {
    
        public static int ComiendoChocolates(bool[,] mapa, int[] ranas)
        {
            int best = 0;
            List<Rana> listaDeRanas = Ranas(ranas);
            bool[,] mask = GetMap(mapa);
            bool[,] mapaDeRanas = new bool[mapa.GetLength(0), mapa.GetLength(1)];
            MoverRana(listaDeRanas[0], 0, 0);
            return best;

            List<Rana> PosiblesMovimientos(Rana posicionActual, bool[,] mapa)
            {
                List<Rana> posiciones = new();
                if (posicionActual.Fila >= mapa.GetLength(0) - 1) return posiciones;

                for (int i = Math.Max(0, posicionActual.Columna - 1); i < Math.Min(posicionActual.Columna + 2, mapa.GetLength(1)); i++)
                {
                    if (mapaDeRanas[posicionActual.Fila + 1, i]) continue;
                    posiciones.Add(new Rana(posicionActual.Fila + 1, i));
                }
                return posiciones;
            }

            void MoverRana(Rana posActual, int numeroRana, int maximoActual)
            {
                List<Rana> posiciones = PosiblesMovimientos(posActual, mask);
                if (posiciones.Count == 0)
                {
                    if (numeroRana == listaDeRanas.Count - 1)
                    {
                        best = Math.Max(best, maximoActual);
                        return;
                    }
                    MoverRana(listaDeRanas[numeroRana + 1], numeroRana + 1, maximoActual);
                    return;
                }

                foreach (var posicion in posiciones)
                {
                    mapaDeRanas[posicion.Fila, posicion.Columna] = true;
                    if (mask[posicion.Fila, posicion.Columna])
                    {
                        mask[posicion.Fila, posicion.Columna] = false;
                        MoverRana(posicion, numeroRana, maximoActual + 1);
                        mask[posicion.Fila, posicion.Columna] = true;
                    }
                    else
                    {
                        MoverRana(posicion, numeroRana, maximoActual);
                    }
                    mapaDeRanas[posicion.Fila, posicion.Columna] = false;
                }
            }
        }

        static List<Rana> Ranas(int[] ranas)
        {
            List<Rana> aux = [];
            foreach (int i in ranas) aux.Add(new Rana(0, i));
            return aux;
        }

        static bool[,] GetMap(bool[,] mapa)
        {
            bool[,] aux = new bool[mapa.GetLength(0), mapa.GetLength(1)];
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    aux[i, j] = mapa[i, j];
                }
            }
            return aux;
        }
    }
    public class Rana
    {
        public int Fila { get; set; }
        public int Columna { get; set; }

        public Rana(int fila, int columna) => (Fila,Columna) = (fila,columna);
    }

}
//implementacion de tuplas
//     public static int ComiendoChocolates(bool[,] mapa , int[] ranas )
    //     {
    //         int best = 0;
    //         List<(int fila,int columna)> ListaDeRanas = Ranas(ranas);
    //         bool[,] mask = GetMap(mapa);
    //         bool[,] mapaDeRanas = new bool[mapa.GetLength(0),mapa.GetLength(1)];
    //         MoverRana(ListaDeRanas[0] , 0,0);
    //         return best;
    //         List<(int fila,int columna)> PosiblesMovimientos((int fila , int columna) posicionActual , bool[,] mapa)
    //         {
    //             List<(int fila,int columna)> posiciones = new();
    //             if (posicionActual.fila >= mapa.GetLength(0) -1 )    return posiciones;
    //             for (int i = Math.Max(0 ,posicionActual.columna - 1 ); i < Math.Min(posicionActual.columna + 2 , mapa.GetLength(1)); i++)
    //             {   
    //                 if(mapaDeRanas[posicionActual.fila + 1  , i ])    continue ; 
    //                 posiciones.Add((posicionActual.fila + 1 , i));
    //             }
    //             return posiciones;
    //         }
    //         void  MoverRana ( (int fila , int columna ) posActual , int NumeroRana    ,  int MaximoActual)
    //         {   
    //             List<(int fila , int columna )> posiciones = PosiblesMovimientos(posActual , mask );  
    //             if( posiciones.Count == 0 )
    //             {
    //                 if( NumeroRana ==  ListaDeRanas.Count - 1)
    //                 {    
    //                     best = Math.Max(best , MaximoActual);
    //                     return ; 
    //                 }
    //                 MoverRana(ListaDeRanas[NumeroRana + 1]  , NumeroRana + 1  , MaximoActual);
    //                 return;
    //             }   
    //                 for (int i = 0; i < posiciones.Count; i++)
    //                 {        
    //                     mapaDeRanas[posiciones[i].fila ,posiciones[i].columna] = true ; 
    //                     if(mask[posiciones[i].fila ,posiciones[i].columna])
    //                     {
    //                         mask[posiciones[i].fila ,posiciones[i].columna] = false ; 
    //                         MoverRana((posiciones[i].fila,posiciones[i].columna) , NumeroRana , MaximoActual + 1 );
    //                         mask[posiciones[i].fila ,posiciones[i].columna] = true  ; 
    //                     } 
    //                     else
    //                     {
    //                         MoverRana( (posiciones[i].fila,posiciones[i].columna), NumeroRana , MaximoActual);
    //                     } 
    //                     mapaDeRanas[posiciones[i].fila ,posiciones[i].columna] = false ; 
    //                 }
    //             }
    //     }
    //     static List<(int fila,int columna)> Ranas(int[]ranas)
    //     {
    //         List<(int fila,int columna)> aux = new();
    //         foreach(int i in ranas)    aux.Add((0 , i));
    //         return aux ;
    //     }
    //     static bool[,] GetMap(bool[,]mapa)
    //     {
    //         bool[,] aux = new bool[mapa.GetLength(0),mapa.GetLength(1)];
    //         for (int i = 0; i < mapa.GetLength(0); i++)
    //         {
    //             for(int j = 0;j < mapa.GetLength(1);j++)
    //             {
    //                 aux[i,j] = mapa[i,j];
    //             }
    //         }
    //         return aux;
    //     }
    // }