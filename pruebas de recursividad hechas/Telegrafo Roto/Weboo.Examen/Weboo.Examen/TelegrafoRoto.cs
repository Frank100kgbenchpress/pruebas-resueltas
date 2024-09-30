using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public class TelegrafoRoto
    {
        public static IEnumerable<string> DecodificarMensaje(Dictionary<char, string> alfabeto, string mensaje)
        {
            Dictionary<string, char> dic = new Dictionary<string, char>();
            List<char> Keys = new List<char>(alfabeto.Keys);
            List<string> Values = new List<string>(alfabeto.Values);
              for(int i=0; i< alfabeto.Count; i++)
            {
                dic.Add(Values[i], Keys[i]);
            }
            return DescodificarMensaje(dic, mensaje,  "");
        }
        public static IEnumerable<string> DescodificarMensaje(Dictionary<string, char> alfabeto, string mensaje,  string a)
        {
            List<string> m = new List<string>();
            if (mensaje.Length == 0) m.Add(a);
            foreach(var palabra in alfabeto.Keys)
            {
                if (palabra.Length > mensaje.Length) continue;
                bool es = true;
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] != mensaje[i]) es = false;
                }
                if(es)
                {
                    foreach(var elemento in DescodificarMensaje(alfabeto,mensaje.Substring(palabra.Length), a + alfabeto[palabra]))
                    {
                        m.Add(elemento);
                    }
                }
            }
            return m;
        }
    }
}
