using System.Text;

namespace TelegrafoRoto
{
    public class TelegrafoRoto
    {
        public static IEnumerable<string> DecodificarMensaje(Dictionary<char, string> alfabeto, string mensaje)
        {
            List<string> result  = new();
            Backtrack(0,new StringBuilder());
            void Backtrack(int index,StringBuilder actualWord)
            {
                if(index == mensaje.Length)
                {
                    result.Add(actualWord.ToString());
                    return;
                }
                foreach(var entrada in alfabeto)
                {
                    string code = entrada.Value;
                    if(mensaje.Substring(index).StartsWith(code))
                    {
                        actualWord.Append(entrada.Key);
                        Backtrack(index+code.Length,actualWord);
                        actualWord.Length -=1;
                    }
                }
            }            
            return result.Count > 0 ? result : null;
        }
    }   
}