using Ranas;
class Program
{
    public static void Main(string[] args)
    {
        int resultado1 = Charco.ComiendoChocolates(new bool[,] 
        { 
            { false, false, false, false, false, false, false, false }, 
            { false, false, true,  false, false, true,  false, false }, 
            { false, true,  false, false, true,  false, true,  false }, 
            { false, false, true,  false, false, false, false, true  } 
        }, new int[] { 1, 3, 6 }); 
        // Máxima cantidad de chocolates que pueden comer: 7
        int resultado2 = Charco.ComiendoChocolates(new bool[,] 
        { 
            { false, false, false, false, false, false, false, false }, 
            { false, false, true,  false, false, true,  false, false }, 
            { false, true,  false, false, true,  false, true,  false }, 
            { true,  false, true,  false, false, false, false, true  } 
        }, new int[] { 1, 3, 6 });  // Máxima cantidad de chocolates que pueden comer: 7
       int resultado3 = Charco.ComiendoChocolates(new bool[,] 
       {
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, false, true, false, true },
            { false, false, false, false, false, false, true, false },
            { false, false, false, false, false, false, false, true }
        }, new int[] { 1, 3 });     // Máxima cantidad de chocolates que pueden comer: 0

    
        Console.WriteLine(" El glorioso y correcto resultado es : " + resultado3);
    }
}
