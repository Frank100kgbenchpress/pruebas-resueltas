using System.Diagnostics;
using Weboo.Examen;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            //EJEMPLO 1
            string s1 = "{{)";
            sw.Restart();
            int r1 = CadenasBalanceadas.MinOperacionesParaBalancear(s1);
            sw.Stop();
            Test(1, -1, r1, sw);
            //r1 = -1

            //EJEMPLO 2
            string s2 = "}}[)";
            sw.Restart();
            int r2 = CadenasBalanceadas.MinOperacionesParaBalancear(s2);
            sw.Stop();
            Test(2, 2, r2, sw);
            //r2 = 2  => {}[]

            //EJEMPLO 3
            string s3 = "(()[]){{}}";
            sw.Restart();
            int r3 = CadenasBalanceadas.MinOperacionesParaBalancear(s3);
            sw.Stop();
            Test(3, 0, r3, sw);
            //r3 = 0

            //EJEMPLO 4
            string s4 = "]{(]{{{[";
            sw.Restart();
            int r4 = CadenasBalanceadas.MinOperacionesParaBalancear(s4);
            sw.Stop();
            Test(4, 4, r4, sw);
            //r4 = 4  => [{}]{{}}


            //EJEMPLO 5
            string s5 = "{[]}}[}({]])";
            sw.Restart();
            int r5 = CadenasBalanceadas.MinOperacionesParaBalancear(s5);
            sw.Stop();
            Test(5, 3, r5, sw);
            //r5 = 3  => {[]}([[()]])


            //EJEMPLO 6
            string s6 = "])[]{(()(]{}[[{]}][)";
            sw.Restart();
            int r6 = CadenasBalanceadas.MinOperacionesParaBalancear(s6);
            sw.Stop();
            Test(6, 6, r6, sw);
            //r6 = 6  => ()[]{}()(){}[[]][]()


            //EJEMPLO 7
            string s7 = ")](}[])}}(){({({}[(({][}";
            sw.Restart();
            int r7 = CadenasBalanceadas.MinOperacionesParaBalancear(s7);
            sw.Stop();
            Test(7, 9, r7, sw);
            //r7 = 9  => []()[]{}[(){}{}{}[]()]{}

        }

        #region Utiles
        private static void Test(int test, int expected, int answer, Stopwatch sw)
        {
            var color = Console.ForegroundColor;

            Console.Write("Ejemplo {0}: ", test);
            if (expected == answer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correcto. Tiempo {0:0.0}s", TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).TotalSeconds);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrecto. Se esperaba {1} y devolvió {2}. Tiempo {0:0.0}s", TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).TotalSeconds, expected, answer);
            }

            Console.ForegroundColor = color;
        }
        #endregion

    }
}