using System.Data;
using System.IO.Compression;

namespace Weboo.Examen;

public static class Solution
{
    public static int Solve(int[,] map, int capacity, int origin)
    {
        if(map.GetLength(0) == 1) return 0;                     // si es 1x1 no se gasta
        bool[]flag = new bool[map.GetLength(0)];                // bandera para hacer los recorridos recursivos
        int best = int.MaxValue;                                //variable para almacenar casos
        int cantidad = 0;                                       //variable para guardar la gasolina gastada
        Backtrack(origin,capacity);                             //metodo recursivo estilo Traveling sales man
        return best == int.MaxValue? -1 : best;                 // si best no se actualizo no hay caminos validos y si no devuelve el mejor
        void Backtrack(int index,int gasolina)
        {
            if(index == origin)                                 // si estamos en la ciudad de origen
            {
                if(flag.All(x=>x ))                             // y pasamos todas las ciudades
                {
                    best = Math.Min(best, cantidad);            // es camino valido y actualizamos best 
                    return;                                     // salimos
                }
                gasolina = capacity;                            // si no llenamos tanque
                flag[index] = false;                            // y volvemos falso la casilla de nuevo para que se pueda volver a pasar por alli
            }
            for(int i = 0; i < map.GetLength(0); i++)           // for para recorrer las ciudades
            {
                if(index == i) continue;                        //si estamos en la misma se la salta
                if(gasolina >= map[index,i] && !flag[i])        // si alcanza la gasolina y no hemos pasado
                {                       
                    flag[i] = true;                             // marcamos visitada
                    cantidad += map[index,i];                   //aumentamos gasto de gasolina
                    Backtrack(i,gasolina-map[index,i]);         //llamamos recursivo con el gasto de gasolina
                    cantidad -= map[index,i];                   //deshacemos cambios de gasolina para proximas opciones
                    flag[i] = false;                            // desmarcamos visitada para proximas opciones
                }
            }
        }        
    }
    //segunda via llevando una lista con los caminos y quedarse con el menor (consume mas memoria pero funciona igual)
//     public static int Solve(int[,] map, int capacity, int origin)
// {
//     if (map.GetLength(0) == 1) return 0;                     // si es 1x1 no se gasta
//     bool[] flag = new bool[map.GetLength(0)];                 // bandera para hacer los recorridos recursivos
//     List<Tuple<List<int>, int>> caminos = new List<Tuple<List<int>, int>>(); // Lista de caminos y sus costos
//     int cantidad = 0;                                         // variable para guardar la gasolina gastada
//     Backtrack(origin, capacity, new List<int> { origin });    // método recursivo estilo TSP
//     return caminos.Count == 0 ? -1 : caminos.Min(c => c.Item2);  // devolver el menor costo

//     void Backtrack(int index, int gasolina, List<int> camino)
//     {
//         if (index == origin && flag.All(x => x))              // si estamos en la ciudad de origen y pasamos todas
//         {
//             caminos.Add(new Tuple<List<int>, int>(new List<int>(camino), cantidad)); // Guardar el camino y su costo
//             return;
//         }

//         if (index == origin)
//         {
//             gasolina = capacity;                              // rellenar tanque al regresar al origen
//             flag[index] = false;                              // desmarcar origen para futuros caminos
//         }

//         for (int i = 0; i < map.GetLength(0); i++)
//         {
//             if (index == i) continue;                         // si estamos en la misma ciudad, continuar
//             if (gasolina >= map[index, i] && !flag[i])        // si alcanza la gasolina y no hemos pasado por la ciudad
//             {
//                 flag[i] = true;                               // marcar como visitada
//                 cantidad += map[index, i];                    // aumentar el consumo de gasolina
//                 camino.Add(i);                                // añadir ciudad al camino
//                 Backtrack(i, gasolina - map[index, i], camino); // llamada recursiva
//                 camino.RemoveAt(camino.Count - 1);            // eliminar la ciudad del camino al retroceder
//                 cantidad -= map[index, i];                    // deshacer el cambio de gasolina
//                 flag[i] = false;                              // desmarcar ciudad para otros caminos
//             }
//         }
//     }
// }

}
