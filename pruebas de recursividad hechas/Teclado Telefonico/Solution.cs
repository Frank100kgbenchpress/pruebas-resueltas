using System;
using System.Collections.Generic;
using System.Linq;

public class Extraordinario
{
    static readonly Dictionary<char, string> tecladoMap = new Dictionary<char, string>
    {
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"}
    };

    public static IEnumerable<string> Cadenas(string secuenciaTeclas)
    {
        List<string> resultados = [];                           //lista a devolver
        GenerarCombinaciones(secuenciaTeclas, 0, "", resultados);//metodo recursivo que genera combinaciones
        return resultados;                                      //retornamos la lista
    }

    static void GenerarCombinaciones(string secuencia, int index, string combinacionActual, List<string> resultados)
    {
        if (index == secuencia.Length)  // si llegamos al final de la secuencia
        {
            resultados.Add(combinacionActual);  //añadimos a la lista
            return;                     //salimos
        }

        char tecla = secuencia[index];  // caracter actual
        if (tecladoMap.ContainsKey(tecla))  // si lo contiende el diccionario de teclas
        {
            foreach (char letra in tecladoMap[tecla])
            {
                GenerarCombinaciones(secuencia, index + 1, combinacionActual + letra, resultados);  //por cada tecla llamamos recursivo
            }
        }
        else
        {
            GenerarCombinaciones(secuencia, index + 1, combinacionActual, resultados);  //si no saltamos el caracter
        }
    }
}
