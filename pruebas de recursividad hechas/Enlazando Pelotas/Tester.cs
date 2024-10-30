using Weboo.Examen;
namespace Probador
{
    class Program
    {
        static void Main(string[] args)
        {
            int costo = Pelotas.EnlazaOptimo(new int[] { 1, 4, 4, 2, 2, 2, 4, 1, 1, 2 });
            Console.WriteLine("Costo: " + costo);
        }
    }
}