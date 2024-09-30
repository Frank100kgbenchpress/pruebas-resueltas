using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> alfabetoMorse = new Dictionary<char, string>
           {
             {'a',".-"},  {'b',"-..."}, {'c',"-.-."},  {'d',"-.."},   {'e',"."},
             {'f',"..-."},  {'g',"--."},      {'h',"...."},  {'i',".."},    {'j',".---"},
             {'k',"-.-"},   {'l',".-.."}, {'m',"--"},    {'n',"-."},    {'o',"---"},
             {'p',".--."},  {'q',"--.-"}, {'r',".-."},   {'s',"..."},   {'t',"-"},
             {'u',"..-"},   {'v',"...-"}, {'w',".--"},   {'x',"-..-"}, {'y',"-.--"},
             {'z',"--.."}
            };

            //Ejemplo #1
            string mensaje1 = "..-";
            IEnumerable<string> resultado1 = TelegrafoRoto.DecodificarMensaje(alfabetoMorse, mensaje1);
            // resultado => "u", "ea", "it", "eet" 

            ComprobarResultado(new[] { "ea", "eet", "it", "u" }, resultado1, "EJEMPLO 1");

            //Ejemplo #2
            string mensaje2 = "...";
            IEnumerable<string> resultado2 = TelegrafoRoto.DecodificarMensaje(alfabetoMorse, mensaje2);
            // resultado => "eee", "ei", "ie", "s"

            ComprobarResultado(new[] { "eee", "ei", "ie", "s" }, resultado2, "EJEMPLO 2");


            Dictionary<char, string> alfabetoHawaiano = new Dictionary<char, string>
            {
                { 'a', "..-" }, { 'e', ".-.-." }, { 'h', "--.-" }, { 'i', ".-" },
                { 'k', "--." }, { 'l', "--" }, { 'm', "-.-.-" }, { 'n', "-.-" },
                { 'o', "." }, { 'p', "-.." }, { 'u', ".-." }, { 'w', ".-.-" }
            };

            //Ejemplo #3
            string mensaje3 = "-";
            IEnumerable<string> resultado3 = TelegrafoRoto.DecodificarMensaje(alfabetoHawaiano, mensaje3);
            // resultado => null

            ComprobarResultado(null, resultado3, "EJEMPLO 3");
        }

        public static void ComprobarResultado(IEnumerable<string> resultadoEsperado, IEnumerable<string> resultadoObtenido, string msg)
        {
            Console.Write("\n----> {0} - ", msg);
            var currentColor = Console.ForegroundColor;
            List<string> faltan = new List<string>();
            List<string> sobran = new List<string>();

            if (resultadoEsperado != null)
            {
                faltan = new List<string>(resultadoEsperado);
            }

            if (resultadoObtenido != null)
            {
                sobran = new List<string>(resultadoObtenido);
            }

            if (resultadoObtenido != null)
            {
                foreach (var r in resultadoObtenido)
                {
                    if (faltan.Contains(r))
                    {
                        faltan.Remove(r);
                        sobran.Remove(r);
                    }
                }
            }
            if (faltan.Count != 0 || sobran.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("RESPUESTA INCORRECTA");
                Console.WriteLine("... FALTAN:");
                foreach (var f in faltan)
                    Console.WriteLine(f);
                Console.WriteLine("... SOBRAN:");
                foreach (var s in sobran)
                    Console.WriteLine(s);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("RESPUESTA CORRECTA");
            }
            Console.ForegroundColor = currentColor;
            Console.ReadLine();
        }
    }
}