using System;
using System.Collections.Generic;
using System.Linq;
using Weboo.Examen;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] datos0 =
            {
                {1, 0, 0},
                {0, 1, 0},
                {0, 0, 1}
            };
           Show(datos0,Heroe.Resuelve(datos0).ToList(),1);



            int[,] datos1 =
            {
                {1, 0, 0},
                {1, 1, 0},
            };
            Show(datos1, Heroe.Resuelve(datos1).ToList(), null);



            int[,] datos2 =
            {
                {0, 0, 0},
            };
            Show(datos2, Heroe.Resuelve(datos2).ToList(), 0);


            int[,] datos3 =
            {
                {0, 0, 1},
            };
            Show(datos3, Heroe.Resuelve(datos3).ToList(), 0);

            int[,] datos4 =
            {
                {10, 10, 10},
                {10, 10, 10},
                {10, 10, 10}
            };
            Show(datos4, Heroe.Resuelve(datos4).ToList(), 20);

            int[,] datos5 =
            {
                {1, 1, 2},
                {1, 25, 2},
                {1, 3, 1},
                {1, 0, 2}
            };
            Show(datos5, Heroe.Resuelve(datos5).ToList(), 4);


        }

        private static int? Check(int[,]bonificaciones, IEnumerable<Tuple<int, int>> solution)
        {
            int[] acc = new int[3];
            int j = 0;
            foreach (var v in solution)
            {
                acc[v.Item1] += bonificaciones[j, v.Item1];
                acc[v.Item2] += bonificaciones[j, v.Item2];
                j++;
            }
            if (acc[0] == acc[1] && acc[1] == acc[2])
                return acc[0];
            return null;
        }

        private static void Show(int[,]datos, List<Tuple<int, int>> sol, int? acumulado)
        {
            Console.WriteLine("Bonificaciones:");
            for (int i = 0; i < datos.GetLength(0); i++)
            {
                for (int j = 0; j < datos.GetLength(1); j++)
                { 
                    Console.Write(datos[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Su solucion es:");
            if(sol.Count>0)
            foreach (var x in sol)
                Console.WriteLine(x.Item1 + " " + x.Item2);
            else
                Console.WriteLine("IEnumerable vacio");


            if (acumulado is null)
            {
                if (sol.Count>0)
                    Print("Su respuesta es incorrecta, su solucion no puede conterner elementos", ConsoleColor.Red);
                 else
                    Print("Su respuesta es correcta",ConsoleColor.Green);
            }
            else
            {
                if (sol.Count>0)
                {
                    var result = Check(datos, sol);
                    if (!(result is null) && result == acumulado)
                        Print("Su respuesta es correcta", ConsoleColor.Green);
                    else
                        Print($"Su respuesta es incorrecta, el acumulado total debe ser {acumulado} y su respuesta es {result}", ConsoleColor.Red);
                   
                }
                else
                {
                   Print($"Su respuesta es incorrecta el acumulado, total debe ser {acumulado} y su respuesta no contiene elementos",ConsoleColor.Red);
                }
            }

            Console.WriteLine("\n\n\n");

        }

        private static void Print(string text, ConsoleColor color)
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = c;
        }
    }
}