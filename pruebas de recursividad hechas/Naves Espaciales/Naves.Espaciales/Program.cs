using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

class Program
{
    static void Main(string[] args)
    {
        bool[,] campoBatalla;
        int cantidad;

        campoBatalla  = new bool[5,7];
        campoBatalla[1,1] = campoBatalla[1,2] = campoBatalla[1,5] = campoBatalla[2,6] = campoBatalla[3,0]= campoBatalla[3,3] = true;
        cantidad = Juego.MaximoRescate(campoBatalla);
        Console.WriteLine("Debe de imprimir 4 e imprime {0}", cantidad);

        campoBatalla  = new bool[3,4];
        cantidad = Juego.MaximoRescate(campoBatalla);
        Console.WriteLine("Debe de imprimir 0 e imprime {0}", cantidad);

        campoBatalla  = new bool[3,4];
        campoBatalla[1,0] = campoBatalla[1,1] = campoBatalla[1,2] = campoBatalla[1,3] = true;
        cantidad = Juego.MaximoRescate(campoBatalla);
        Console.WriteLine("Debe de imprimir 0 e imprime {0}", cantidad);

        campoBatalla  = new bool[3,4];
        campoBatalla[1,1] = true;
        cantidad = Juego.MaximoRescate(campoBatalla);
        Console.WriteLine("Debe de imprimir 0 e imprime {0}", cantidad);
    }
}


