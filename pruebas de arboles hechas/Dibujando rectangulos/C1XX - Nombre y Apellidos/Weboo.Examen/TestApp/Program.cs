using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen;
using Weboo.Examen.Interfaces;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Lienzo lienzo = new Lienzo(4);
            Console.WriteLine("Cantidad de Píxeles: {0}", lienzo.Resolucion);
            // Cantidad de Píxeles: 256
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 1
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 0

            lienzo.Dibuja(8, 4, 2, 2);
            Console.WriteLine("Pixel ({0}, {1}): {2}", 8, 5, lienzo.EstaPintado(8, 5));
            // Pixel (8, 5): true
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 9
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 1
            Console.WriteLine("Nodos Grises: {0}", lienzo.CantidadDeNodosGrises);
            // Nodos Grises: 3

            lienzo.Dibuja(8, 6, 2, 4);
            Console.WriteLine("Pixel ({0}, {1}): {2}", 10, 7, lienzo.EstaPintado(10, 7));
            // Pixel (10, 7): true
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 7
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 3
            Console.WriteLine("Nodos Grises: {0}", lienzo.CantidadDeNodosGrises);
            // Nodos Grises: 3

            lienzo.Dibuja(10, 4, 2, 2);
            Console.WriteLine("Pixel ({0}, {1}): {2}", 8, 7, lienzo.EstaPintado(8, 7));
            // Pixel (8, 7): true
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 6
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 1
            Console.WriteLine("Nodos Grises: {0}", lienzo.CantidadDeNodosGrises);
            // Nodos Grises: 2

            lienzo.Dibuja(4, 12, 1, 1);
            Console.WriteLine("Pixel ({0}, {1}): {2}", 4, 13, lienzo.EstaPintado(4, 13));
            // Pixel (4, 13): false
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 14
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 2
            Console.WriteLine("Nodos Grises: {0}", lienzo.CantidadDeNodosGrises);
            // Nodos Grises: 5

            lienzo.Dibuja(4, 12, 2, 2);
            Console.WriteLine("Pixel ({0}, {1}): {2}", 10, 10, lienzo.EstaPintado(10, 10));
            // Pixel (10, 10): false
            Console.WriteLine("Nodos Blancos: {0}", lienzo.CantidadDeNodosBlancos);
            // Nodos Blancos: 11
            Console.WriteLine("Nodos Negros: {0}", lienzo.CantidadDeNodosNegros);
            // Nodos Negros: 2
            Console.WriteLine("Nodos Grises: {0}", lienzo.CantidadDeNodosGrises);
            // Nodos Grises: 4
        }
    }
}
