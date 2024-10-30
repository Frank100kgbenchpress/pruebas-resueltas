using Torres;
namespace Probador.PruebaFinal.Torres
{
    
    class Program
    {
        static void Main(string[] args)
        {
             bool[,] tablero1 = {
                { false, false, false, false, false, false, false},
                { false, true, true, false, false, true, false}, 
                { false, false, false, false, false, false, true}, 
                { true, false, false, true, false, false, false}, 
                { false, false, false, false, false, false, false}
            };

            Console.WriteLine(Juego.MayorEliminacion(tablero1));

            bool[,] tablero2 = {
                { false, false, false, false, false, false, false},
                { false, false, true, false, true, true, false},
                { false, false, true, false, false, false, false},
                { false, false, false, false, false, false, false},
                { false, false, false, false, true, false, false}
            };

            Console.WriteLine(Juego.MayorEliminacion(tablero2));

            bool[,] tablero3 = {
                { false, false, false, false, false, false, false},
                { true, true, true, true, true, true, true},
                { false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false}
            };

            Console.WriteLine(Juego.MayorEliminacion(tablero3));
        }
    }
}
