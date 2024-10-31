using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolucionCaminosEnergia;

namespace ProbandoSolucion
{
    class Program
    {
        // puede sustituir la implementación del método Main por la lógica de testing que desee.
        static void Main(string[] args)
        {
            int[,] matrizEnunciado = new int[,]
            {
                { 4, 4, -5, 9},
                {3, 0, 15, 1},
                {7, -1, 8, 10},
                {4, 1, 0, 14}
            };

            Console.WriteLine(Examen.HayCamino(matrizEnunciado, 1,0, 2, 3, 30));
        }
    }
}