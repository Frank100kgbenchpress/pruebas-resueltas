using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiritas
{
    public class Tester
    {
        static void Main()
        {
            bool[,] patron = new bool[,] 
            { 
                {false, false,  true, false, false}, 
                { true,  true,  true,  true,  true}, 
                {false, false,  true, false, false}, 
                {false, false,  true, false, false}, 
            }; 

            int resultado = Solution.Resolver(patron);
            Console.WriteLine(resultado);  // Debe imprimir 2

        }
    }
}