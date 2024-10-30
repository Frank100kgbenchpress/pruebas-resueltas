using Recorrido;

public class Tester
{
    public static void Main()
    {
        int[,] area1 =
        {
            {0,2,0},
            {0,1,2},
            {2,0,1}
        };
        Console.WriteLine(Solution.CantidadMinimaDeMedicos(area1, 1) +"=> Resultado Esperado: 1");
        int[,] area2 =
        {
            {1,2,0,0,2,0,0},
            {0,0,0,1,0,0,0},
            {0,0,2,0,2,0,0},
            {0,0,0,0,0,1,0}
        };
        Console.WriteLine(Solution.CantidadMinimaDeMedicos(area2, 1) +"=> Resultado Esperado: 2");
        int[,] area3 =
        {
            {0,2,0},
            {0,2,2},
            {2,0,1}
        };
        Console.WriteLine(Solution.CantidadMinimaDeMedicos(area3, 1) +"=> Resultado Esperado: -1");
        
        Console.WriteLine(Solution.CantidadMinimaDeMedicos(area3, 2) +"=> Resultado Esperado: 1");
    }
}

