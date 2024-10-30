using System.ComponentModel;
public static class Examen    //implementacion tipo TSM
{
    public static int MinEstudiantesAvisar(bool[,] amigos, int k)
    {
        if(k == 0) return amigos.GetLength(0); // si no se pueden dar pasos hay que avisar a todos los amigos
        int combinaciones = 1;                 // si k no es 0 vamos a probar llamar a un amigo
        while(combinaciones < amigos.GetLength(0) && !BuscarMejorOpcion(new bool[amigos.GetLength(0)],combinaciones)) // mientras queden amigos y no halla mejor opcion
        {
            combinaciones ++ ;                //entonces no hemos llamado a todos los amigos y hay que probar con mas amigos
        }
        return combinaciones < amigos.GetLength(0)? combinaciones: amigos.GetLength(0); // si hubo combinacion minima la devolvemos si no se devuelve todos los amigos
        bool BuscarMejorOpcion(bool[] flag,int aux) // busca mejor opcion de amigos a llarmar retursivamente tipo TSM
        {
            if(aux == 0) return Avisar(flag,k);     // con nuestra condicion de amigo avisado actual chequeamos si ese avisa a todos
            for(int i = 0; i < flag.Length; i++)    //for para llamar amigos tipo TSM
            {
                if(!flag[i])                        // si no lo hemos llamado
                {
                    flag[i] = true;                 //lo llamamos
                    if(BuscarMejorOpcion(flag,aux - 1)) return true;    // si ese amigo llega a avisar a todos es una opcion valida por tanto true
                    flag[i] = false;                // si no deshacemos para proximos casos
                }
            }
            return false;                           // si ninguno cumplio damos falso de que no hay mejor opcion que nuestra cantidad de estudiantes actual
        }
        bool Avisar(bool[] flag,int k)
        {
            if(k == 0)    return flag.All(x=>x);                          // si se acabaron los amigos chequeamos que todos sean avisados
            bool[] aux = CloneMask(flag);           // si no creamos un nuevo aviso desde esta condicion
            for(int i = 0 ; i < amigos.GetLength(0) ; i++)  
            {
                if(flag[i])                         // si esta avisado
                {
                    for(int j = 0; j < amigos.GetLength(1);j++)
                    {
                        if(amigos[i,j])
                        {
                            aux[j] = true;          // lo ponemos a avisar a sus amigos
                        }
                    }
                }
                
            }
            return Avisar(aux,k-1);             //  y seguimos con los amigos restantes
        }
        bool[] CloneMask(bool[]mask)
        {
            List<bool> a = [.. mask];
            return [.. a];
        }
    }
}




