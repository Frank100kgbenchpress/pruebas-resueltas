namespace Paracaidas
{
    class Paracaidista
    {
        public static int EscogeMayorArea(int[,] terreno,int delta)
        {
            int best = 0;
            for(int i = 0; i< terreno.GetLength(0) ; i++)
            {
                for(int j = 0 ; j < terreno.GetLength(1);j++)
                {
                    Backtrack(i,j,terreno[i,j],0,new bool [terreno.GetLength(0),terreno.GetLength(1)]);
                }
            }
            return best;
            void Backtrack(int i , int j,int counter,int pasos,bool[,]mask)
            {
                if(InvalidMove(i,j,counter,mask)) return;
                mask[i,j] = true;
                pasos ++;
                if(pasos > best) best = pasos;
                Backtrack(i+1,j,terreno[i,j],pasos,mask);
                Backtrack(i,j+1,terreno[i,j],pasos,mask);
                Backtrack(i-1,j,terreno[i,j],pasos,mask);
                Backtrack(i,j-1,terreno[i,j],pasos,mask);
                mask[i,j] = false;
            }
            bool InvalidMove(int i , int j,int counter,bool[,]mask) => i < 0 || i >= terreno.GetLength(0) || j < 0 || j >= terreno.GetLength(1) || Math.Abs(terreno[i,j] - counter) > delta || mask[i,j];
        }
    }
}