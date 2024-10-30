using Weboo.Examen.Extra;

namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] viaje1;
            int[] viaje2;

            int[,] ciudades = new int[,] {
                { 0, 1, 4, 4 },
                { 3, 0, 2, 3 },
                { 4, 1, 0, 6 },
                { 2, 1, 5, 0 }
            };

            Padre.ResuelveVacaciones(ciudades, out viaje1, out viaje2);

            Console.WriteLine("Itinerario hijo1");
            foreach (var ciudad in viaje1)
                Console.Write(ciudad + " ");
            Console.WriteLine();
            Console.WriteLine("Itinerario hijo2");
            foreach (var ciudad in viaje2)
                Console.Write(ciudad + " ");
        }
    }
}
