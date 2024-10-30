namespace NivelandoTerrenos
{
    public class Constructora
    {
        public static int MinNivelarParcela(int[] parcela)
        {
            int viajes = 0;                                 // variable para almacenar los viajes
            int nivel = parcela.Max();                      //sacar el maximo de una parcela
            int min = parcela.Min();                        // sacar el minimo de una parcela
            Nivelar(parcela,min,nivel,ref viajes);          // llamado al metodo recursivo que devuelve la mejor opcion
            return viajes;                                  //retornamos la solucion
            void Nivelar(int[]parcela,int min,int max,ref int viajes)
            {
                if(min==max) return;                        // si minimo igual a maximo quiere decir que ya esta nivelada
                for(int i = 0; i < parcela.Length; i++)     //recorremos la parcela
                {
                    if(parcela[i]== min)                    //el mejor movimiento siempre sera empezar por el menor por eso chequeamos
                    {
                        for(int j = i; j < parcela.Length;j++)//intentamos sacar todos los menores adyacentes
                        {
                            if(parcela[j]!= min)                // si no hay mas ninguno 
                            {   
                                i = j;                      //corremos el puntero
                                break;                      // salimos a buscar otra opcion
                            }
                            parcela[j]++;                   //nivelamos parcelas adyacentes
                        }
                        viajes++;                           //contamos un viaje
                    }
                }
                Nivelar(parcela,parcela.Min(),max,ref viajes);//llamamos recursivo con nuestro nuevo minimo
            }
        }
    }
}