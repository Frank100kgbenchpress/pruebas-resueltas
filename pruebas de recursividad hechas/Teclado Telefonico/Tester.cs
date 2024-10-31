using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> resultadoEsperado;
            string entrada;
            //a continuacion se prueban los ejemplos que aparecen en la especificacion del ejercicio
            //Ejemplo 1
            entrada = "2";
            resultadoEsperado = new string[] { "A", "B", "C" };
            
            CompararResultados(Extraordinario.Cadenas(entrada), resultadoEsperado);

            //Ejemplo 2
            entrada = "28";
            resultadoEsperado = new string[] { "AT", "AU", "AV", "BT", "BU", "BV", "CT", "CU", "CV" };
            
            CompararResultados(Extraordinario.Cadenas(entrada), resultadoEsperado);

            //Ejemplo 3
            entrada = "666";
            resultadoEsperado = new string[]
                                    {
                                        "MMM", "MMN", "MMO", "MNM", "MNN", "MNO", "MOM", "MON", "MOO",
                                        "NMM", "NMN", "NMO", "NNM", "NNN", "NNO", "NOM", "NON", "NOO",
                                        "OMM", "OMN", "OMO", "ONM", "ONN", "ONO", "OOM", "OON", "OOO"
                                    };
            
            CompararResultados(Extraordinario.Cadenas(entrada), resultadoEsperado);

            //Ejemplo 4
            entrada = "128#";
            resultadoEsperado = new string[] { "AT", "AU", "AV", "BT", "BU", "BV", "CT", "CU", "CV" };
            
            CompararResultados(Extraordinario.Cadenas(entrada), resultadoEsperado);

            //OJO: que su implementacion funcione bien con estos ejemplos NO quiere decir
            //que esta este bien. pruebe con otros casos y sobre todo revise su codigo linea
            //a linea para verificar que funciona bien PARA TODOS LOS CASOS POSIBLES.
        }

        #region no modificar
        /// <summary>
        /// utilice esta funcion para comparar el resultado da su implementacion de Cadenas con el resultado real
        /// </summary>
        /// <param name="resultadoObtenido">resultado calculado por usted</param>
        /// <param name="resultadoEsperado">resultado real</param>
        static void CompararResultados(IEnumerable<string> resultadoObtenido, IEnumerable<string> resultadoEsperado)
        {
            if (Enumerable.SequenceEqual(resultadoEsperado, resultadoObtenido))
                Console.WriteLine("el resultado obtenido coincide con el esperado");
            else
                Console.WriteLine("el resultado obtenido no coincide con el esperado");
        }
        #endregion
    }
}

