namespace Weboo.ApareandoPatrones
{
    public static class Examen
    {
        public static int CantidadCoincidencias(string patron, string cadena)
        {
            int cantidad = 0;
            void Cantidad( int indexPatron,int indexCadena)
            {
                bool SonIguales(int indexCadena , int indexPatron) =>   indexCadena < cadena.Length && (patron[indexPatron] == cadena[indexCadena] ||patron[indexPatron] == '!');
                if(indexPatron == patron.Length)
                {
                    if(indexCadena == cadena.Length)
                    {
                        cantidad += 1;
                        return;
                    }
                    else return ;
                }
                if(SonIguales(indexCadena,indexPatron) )    Cantidad(indexPatron+1, indexCadena+1);  
                if(patron[indexPatron] == '+')
                {
                    for(int i = 1; i< cadena.Length; i++)
                    {
                        Cantidad(indexPatron +1, indexCadena+ i);
                    }
                }
                if(patron[indexPatron] == '*')
                {
                    for(int i = 0; i<= cadena.Length; i++)
                    {
                        Cantidad(indexPatron +1, indexCadena+ i);
                    }
                }
                if(patron[indexPatron] == '?')
                {
                    for(int i = 0; i<=1; i++)
                    {
                        Cantidad(indexPatron +1, indexCadena+ i);
                    }
                }
            }
            Cantidad(0,0);
            return cantidad;
        }
    }
}