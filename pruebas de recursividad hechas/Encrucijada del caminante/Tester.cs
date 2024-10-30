
namespace Weboo.Examen.Final.Probador
{
    using Caminante;
    class Program
    {
        private static int caso = 1;
        static void Main()
        {
            Probar(new[] {1, 3, 2}, 2, 4);
            Probar(new[] { 5, 7, 3, 5 }, 2, 7);
            Probar(new[] { 1, 3, 5 }, 2, 3);
            Probar(new[] { 1, 3, 5 }, 1, 0);

            Console.ReadLine();
        }

        private static void Probar(int[] cajas, int alturaMax, int correcto)
        {
            int resultado = Caminante.CantidadCombinacionesCajas(cajas, alturaMax);

            Console.Write("Caso {0} => ", caso++);

            if (resultado == correcto)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Correcto");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrecto: Se esperaba {0} pero se obtuvo {1}.", correcto, resultado);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
