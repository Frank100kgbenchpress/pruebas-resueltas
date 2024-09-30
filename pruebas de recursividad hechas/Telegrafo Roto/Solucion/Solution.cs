using System.Text;

namespace TelegrafoRoto
{
    public class TelegrafoRoto
    {
        public static IEnumerable<string> DecodificarMensaje(Dictionary<char, string> alfabeto, string mensaje)
        {
            List<string> result  = new();
            BackTrack(alfabeto,mensaje,0,new StringBuilder(),result);
            return result.Count > 0 ? result : null;
        }
        static void BackTrack(Dictionary<char, string> alfabeto, string mensaje, int index , StringBuilder actualWord , List<string> result)
        {
            if (index == mensaje.Length)
            {
                result.Add(actualWord.ToString());
                return;
            }
            foreach (var entrada in alfabeto)
            {
                string code = entrada.Value;
                if (mensaje.Substring(index).StartsWith(code))
                {
                    actualWord.Append(entrada.Key);
                    BackTrack(alfabeto, mensaje, index + code.Length, actualWord, result);
                    actualWord.Length -= 1;
                }
            }

        }
    }   
}