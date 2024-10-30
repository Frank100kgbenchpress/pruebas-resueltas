using System.Collections.Generic;  

namespace Weboo.Examen
{  
    public class Manager 
    {  
        public static double DuracionProyecto(int[] tareas, double[,] desarrolladores)  
        {  
            int n = tareas.Length; // Número de tareas 
            int m = desarrolladores.GetLength(0); // Número de desarrolladores 
            double minTime = double.MaxValue;     
            double[] tiempos = new double[m];   // Array para almacenar el tiempo que cada desarrollador toma  
            AsignarTareas(0);                   // Iniciar la asignación de tareas desde la primera tarea  
            return minTime;
             
            void AsignarTareas(int tareaIndex)  // Función recursiva para asignar tareas  
            {  
                if (tareaIndex == n) // Si se han asignado todas las tareas 
                {  
                    double maxTime = 0;  
                    foreach (var tiempo in tiempos)  // toma el tiempo maximo de cada desarrollador
                    {  
                        maxTime = Math.Max(maxTime, tiempo);  
                    }  
                    minTime = Math.Min(minTime, maxTime);  //actualizamos minimo
                    return;                             //salimos
                }  

                for (int i = 0; i < m; i++)          // Asignar la tarea tareaIndex a cada desarrollador  
                {  
                    double tiempoAnterior = tiempos[i]; // Guardar el tiempo actual del desarrollador  
                    tiempos[i] += tareas[tareaIndex] * desarrolladores[i, tareaIndex];  // Asignar la tarea  
                    AsignarTareas(tareaIndex +1);       // Llamar recursivamente para la siguiente tarea  
                    tiempos[i] = tiempoAnterior;    // Deshacer la asignación  
                }  
            }      
        }  
    }  
}