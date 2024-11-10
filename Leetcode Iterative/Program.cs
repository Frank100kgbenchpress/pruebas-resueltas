#region LengthOfLongestSubstring 
public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        HashSet<char> aux = new();  //auxiliar para guardar los caracteres que vamos sacando
        int counter = 0;            //contador de la longitud de la subcadena
        int min = 0;                //el que va almacenando las validas
        int start = 0;              //comienzo
        for(int i = 0; i < s.Length;i++)
        {
            if(!aux.Contains(s[i])) //si no se ha repetido
            {
                aux.Add(s[i]);      //añadimos
                min ++;             //contamos valida
            }
            else                    //si esta repetida
            {
                counter = Math.Max(min,counter);    //guardamos la maxima longitud
                while(s[start] != s[i])             //borramos los caracteres anteriores a la repetida
                {
                    aux.Remove(s[start]);
                    start ++;
                    min--;
                }
                start ++;
            }
        } 
        return Math.Max(min,counter);   //retornamos el maximo entre el contador y la longitud de la subcadena
    }
}
#endregion