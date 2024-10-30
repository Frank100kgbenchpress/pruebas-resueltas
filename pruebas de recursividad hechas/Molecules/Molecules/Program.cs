namespace Weboo.Examen;

public static class Program
{
    public static void Main(string[] args)
    {
        //                         0    1    2    3    4    5    6    7    8    9   10   11   12   13   14   15   16   17
        string[] muestraAtomos = ["S", "T", "P", "I", "D", "S", "S", "P", "T", "I", "P", "D", "S", "T", "S", "D", "I", "P"];
        bool[,] muestraEnlances = new bool[18, 18];
        muestraEnlances[8,9] = muestraEnlances[9,8] =
        muestraEnlances[0,1] = muestraEnlances[1,0] = muestraEnlances[9,10] = muestraEnlances[10,9] =
        muestraEnlances[0,2] = muestraEnlances[2,0] = muestraEnlances[9,11] = muestraEnlances[11,9] =
        muestraEnlances[2,3] = muestraEnlances[3,2] = muestraEnlances[10,12] = muestraEnlances[12,10] =
        muestraEnlances[1,3] = muestraEnlances[3,1] = muestraEnlances[11,12] = muestraEnlances[12,11] =
        muestraEnlances[3,4] = muestraEnlances[4,3] = muestraEnlances[12,13] = muestraEnlances[13,12] =
        muestraEnlances[5,6] = muestraEnlances[6,5] = muestraEnlances[13,14] = muestraEnlances[14,13] =
        muestraEnlances[5,9] = muestraEnlances[9,5] = muestraEnlances[13,15] = muestraEnlances[15,13] =
        muestraEnlances[6,7] = muestraEnlances[7,6] = muestraEnlances[15,16] = muestraEnlances[16,15] =
        muestraEnlances[6,8] = muestraEnlances[8,6] = muestraEnlances[16,17] = muestraEnlances[17,16] =
        muestraEnlances[7,9] = muestraEnlances[9,7] = muestraEnlances[14,17] = muestraEnlances[17,14] = true;
        
        string[] sentinelaAtomos = ["S", "T", "P", "I", "D"];
        bool[,] sentinelaEnlaces = {
            // "S"   "T"    "P"    "I"    "D" 
    /*S*/   {false, true , true , false, false},
    /*T*/   {true , false, false, true , false},
    /*P*/   {true , false, false, true , false},
    /*I*/   {false, true , true , false, true },
    /*D*/   {false, false, false, true , false}
        };

        Assert(Solution.CantidadMoleculas(muestraAtomos, muestraEnlances, sentinelaAtomos, sentinelaEnlaces), 2);
        
        //                0    1    2    3    4    
        muestraAtomos = ["S", "T", "U", "T", "S"];
        muestraEnlances = new bool[5, 5];
        muestraEnlances[0,1] = muestraEnlances[0,2] = muestraEnlances[0,3] = 
        muestraEnlances[2,0] = muestraEnlances[2,1] = muestraEnlances[2,3] = muestraEnlances[2,3] =
        muestraEnlances[1,0] = muestraEnlances[1,2] = 
        muestraEnlances[3,0] = muestraEnlances[3,2] = 
        muestraEnlances[4,2] = true;
        
        sentinelaAtomos = ["S", "T", "U"];
        sentinelaEnlaces = new bool[,] {
            // "S"   "T"    "U"   
    /*S*/   {false, true , true },
    /*T*/   {true , false, true },
    /*U*/   {true , true , false}
        };

        Assert(Solution.CantidadMoleculas(muestraAtomos, muestraEnlances, sentinelaAtomos, sentinelaEnlaces), 2);

        //                0    1    2    3    
        muestraAtomos = ["S", "S", "S", "T"];
        muestraEnlances = new bool[4, 4];
        muestraEnlances[0,1] = muestraEnlances[0,2] = muestraEnlances[0,3] = 
        muestraEnlances[2,0] = 
        muestraEnlances[1,0] = 
        muestraEnlances[3,0] = true;
        
        sentinelaAtomos = ["S", "S", "T"];
        sentinelaEnlaces = new bool[,] {
            // "S"   "S"    "T"   
    /*S*/   {false, false , false },
    /*S*/   {false , false, false},
    /*T*/   {false , false, false}
        };
        Assert(Solution.CantidadMoleculas(muestraAtomos, muestraEnlances, sentinelaAtomos, sentinelaEnlaces), 1);

        //                0    1    2    3    
        muestraAtomos = ["S", "S", "S", "T"];
        muestraEnlances = new bool[4, 4];
        muestraEnlances[0,1] = muestraEnlances[0,2] = muestraEnlances[0,3] = 
        muestraEnlances[2,0] = 
        muestraEnlances[1,0] = 
        muestraEnlances[3,0] = true;
        
        sentinelaAtomos = ["S", "S", "R"];
        sentinelaEnlaces = new bool[,] {
            // "S"   "S"    "R"   
    /*S*/   {false, true , true },
    /*S*/   {true , false, false},
    /*R*/   {true , false, false}
        };

        Assert(Solution.CantidadMoleculas(muestraAtomos, muestraEnlances, sentinelaAtomos, sentinelaEnlaces), 0);
    }

    private static void Assert(int answer, int solution)
    {
        if (answer == solution)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correcto!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        else 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrecto!!!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}