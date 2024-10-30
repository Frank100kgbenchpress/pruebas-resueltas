
using System;
using System.Collections.Generic;
using System.Linq;
namespace Weboo.Examen
{
    class Heroe
    {
        public static IEnumerable<Tuple<int, int>> Resuelve(int[,] bonificaciones)
        {
            int m = bonificaciones.GetLength(0); // Número de misiones
            int n = bonificaciones.GetLength(1); // Número de ayudantes (siempre 3)
            
            // Lista de pares de ayudantes seleccionados para cada misión
            List<Tuple<int, int>> seleccion = new List<Tuple<int, int>>();
            
            // Generar todas las combinaciones posibles de dos ayudantes
            List<Tuple<int, int>> combinaciones = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(0, 2),
                new Tuple<int, int>(1, 2)
            };

            // Guardar la mejor solución (por ahora vacía)
            List<Tuple<int, int>> mejorSeleccion = new List<Tuple<int, int>>();
            int mejorAcumulado = int.MinValue;

            // Probar todas las combinaciones de ayudantes para cada misión
            ResuelveRecursivo(bonificaciones, combinaciones, new int[n], 0, seleccion, ref mejorSeleccion, ref mejorAcumulado);
            
            // Si encontramos una selección válida, la devolvemos
            return mejorSeleccion.Any() ? mejorSeleccion : new List<Tuple<int, int>>();
        }

        static void ResuelveRecursivo(int[,] bonificaciones, List<Tuple<int, int>> combinaciones, int[] acumulado, int misionActual,List<Tuple<int, int>> seleccionActual, ref List<Tuple<int, int>> mejorSeleccion, ref int mejorAcumulado)
        {
            // Si hemos procesado todas las misiones
            if (misionActual == bonificaciones.GetLength(0))
            {
                // Verificar si todos los ayudantes tienen el mismo acumulado
                if (acumulado.All(x => x == acumulado[0]))
                {
                    int acumuladoTotal = acumulado.Sum();

                    // Si esta solución es mejor que la anterior, la guardamos
                    if (acumuladoTotal > mejorAcumulado)
                    {
                        mejorAcumulado = acumuladoTotal;
                        mejorSeleccion = new List<Tuple<int, int>>(seleccionActual);
                    }
                }
                return;
            }

            // Probar todas las combinaciones de dos ayudantes para la misión actual
            foreach (var comb in combinaciones)
            {
                int a1 = comb.Item1;
                int a2 = comb.Item2;

                // Crear un acumulado temporal para esta misión
                int[] acumuladoTemp = (int[])acumulado.Clone();
                acumuladoTemp[a1] += bonificaciones[misionActual, a1];
                acumuladoTemp[a2] += bonificaciones[misionActual, a2];

                // Guardar la selección actual y avanzar a la siguiente misión
                seleccionActual.Add(new Tuple<int, int>(a1, a2));
                ResuelveRecursivo(bonificaciones, combinaciones, acumuladoTemp, misionActual + 1, seleccionActual, ref mejorSeleccion, ref mejorAcumulado);
                seleccionActual.RemoveAt(seleccionActual.Count - 1); // Backtrack
            }
        }
    }
}



