using System.ComponentModel;
public static class Examen
{
    public static int MinEstudiantesAvisar(bool[,] amigos, int k)
    {
        if(k == 0) return amigos.GetLength(0); 
        int combinaciones = 1; 
        while(combinaciones < amigos.GetLength(0) && !BuscarMejorOpcion(new bool[amigos.GetLength(0)],combinaciones))
        {
            combinaciones ++ ;
        }
        if(combinaciones < amigos.GetLength(0)) return combinaciones;
        return amigos.GetLength(0);
        bool BuscarMejorOpcion(bool[] flag,int aux)
        {
            if(aux == 0) return Avisar(flag,k);
            for(int i = 0; i < flag.Length; i++)
            {
                if(!flag[i])
                {
                    flag[i] = true;
                    if(BuscarMejorOpcion(flag,aux - 1)) return true;
                    flag[i] = false;
                }
            }
            return false;
        }
        bool Avisar(bool[] flag,int k)
        {
            if(k == 0)
            {
                int a = 0;
                foreach (var friend in flag)
                {
                    if(friend) a++;
                }
                return a == flag.Length;
            }
            bool[] aux = CloneMask(flag);
            for(int i = 0;i < amigos.GetLength(0);i++)
            {
                if(flag[i])
                {
                    for(int j = 0; j < amigos.GetLength(1);j++)
                    {
                        if(amigos[i,j])
                        {
                            aux[j] = true;
                        }
                    }
                }
                
            }
            return Avisar(aux,k-1);
        }
        bool[] CloneMask(bool[]mask)
        {
            bool[] clone = new bool[mask.Length];
            List<bool> a = [.. mask];
            return a.ToArray();
        }
    }
}